using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace csharp_tdd_oop_bobs_bagels_Csharp_Classes
{
    public class ShopItem
    {
        private string _name;
        private decimal _price;
        private string _variant;
        private string _SKU;

        public string Name { get =>  _name; set { _name = value;} }
        public decimal Price { get => _price; set { _price = value;} }
        public string Variant { get => _variant; set { _variant = value;} }
        public string SKU { get => _SKU; set { _SKU = value; } }

        public ShopItem(string SKU, string Variant, decimal Price, string Name)
        {
            this.SKU = SKU;
            this.Price = Price;
            this.Name = Name;
            this.Variant = Variant;
        }

    }
}