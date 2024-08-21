using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.products;

namespace exercise.main.Extensions
{
    public class Extension1
    {

        private List<Product> copyOfBasket;
        private float copyOfPrice;
        private Dictionary<string, int> productDiscount;
        private List<Product> permanentBasketCopy;

        public Extension1(List<Product> basket, float price)
        {
            productDiscount = new Dictionary<string, int>() { };

            copyOfBasket = basket;
            permanentBasketCopy = basket.ToList();

            copyOfPrice = (float)Math.Round(price, 2);
            CheckForBGLOdiscount();
        }


        public float ValidateDiscounts()
        {
            return copyOfPrice;
        }

        public Dictionary<string, int> GetRecieptDiscount()
        {
            return productDiscount;
        }

        private void CheckForBGLOdiscount()
        {
            foreach (Product product in permanentBasketCopy.Where(product => product is Bagle))
            {
                if (!productDiscount.ContainsKey(product.Name))
                {
                    productDiscount.Add(product.Name, 0);
                }
            }
            foreach (KeyValuePair<string, int> kvp in productDiscount)
            {
                int divisor = copyOfBasket.Count(p => p.Name == kvp.Key);

                if (divisor >= 12)
                {
                    int MaxDepth = 1;
                    float tempTestCost = 0f;
                    DcDiscount(kvp.Key, 12, MaxDepth, tempTestCost);
                    divisor = copyOfBasket.Count(p => p.Name == kvp.Key);
                    copyOfPrice = (float)Math.Round(copyOfPrice, 2);
                }
                if (divisor >= 6)
                {
                    int MaxDepth = 1;
                    float tempTestCost = 0f;
                    DcDiscount(kvp.Key, 6, MaxDepth, tempTestCost);
                    copyOfPrice = (float)Math.Round(copyOfPrice, 2);
                }
            }
            int discount = 0;
            CoffeDiscount(discount);
        }


        private void DcDiscount(string key, int i, int MaxDepth, float tempTestCost)
        {
            Product product = copyOfBasket.FirstOrDefault(p => p.Name == key);
            if (copyOfBasket.Remove(product))
            {
                tempTestCost += product.Cost;
                if (MaxDepth - i == 0)
                {
                    if (i == 12)
                    {
                        copyOfPrice -= tempTestCost;
                        tempTestCost = 0f;
                        copyOfPrice += (float)Math.Round(3.99f, 2);
                        productDiscount[key]++;
                    }
                    else if (i == 6)
                    {
                        copyOfPrice -= tempTestCost;
                        tempTestCost = 0f;
                        copyOfPrice += (float)Math.Round(2.49f, 2);
                        productDiscount[key]++;
                    }
                }
                else
                {
                    DcDiscount(product.Name, i, MaxDepth + 1, tempTestCost);
                }
            };
        }


        private void CoffeDiscount(int discount)
        {

            if (copyOfBasket.FirstOrDefault(p => p is Bagle) != null && copyOfBasket.FirstOrDefault(p => p is Drink) != null)
            {
                discount++;
                Product bagle = copyOfBasket.FirstOrDefault(p => p is Bagle)!;
          
                Product drink = copyOfBasket.FirstOrDefault(predicate => predicate is Drink)!;
                copyOfPrice -= bagle.Cost;
                copyOfPrice -= drink.Cost;
                copyOfBasket.Remove(drink);
                copyOfBasket.Remove(bagle);
                copyOfPrice += 1.25f;
                if (productDiscount.ContainsKey($"{drink.Name}"))
                {
                    productDiscount[$"{drink.Name}"]++;
                }
                else
                {
                    productDiscount.Add($"{drink.Name}", 1);
                }
                CoffeDiscount(discount);
            }
        }
    }
}
