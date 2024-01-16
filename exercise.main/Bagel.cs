using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Bagel : Product
    {
        public string _sku;
        public double _price;
        public string _name;
        public string _variant;
        public List<Fillings> _fillings;

        public Bagel(string SKU, double Price, string Name, string Variant, List<Fillings> fillings)
        {
            _fillings = new List<Fillings>();
            _sku = SKU;
            _price = Price;
            _name = Name;
            _variant = Variant;
        }

        //public string SKU { get { return _sku; } set { _sku = value; } }
        //public double Price { get { return _price; } set { _price = value; } }
        //public string Name { get { return _name; } set { _name = value; } }
        //public string Variant { get { return _variant; } set { _variant = value; } }
    }
}
