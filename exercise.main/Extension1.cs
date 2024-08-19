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
            Console.WriteLine("basket const" + copyOfPrice);

            copyOfPrice = CheckForBGLOdiscount();
        }

    
        public float ValidateDiscounts()
        {
            return copyOfPrice;        
        }

        private float CheckForBGLOdiscount() 
        {
            int disc = loop(6);
            Console.WriteLine("Mod : " + disc % 12);
            copyOfPrice -= (float)Math.Round((disc * 6 * 0.49f), 2);
            copyOfPrice += (float)Math.Round((2.49f * disc), 2);
            return (float)Math.Round(copyOfPrice, 2);
        }


        private int loop(int i)
        {
            int cnt = 0;
            int c = copyOfBasket.Count;

            for (int j = 0; j <= c; j++)
            {
                Product product = GetProductFromBasket();
                if (product == null)
                {
                    break;
                }
                if (copyOfBasket.Remove(product)) { 
                    cnt++;
                };
            }
            return (cnt/i) ;
        }

        private Product GetProductFromBasket()
        {
            return copyOfBasket.FirstOrDefault(new Bagle(bagleType.BGLO));
        }
    }
}
