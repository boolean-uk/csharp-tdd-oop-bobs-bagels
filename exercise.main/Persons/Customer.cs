using exercise.main.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Persons
{
    public class Customer
    {
        #region
        private Basket _basket;
        public Basket Basket { get => _basket; }
        #endregion

        public Customer() 
        { 
            _basket = new Basket(); 
        }
        public bool AddItemToBasket(Item item)
        {
            return _basket.Add(item);
        }

        public bool RemoveItemFromBasket(Item bagel)
        {
            return _basket.Remove(bagel);
        }

        public double GetTotalSumOfBasket()
        {
            double total = 0;

            List<Bagel> bagelList = new List<Bagel>();
            List<Item> itemList = new List<Item>();

            foreach (var item in _basket.ItemsInBasket)
            {
                if (item.GetType() == typeof(Bagel))
                {
                    bagelList.Add((Bagel) item);
                } else
                {
                    itemList.Add(item);
                }
            }

            foreach (Bagel bagel in bagelList) 
            {
                if (bagel.Fillings.Count > 0)
                {
                    total += bagel.Price;
                    total += bagel.Fillings.Sum(filling => filling.Price);
                } else
                {
                    total += bagel.Price;
                }
            }

            double itemListSum = itemList.Sum(item => item.Price);

            return total + itemListSum;

            // return _basket.ItemsInBasket.Sum(item => item.Price);
        }

        public double GetCostOfItem(Item item)
        {
            return item.Price;
        }

        public bool AddFillingToBagel(Bagel bagel, Filling filling)
        {
            return _basket.AddFillingToBagel(bagel, filling);
        }
    }
}
