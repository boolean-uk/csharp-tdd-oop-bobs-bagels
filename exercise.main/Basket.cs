using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        Inventory inventory = new Inventory();
        int maxCapacity = 5;
        List<Item> basket = new List<Item>();

        public bool addItem(string sku)
        {
            bool result = false;
            Item? temp = null;
            temp = inventory.getItem(sku);

            if (temp != null)
            {
                if (basket.Count < maxCapacity)
                {
                    basket.Add(temp);
                    result = true;
                }
            }

        return result;
        }
        public bool removeItem(int listNum)
        {
            bool result = false;
            if (listNum < basket.Count)
            {
                basket.RemoveAt(listNum);
                result = true;
            }
            return result;
        }
        public bool changeMaxCap(int newCap)
        {
            bool result = false;

            if (newCap >= basket.Count)
            {
                maxCapacity = newCap;
                result = true;
            }
            
            return result;
        }

        public float totalCost()
        {
            float totalCost = 0;

            foreach (var item in basket)
            {
                totalCost += item._price;

                if (item.filling.Count > 0)
                {
                    for(int i = 0; i < item.filling.Count; i++)
                    {
                        totalCost += item.filling[i]._price;
                    }
                }
            }

            return totalCost;
        }

        public float itemPrice(string sku)
        {
            float price = 0;

            Item? item = inventory.getItem(sku);

            if(item != null)
            {
                price = item._price;
            }

            return price;
        }
        public bool addFilling(int listNum, string sku)
        {
            bool result = false;

            if(listNum < basket.Count && basket[listNum]._name == "Bagel")
            {
                Item? item = inventory.getItem(sku); 
                if(item != null)
                {
                    basket[listNum].filling.Add(item);
                    result = true;
                }
            }

            return result;
        }
        public List<string> listFillings()
        {
            List<Item> fillings = new List<Item>();
            List<string> list = new List<string>();
            fillings = inventory.giveFillings();

            foreach(Item item in fillings)
            {
                list.Add(item._variant+","+item._price);
            }

            return list;
        }

    }


}
