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
        private List<Base> fillings = new List<Base>(); //product fillings

        public Product(Base info) 
        {
            this.info = info;
        }

        public void AddFilling(Product filling)
        {
            //Add filling
            fillings.Add(filling.info);
        }

        public float Cost()
        {
            //Get the total cost of the product with all fillings
            float cost = info.price;
            foreach (Base filling in fillings)
            {
                cost += filling.price;
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
