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
        public List<Type> ProductSequence = new List<Type>();

        public string Name { get { return name; } }

        public float DiscountPrice { get { return price; } set { } }

        /// <summary>
        /// New list (shallow copy) return list
        /// </summary>
        /// <returns></returns>
        public List<Type> GetSequence() 
        {
            return new List<Type>(ProductSequence);
        }
    }
}
