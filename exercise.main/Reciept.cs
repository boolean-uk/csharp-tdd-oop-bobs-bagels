using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Reciept
    {
        private List<Product> _order = new();
        private decimal _total;

        public Reciept(Basket basket) 
        {
            _order = basket.Products;
            _total = basket.Total;
        }

        public Dictionary<Product, int> MakeQuantities()
        {
            Dictionary<Product, int> itemMapping = new Dictionary<Product, int>();
            var groupingAmounts = Order.GroupBy(i => i.SKU);
            foreach (var item in groupingAmounts)
            {
                itemMapping.Add((Product)item.ElementAt(0), item.Count());
            }
            return itemMapping;
        }

        public void PrintReciept()
        {
            Console.WriteLine($"         ~~ Bob's Bagels ~~");
            Console.WriteLine();
            Console.WriteLine($"         {DateTime.Now.ToShortTimeString()}");
            Console.WriteLine();
            Console.WriteLine("{0,10}    {1,10}    {2,10} ", "Product", "Qty", "Price");

            var itemMapping = MakeQuantities();
            foreach (var item in itemMapping) 
            {
                Console.WriteLine("{0,10}    {1,10}    {2,10}   {3, 10}",
                    item.Key.Type,
                    item.Key.Variant,
                    item.Value,
                    $"{item.Key.Price * item.Value}"
                    );
            }
            Console.Write($"    Total                   {Total}");
        }

        public List<Product> Order {  get { return _order; } set { _order = value; } }
        public decimal Total { get { return _total; } set { _total = value; } }


    }
}
