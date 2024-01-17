using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Products
{
    public class Bagel : IProduct
    {
        List<Filling> filling = new List<Filling>();
        string _SKUName;
        float _basePrice;
        public Bagel(string SKU, float price)
        {
            _SKUName = SKU;
            _basePrice = price;
        }

        public float GetPrice()
        {
            return _basePrice + filling.Sum(fill => fill.GetPrice());
        }

        public float GetBasePrice()
        { 
            return _basePrice;
        }

        public string GetSKUName()
        {
            return _SKUName;
        }

        public List<Filling> GetFilling() 
        {
            return filling;
        }

        public bool AddFilling(Filling fill)
        {
            if (fill.GetPrice() > 0f)
            {
                int count1 = filling.Count;
                filling.Add(fill);
                int count2 = filling.Count;


                return count2 > count1;
            }
            else 
            {
                return false;
            }
        }
    }
}
