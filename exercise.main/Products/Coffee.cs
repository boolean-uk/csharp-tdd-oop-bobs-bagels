using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Products
{
    public class Coffee : Product
    {
        string _SKUName;
        float _price;

        public Coffee(string SKU, float price)
        {
            _SKUName = SKU;
            _price = price;
        }

        public float GetPrice()
        {
            return _price;
        }

        public string GetSKUName()
        {
            return _SKUName;
        }
    }
}
