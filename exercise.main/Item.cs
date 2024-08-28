namespace BobsBagels.main
{
    public abstract class Item
    {
        private string _sku;
        private float _price;
        private string _name;
        private string _variant;

        public Item(string sku, float price, string name, string variant)
        {
            _sku = sku;
            _price = price;
            _name = name;
            _variant = variant;
        }

        public string SKU { get { return _sku; } }
        public float Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public string Name { get { return _name; } }
        public string Variant { get { return _variant; } }
    }
}
