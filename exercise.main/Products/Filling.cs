using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Products
{
    public class Filling
    {
        /// <summary>
        /// The SKU of the filling
        /// </summary>
        public string SKUName { get; }

        /// <summary>
        /// The price for the filling
        /// </summary>
        float _price;

        public Filling(string SKU)
        {
            if (IsValid(SKU))
            {
                _price = Inventory.GetFillingPrice(SKU);

            } else 
            {
                _price = Inventory.GetFillingPrice(SKU);
            }
            SKUName = SKU;
        }

        /// <summary>
        /// A method that validates if the provided SKU is a valid filling contained within Bob inventory.
        /// </summary>
        /// <param name="SKU"> The SKU to check validity of</param>
        /// <returns><bool> True if the SKU is valid, false otherwise</bool></returns>
        public bool IsValid(string SKU) 
        {
            return Inventory.GetFillingPrice(SKU) > 0f;
        }

        /// <summary>
        /// Retrieve the price of the filling
        /// </summary>
        /// <returns><float>A float of the price of the object</float></returns>
        public float GetPrice() 
        {
            return _price;
        }
    }
}
