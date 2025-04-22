using Inventory_Management.Filters;
using Inventory_Management.IServices;
using Inventory_Management.Models;
using Inventory_Management.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MasterController : ControllerBase
    {
        private readonly IMasterServices _masterServices;
        public MasterController(IMasterServices masterServices)
        {
            _masterServices = masterServices;
        }
        //[Authorize(Roles ="Admin")]
        [Authorize(Policy = "AdminOnly")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryMaster>>> GetAllMasters()
        {
            var masters = await _masterServices.GetAllMasters();
            return Ok(masters);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] InventoryMaster master)
        {
            if (master == null)
            {
                return BadRequest();
            }
            await _masterServices.CreateMaster(master);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody]InventoryMaster master)
        {
            if(id != master.Id)
            {
                return BadRequest();
            }
            await _masterServices.UpdateMaster(master);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var master = await _masterServices.GetMasterById(id);
            if (master == null)
            {
                return NotFound();
            }
            await _masterServices.DeleteMaster(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryMaster>> GetMasterById(int id)
        {
            var master = await _masterServices.GetMasterById(id);
            if (master == null)
            {
                return NotFound();
            }
            return Ok(master);
        }

        [HttpGet("filter")]
        public async Task<ActionResult<InventoryMaster>> GetFilteredData([FromQuery] string name)
        {
            MastersFilter filter = new MastersFilter
            {
                Name = name
            };
            var masters = await _masterServices.GetFilteredMaster(filter);
            if(masters == null || !masters.Any())
            {
                return NotFound();
            }
            return Ok(masters);
        }
    }
}
