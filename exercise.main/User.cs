using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class User
    {
        private bool manager;

        public Basket UserBasket = new Basket();

        public CheckOut checkOut = new CheckOut();

        public User(bool manager = false) {  this.manager = manager; }
        
        public bool AddToBasket(string sku)
        {
            return UserBasket.Add(sku);
        }

        public bool RemoveFromBasket(string sku)
        {
            return UserBasket.Remove(sku);
        }

        

        public float GetItemPrice(string sku)
        {
            return UserBasket.PriceItem(sku);
        }

        public float GetTotalCost()
        {
            return checkOut.CalculateCost(UserBasket.itemAmounts);
        }

        public void GetReceipt()
        {
            checkOut.Receipt(UserBasket.itemAmounts);
        }

        public void ChangeBasketCapacity(int newCapacity)
        {
            if (manager)
            {
                Basket.ChangeCapacity(newCapacity, "secret password");
            }

        }
    }
}
