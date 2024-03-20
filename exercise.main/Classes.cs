using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public interface Iitem
    {
        string name { get; }
        string SKU { get; }
        float price { get; }

    }

    public class Bagel : Iitem
    {
        public string name { get; private set; }
        public string SKU { get; private set; }
        public float price { get; private set; }
        public string variant { get; private set; }

        public Bagel(string name, string SKU, float price)
        {
            this.name = name;
            this.SKU = SKU;
            this.price = price;
            this.variant = "Bagel";
        }

    }

    public class Coffee : Iitem
    {
        public string name { get; private set; }
        public string SKU { get; private set; }
        public float price { get; private set; }
        public string variant { get; private set; }

        public Coffee(string name, string SKU, float price)
        {
            this.name = name;
            this.SKU = SKU;
            this.price = price;
            this.variant = "Coffee";
        }

    }

    public class Filling : Iitem
    {
        public string name { get; private set; }
        public string SKU { get; private set; }
        public float price { get; private set; }
        public string variant { get; private set; }

        public Filling(string name, string SKU, float price)
        {
            this.name = name;
            this.SKU = SKU;
            this.price = price;
            this.variant = "Filling";
        }

    }
    
    //InventoryClass
    public class Inventory
    {
        //List with all Items
        private List<Iitem> itemsList = new List<Iitem>();

        //Add Item to List
        public void addItemToInventory(Iitem item)
        {
            itemsList.Add(item);
        }

        //Check if Item is in stock
        public bool isItemInStock(string SKU)
        {
            bool isItemInStock = false;

            foreach (Iitem item in itemsList)
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
            foreach (Iitem item in itemsList)
            {
                if (item.SKU == SKU)
                {
                    price = item.price;
                }
            }
            return price;
        }
    }

    public class Basket
    {
        //MaxCapacity & ItemList
        private int maxCapacity = 5;
        private List<Iitem> itemsList = new List<Iitem>();
        public Inventory inventory;

        //Add To Basket
        public void addItemToBasket(Iitem item)
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
        public List<Iitem> getItemsList()
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

            foreach (Iitem item in itemsList)
            {
                totalPrice.Add(item.price);
            }
            return totalPrice.Sum();
        }

    }
}
