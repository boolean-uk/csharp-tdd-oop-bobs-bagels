using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Products
{
    public class Filling
    {
        public string SKUName { get; }
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

        public bool IsValid(string SKU) 
        {
            return Inventory.GetFillingPrice(SKU) > 0f;
        }

        public float GetPrice() 
        {
            return _price;
        }
    }
}
