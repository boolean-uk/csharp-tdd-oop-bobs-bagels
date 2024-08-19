using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Customer 
    {
        private List<Product> basket;
        protected int basketMaxSize;
        private string name;

        public Customer(string name)
        {
            this.basket = new List<Product>();
            this.basketMaxSize = 5;
            this.name = name;
        }

        public bool addItemToBascet(drinkType p)
        {
            if (basket.Count >= basketMaxSize)
            {
                return false;
            }
            else 
            {
                Console.WriteLine($"Added {new Drink(p).Name} to basket, it costs: {new Drink(p).Cost} ");
                basket.Add(new Drink(p));
                return true;
            }
        }
        public bool addItemToBascet(fillingType p)
        {
            if (basket.Count >= basketMaxSize)
            {
                return false;
            }
            else
            {
                Console.WriteLine($"Added {new Fillings(p).Name} to basket, it costs: {new Fillings(p).Cost} ");
                basket.Add(new Fillings(p));
                return true;
            }
        }
        public bool addItemToBascet(bagleType p)
        {
            if (basket.Count >= basketMaxSize)
            {
                return false;
            }
            else
            {
                Console.WriteLine($"Added {new Bagle(p).Name} to basket, it costs: {new Bagle(p).Cost} ");
                basket.Add(new Bagle(p));
                return true;
            }
        }


        public bool addItemToBascet(Product p)
        {
            if (basket.Count >= basketMaxSize)
            {
                return false;
            }
            else
            {
                Console.WriteLine($"Added {p.Name} to basket, it costs: {p.Cost} ");
                basket.Add(p);
                return true;
            }
        }

        public bool removeItemFromBasket(Product p) {
            return basket.Remove(p);
        }

        public List<Product> GetBasket() { return basket; }

        public int GetBasketMaxSize() { return basketMaxSize; }
        public void SetBasketMaxSize(int basketMaxSize) { this.basketMaxSize = basketMaxSize; }

        public float GetCost()
        {
            float cost = 0f;
            foreach (Product p in basket)
            {
                cost += p.Cost;
            }

            return cost;
        }

        public float ImplementDiscount()
        {
            Extension1 discount = new Extension1(basket, GetCost());
            return discount.ValidateDiscounts();
        }

    }
}
