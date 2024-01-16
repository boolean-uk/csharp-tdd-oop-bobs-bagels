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
            capacity = 10;
            basket = new List<Bagel>();
        }

        public bool AddBagel(string SKU, float cost, string fillingName = "", float fillingCost = 0)
        {
            if (BasketFull())
                return false;

            if (SKU == "")
                return false;

            if (cost < 0 || fillingCost < 0)
                return false;

            Bagel bagel = new Bagel(SKU, cost, fillingName, fillingCost);
            basket.Add(bagel);
            return true;
        }

        public bool RemoveBagel(string SKU, string fillingName)
        {
            if (SKU == "")
                return false;

            if (!ItemExists(SKU, fillingName))
                return false;

            for (int i = 0; i < basket.Count(); i++)
            {
                if (basket[i].GetBagelType() == SKU && basket[i].GetFillingName() == fillingName)
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

        public bool ItemExists(string SKU, string fillingName)
        {
            for (int i = 0; i < basket.Count(); i++)
            {
                if (basket[i].GetBagelType() == SKU && basket[i].GetFillingName() == fillingName)
                    return true;
            }

            return false;
        }

        public float TotalCost()
        {
            float total = 0;

            for (int i = 0; i < basket.Count(); i++)
                total += basket[i].GetBagelCost();

            return total;
        }

        public List<Bagel> GetBagels()
        {
            return basket;
        }
    }
}