using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;


namespace exercise.main
{
    public class Basket
    {
        public int _capacity = 12;
        public List<Product> basketList = new List<Product>();
        public Menu menu = new Menu();
        
        
        

        public Basket()
        {
            basketList = new List<Product>(_capacity);
            menu.printMenu();
        }

        public List<Product> Products { get { return basketList; } }
        public int Capacity { get { return _capacity; } }

        public bool addProductToBasket(Product prod)
        {
            if (basketList.Count > _capacity)
            {
                Console.WriteLine("Basket is full");
                return false;
            }
            else if (!checkInventory(prod._sku))
            {
                Console.WriteLine("Item not in inventory");
                return false;
            }
            else
            {
                basketList.Add(prod);
                return true;
            }

        }

        public void removeProduct(Product product)
        {
            if(!basketList.Contains(product))
            {
                ProductNotInBasket(product);
            }
            else { basketList.Remove(product);}
            
        }

        public void changeBasketCapacity(int size) 
        {
            _capacity = size;
        }

        public string ProductNotInBasket(Product prod)
        {
            return ($"{prod} is not in the basket");
        }

        public double totalCost()
        {
            double totalCost = 0;
            foreach(Product product in basketList)
            {
                totalCost += (product._price * product.count);
            }

            return totalCost;
        }

        public string showMenu()
        {
            string s = menu.stringifyMenu();
            return s;
        }

        public bool checkInventory(string sku)
        {
            
            foreach(var item in menu.menuList)
            {
                if(item._sku == sku )
                {
                    return true;
                }

            }
            return false;
        }
        public string printBasket()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Product product in basketList)
            {
                sb.Append(product.ToString());
                
            }
            return sb.ToString();
        }

        //Extension 1 

        public double CalculateTotalCost()
        {
            double totalCost = 0;
            double discountCost = 0;


            foreach (Product product in basketList)
            {
                totalCost += (product._price * product.count);
            }

            foreach (Product product in basketList)
            {
                discountCost += product.SpecialOfferCost();
            }

            return discountCost;
        }

        public void WriteReceipt()
        {
            Console.WriteLine($"         ~~ Bob's Bagels ~~");
            Console.WriteLine();
            Console.WriteLine($"         {DateTime.Now.ToShortTimeString()}");
            Console.WriteLine();
            Console.WriteLine("{0,10}    {1,10}    {2,10} ", "Product", "Qty", "Price");
            foreach (Product prod in basketList)
            {
                Console.WriteLine("{0,10}    {1,10}    {2,10}", prod._variant, prod.count, $"£{prod._price}");

            }

            Console.WriteLine(new string('-', 40));
            double result = totalCost();
            Console.WriteLine($"Total                          {result}");
        }

    }
}
