using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public abstract class Product
    {
        private BagelShop _shop;
        private string _sku;
        private double _price;
        private string _name;
        private string _variant;
        private int _stock;

        public Product(BagelShop shop,  string sku, double price, string name, string variant)
        {
            _shop = shop;
            _sku = sku;
            _price = price;
            _name = name;
            _variant = variant;
            _stock = 100; // default stock of 100
        }

        public virtual bool DecreaseStock()
        {
            if (_stock > 0)
            {
                _stock--;
                return true;
            }
            return false;
        }

        public virtual bool IncreaseStock()
        {
            _stock++;
            return true;
        }

        public override string ToString()
        {
            return $"{_variant} {_name}";
        }


        public string Sku { get => _sku; set => _sku = value; }
        public double Price { get => _price; set => _price = value; }
        public string Name { get => _name; set => _name = value; }
        public string Variant { get => _variant; set => _variant = value; }
        public int Stock { get => _stock; set => _stock = value; }
        public BagelShop Shop { get => _shop; set => _shop = value; }
    }
}
