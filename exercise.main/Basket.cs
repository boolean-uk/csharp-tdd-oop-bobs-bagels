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

            //Apply the discount
            for(int i = 0; i < coffees; i++)
            {
                if(excessBagels > 0) //If there are more bagels left
                {
                    totalCost -= 0.23f;
                    excessBagels--;
                }
                else //Exit the loop
                {
                    break;
                }
            }

            return totalCost;
        }

        public string Receipt()
        {
            //Masterfully construct the receipt
            string receipt = $"      ~~~Bob's Bagels~~~\n\n     {DateTime.Now.ToString("G")}\n\n-------------------------------\n\n";

            //For each item, add the name, amount and total cost
            foreach (var item in products)
            {
                if(item.info.key == "BGLE" || item.info.key == "COFC")
                {
                    receipt += $"{item.info.variant} {item.info.name}\t\t{item.GetAmount()}\t{item.Cost()}\n";
                }
                else
                {
                    receipt += $"{item.info.variant} {item.info.name}\t\t\t{item.GetAmount()}\t{item.Cost()}\n";
                }
            }

            //Spacing and total cost
            receipt += $"\n-------------------------------\nTotal\t\t\t\t\t{this.TotalCost()}";

            return receipt;
        }

        public void Empty()
        {
            this.products.Clear();
        }
    }
}
