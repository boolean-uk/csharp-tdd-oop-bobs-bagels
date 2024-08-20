using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Reciept
    {
        private DateTime _currentDate;
        private TimeSpan _currentTime;
        public void print(List<Tuple<string, string, float, int, bool>> purchase, Manager manager) //includes discounts
        {
            _currentDate = DateTime.Now;
            _currentTime = TimeSpan.Zero;
            _currentDate.Add(_currentTime);
            printTop();

            float[] costAndDiscount = printMid(purchase, manager);

            printBottom(costAndDiscount);
        }

        private void printTop()
        {
            Console.WriteLine($"~~~ Bob's Bagels ~~~\n\n{_currentDate}\n\n----------------------------\n\n");
        }

        private float[] printMid(List<Tuple<string, string, float, int, bool>> purchase, Manager manager)
        {
            float[] costAndDiscount = new float[2];
            float totalCost = 0f;
            float totalDiscounted = 0f;
            float actualDiscount = 0f;

            List<Product> products = manager.getMenu();
            List<Tuple<string, string, string, float>[]> productsListList = new List<Tuple<string, string, string, float>[]>();
            List<Tuple<string, string, string, float>> productsList = new List<Tuple<string, string, string, float>>();
            products.ForEach(p =>
            {
                productsListList.Add(p.getVariants());

            });

            foreach (var product in productsListList) {
                foreach (var item in product) {
                    productsList.Add(item);
                } 
            }


            purchase.ForEach(item => {
                Console.WriteLine($"{item.Item1}  {item.Item4}  {item.Item3}");
                totalCost += item.Item3;
                if(item.Item5) { totalDiscounted += item.Item3; }
                });

            
            purchase.ForEach(item =>
            {
                if (item.Item5)
                {
                    actualDiscount = ((float)item.Item4 * productsList.FirstOrDefault(product => product.Item1.Contains(item.Item1)).Item4) - item.Item3;
                }
            });
            //products.ForEach(product => {
            //    actualDiscount = product.price - 
            //totalDiscounted = (totalCost - (totalCost - ))

            //Console.WriteLine($"total cost {totalCost}\nactual discount {Math.Round(actualDiscount, 2)}");


            costAndDiscount[0] = totalCost;
            costAndDiscount[1] = actualDiscount;




            //return costAndDiscount[totalCost, 0f];
            return costAndDiscount;
            //List<Product> setOfItems = new List<Product> ();
            //setOfItems.Add(purchase.FirstOrDefault(x => x.SKU.Contains("BGL")));
            //setOfItems.Add(purchase.FirstOrDefault(x => x.SKU.Contains("COf")));
            //setOfItems.Add(purchase.FirstOrDefault(x => x.SKU.Contains("FIL")));
            //foreach (var item in setOfItems)
            
                //Console.WriteLine(($"{item.name}    {purchase.FindAll(product => product.SKU == item.SKU).Count}    {item.price * purchase.FindAll(product => product.SKU == item.SKU).Count}"));
                //setOfItems.ForEach(item => Console.WriteLine($"{item.name}    {purchase.FindAll(product => product.SKU == item.SKU).Count}    {item.price * purchase.FindAll(product => product.SKU == item.SKU).Count}"));
            
        }

        private void printBottom(float[] cost)
        {
            Console.WriteLine($"\r\n----------------------------\r\nTotal                 £{cost[0]}\r\n\r\n You saved a total of £{Math.Round(cost[1], 2)}\r\n       on this shop\r\n\r\n        Thank you\r\n      for your order!");
        }
    }
}
