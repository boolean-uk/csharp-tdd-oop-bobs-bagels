using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;
using exercise.main.Inventory;

namespace exercise.main.Inventory
{
    public class Basket
    {
        public List<Item> Items { get; set; } = new List<Item>();
        public int _capacity { get; set; }

        public Basket(int capacity) 
        {
            _capacity = capacity;
        }

        public void AddItem(Item item)
        {
            if(Items.Count() < _capacity)
            {
                Items.Add(item);
            }
            else
            {
                Console.WriteLine("Basket is full");
            }

        }

        public bool RemoveItem(Item item) 
        {

            bool exists = true;
            if (Items.Contains(item) != true)
            {
                Console.WriteLine("Item does not exist in basket");
                exists = false;
            }
            else
            {
                Items.Remove(item);
            }
            return exists;
          
        }

        public static void ListOfItems()
        {
            //Print the price and the variant of the item
            foreach (var item in BobsInventory.Inventory)
            {
                //If-statment to make the prints more readable, and to distinct the different items.
                if(item._SKU == "BGL")
                {
                    Console.WriteLine($"Price of bagel: {item._price}, Variant: {item._variant}");
                }
                if(item._SKU == "COF")
                {
                    Console.WriteLine($"Price of coffee: {item._price}, Variant: {item._variant}");
                }
                if(item._SKU == "FIL")
                {
                    Console.WriteLine($"Price of filling: {item._price}, Variant: {item._variant}");
                }
                
                
            }


        }

        public string PriceOfItem(Item item)
        {
            BobsInventory Stock = new BobsInventory();

            StringBuilder sb = new StringBuilder();

            bool found = false;

            foreach (var shopitem in Stock.Stock)
            {
                if(shopitem._SKU == item._SKU)
                {
                    sb.Append($"Price of item: {shopitem._price}");
                    found = true;
                }
                
            } 
            if(!found)
            {
                sb.Append("No such item in inventory");
            }
            return sb.ToString();
        }

        public string changeBasketSize(int newSize)
        {
            _capacity = newSize;

            return $"Capacity is set to {newSize}";
        }

        public double TotalCost()
        {
            return Items.Sum(item => item._price);
        }

        public int QuantityCounter(string sku)
        {
            return Items.Where(x => x._SKU == sku).ToList().Count();
        }

        public void WriteReceipt()
        {
            

            Console.WriteLine($"         ~~ Bob's Bagels ~~");
            Console.WriteLine();
            Console.WriteLine($"         {DateTime.Now.ToShortTimeString()}");
            Console.WriteLine();
            Console.WriteLine("{0,10}    {1,10}    {2,10} ", "Product", "Qty", "Price");
            
            foreach (Item item in Items.GroupBy(x => x._SKU).Select(x => x.First()).ToList())
            {//Item item in Items.Distinct(x => x._SKU).ToList()

                Console.WriteLine("{0,10}    {1,10}    {2,10}",
                        item._variant,
                        QuantityCounter(item._SKU),
                        $"£{item._price * QuantityCounter(item._SKU)}"
                        );

            }

            Console.WriteLine(new string('-', 40));
            double result = 0;
            
            result = TotalCost();

            Console.WriteLine($"Total                          {result}");


        }


    }

}