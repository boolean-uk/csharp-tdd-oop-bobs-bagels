using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class BobsBagelsApp
    {
        private static BobsInventory _inventory = new BobsInventory();

        private static Dictionary<string, double> _bagelsInventory = new Dictionary<string, double>
        {   // TODO: delete this property
            {"onion", 0.49},
            {"plain", 0.39},
            {"everything", 0.49},
            {"sesame", 0.49}
        };

        private static Dictionary<string, double> _coffeeInventory = new Dictionary<string, double>
        {   // TODO: delete this property
            {"black", 0.99},
            {"white", 1.19},
            {"capuccino", 1.29},
            {"latte", 1.29}
        };

        private static Dictionary<string, double> _fillingsInventory = new Dictionary<string, double>
        {   // TODO: delete this property
            {"bacon", 0.12},
            {"egg", 0.12},
            {"cheese", 0.12},
            {"cream cheese", 0.12},
            {"smoked salmon", 0.12},
            {"ham", 0.12}
        };

        private static int _basketCapacity = 6;

        private List<Bagel> _bagelsBasket = new List<Bagel>();   // TODO: delete this property

        private Dictionary<SKUEnum, int> _basket = new Dictionary<SKUEnum, int>();
        private int _itemsInBasket = 0;

        public bool IsFull { get => _itemsInBasket == _basketCapacity; }

        private bool AddBagel(Bagel bagel)
        {   // TODO: delete this method
            if (_bagelsBasket.Count == _basketCapacity)
                return false;
            if (!_bagelsInventory.ContainsKey(bagel.Type))
                return false;
            _bagelsBasket.Add(bagel);
            return true;
        }

        private bool AddItem(string variant, string name)
        {
            if (IsFull)
                return false;
            
            // retrieve stock item with this variant property
            StockItem item = _inventory.GetStockItem(variant);
            // variant must exist in inventory
            if ((item == null) || (item.Name != name))
                return false;

            // add or update this item in basket
            _basket[item.SKU] = _basket.ContainsKey(item.SKU) ? _basket[item.SKU] + 1 : 1;

            // update items in bakset, if item is not a filling
            if (item.Name != "Filling")
                ++_itemsInBasket;
            return true;
        }

        private bool RemoveItem(string variant, string name)
        {
            // retrieve stock item with this variant property
            StockItem item = _inventory.GetStockItem(variant);
            // variant must exist in inventory
            if ((item == null) || (item.Name != name))
                return false;
            
            if (!_basket.ContainsKey(item.SKU))
                return false;
            // update items in bakset
            --_itemsInBasket;
            if (_basket[item.SKU] == 1)
            {
                return _basket.Remove(item.SKU);
            }
            else
            {
                _basket[item.SKU]--;
                return true;
            }
        }

        public bool AddBagel(string bagelType)
        {
            return AddItem(bagelType, "Bagel");
        }

        public bool AddCoffee(string coffeeType)
        {
            return AddItem(coffeeType, "Coffee");
        }

        public bool AddFilling(string fillingType)
        {
            return AddItem(fillingType, "Filling");
        }

        public bool RemoveBagel(string bagelType)
        {
            return RemoveItem(bagelType, "Bagel");
        }

        public bool RemoveCoffee(string coffeeType)
        {
            return RemoveItem(coffeeType, "Coffee");
        }

        // public bool RemoveFilling(string fillingType)
        // {
        //     return RemoveItem(fillingType, "Filling");
        // }

        public bool ChangeCapacity(int capacity, bool isManager)
        {
            if (!isManager)
                return false;
            _basketCapacity = capacity;
            return true;
        }

        public double GetTotalCost()
        {
            double total = 0.0;
            foreach (Bagel bagel in _bagelsBasket)
            {
                total += _bagelsInventory[bagel.Type];
                bagel.Fillings.ForEach(f => total += _fillingsInventory[f.Type]);
            }

            return total;
        }

        public double GetBagelCost(string bagelType)
        {
            if (!_bagelsInventory.ContainsKey(bagelType))
                return Double.NaN;
            return _bagelsInventory[bagelType];
        }

        public bool AddBagelWithFillings(string bagelType, List<string> fillingTypes)
        {
            if (fillingTypes.Exists(t => !_fillingsInventory.ContainsKey(t)))
                return false;
            return AddBagel(new Bagel(bagelType, fillingTypes));
        }

        public double GetFillingCost(string fillingType)
        {
            if (!_fillingsInventory.ContainsKey(fillingType))
                return Double.NaN;
            return _fillingsInventory[fillingType];
        }

        public int ItemsInBasket { get => _itemsInBasket; }

        public int BasketCapacity { get => _basketCapacity; }
    }

}
