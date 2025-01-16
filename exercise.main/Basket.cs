using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main
{
    public class Basket
    {
        private int capacity;
        private List<Item> items;
        private double totalPrice;

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
                capacity = newCapacity;
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
            StringBuilder result = new StringBuilder();
            result.Append(string.Format("{0,3} {1,-1}", "", "~~~ Bob's Bagels ~~~\n"));
            result.Append(string.Format("{0,3} {1,-1}", "", DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")));
            result.Append("\n--------------------------------\n");
            GetProductPrice(result);
            result.Append("--------------------------------\n");
            result.Append(string.Format("{0,-26}", "Total Price ") + GetTotalCost());
            result.Append("\n--------------------------------\n");
            result.Append(string.Format("{0,5} {1,-1}", "", "Have a good day!"));
            return result.ToString();
        }

        public string GetTotalCost()
        {
            return string.Format("£{0:F2}", totalPrice);
        }

        private StringBuilder GetProductPrice(StringBuilder result)
        {
            double discountedPrice;
            double discounted;
            totalPrice = 0;
            var uniqueItems = items.Distinct();

            foreach (var uniqueItem in uniqueItems)
            {
                string itemName = $"{uniqueItem.Name} {uniqueItem.Variant}";
                int quantity = items.Count(item => item.Equals(uniqueItem));

                if (uniqueItem.Name.Equals("Bagel"))
                {
                    discountedPrice = CalculateBagelOffer(uniqueItem, quantity);
                    discounted = uniqueItem.Price * quantity - discountedPrice;
                    totalPrice += discountedPrice;

                    if (discounted > 0)
                    {
                        result.Append(string.Format("{0,-20} {1,-4} £{2:F2}\n", itemName, quantity, discountedPrice));
                        string discountedString = string.Format("(£{0:F2})\n", discounted);
                        result.Append(string.Format("{0,-26}", " ") + discountedString);
                    }
                    else
                    {
                        result.Append(string.Format("{0,-20} {1,-4} £{2:F2}\n", itemName, quantity, discountedPrice));
                    }
                }
                else if (uniqueItem.Sku.Equals("COFD"))
                {
                    discountedPrice = 1.25 * quantity;
                    discounted = 0.23 * quantity;
                    result.Append(string.Format("{0,-20} {1,-4} £{2:F2}\n", itemName, quantity, discountedPrice));
                    string discountedString = string.Format("(£{0:F2})\n", discounted);
                    result.Append(string.Format("{0,-26}", " ") + discountedString);
                }
                else
                {
                    discountedPrice = CalculateItemPrice(uniqueItem, quantity);
                    totalPrice += discountedPrice;
                    result.Append(string.Format("{0,-20} {1,-4} £{2:F2}\n", itemName, quantity, discountedPrice));
                }
            }
            return result;
        }

        private double CalculateBagelOffer(Item item, int quantity)
        {
            double discountedPrice = 0.0;
            int remainingBagels;

            int deal12Quantity = quantity / 12;
            discountedPrice += deal12Quantity * 3.99;
            remainingBagels = quantity % 12;

            int deal6Quantity = remainingBagels / 6;
            discountedPrice += deal6Quantity * 2.49;
            remainingBagels %= 6;

            discountedPrice += remainingBagels * item.Price;
            return discountedPrice;
        }

        private double CalculateItemPrice(Item item, int quantity)
        {
            return item.Price * quantity;
        }
    }
}
