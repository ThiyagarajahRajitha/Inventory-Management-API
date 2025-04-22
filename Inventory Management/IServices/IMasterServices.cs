using System.Runtime.InteropServices;
using Inventory_Management.DTOs;
using Inventory_Management.Filters;
using Inventory_Management.Models;

namespace Inventory_Management.IServices
{
    public interface IMasterServices
    {
        Task<IEnumerable<InventoryMaster>> GetAllMasters();
        Task<InventoryMaster> GetMasterById(int id);
        Task CreateMaster(InventoryMaster createMaster);
        Task UpdateMaster(InventoryMaster createMaster);
        Task DeleteMaster(int id);
        Task<List<InventoryMaster>> GetFilteredMaster(MastersFilter filter);
    }
}
