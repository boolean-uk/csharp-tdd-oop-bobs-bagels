using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        public int size {  get; set; } //Size of basket
        public List<Product> products = new List<Product>(); //List of all 

        public Basket(Manager manager)
        {
            this.size = manager.allowedBasketSize; 
        }

        public int Search(string product)
        {
            int index = 0;
            //Loop through all products and try to find the index of the selected one
            foreach (var item in products)
            {
                if (item.info.key == product)
                {
                    return index;
                }
                index++;
            }
            return -1;
        }

        public float TotalCost()
        {
            //Calculate the total cost of all products in basket
            float totalCost = 0.0f;
            foreach (var item in products)
            {
                totalCost += item.Cost();
            }

            //Apply coffee discount
            totalCost -= 0.23f * (float)this.CoffeeDiscounts();

            return totalCost;
        }

        private int CoffeeDiscounts()
        {
            int coffeeDiscounts = 0;
            //Calculate the 0.23 discount for every coffee and excess bagel that exists
            int coffees = 0;
            int excessBagels = 0;

            //Find how many of each exists
            foreach (var item in products)
            {
                //Add Coffee
                if (item.info.key[0] == 'C')
                {
                    coffees += item.GetAmount();
                }

                //Add Bagel
                if (item.info.key[0] == 'B')
                {
                    excessBagels += item.GetExcessBagelAmount();
                }
            }

            //Check how many discounts can be applied
            for (int i = 0; i < coffees; i++)
            {
                if (excessBagels > 0) //If there are more bagels left
                {
                    coffeeDiscounts++;
                    excessBagels--;
                }
                else //Exit the loop
                {
                    break;
                }
            }

            return coffeeDiscounts;
        }

        public string Receipt()
        {
            //Masterfully construct the receipt
            string receipt = $"       ~~~Bob's Bagels~~~\n\n      {DateTime.Now.ToString("G")}\n\n-------------------------------\n\n";

            int coffeeDiscounts = this.CoffeeDiscounts();

            float totalDiscount = 0.0f;

            //For each item, add the name, amount and total cost
            foreach (var item in products)
            {
                //Check if it's an everything bagel or capuccino (cause long names)
                if(item.info.key == "BGLE" || item.info.key == "COFC")
                {
                    receipt += $"{item.info.variant} {item.info.name}\t\t{item.GetAmount()}\t£{item.Cost()}\n";
                }
                else //Otherwise just add anything else
                {
                    receipt += $"{item.info.variant} {item.info.name}\t\t\t{item.GetAmount()}\t£{item.Cost()}\n";
                }

                //Check if any bagel discounts have been applied
                if (item.info.key[0] == 'B' && item.BagelDiscount() > 0) 
                {
                    receipt += $"\t\t\t\t\t  (-£{item.BagelDiscount()})\n";
                    totalDiscount += item.BagelDiscount();
                }
                else if (item.info.key[0] == 'C' && coffeeDiscounts > 0) //Check if any coffee discounts have been applied
                {
                    //If the coffee discounts exceed the amount of coffees of this type
                    if(coffeeDiscounts > item.GetAmount())
                    {
                        receipt += $"\t\t\t\t\t  (-£{0.23f * item.GetAmount()})\n";
                        totalDiscount += 0.23f * item.GetAmount();
                    }
                    else //The amount of coffees of this type exceeds the amount of coffee discounts left
                    {
                        receipt += $"\t\t\t\t\t  (-£{0.23f * coffeeDiscounts})\n";
                        totalDiscount += 0.23f * coffeeDiscounts;
                    }
                    coffeeDiscounts -= item.GetAmount();
                }
            }

            //Spacing and total cost
            receipt += $"\n-------------------------------\nTotal\t\t\t\t\t£{this.TotalCost()}";

            return receipt;
        }

        public void Empty()
        {
            this.products.Clear();
        }
    }
}
