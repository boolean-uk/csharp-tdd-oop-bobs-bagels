using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Extension1 {

        private List<Product> copyOfBasket;
        private float copyOfPrice;
        private Dictionary<string, int> productDiscount;

        public Extension1(List<Product> basket, float price) 
        {
            productDiscount = new Dictionary<string, int>() {
                {"Twelve",0 },
                {"Six", 0 },
                {"Coffe", 0 }
            };

            this.copyOfBasket = basket;
            this.copyOfPrice = (float)Math.Round((price), 2);
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
            int divisor = copyOfBasket.Count(p => p.IsBagle == true);
            while (divisor >= 12)
            {
                int disc = loop(12);
                copyOfPrice += (float)Math.Round((3.99f * disc), 2);
                copyOfPrice = (float)Math.Round(copyOfPrice, 2);
                divisor = copyOfBasket.Count(p => p.IsBagle == true);
                productDiscount["Twelve"] = disc;
            }
            while (divisor >= 6)
            {
                int disc = loop(6);
                copyOfPrice += (float)Math.Round((2.49f * disc), 2);
                copyOfPrice = (float)Math.Round(copyOfPrice, 2);
                divisor = copyOfBasket.Count(p => p.IsBagle == true);
                productDiscount["Six"] = disc;
            }
            coffeDiscount();

        }


        private int loop(int i)
        {
            int cnt = 0;
            int c = copyOfBasket.Count;
            float tempTestCost = 0f;

            for (int j = 0; j <= c; j++)
            {
                Product product = copyOfBasket.FirstOrDefault(p => p.IsBagle == true);
                if (product == null)
                {
                    break;
                }
                if (copyOfBasket.Remove(product)) {
                    tempTestCost += product.Cost;
                    cnt++;
                    if (cnt % i == 0) { 
                        copyOfPrice -= tempTestCost; 
                        tempTestCost = 0f;
                        if (copyOfBasket.Count(p => p.IsBagle == true)  < i)
                        {
                            break;
                        }
                    }            
                };
            }
            
            return (cnt/i) ;
        }

        private void coffeDiscount()
        {

            if ((copyOfBasket.FirstOrDefault(p => p.IsBagle == true) != null) && (copyOfBasket.FirstOrDefault(p => p.IsDrink == true) != null))
            {
                Product bagle = copyOfBasket.FirstOrDefault(p => p.IsBagle==true);
                Product drink = copyOfBasket.FirstOrDefault(predicate => predicate.IsDrink == true);
                copyOfPrice -= bagle.Cost;
                copyOfPrice -= drink.Cost;
                copyOfBasket.Remove(drink);
                copyOfBasket.Remove(bagle);
                copyOfPrice += 1.25f;
                productDiscount["Coffe"] += 1;
               coffeDiscount();
            }
        }
    }
}
