using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        public List<Item> _basketItems = new List<Item>();
        public int _capasity;

        public Basket(List<Item> basketItems, int capasity)
        {
            _basketItems = basketItems;
            _capasity = capasity;
        }

        public Basket()
        {

        }



        public List<Item> BasketItems { get { return _basketItems; }set { _basketItems = value; } }
        public int Capacity { get { return _capasity; } set { _capasity = value; } }


        Inventory inventory = new Inventory();

        public void AddBagel(string Sku)
        {
            foreach (var itemInv in inventory.InventoryItems)
            {
                if (itemInv.Sku == Sku)
                {
                    BasketItems.Add(itemInv);
                }
            }
        }

        public bool RemoveBagel(string Sku)
        {
            throw new NotImplementedException();
        }

        public bool IsBasketFull()
        {
            throw new NotImplementedException();
        }

        public void ChangeBasketCapacity(int newCapacity)
        {
            throw new NotImplementedException();
        }

        public int TotalCostBasket()
        {
            throw new NotImplementedException();
        }

        public void AddFilling(string Sku)
        {
            throw new NotImplementedException();
        }

        public int CostOfFilling()
        {
            throw new NotImplementedException();
        }

        public int CostOfBagel()
        {
            throw new NotImplementedException();
        }




    }
}
