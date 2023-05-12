using System.Security.Cryptography.X509Certificates;

namespace csharp_tdd_oop_bobs_bagels.source
{
    public class Product
    {
        private string sku;
        private decimal price;
        private string name;
        private string variant;

        public Product()
        {

        }

        public Product(string sku, decimal price, string name, string variant)
        {
            this.sku = sku;
            this.price = price;
            this.name = name;
            this.variant = variant;
        }

        public string Sku { get => sku; set => sku = value; }
        public decimal Price { get => price; set => price = value; }
        public string Name { get => name; set => name = value; }
        public string Variant { get => variant; set => variant = value; }
    }
}