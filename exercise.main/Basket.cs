using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {

        private Inventory inventory { get; }
        private int Capacity { get; set; }
        private List<Item> items = new List<Item>();

        public Basket(Inventory inventory)
        {
            this.inventory = inventory;
        }

       

        public bool AddToBasket(string sku)
        {
            throw new NotImplementedException();
        }

        public bool RemoveFromBasket(string sku) {

            return false;
        }

        public void ChangeBasketCapacity(int newCapacity) {
            Capacity = newCapacity;
        }

        public float TotalCostOfBasket()
        {

            return 0f;
        }



        private bool IsFull()
        {
            return items.Count > Capacity;
        }

        private bool ContainsInBasket(string sku)
        {
            foreach (Item item in items) { 
                if (item.Sku.Equals(sku)) return true;
            }
            return false;
        }
        

        
    }
}