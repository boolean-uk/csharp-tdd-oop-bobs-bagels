using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            Console.WriteLine("\n    ~~~ Bob's Bagels ~~~\n\n    {0, 15}", _currentDate);
            Console.WriteLine("\n----------------------------\n");
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

            foreach (var product in productsListList)
            {
                foreach (var item in product)
                {
                    productsList.Add(item);
                }
            }


            purchase.ForEach(item =>
            {
                if (item.Item5)
                {
                    Console.WriteLine("      {0,-6} {1,-3} {2, -10}", item.Item1, item.Item4, item.Item3);
                    totalCost += item.Item3;
                    totalDiscounted += item.Item3;
                }
                else
                {
                    totalCost += item.Item3 * (float)item.Item4;

                    Console.WriteLine("      {0,-6} {1,-3} {2, -10}", item.Item1, item.Item4, item.Item3 * (float)item.Item4);



                }
            });


            purchase.ForEach(item =>
            {
                if (item.Item5)
                {
                    actualDiscount = ((float)item.Item4 * productsList.FirstOrDefault(product => product.Item1.Contains(item.Item1)).Item4) - item.Item3;
                }
            });

            costAndDiscount[0] = (float)Math.Round(totalCost, 2);
            costAndDiscount[1] = (float)Math.Round(actualDiscount, 2);

            return costAndDiscount;
        }

        private void printBottom(float[] cost)
        {
            Console.WriteLine($"\r\n----------------------------\r\nTotal                 £{cost[0]}\r\n\r\n You saved a total of £{Math.Round(cost[1], 2)}\r\n       on this shop\r\n\r\n        Thank you\r\n      for your order!\n\n");
        }

        //public string PrintMidSection
        //{
        //    get {
        //        //return String.Format("{0,-10} - {1,-10}, {2, 10} - {3,5}"), );
        //    }
        //}
    }
}
