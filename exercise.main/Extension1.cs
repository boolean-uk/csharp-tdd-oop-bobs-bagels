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
            copyOfPrice = CheckForBGLEdiscount();
        }

    
        public float ValidateDiscounts()
        {
            return copyOfPrice;        
        }

        private float CheckForBGLOdiscount() 
        {
            int disc = loop(6, productType.BGLO);
            copyOfPrice -= (float)Math.Round((disc * 6 * 0.49f), 2);
            copyOfPrice += (float)Math.Round((2.49f * disc), 2);
            return (float)Math.Round(copyOfPrice, 2);
        }

        private float CheckForBGLEdiscount()
        {
            int disc = loop(6, productType.BGLE);
            copyOfPrice -= (float) Math.Round((disc * 6 * 0.49f), 2);
            copyOfPrice += (float)Math.Round((2.49f * disc), 2);
            return (float)Math.Round(copyOfPrice, 2);
        }

        private int loop(int i, productType productType)
        {
            int cnt = 0;
            int c = copyOfBasket.Count;

            for (int j = 0; j <= c; j++)
            {
                Product product = GetProductFromBasket(productType);
                if (product == null)
                {
                    break;
                }
                if (copyOfBasket.Remove(product)) { 
                    cnt++;
                    Console.WriteLine($"Removed from basket {productType}  cnt: {cnt}");
                };
            }
            return (cnt/i) ;
        }

        private Product GetProductFromBasket(productType p)
        {
            return copyOfBasket.FirstOrDefault(Product => Product.Type == p);
        }
    }
}
