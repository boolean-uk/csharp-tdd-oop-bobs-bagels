using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Products
{
    public class Bagel : Product
    {
        List<Filling> filling = new List<Filling>();
        string _SKUName;
        float _basePrice;
        public Bagel(string SKU, string price)
        {
            throw new NotImplementedException(); 
        }

        public bool AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public float GetPrice()
        {
            throw new NotImplementedException();
        }

        public string GetSKUName()
        {
            throw new NotImplementedException();
        }

        public bool AddFilling(Filling fill) 
        {
            throw new NotImplementedException();
        }
    }
}
