namespace Inventory_Management.Filters
{
    public class ItemsFilter
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal MinQty { get; set; }
        public decimal MaxQty { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
    }
}
