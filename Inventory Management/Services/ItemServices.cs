using Inventory_Management.DTOs;
using Inventory_Management.Filters;
using Inventory_Management.IServices;
using Inventory_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Management.Services
{
    public class ItemServices:IItemServices
    {
        private readonly InventoryDbContext _inventoryDbContext;

        public ItemServices(InventoryDbContext inventoryDbContext)
        {
            _inventoryDbContext = inventoryDbContext;
        }

        public async Task<IEnumerable<InventoryItem>> GetAllItems()
        {
            return await _inventoryDbContext.InventoryItems.Include(m => m.InventoryMaster).ToListAsync();
        }

        public async Task CreateItem(CreateItemDTO createItem)
        {
            var master = await _inventoryDbContext.InventoryMasters.FindAsync(createItem.MasterId);
            InventoryItem inventoryItem = new InventoryItem
            {
                Name = createItem.Name,
                Description = createItem.Description,
                Unit = createItem.Unit,
                Qty = createItem.Qty,
                Price = createItem.Price,
                MasterId = createItem.MasterId,
                InventoryMaster = master
            };
            _inventoryDbContext.InventoryItems.Add(inventoryItem);
            await _inventoryDbContext.SaveChangesAsync();
        }

        public async Task UpdateItem(int id,UpdateItemDTO updateItem)
        {
            var item = await _inventoryDbContext.InventoryItems.Include(i => i.InventoryMaster).FirstOrDefaultAsync(i => i.Id == id);
            var master = await _inventoryDbContext.InventoryMasters.FindAsync(updateItem.MasterId);

            if (item != null) 
            {
                item.Name = updateItem.Name;
                item.Description = updateItem.Description;
                item.Unit = updateItem.Unit;
                item.Qty = updateItem.Qty;
                item.Price = updateItem.Price;
                item.MasterId = updateItem.MasterId;
                item.InventoryMaster = master;
            }
            
            _inventoryDbContext.InventoryItems.Update(item);
            await _inventoryDbContext.SaveChangesAsync();
        }
        public async Task DeleteItem(int id)
        {
            var Itemr = await _inventoryDbContext.InventoryItems.FindAsync(id);
            if (Itemr == null)
            {
                throw new KeyNotFoundException($"Item with ID {id} not found.");
            }
            _inventoryDbContext.InventoryItems.Remove(Itemr);
            await _inventoryDbContext.SaveChangesAsync();
        }

        public async Task<InventoryItem> GetItemById(int id)
        {
            var Item = await _inventoryDbContext.InventoryItems.FirstOrDefaultAsync(m => m.Id == id);
            return Item;
        }
        public async Task<List<InventoryItem>> GetFilteredItem(ItemsFilter filter)
        {
            var Items = await _inventoryDbContext.InventoryItems.ToListAsync();
            if (!string.IsNullOrEmpty(filter.Name))
            {
                Items = Items.Where(m => m.Name.Contains(filter.Name, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            return Items;
        }
    }
}
