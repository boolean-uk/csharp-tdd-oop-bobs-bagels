using exercise.main.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Discounts
{
    public abstract class Discount(string name, float price)
    {
        public List<Product> ProductSequence = new List<Product>();

        public string Name { get { return name; } }

        public float DiscountPrice { get { return price; } }

        public List<Product> GetSequence() 
        {
            return new List<Product>(ProductSequence);
        }
    }
}
