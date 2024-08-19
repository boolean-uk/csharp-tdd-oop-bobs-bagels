using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Product
    {
        public Base info; //product information
        private int amount = 1;
        private List<Base> fillings = new List<Base>(); //product fillings

        public Product(Base info)
        {
            this.info = info;
        }

        public void IncreaseAmount(int amount)
        {
            this.amount += amount;
        }

        public void DecreaseAmount(int amount) 
        {
            this.amount -= amount; 
        }

        public int GetAmount()
        {
            return this.amount;
        }

        public void AddFilling(Product filling)
        {
            //Add filling
            fillings.Add(filling.info);
        }

        public float Cost()
        {
            //Get the total cost of the product with all fillings
            float cost = info.price * amount;
            foreach (Base filling in fillings)
            {
                cost += filling.price * amount;
            }
            return cost;
        }

        public bool IsBagel()
        {
            if (info.key[0] == 'B')
            {
                return true;
            }
            return false;
        }
    }
}
