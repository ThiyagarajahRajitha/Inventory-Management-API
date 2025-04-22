namespace Inventory_Management.DTOs
{
    public class UpdateItemDTO
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string Unit { get; set; }
        public decimal Qty { get; set; }
        public decimal Price { get; set; }
        public int MasterId { get; set; }
    }
}
