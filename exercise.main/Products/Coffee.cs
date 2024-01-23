using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Products
{
    public class Coffee : IProduct
    {
        string _SKUName;
        float _price;

        public Coffee(string SKU, float price)
        {
            _SKUName = SKU;
            _price = price;
        }

        /// <summary>
        /// Return the total price of the Coffee object
        /// </summary>
        /// <returns> <float> The total object price as a float </float></returns>

        public float GetPrice()
        {
            return _price;
        }

        /// <summary>
        /// Return the total price of the Coffee object
        /// </summary>
        /// <returns> <float> The total object price as a float </float></returns>

        public float GetBasePrice() 
        {
            return GetPrice();
        }

        /// <summary>
        /// Return the SKU tag for the IProduct object
        /// </summary>
        /// <returns><string>A string of a 4-character item identifier</string></returns>
        public string GetSKUName()
        {
            return _SKUName;
        }
    }
}
