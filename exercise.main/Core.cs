using System.Diagnostics;
using System.Runtime.InteropServices;

namespace exercise.main
{

    public class Offers
    {       
        private string sku;
        private int quantity;
        private float costReduction;

        
    }

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
            _fillings = new List<Item>(item._fillings.Select(filling => new Item(filling)));
        }

        public Item AddFilling(Item filling)
        {
            Item newBagel = new Item(this);
            newBagel._fillings.Add(filling);
            return newBagel;
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
        private Dictionary<string, Item> _items;

        public Inventory() {
            _items = new Dictionary<string, Item>
            {
                { "BGLO", new Item("BGLO", 0.49f, "Bagel", "Onion") },
                { "BGLP", new Item("BGLP", 0.39f, "Bagel", "Plain") },
                { "BGLE", new Item("BGLE", 0.49f, "Bagel", "Everything") },
                { "BGLS", new Item("BGLS", 0.49f, "Bagel", "Sesame") },
                { "COFB", new Item("COFB", 0.99f, "Coffee", "Black") },
                { "COFW", new Item("COFW", 1.19f, "Coffee", "White") },
                { "COFC", new Item("COFC", 1.29f, "Coffee", "Cappuccino") },
                { "COFL", new Item("COFL", 1.29f, "Coffee", "Latte") },
                { "FILB", new Item("FILB", 0.12f, "Filling", "Bacon") },
                { "FILE", new Item("FILE", 0.12f, "Filling", "Egg") },
                { "FILC", new Item("FILC", 0.12f, "Filling", "Cheese") },
                { "FILX", new Item("FILX", 0.12f, "Filling", "Cream Cheese") },
                { "FILS", new Item("FILS", 0.12f, "Filling", "Smoked Salmon") },
                { "FILH", new Item("FILH", 0.12f, "Filling", "Ham") }
            };

        }

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

        public Item GetItem(string sku)
        {
            if (this.ItemExists(sku))
            {
                return _items[sku];
            }
            else return null;
        }

    }

    public class Basket
    {
        private int _maxCapacity = 4;
        public readonly List<Item> _basketList = new List<Item>();
        private Inventory _inventory;

        public Basket(Inventory inventory)
        {
            _inventory = inventory;
        }

        public bool AddBagel(string sku)
        {
            if (sku.Substring(0, 3) == "BGL" && _inventory.ItemExists(sku) && _basketList.Count < _maxCapacity)
            {
                //Item bagel = new Item(_inventory.GetItem(sku));
                _basketList.Add(_inventory.GetItem(sku));
                return true;
            }
            else return false;
            
        }

        public bool AddFilling(int index, string fillingSku)
        {
            if(index >= 0  && index < _basketList.Count)
            {
                if (_inventory.ItemExists(fillingSku) && fillingSku.Substring(0, 3) != "BGL")
                {
                    //Item fillingToAdd = new Item(_inventory.GetItem(fillingSku));
                    _basketList[index] = _basketList[index].AddFilling(_inventory.GetItem(fillingSku));
                    return true;
                }
            }
            return false;

        }

        public bool RemoveBagel(int index)
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
