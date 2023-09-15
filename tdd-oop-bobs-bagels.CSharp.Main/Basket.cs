using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd.oop.bobs.bagels.CSharp.Main
{
    public class Basket
    {
        //public int Capacity { get; set; } = 3;

        private int capacity;
        public bool isMaximumReached {  get { return items.Count >= capacity; } }

        public Basket(int initialCapacity)
        {
            capacity = initialCapacity;
            
        }

        public List<Item> items {  get; set; } = new List<Item>(); //store thing that i am buying 
        public void AddItem(Item item)
        {   
            if (!isMaximumReached && item != null)
            {
               items.Add(item);
                
            }

        }

        public void RemoveItem(Item item)
        {
            items.Remove(item);
        }

        public string RemoveBagelMessage( Item itemToRemove)
        {
            if (items.Contains(itemToRemove))
            {
                items.Remove(itemToRemove);
                return "Your item is deleted.";
            }
            return "The item you want to remove is not in your basket";
        }

        public decimal TotalPrice()
        {
            decimal totalPrice = 0;
            foreach(Item item in items)
            {   
                totalPrice += item.Price;

            }
            return totalPrice;
        }

        public decimal BeforeIbuy(Item item)
        {
            decimal itemPrice = item.Price;

            return itemPrice;
        }
    }
}
