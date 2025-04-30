using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_Management;
using Inventory_Management.DTOs;
using Inventory_Management.Models;
using Inventory_Management.Services;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Tests
{
    public class InventoryMasterServiceTests
    {
        private InventoryDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<InventoryDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb_" + System.Guid.NewGuid().ToString())
                .Options;
            return new InventoryDbContext(options);
        }

        [Fact]
        public async Task Create_AddNewMaster()
        {
            using var context = GetDbContext();
            var service = new MasterService(context);

            var master = new InventoryMaster {Name = "TEst Master", Description = "Test Description"};
            await service.CreateMaster(master);

            Assert.Equal(1, context.InventoryMasters.Count());
            Assert.Equal("TEst Master", context.InventoryMasters.First().Name);
        }

        [Fact]
        public async Task GetById_CorrectMaster()
        {
            using var context = GetDbContext();
            var service = new MasterService(context);

            var master = new InventoryMaster { Name = "Test GetId Master", Description = "Test Description" };
            await service.CreateMaster(master);

            var result = service.GetMasterById(master.Id);

            Assert.NotNull(result);
            Assert.Equal("Test GetId Master", context.InventoryMasters.First().Name);
        }

        [Fact]
        public async Task GetAllMaster()
        {
            using var context = GetDbContext();
            var service = new MasterService(context);

            var master = new InventoryMaster { Name = "GetAllMaster Test", Description = "testing" };
            await service.CreateMaster(master);

            var results = service.GetAllMasters();

            Assert.NotNull(results);
            Assert.Equal("GetAllMaster Test", context.InventoryMasters.Last().Name);
            Assert.Equal(1,context.InventoryMasters.Count());
        }

        [Fact]
        public async Task UpdateMaster()
        {
            using var context = GetDbContext();
            var service = new MasterService(context);

            var master = new InventoryMaster { Name = "GetAllMaster Test", Description = "testing" };
            await service.CreateMaster(master);

            master.Name = "Test Update";
            master.Description = "testing Des";
            var updatedResutls = service.UpdateMaster(master);

            var updatedMasterResult = await service.GetMasterById(master.Id);

            Assert.NotNull(updatedMasterResult);
            Assert.Equal(1, context.InventoryMasters.First().Id);
            Assert.Equal("Test Update", updatedMasterResult.Name);
            Assert.Equal("testing Des", updatedMasterResult.Description);
        }

        [Fact]
        public async Task DeleteMaster()
        {
            using var context = GetDbContext();
            var service = new MasterService(context);

            var master = new InventoryMaster { Name = "DeleteMaster Test", Description = "testing" };
            await service.CreateMaster(master);

            await service.DeleteMaster(master.Id);

            var deletedMaster = await service.GetMasterById(master.Id);

            Assert.Null(deletedMaster);
            
        }
    }
}
