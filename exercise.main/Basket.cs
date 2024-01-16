using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket { 

        public List<Product> products { get; } = new List<Product>();
        private int capacity = 3;

        public bool Add(Product product)
        {
            if (products.Count >= capacity) return false;
            products.Add(product); 
            return true;
        }

        public bool Remove(Product product)
        {
            if ( !products.Contains(product) ) return false;
            products.Remove(product);
            return true;
        }

        public void ChangeCapacity(int v)
        {
            capacity = v;
        }

        public double TotalCost()
        {
            return products.Sum(x => x.GetPrice());
        }
    }
}
