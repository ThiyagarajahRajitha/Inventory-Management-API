using System.Runtime.CompilerServices;
using Inventory_Management;
using Inventory_Management.DTOs;
using Inventory_Management.Models;
using Inventory_Management.Services;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Tests
{
    public class InventoryItemServiceTests
    {
        private InventoryDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<InventoryDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb_" + System.Guid.NewGuid().ToString())
                .Options;
            return new InventoryDbContext(options);
        }

        [Fact]
        public async Task Create_AddNewItem()
        {
            using var context = GetDbContext();
            var service = new ItemServices(context);

            var item = new CreateItemDTO { Name = "Test Item", MasterId = 1, Description = "Testttt", Unit = "Kg", Price = 200, Qty = 10 };
            await service.CreateItem(item);

            Assert.Equal(1, context.InventoryItems.Count());
            Assert.Equal("Test Item", context.InventoryItems.First().Name);
        }
    }
}