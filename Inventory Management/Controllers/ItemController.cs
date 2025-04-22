using Inventory_Management.DTOs;
using Inventory_Management.Filters;
using Inventory_Management.IServices;
using Inventory_Management.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemServices _itemServices;
        public ItemController(IItemServices itemServices)
        {
            _itemServices = itemServices;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryItem>>> GetAllItems()
        {
            var Items = await _itemServices.GetAllItems();
            return Ok(Items);
        }



        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateItemDTO Item)
        {
            if (Item == null)
            {
                return BadRequest();
            }
            await _itemServices.CreateItem(Item);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateItemDTO Item)
        {
            var ItemData = await _itemServices.GetItemById(id);
            if (ItemData == null)
            {
                return NotFound();
            }
            await _itemServices.UpdateItem(id,Item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Item = await _itemServices.GetItemById(id);
            if (Item == null)
            {
                return NotFound();
            }
            await _itemServices.DeleteItem(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryItem>> GetItemById(int id)
        {
            var Item = await _itemServices.GetItemById(id);
            if (Item == null)
            {
                return NotFound();
            }
            return Ok(Item);
        }

        [HttpGet("filter")]
        public async Task<ActionResult<InventoryItem>> GetFilteredData([FromQuery] string name)
        {
            ItemsFilter filter = new ItemsFilter
            {
                Name = name
            };
            var Items = await _itemServices.GetFilteredItem(filter);
            if (Items == null || !Items.Any())
            {
                return NotFound();
            }
            return Ok(Items);
        }
    }
}

