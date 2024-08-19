﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Manager : Person
    {
        private int _currentBasketCapacityInStore;
        private Product _bagel;
        private Product _coffee;
        private Product _filling;

        public Manager(string firstName, string lastName)
            :base(firstName, lastName)
        { 
            _currentBasketCapacityInStore = 3;
            _bagel = new Bagel(getBagelMenu());
            _coffee = new Coffee(getCoffeeMenu());
            _filling = new Filling(getFillingMenu());
        }

        public void changeBasketCapacity(int newBasketCapacity)
        {
            _currentBasketCapacityInStore = newBasketCapacity;
        }

        public int getCurrentBasketSize() { return _currentBasketCapacityInStore;}

        public Product getProductReference(string SKU)
        {
            Product product = null;
            if (SKU.Contains("BGL"))
            {
                return product = new Bagel(_bagel.getVariants().FirstOrDefault(item => item.Item1 == SKU));
            }
            else if (SKU.Contains("COF"))
            {
                return product = new Bagel(_coffee.getVariants().FirstOrDefault(item => item.Item1 == SKU));
            }
            else if (SKU.Contains("FIL"))
            {
                return product = new Bagel(_filling.getVariants().FirstOrDefault(item => item.Item1 == SKU));
            }
            return null;
        }


        public bool getProduct(string SKU, Customer customer) {
            //Tuple<string, string, string, float> bagel = _bagel.getVariants().FirstOrDefault(item => item.Item1 == SKU);
            
            Product product = null;
            if (SKU.Contains("BGL"))
            {
                product = new Bagel(_bagel.getVariants().FirstOrDefault(item => item.Item1 == SKU));
                bool productAdded = customer.recieveProductInBasket(product);
                if (!productAdded) { basketOverflowWarning(); }
                return productAdded;
            } else if (SKU.Contains("COF")) 
            {
                product = new Bagel(_coffee.getVariants().FirstOrDefault(item => item.Item1 == SKU));
                bool productAdded = customer.recieveProductInBasket(product);
                if (!productAdded) { basketOverflowWarning(); }
                return productAdded;
            }
            else if (SKU.Contains("FIL"))
            {
                product = new Bagel(_filling.getVariants().FirstOrDefault(item => item.Item1 == SKU));
                bool productAdded = customer.recieveProductInBasket(product);
                if (!productAdded) { basketOverflowWarning(); }
                return productAdded;
            }
            return false;
        }

        private Tuple<string, string, string, float>[] getBagelMenu()
        {
            Tuple<string, string, string, float>[] variants =
{
            Tuple.Create("BGLO", "Bagel", "Onion", 0.49f),
            Tuple.Create("BGLP", "Bagel", "Plain", 0.39f),
            Tuple.Create("BGLE", "Bagel", "Everything", 0.49f),
            Tuple.Create("BGLS", "Bagel", "Sesame", 0.49f),
        };
            return variants;
        }

        private Tuple<string, string, string, float>[] getFillingMenu()
        {
            Tuple<string, string, string, float>[] variants =
{
            Tuple.Create("FILB", "Filling", "Bacon", 0.12f),
            Tuple.Create("FILE", "Filling", "Egg", 0.12f),
            Tuple.Create("FILC", "Filling", "Cheese", 0.12f),
            Tuple.Create("FILX", "Filling", "Cream Cheese", 0.12f),
            Tuple.Create("FILS", "Filling", "Smoked Salmon", 0.12f),
            Tuple.Create("FILH", "Filling", "Ham", 0.12f),
        };
            return variants;
        }

        private Tuple<string, string, string, float>[] getCoffeeMenu()
        {
            Tuple<string, string, string, float>[] variants =
{
            Tuple.Create("COFB", "Coffee", "Black", 0.99f),
            Tuple.Create("COFW", "Coffee", "White", 1.19f),
            Tuple.Create("COFC", "Coffee", "Capuccino", 1.29f),
            Tuple.Create("COFL", "Coffee", "Latte", 1.29f),
        };
            return variants;
        }

        public void basketOverflowWarning() { Console.WriteLine("I am sorry but you basket is full. I cannot add anymore to it!"); }


    }
}
