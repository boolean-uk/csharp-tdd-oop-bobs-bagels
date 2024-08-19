using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        Inventory inventory = new Inventory();
        public int MAX_BASKET_SIZE { get; set; } = 3;
        public List<Item> yourBasket = new List<Item>();
        public int items_in_basket = 0;
        
        public bool addItem(string itemType, string variant)
        {

            Item item = inventory.findItemByName(variant);
            
            if (items_in_basket >= MAX_BASKET_SIZE)
            {
                Console.WriteLine("Basket is full...");
                return false;
            }
            if (item != null) { 
                yourBasket.Add(item);
                items_in_basket++;
                return true;
            }
            else
            {
                Console.WriteLine("No such item...");
                return false;
            }
        }

        public void removeItem(string itemName)
        {
            Item item = inventory.findItemByName(itemName);
            if (!yourBasket.Contains(item))
            {
                Console.WriteLine("Your basket does not contain this item...");
                return;
            }
            else
            {
                yourBasket.Remove(item);
            }
        }

        public void changeCapacity(int newCapacity, Person person)
        {
            if ((newCapacity <= 0) || (person.role == Role.CUSTOMER))
            {
                Console.WriteLine("Cannot change capacity to 0 or lower or you do not have the permission to do this action...");
            }
            else
            {
                MAX_BASKET_SIZE = newCapacity;
            }
        }

        public double checkTotal()
        {
            return yourBasket.Sum(item => item.price);
        }

        public double checkPriceForType(string type)
        {
            return inventory.findItemByName(type).price;
        }


        //extension 2
        public string reciept()
        {
            string reciept = $"----     Reciept     ----\n";
            double totalPrice = 0;
            List<string> allreadyCountedItems = [];
            foreach (Item item in yourBasket)
            {
                double totalPriceForSpecifiedItem = 0;
                double itemCount = 0;

                if (!allreadyCountedItems.Contains(item.id))
                {

                    foreach (Item specificItem in yourBasket)
                    {
                        if (specificItem.id == item.id)
                        {
                            itemCount++;
                        }
                    }
                    totalPriceForSpecifiedItem = itemCount * item.price;
                    reciept += $"{item.name}: {item.variant}  {itemCount}x - {totalPriceForSpecifiedItem}\n";
                    allreadyCountedItems.Add(item.id);
                }
            }
            reciept += $"-------------------------\ntotal:            {totalPrice}";

            Console.WriteLine(reciept);
            return reciept;
        }



        //extension 1 and 3 made into one method. Not pretty. Next time Ill add an internal counter inside item, should make everything much easier
        public string recieptWithDiscount()
        {
            string reciept = $"----     Reciept     ----\n\n";
            reciept += $"    {DateTime.Now.ToString()}    \n";
            reciept += $"-------------------------\n";
            double totalPrice = 0;
            List<string> allreadyCountedItems = [];
            foreach (Item item in yourBasket)
            {
                double totalPriceForSpecifiedItem = 0;
                double discountedPrice = 0;
                double itemCount = 0;
                double discount = 0;

                if (!allreadyCountedItems.Contains(item.id))
                {

                    foreach (Item specificItem in yourBasket)
                    {
                        if (specificItem.id == item.id)
                        {
                            itemCount++;
                        }
                    }
                    if (itemCount == 6)
                    {
                        totalPriceForSpecifiedItem = itemCount * item.price;
                        discountedPrice = 2.49;
                        discount = totalPriceForSpecifiedItem - discount;
                        totalPrice += discountedPrice;
                        reciept += $"{item.name}: {item.variant}  {itemCount}x - {discountedPrice}\n";
                        reciept += $"          discount ({ discount })\n";
                        allreadyCountedItems.Add(item.id);
                    }
                    else if (itemCount == 12)
                    {
                        totalPriceForSpecifiedItem = itemCount * item.price;
                        discountedPrice = 3.99;
                        discount = totalPriceForSpecifiedItem - discount;
                        totalPrice += discountedPrice;
                        reciept += $"{item.name}: {item.variant}  {itemCount}x - {discountedPrice}\n";
                        reciept += $"          discount ({discount})\n";
                        allreadyCountedItems.Add(item.id);
                    }
                    else
                    {
                        totalPriceForSpecifiedItem = itemCount * item.price;
                        reciept += $"{item.name}: {item.variant}  {itemCount}x - {totalPriceForSpecifiedItem}\n";
                        totalPrice += totalPriceForSpecifiedItem;
                        allreadyCountedItems.Add(item.id);
                    }
                    
                }
            }
            

            reciept += $"-------------------------\ntotal:            {totalPrice}";

            Console.WriteLine(reciept);
            return reciept;
        }
    }
}



