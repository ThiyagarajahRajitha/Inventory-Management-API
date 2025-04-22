using System.Formats.Asn1;

namespace Inventory_Management.Models
{
    public class InventoryItem
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string Unit { get; set; }
        public decimal Qty { get; set; }
        public decimal Price { get; set; }
        public int MasterId { get; set; }
        public InventoryMaster InventoryMaster { get; set; }
    }
}
