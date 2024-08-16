using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        public Basket() { }

        public string Add(string product)
        {
            if (capacity <= productCount) { return "your basket is full"; }

            _basket.Add(product);
            return "product added to basket";
        }

        public bool Remove(string productID)
        {
            if (_basket.Contains(productID))
            {
                _basket.Remove(productID);
                return true;
            }
            return false;
        }

        public int ChangeCapacity(int c)
        {
            capacity = c;
            return capacity;
        }

        public int capacity { get; set; } = 5;
        public int productCount { get { return _basket.Count; } }
        public List<string> _basket { get; set; } = new List<string>();
    }
}
