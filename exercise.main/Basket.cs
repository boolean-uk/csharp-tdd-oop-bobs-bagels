using System;
using System.Collections.Generic;
using System.Linq;

namespace exercise.main
{
    public class Basket
    {
        private List<Product> basketItems;
        private int basketCapacity;
        private double discount6 = 2.49;
        private double discount12 = 3.99;
        private double totalPrice; 

        public Basket(int capacity = 20)
        {
            basketItems = new List<Product>();
            basketCapacity = capacity;
        }

        public void AddItem(Product item)
        {
            if (basketItems.Count < basketCapacity)
            {
                basketItems.Add(item);
                Console.WriteLine($"{item.Name} was added to the basket!");

                if (item is Bagel bagel)
                {
                    UseBagelDiscount(bagel);
                }
            }
            else
            {
                Console.WriteLine($"Basket is full. You cannot add more items. Max capacity: {basketCapacity}");
            }
        }

        private void UseBagelDiscount(Bagel bagel)
        {
            int bagels = basketItems.Count(item => item is Bagel);

            if (bagels == 6)
            {
                foreach (var item in basketItems.Where(item => item is Bagel))
                {
                    totalPrice = discount6;
                }
            }
            else if (bagels == 12)
            {
                foreach (var item in basketItems.Where(item => item is Bagel))
                {
                    totalPrice = discount12;
                }
            }
        }

        public void RemoveItem(int index)
        {
            if (index >= 0 && index < basketItems.Count)
            {
                Product removedItem = basketItems[index];
                basketItems.RemoveAt(index);
                Console.WriteLine($"{removedItem.Name} removed from the basket!");
            }
            else
            {
                Console.WriteLine("Invalid index. Please try again.");
            }
        }

        public double CalculateTotal()
        {
            foreach (var item in basketItems)
            {
                if (item is Bagel bagel)
                {
                    UseBagelDiscount(bagel);
                }
                else
                {
                    totalPrice = basketItems.Sum(item => item.Price);
                }
            }
            return totalPrice;
        }

        public int GetBasketCount()
        {
            return basketItems.Count;
        }

        public Product GetItem(int index)
        {
            if (index >= 0 && index < basketItems.Count)
            {
                return basketItems[index];
            }
            else
            {
                return null;
            }
        }

        public void ShowReceipt()
        {
            var time = DateTime.Now;

            Console.Clear();

            if (basketItems.Count == 0)
            {
                Console.WriteLine("Basket is empty. Total price: $0.00");
            }
            else
            {
                Console.WriteLine("~~~ Bob's Bagels ~~~");
                Console.WriteLine("\n");
                Console.WriteLine(time);
                Console.WriteLine("\n");
                Console.WriteLine("-------------------------");
                Console.WriteLine("\n");
                for (int i = 0; i < basketItems.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {basketItems[i].Name} - {basketItems[i].Variant} - ${basketItems[i].Price}");
                }

                Console.WriteLine("\n");
                Console.WriteLine("-------------------------");
                Console.WriteLine($"Total price: ${CalculateTotal()}");
                Console.WriteLine("\n");
                Console.WriteLine("Thank you \nfor your order!");
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        public void ChangeBasketCapacity(int newCapacity)
        {
            if (newCapacity > 0)
            {
                basketCapacity = newCapacity;
                Console.WriteLine($"Basket capacity changed to {newCapacity}.");
            }
            else
            {
                Console.WriteLine("Invalid capacity.");
            }
        }

        public int GetBasketCapacity()
        {
            return basketCapacity;
        }
    }
}
