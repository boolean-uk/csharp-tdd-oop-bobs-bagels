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

        public void AddItem(string item)
        {
            if (BobsInventory.Inventory.Any(x => x._SKU == item)) 
            {
                var item2 = BobsInventory.Inventory.Where(x => x._SKU == item).FirstOrDefault();
                Items.Add(new Item(item2._SKU, item2._price, item2._type, item2._variant));
            }
            else if (Items.Count > _capacity) 
            {
                Console.WriteLine("Basket is full");
            }

        }

        public void RemoveItem(Item item) 
        {
            if (Items.Contains(item) != true)
            {
                Console.WriteLine("Item does not exist in basket");
            }
            else
            {
                Items.Remove(item);
            }
          
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

        public static string PriceOfItem(string item)
        { 
            StringBuilder sb = new StringBuilder();

            bool found = false;

            foreach(var shopitem in  BobsInventory.Inventory)
            {
                if(shopitem._variant == item)
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


    }

}