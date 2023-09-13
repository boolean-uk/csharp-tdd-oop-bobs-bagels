using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class Basket
    {
        private List<Bagel> bagels = new List<Bagel>();

        private Dictionary<string, double> prices; 

        private int capacity;

        public Basket(int capacity, Dictionary<string, double> inventoryPrices)
        {
            this.capacity = capacity;
            prices = inventoryPrices; 
        }

        public int SetCapacity()
        {
           return capacity;
        }

        public bool IsFull()
        {
            return bagels.Count == capacity;
        }

        public void ChangeBasketCapacity(int newCapacity)
        {
            capacity = newCapacity;
        }

        public bool AddBagel(Bagel bagel)
        {
            if (bagels.Count < capacity)
            {
                bagels.Add(bagel);
                return true;
            }
            return false;
        }

        public double AddFillingToBagel(Bagel bagel, string fillingSKU)
        {
            switch (fillingSKU)
            {
                case "FILB":
                case "FILE":
                case "FILC":
                case "FILX":
                case "FILS":
                case "FILH":
                    double fillingPrice = 0.12;
                    bagel.Name += " with Filling";
                    return fillingPrice;
                default:
                    throw new InvalidOperationException("Invalid filling SKU.");
            }
        }

        public double GetBagelCost(string bagelName)
        {
            Bagel selectedBagel = bagels.FirstOrDefault(b => b.Name == bagelName);

            if (selectedBagel != null)
            {
                return selectedBagel.Price;
            }
            else
            {
                throw new InvalidOperationException("Bagel not found in the basket.");
            }
        }

        public bool CheckStock(string itemSKU)
        {
            return prices.ContainsKey(itemSKU);
        }

        public bool RemoveBagel(Bagel bagel)
        {
            if (bagels.Contains(bagel))
            {
                bagels.Remove(bagel);
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetBagelCount()
        {
            return bagels.Count;
        }

        public double GetTotalCost()
        {
            return bagels.Sum(b => b.Price);
        }
    }
}