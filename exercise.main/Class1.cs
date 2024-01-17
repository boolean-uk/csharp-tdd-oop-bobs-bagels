using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    //InventoryClass
    public class Inventory
    {
        //List with all Items
        private List<Item> itemsList = new List<Item>();

        //Add Item to List
        public void addItemToInventory(Item item)
        {
            itemsList.Add(item);
        }

        //Check if Item is in stock
        public bool isItemInStock(string SKU) 
        {
            bool isItemInStock = false;

            foreach (Item item in itemsList) 
            {
                if (item.SKU == SKU) 
                {
                    isItemInStock = true;
                }
            }
            return isItemInStock;
        }

        //Get price of Item with SKU
        public float getItemPrice(string SKU) 
        {   
            float price = 0.0f;
            foreach (Item item in itemsList) 
            {
                if (item.SKU == SKU) 
                {
                    price = item.Price;
                }
            }
            return price;
        }
    }

    public class Basket 
    {
        //MaxCapacity & ItemList
        private int maxCapacity = 5;
        private List<Item> itemsList = new List<Item>();

        //Add To Basket
        public void addItemToBasket(Item item, Inventory inventory) 
        {
            if (itemsList.Count < maxCapacity && inventory.isItemInStock(item.SKU))
            {
                itemsList.Add(item);
            }
            else
            {
                //Error Message
                Console.WriteLine("Cannot add item to basket," +
                    "\n max capacity reached or item is not in stock");
            }
        }

        //Remove Item
        public void removeItemFromBasket(string SKU) 
        {
            bool removed = itemsList.RemoveAll(item => item.SKU == SKU) > 0;
            if (!removed)
            {
                //Error Message
                Console.WriteLine("The item you try to remove is not in basket");
            }
        }

        //Get the list of Items
        public List<Item> getItemsList() 
        {
            return itemsList;
        }

        //Set maxcapacity
        public void setMaxCapacity(int maxCapacity) 
        {
            this.maxCapacity = maxCapacity;
        }

        //Get maxcapacity
        public int getMaxCapacity() 
        {
            return maxCapacity;
        }

        //Get total price of items in basket
        public float getTotalPrice() 
        {
            List<float> totalPrice = new List<float>();

            foreach (Item item in itemsList) 
            {
                totalPrice.Add(item.Price);
            }
            return totalPrice.Sum();
        }
        
    }

    //Item Class
    public class Item 
    {
        //All the properties of the Item
        public string Name { get; set; }
        public string Variant { get; set; }
        public string SKU { get; set; }
        public float Price { get; set; }

        //Set the value in the constrictor
        public Item(string variant, string name, string sku, float price)
        {
            Name = name;
            Variant = variant;
            SKU = sku;
            Price = price;
        }
    }
}
