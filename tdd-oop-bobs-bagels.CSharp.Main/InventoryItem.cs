namespace tdd_oop_bobs_bagels.CSharp.Main
{
        public class InventoryItem
        {
            public string SKU { get; set; }
            public float Price { get; set; }
            public string Name { get; set; }
            public string Variant { get; set; }
            public int InStock { get; set; }
            public bool CanOrder  => InStock > 0;


            public InventoryItem(string SKU, float Price, string Name, string Variant, int InStock)
            {
                this.SKU = SKU;
                this.Price = Price;
                this.Name = Name;
                this.Variant = Variant;
                this.InStock = InStock;

            }


        }
}
