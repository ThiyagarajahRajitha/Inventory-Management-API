using Inventory_Management.DTOs;
using Inventory_Management.Filters;
using Inventory_Management.Models;

namespace Inventory_Management.IServices
{
    public interface IItemServices
    {
        Task<IEnumerable<InventoryItem>> GetAllItems();
        Task<InventoryItem> GetItemById(int id);
        Task CreateItem(CreateItemDTO createItem);
        Task UpdateItem(int id, UpdateItemDTO updateItem);
        Task DeleteItem(int id);
        Task<List<InventoryItem>> GetFilteredItem(ItemsFilter filter);
    }
}
