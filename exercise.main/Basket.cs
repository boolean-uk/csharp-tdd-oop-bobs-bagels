using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private List<Bagel> basket;
        private int capacity;

        public Basket()
        {
            basket = new List<Bagel>();
        }

        public bool AddBagel(Bagel bagel)
        {
            return false;
        }

        public bool RemoveBagel(string bagelType)
        {
            return false;
        }

        public bool BasketFull()
        {
            return false;
        }

        public int IncreaseCapacity(int newCapacity)
        {
            return 0;
        }

        public bool ItemExists(string bagelType)
        {
            return false;
        }

        public int TotalCost()
        {
            return 0;
        }

    }
}