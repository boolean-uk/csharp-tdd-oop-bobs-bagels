using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        public Basket(int bagelCap = 3)
        {
            BasketCapacity = bagelCap;
        }

        public List<Bagel> BagelList { get; set; } = new List<Bagel>();
        //public List<Coffee> CoffeeList { set; get; } = new List<Coffee>();
        public int BasketCapacity { set; get; }

        public bool AddBagel(Bagel bagel)
        {
            if (!Inventory.IsInInventory(bagel.BagelType) && !Inventory.IsInInventory(bagel.BagelFilling))
                return false;

            if (BagelList.Count >= BasketCapacity)
            {
                Console.WriteLine("ERROR! Basket is full!");
                return false;
            } 
            
            BagelList.Add(bagel);
            return true;
        }

        public double GetBasketTotal()
        {
            double totalSum = 0;

            foreach (var bagel in BagelList)
            {
               totalSum += Inventory.items.Where(x => x.Variant == bagel.BagelType).ToList()[0].Price;
               if (bagel.BagelFilling != "")
                 totalSum += Inventory.items.Where(x => x.Variant == bagel.BagelFilling).ToList()[0].Price;

            }

            //foreach (var coffee in CoffeeList)
            //{

            //}

            return totalSum;
        }

        public bool RemoveBagel(Bagel bagelToRemove)
        {
            if (BagelList.Contains(bagelToRemove))
            {
                BagelList.Remove(bagelToRemove);
                return true;
            }

            Console.WriteLine("WARNING, tried to remove bagel that does not exist!");
            return false;
        }

        public void UpdateCapacity(int i)
        {
            BasketCapacity = i;
        }
    }
}
