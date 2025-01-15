using exercise.main;
using System;
using System.Collections.Generic;

namespace exercise.main
{
    public class Basket
    {
        private int capacity;
        private List<Item> items;
        private int quantity;

        public Basket(int capacity)
        {
            this.capacity = capacity;
            items = new List<Item>();
        }

        public void ClearItems()
        {
            items.Clear();
        }

        public bool ChangeCapacity(int newCapacity)
        {
            if (newCapacity >= items.Count)
            {
                this.capacity = newCapacity;
                return true;
            }
            return false;
        }

        public bool AddItems(Inventory inventory, string sku, int quantity)
        {
            Item itemToAdd = inventory.GetItemBySKU(sku);
            if (itemToAdd == null)
            {
                Console.WriteLine("Item not found");
                return false;
            }
            if (items.Count + quantity > capacity)
            {
                Console.WriteLine($"Basket capacity is reached. Current basket: {items.Count}. Capacity: {capacity}");
                return false;
            }

            for (int i = 0; i < quantity; i++)
            {
                items.Add(itemToAdd);
            }
            return true;
        }

        public bool RemoveItems(Inventory inventory, string skuToRemove, int quantityToRemove)
        {
            Item itemToRemove = inventory.GetItemBySKU(skuToRemove);
            if (itemToRemove != null && items.Contains(itemToRemove))
            {
                for (int i = 0; i < quantityToRemove; i++)
                {
                    items.Remove(itemToRemove);
                }
                return true;
            }
            Console.WriteLine("Item was not found");
            return false;
        }

        public string ShowBasket()
        {
            return string.Join(", ", items);
        }

        public int ItemsCount()
        {
            return items.Count;
        }


        public double GetTotalCost()
        {
            double totalCost = 0;
            foreach (Item item in items)
            {
                totalCost += item.Price; 
            }
            return totalCost;
        }
    }
}
