using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private int _capacity;
        public List<string> content;
        public Basket(int capacity)
        {
            _capacity = capacity;
            content =  new List<string>();
        }
        public bool addItem(string SKU)
        {
            return false;
        }
        public bool removeItem()
        {
            return false;
        }
        private int changeCapacity()
        {
            return 0;
        }
    }
}