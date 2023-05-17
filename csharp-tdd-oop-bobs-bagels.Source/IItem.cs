namespace csharp_tdd_oop_bobs_bagels.Source
{
    public interface IItem
    {
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Variant { get; set; }
        public int Stock { get; set; }
        public int Amount { get; set; }
        public decimal Cost { get; set; }
    }
}