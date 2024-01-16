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
            capacity = 6;
            basket = new List<Bagel>();
        }

        public bool AddBagel(string bagelType, int cost, string fillingName = "", int fillingCost = 0)
        {
            if (BasketFull())
                return false;

            if (bagelType == "")
                return false;

            if (cost < 0 || fillingCost < 0)
                return false;

            Bagel bagel = new Bagel(bagelType, cost, fillingName, fillingCost);
            basket.Add(bagel);
            return true;
        }

        public bool RemoveBagel(string bagelType, string fillingName)
        {
            if (bagelType == "")
                return false;

            if (!ItemExists(bagelType, fillingName))
                return false;

            for (int i = 0; i < basket.Count(); i++)
            {
                if (basket[i].GetBagelType() == bagelType && basket[i].GetFillingName() == fillingName)
                    basket.RemoveAt(i);
            }

            return true;
        }

        public bool BasketFull()
        {
            if (basket.Count() == capacity)
                return true;

            return false;
        }

        public int IncreaseCapacity(int newCapacity)
        {
            if (capacity < newCapacity)
                capacity = newCapacity;

            return capacity;
        }

        public bool ItemExists(string bagelType, string fillingName)
        {
            for (int i = 0; i < basket.Count(); i++)
            {
                if (basket[i].GetBagelType() == bagelType && basket[i].GetFillingName() == fillingName)
                    return true;
            }

            return false;
        }

        public int TotalCost()
        {
            int total = 0;

            for (int i = 0; i < basket.Count(); i++)
                total += basket[i].GetBagelCost();

            return total;
        }
    }
}