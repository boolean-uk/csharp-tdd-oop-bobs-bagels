using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private int capacity = 6;
        List<Item> contents = new List<Item>();
        public Basket()
        {

        }
        public bool addItem(Item item)
        {
            return false;
        }
        public bool removeItem(Item item)
        {
            return false;
        }
        public int changeBasketSize(int newSize)
        {
            return newSize;
        }
    }
}
