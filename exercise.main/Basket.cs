using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
        public List<Coffee> CoffeeList { set; get; } = new List<Coffee>();

        public int BasketCapacity { set; get; }

        public bool AddBagel(Bagel bagel)
        {
            //Not needed when enums are used for type.
            //if (!Inventory.IsInInventory(bagel.mBagelType) && !Inventory.IsInInventory(bagel.mBagelFilling))
            //{
            //    Console.WriteLine("ERROR! Bagel is not in current inventory!");
            //    return false;
            //}

            if (BagelList.Count >= BasketCapacity)
            {
                Console.WriteLine("ERROR! Basket is full!");
                return false;
            } 
            
            BagelList.Add(bagel);
            return true;
        }

        public void AddCoffee(Coffee coffee)
        {
            CoffeeList.Add(coffee);
        }

        public void RemoveCoffee(Coffee coffee)
        {
            CoffeeList.Remove(coffee);
        }

        public double GetBasketTotal()
        {
            double totalSum = 0;

            //List<Bagel> CopyList = BagelList;

            //Check discount here, remove items discounts apply to
            for (int i = 0; i < Inventory.BagelDiscountList.Count; i++)
            {

                int discountAmount = Inventory.BagelDiscountList[i].specialAmount;
                while (BagelList.Where(x => x.mBagelType == Inventory.BagelDiscountList[i].Variant).ToList().Count >=
                    discountAmount)
                {
                    totalSum += Inventory.BagelDiscountList[i].discountPrice;

                    List<Bagel> tempList = BagelList.Where(x => x.mBagelType == Inventory.BagelDiscountList[i].Variant)
                        .ToList();
                    tempList.RemoveRange(discountAmount, tempList.Count - discountAmount);
                    foreach (var temp in tempList)
                    {
                        BagelList.Remove(temp);
                    }
                }
            }

            for (int i = 0; i < Inventory.CoffeeDiscountList.Count; i++)
            {

                while (CoffeeList.Count(x => x.mCoffeeType == Inventory.CoffeeDiscountList[i].Variant) > 0 && BagelList.Count > 0)
                {
                    totalSum += Inventory.CoffeeDiscountList[i].discountPrice;

                    CoffeeList.RemoveAt(0);
                    BagelList.RemoveAt(0);
                }
            }

            foreach (var bagel in BagelList)
            {
               totalSum += Inventory.bagels.Where(x => x.Variant == bagel.mBagelType).ToList()[0].Price;
            }
            totalSum += Inventory.GetFillingPrice(BagelList);

            foreach (var coffee in CoffeeList)
            {
                totalSum += Inventory.coffee.Where(x => x.Variant == coffee.mCoffeeType).ToList()[0].Price;
            }

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
