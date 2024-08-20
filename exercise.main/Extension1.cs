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

        public Extension1(List<Product> basket, float price) { 

            this.copyOfBasket = basket;
            this.copyOfPrice = (float)Math.Round((price), 2);
            CheckForBGLOdiscount();
        }

    
        public float ValidateDiscounts()
        {
            return copyOfPrice;        
        }

        private void CheckForBGLOdiscount() 
        {
            int divisor = copyOfBasket.Count(p => p.IsBagle == true);
            while (divisor >= 12)
            {

                int disc = loop(12);
                copyOfPrice += (float)Math.Round((3.99f * disc), 2);
                copyOfPrice = (float)Math.Round(copyOfPrice, 2);
                Console.WriteLine("Price 12 : " + copyOfPrice);
                divisor = copyOfBasket.Count(p => p.IsBagle == true);
            }
            while (divisor >= 6)
            {
                int disc = loop(6);

                //copyOfPrice -= (float)Math.Round((disc * 6 * 0.49f), 2);
                copyOfPrice += (float)Math.Round((2.49f * disc), 2);
                copyOfPrice = (float)Math.Round(copyOfPrice, 2);
                Console.WriteLine("Price 6 : " + copyOfPrice);
                divisor = copyOfBasket.Count(p => p.IsBagle == true);
            }

        }


        private int loop(int i)
        {
            int cnt = 0;
            int c = copyOfBasket.Count;
            float tempTestCost = 0f;

            for (int j = 0; j <= c; j++)
            {
                Product product = GetProductFromBasket();
                if (product == null)
                {
                    break;
                }
                if (copyOfBasket.Remove(product)) {
                    tempTestCost += product.Cost;

                   
                    cnt++;
                    Console.WriteLine($"Cnt: {cnt} i {i}  Mod: {cnt % i}");
                    if (cnt % i == 0) { 
                        copyOfPrice -= tempTestCost; 
                        if (copyOfBasket.Count(p => p.IsBagle == true)  < 12)
                        {
                            break;
                        }
                    }            
                };
            }
            
            return (cnt/i) ;
        }

        private Product GetProductFromBasket()
        {
            return copyOfBasket.FirstOrDefault(p => p.IsBagle == true);
        }
    }
}
