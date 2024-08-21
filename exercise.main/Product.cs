﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Product
    {
        public Base info; //product information
        private int amount { get; set; } = 1;
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

        public int GetExcessBagelAmount()
        {
            //Get the amount of bagels left after the bagel discount has been applied
            return this.amount % 6;
        }

        public void AddFilling(Product filling)
        {
            //Add filling
            fillings.Add(filling.info);
        }

        public float Cost()
        {
            //Get the total cost of the product with all fillings
            float cost = info.price * (float)amount;

            foreach (Base filling in fillings)
            {
                cost += filling.price * (float)amount;
            }

            //Apply bagel discount
            if (IsBagel())
            {
                cost -= BagelDiscount();
            }

            return (float)Math.Round(cost, 2);
        }

        public float BagelDiscount()
        {
            float bagelDiscount = 0.0f;

            //Calculate the rest of modulus 12
            int rest = amount % 12;

            //Calculate how many 12 bagel discounts should be added
            int discounts12 = (int)Math.Floor((decimal)(amount / 12));

            //Add the number of 12 bagel discounts
            bagelDiscount += (float)discounts12 * 3.99f;

            //Check if a 6 discount should be added
            if (rest >= 6)
            {
                bagelDiscount += 2.49f;
                rest -= 6;
            }

            //Add the rest of the price
            bagelDiscount += info.price * (float)rest;

            //Price of fillings
            foreach (Base filling in fillings)
            {
                bagelDiscount += filling.price * (float)amount;
            }

            //Calculate the base price
            float basePrice = info.price * (float)amount;

            foreach (Base filling in fillings)
            {
                basePrice += filling.price * (float)amount;
            }

            return (float)Math.Round(Math.Abs(basePrice - bagelDiscount), 2);
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
