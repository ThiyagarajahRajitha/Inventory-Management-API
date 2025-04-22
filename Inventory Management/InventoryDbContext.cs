using Inventory_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Management
{
    public class InventoryDbContext:DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) :base (options){ }

        public DbSet<InventoryMaster> InventoryMasters { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
    }
}
