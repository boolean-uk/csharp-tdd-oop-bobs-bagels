using System;
using System.Collections.Generic;
using System.Linq;
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

        internal float TotalCost()
        {
            //Calculate the total cost of all products in basket
            float totalCost = 0;
            foreach (var item in products)
            {
                totalCost += item.Cost();
            }
            return totalCost;
        }
    }
}
