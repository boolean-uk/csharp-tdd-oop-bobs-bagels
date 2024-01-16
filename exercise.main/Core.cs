using System.Diagnostics;
using System.Runtime.InteropServices;

namespace exercise.main
{
    public class Item
    {
        private string _sku;
        private float _price;
        private string _itemName;
        private string _variant;
        private List<Item> _fillings;

        public Item(string sku, float price, string itemName, string variant) 
        {
            _sku = sku;
            _price = price;
            _itemName = itemName;
            _variant = variant;
            _fillings = new List<Item>();        
        }
        public Item(Item item)
        {

            _sku = item._sku;
            _price = item._price;
            _itemName = item._itemName;
            _variant = item._variant;
            _fillings = item._fillings;

        }

        public void AddFilling(string sku)
        {
            Inventory inventory = new Inventory();
            _fillings.Add(inventory.getItem(sku));
        }
        public float TotalPrice() 
        { 
            float totalPrice = _price;
            foreach (Item item in _fillings)
            {
                totalPrice += item._price;
            }
            return totalPrice;
        }
    }

    public class Inventory
    {
        private Dictionary<string, Item> _items = new Dictionary<string, Item>();

        public Inventory() {
            _items.Add("BGLO", new Item("BGLO", 0.49f, "Bagel", "Onion"));
            _items.Add("BGLP", new Item("BGLP", 0.39f, "Bagel", "Plain"));
            _items.Add("BGLE", new Item("BGLE", 0.49f, "Bagel", "Everything"));
            _items.Add("BGLS", new Item("BGLS", 0.49f, "Bagel", "Sesame"));
            _items.Add("COFB", new Item("COFB", 0.99f, "Coffee", "Black"));
            _items.Add("COFW", new Item("COFW", 1.19f, "Coffee", "White"));
            _items.Add("COFC", new Item("COFC", 1.29f, "Coffee", "Cappuccino"));
            _items.Add("COFL", new Item("COFL", 1.29f, "Coffee", "Latte"));
            _items.Add("FILB", new Item("FILB", 0.12f, "Filling", "Bacon"));
            _items.Add("FILE", new Item("FILE", 0.12f, "Filling", "Egg"));
            _items.Add("FILC", new Item("FILC", 0.12f, "Filling", "Cheese"));
            _items.Add("FILX", new Item("FILX", 0.12f, "Filling", "Cream Cheese"));
            _items.Add("FILS", new Item("FILS", 0.12f, "Filling", "Smoked Salmon"));
            _items.Add("FILH", new Item("FILH", 0.12f, "Filling", "Ham"));

        }

        /*
        public bool AddItem(string sku, float price, string itemName, string variant)
        {
            int inventorySize = _items.Count;
            Item item = new Item(sku, price, itemName, variant);
            _items.Add(sku, item);
            if ((_items.Count -1 ) == inventorySize) return true;
            else return false;
        }
        */
        public bool ItemExists(string sku)
        {
            return _items.ContainsKey(sku);
        }
        public float GetPrice(string sku) 
        {
            if (this.ItemExists(sku))
            {
                return _items[sku].TotalPrice();
            }
            else
            {
                return 0;
            }
            
        }
        public Item? getItem(string sku)
        {
            if (this.ItemExists(sku))
            {
                return new Item(_items[sku]);
            }
            else return null;
        }

    }

    public class Basket
    {
        private int _maxCapacity = 4;
        public readonly List<Item> _basketList = new List<Item>();
        //private Inventory _inventory = new Inventory();

        public bool AddBagel(string sku)
        {
            Inventory _inventory = new Inventory();
            if (sku.Substring(0, 3) == "BGL" && _inventory.ItemExists(sku) && _basketList.Count < _maxCapacity)
            {
                _basketList.Add(_inventory.getItem(sku));
                return true;
            }
            else return false;
            
        }

        public bool AddFilling(int index, string fillingSku)
        {
            Inventory _inventory = new Inventory();
            if (index >= 0  && index < _basketList.Count)
            {
                if (_inventory.ItemExists(fillingSku) && fillingSku.Substring(0, 3) != "BGL")
                {
                    _basketList[index].AddFilling(fillingSku);
                    return true;
                }
            }
            return false;

        }

        public bool RemoveBagle(int index)
        {
            if (_basketList.Count > index && index>= 0)
            {
                _basketList.RemoveAt(index);
                return true;
            }
            else return false;

        }

        public float TotalCost()
        {
            float totalCost = 0;
            foreach (var item in _basketList)
            {
                totalCost += item.TotalPrice();
            }
            return totalCost;
        }

        public bool ChangeCapacity(int newCapacity)
        {
            if(newCapacity < 1 ||  newCapacity < _basketList.Count -1)
            {
                return false;
            }
            else
            {
                _maxCapacity = newCapacity;
                return true;
            }
        }
    }
}
