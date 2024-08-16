

namespace BobsBagels.main
{
    public class Item(string sku, float price, string name, string variant)
    {
        private string _sku { get; } = sku;
        private float _price { get; } = price;
        private string _name { get; } = name;
        private string _variant { get; } = variant;


        public string SKU { get { return _sku; } }
        public float Price { get { return _price; } }
        public string Name { get { return _name; } }
        public string Variant{ get { return _variant; }
        }
    }
}
