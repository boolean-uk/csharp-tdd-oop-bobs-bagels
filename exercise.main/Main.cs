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

        public bool AddFilling(string sku)
        {
            throw new NotImplementedException();
        }
        public float TotalPrice() 
        { 
            throw new NotImplementedException(); 
        }
    }

    public class Inventory
    {
        private Dictionary<string, Item> _items = new Dictionary<string, Item>();

        public bool AddItem(string sku, float price, string itemName, string variant)
        {
            throw new NotImplementedException();
        }
        public bool ItemExists(string sku)
        {
            throw new NotImplementedException();
        }
        public float GetPrice(string sku) 
        {
            throw new NotImplementedException(); 
        }
        public Item getItem(string sku)
        {
            throw new NotImplementedException();
        }

    }

    public class Basket
    {
        private int _maxCapacity = 4;
        public readonly List<string> _basketList = new List<string>();

        public bool AddBagel(string sku)
        {
            throw new NotImplementedException();
            
        }

        public bool AddFilling(int index, string fillingSku)
        {
            throw new NotImplementedException();
        }

        public bool RemoveBagle(int index)
        {
            throw new NotImplementedException();

        }

        public float TotalCost()
        {
            throw new NotImplementedException();
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
