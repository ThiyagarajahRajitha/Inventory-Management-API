using System.Text.Json.Serialization;

namespace Inventory_Management.Models
{
    public class InventoryMaster
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }

        [JsonIgnore]
        public ICollection<InventoryItem> Items { get; set; } = new List<InventoryItem> { };
    }
}
