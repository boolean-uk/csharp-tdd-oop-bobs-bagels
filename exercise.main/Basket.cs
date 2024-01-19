using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private List<Item> _basketItems = new List<Item>();
        private int _capacity = 20;

        public Basket(List<Item> basketItems, int capacity)
        {
            _basketItems = basketItems;
            _capacity = capacity;
        }

        public Basket(int capacity)
        {
            _capacity = capacity;
        }

        public Basket()
        {

        }

        public List<Item> BasketItems { get { return _basketItems; } set { _basketItems = value; } } 
        public int Capacity { get { return _capacity; } set { _capacity = value; } }


        Inventory inventory = new Inventory();

        public void AddItem(string Sku)
        {
            if (!IsBasketFull())
            {
                foreach (var itemInv in inventory.InventoryItems)
                {
                    if (itemInv.Sku == Sku)
                    {
                       Console.WriteLine($"Item: {itemInv.Variant} {itemInv.Name} has been added to basket");
                        if(itemInv.Quantity == 0)
                        {
                            BasketItems.Add(itemInv);
                            itemInv.Quantity++;
                        } else
                        {
                            itemInv.Quantity++;
                        }

                    }
                }

            }
 
        }

        public bool RemoveItem(string Sku)
        {
            bool result = true;
            Item item = BasketItems.Where(x => x.Sku == Sku).First();
            if(item == null)
            {
                return false;
            }
            BasketItems.Remove(item);
            Console.WriteLine($"Item: {item.Name} {item.Variant} has been removed from basket");
            return result;
        }

        public bool IsBasketFull()
        {
            if(BasketItems.Count < Capacity || BasketItems.Count == 0)
            {
                Console.WriteLine("Basket is not full");
                return false;
            } else
            {
                Console.WriteLine("Basket is full");
                return true;
            }
        }

        public void ChangeBasketCapacity(int newCapacity)
        {
            if (BasketItems.Count <= Capacity)
            {
                Capacity = newCapacity;
                Console.WriteLine("Capacity of basket has been changed");
            }

        }

        public double TotalCostBasket()
        {
            double result = 0d;
            
            bool hasCoffee = false;
            bool hasBagel = false;
            int coffeeQuantity = 0;
            int bagelQuantity = 0;
            int discountQuantity = 0;
            double coffeePrice = 0;
            double bagelPrice = 0;
            double bagelCoffePrice = 0;
            foreach (var item in BasketItems)
            {
                //Checks if there are 0 items left in basket
                while(item.Quantity > 0)
                {
                    //Checks 6 for 2.49 discount
                    if ((item.Variant == "Onion" || item.Variant == "Everything") && item.Quantity >= 6)
                    {
                        result += 2.49d;
                        double discountAmount6 = Math.Round((item.Quantity * item.Price) - 2.49, 2);
                        item.Quantity -= 6;
                        Console.WriteLine($"6 {item.Variant} Bagels for {2.49d} discount (-£{discountAmount6})");
                    }
                    //Checks 12 for 3.99 discount
                    else if ((item.Variant == "Plain" || item.Variant == "Sesame") && item.Quantity >= 12)
                    {
                        result += 3.99d;
                        double discountAmount12 = Math.Round((item.Quantity*item.Price) - 3.99, 2);
                        item.Quantity -= 12;
                        Console.WriteLine($"12 {item.Variant} Bagels for {3.99} discount (-£{discountAmount12})");

                    }  
                    else
                    {
                        //Checks for Coffee and Bagel discount
                        if (item.Name == "Coffee")
                        {
                            hasCoffee = true;
                            coffeeQuantity += item.Quantity;
                            coffeePrice += item.Price * item.Quantity;
                            if (hasBagel)
                            {
                                bagelCoffePrice = bagelPrice;
                            } else
                            {
                                bagelCoffePrice = coffeePrice;
                            }
                        } else if (item.Name == "Bagel")
                        {
                            hasBagel = true;
                            bagelQuantity += item.Quantity;
                            bagelPrice += item.Price * item.Quantity;
                        }
                        //adds coffee and bagel discount if coffee and bagel is in basket
                        if (hasCoffee && hasBagel) { 
                            hasCoffee = false;
                            hasBagel = false;
                            if(coffeeQuantity > bagelQuantity)
                            {
                                discountQuantity = bagelQuantity;

                            } else
                            {
                                discountQuantity = coffeeQuantity;
                            }

                            result += 1.25 * discountQuantity - bagelCoffePrice;
                            item.Quantity -= discountQuantity;
                            Console.WriteLine($"Coffee and Bagel discount        (-£{Math.Round((bagelPrice + coffeePrice - (1.25*discountQuantity)), 2)})");
                              
                        }

                           result += item.Price * item.Quantity;
                           item.Quantity -= item.Quantity;                                         
                    }
                    
                }           

            }
            //          Console.WriteLine("The total cost of basket is: " + Math.Round(result, 2));
            return Math.Round(result, 2);
        }
    }
}
