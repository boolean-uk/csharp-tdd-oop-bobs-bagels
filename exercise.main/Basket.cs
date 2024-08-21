using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.products;

namespace exercise.main
{
    public class Basket
    {

        private List<Product> basket;
        protected int basketMaxSize;
        public Basket() 
        { 
            this.basket = new List<Product>();
            this.basketMaxSize = 5;
        }

        public bool addItemToBascet(productType p)
        {
            if (basket.Count >= basketMaxSize)
            {
                return false;
            }
            else
            {

                if(p == (productType)0)
                {
                    Console.WriteLine($"Added {new Drink(p).Name} to basket, it costs: {new Drink(p).Cost} ");
                    basket.Add(new Drink(p));
                    return true;

                }
                else if(p == (productType)1)
                {
                    Console.WriteLine($"Added {new Bagle(p).Name} to basket, it costs: {new Bagle(p).Cost} ");
                    basket.Add(new Bagle(p));
                    return true;

                }
                else if (p == (productType)2)
                {
                    Console.WriteLine($"Added {new Fillings(p).Name} to basket, it costs: {new Fillings(p).Cost} ");
                    basket.Add(new Fillings(p));
                    return true;
                }

                return false;
                
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

        public bool removeItemFromBasket(Product p)
        {
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
    }
}
