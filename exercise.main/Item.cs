namespace exercise.main
{
    public class Item


    {
        public string sku { get; set; }
        public decimal price { get; set; }

        public string name { get; set; }

        public string variant { get; set; }



        public Item() { }


        public Item(string sku, decimal price, string name, string variant) {
            this.sku = sku;
            this.price = price;
            this.name = name;
            this.variant = variant;
        
        } 

    }
}
