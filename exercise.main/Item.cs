using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Item
    {
        private string _sku;
        private double _price;
        private string _type;
        private string _variant;
        private Item _filling;

        public string Sku { get { return _sku; } set { _sku = value; } }
        public double Price 
        { 
            get { return _price; }
            set { _price = value; } 
        }

        public string Type { get { return _type; } set { _type = value; } }
        public string Variant { get { return _variant; } set { _variant = value; } }
        public Item Filling { get; set; }

        public Item(string sku, double price, string name, string variant) 
        {
            _sku = sku;
            _price = price;
            _type = name;
            _variant = variant;
        }

        public override string ToString()
        {
            if(Filling != null)
            {
                return $"{this.Sku} - {this.Type} ({this.Variant}) with {this.Filling._variant}: ${this.Price:F2}";
            }
            return $"{this.Sku} - {this.Type} ({this.Variant}): ${this.Price:F2}";
        }

        public Item? AddFilling(Item item)
        {
            if(this.Type != "Bagel" && item.Type != "Filling")
            {
                throw new Exception("Error");
            }
           
            return this.Filling = item;
        }

        public double Total()
        {
            return _price + (Filling?.Price ?? 0);
        }
    }
}
