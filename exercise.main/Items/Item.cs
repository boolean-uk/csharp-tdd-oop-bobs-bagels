using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Items
{
    public abstract class Item
    {
        #region Properties
        private string _sku;
        private double _price;
        private string _variant;

        public string Sku { get => _sku; set => _sku = value; }
        public double Price { get => _price; set => _price = value; }
        public string Variant { get => _variant; set => _variant = value; }

        private List<Item> _inventory = new List<Item>()
        {
            new Bagel {Sku = "BGLO", Price = 0.49d, Variant = "Onion"},
            new Bagel {Sku = "BGLP", Price = 0.39d, Variant = "Plain"},
            new Bagel {Sku = "BGLE", Price = 0.49d, Variant = "Everything"},
            new Bagel {Sku = "BGLS", Price = 0.49d, Variant = "Sesame"},
            new Coffee {Sku = "COFB", Price = 0.99d, Variant = "Black"},
            new Coffee {Sku = "COFW", Price = 1.19d, Variant = "White"},
            new Coffee {Sku = "COFC", Price = 1.29d, Variant = "Cappucino"},
            new Coffee {Sku = "COFL", Price = 1.29d, Variant = "Latte"},
            new Filling {Sku = "FILB", Price = 0.12d, Variant = "Bacon"},
            new Filling {Sku = "FILE", Price = 0.12d, Variant = "Egg"},
            new Filling {Sku = "FILC", Price = 0.12d, Variant = "Cheese"},
            new Filling {Sku = "FILX", Price = 0.12d, Variant = "Cream Cheese"},
            new Filling {Sku = "FILS", Price = 0.12d, Variant = "Smoked Salmon"},
            new Filling {Sku = "FILH", Price = 0.12d, Variant = "Ham"}
        };

        public List<Item> Inventory { get => _inventory; }
        #endregion

        protected Item()
        {
        }
        
        protected Item(string skuID, double price, string variant)
        {
            _sku = skuID;
            _price = price;
            _variant = variant;
        }

        protected Item(string skuID) 
        {
            foreach (var item in _inventory)
            {
                if (skuID == item.Sku)
                {
                    _sku = item.Sku;
                    _price = item.Price;
                    _variant = item.Variant;
                }
            }
        }
    }
}
