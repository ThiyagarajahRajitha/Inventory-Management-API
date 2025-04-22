using System.ComponentModel;
using System.Diagnostics.Metrics;
using Inventory_Management.DTOs;
using Inventory_Management.Filters;
using Inventory_Management.IServices;
using Inventory_Management.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Management.Services
{
    public class MasterService:IMasterServices
    {
        private readonly InventoryDbContext _inventoryDbContext;

        public MasterService(InventoryDbContext inventoryDbContext)
        {
            _inventoryDbContext = inventoryDbContext;
        }

        public async Task<IEnumerable<InventoryMaster>> GetAllMasters()
        {
            return await _inventoryDbContext.InventoryMasters.Include(m => m.Items).ToListAsync();
        }

        public async Task CreateMaster(InventoryMaster createMaster)
        {
            _inventoryDbContext.InventoryMasters.Add(createMaster);
            await _inventoryDbContext.SaveChangesAsync();
        }

        public async Task DeleteMaster(int id)
        {
            var masterr = await _inventoryDbContext.InventoryMasters.FindAsync(id);
            if (masterr == null)
            {
                throw new KeyNotFoundException($"Master with ID {id} not found.");
            }
            _inventoryDbContext.InventoryMasters.Remove(masterr);
            await _inventoryDbContext.SaveChangesAsync();
        }

        public async Task<InventoryMaster> GetMasterById(int id)
        {
            var master = await _inventoryDbContext.InventoryMasters.FirstOrDefaultAsync(m => m.Id == id);
            return master;
        }

        public async Task UpdateMaster(InventoryMaster updateMaster)
        {
            _inventoryDbContext.InventoryMasters.Update(updateMaster);
            await _inventoryDbContext.SaveChangesAsync();
        }

        public async Task<List<InventoryMaster>> GetFilteredMaster(MastersFilter filter)
        {
            var masters = await _inventoryDbContext.InventoryMasters.ToListAsync();
            if (!string.IsNullOrEmpty(filter.Name))
            {
                masters = masters.Where(m => m.Name.Contains(filter.Name, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            return masters;
        }
    }
}
