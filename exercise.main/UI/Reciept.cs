using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Inventories;
using exercise.main.Products;

namespace exercise.main.UI
{
    public class Reciept
    {

        private List<Product> _boughtProducts;
        private readonly DateTime _date;

        public Reciept(List<Product> boughtProducts)
        {
            this._boughtProducts = boughtProducts;
            _date = DateTime.Now;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("~~~ Bob's Bagels ~~~");
            sb.AppendLine();
            sb.AppendLine(_date.ToString("yyyy-MM-dd HH:mm:ss"));
            sb.AppendLine();
            sb.AppendLine(new string('-', 28));

            // Add items
            var groupedProducts = _boughtProducts
            .GroupBy(product => product.Sku)
            .Select(g => new
            {
                Sku = g.Key,
                Variant = g.First().Variant,
                Count = g.Count(),
                TotalPrice = Inventory.Instance.GetPrice(g.First()) * g.Count()
            });

            var totalcost = 0d;

            foreach (var item in groupedProducts)
            {
                sb.AppendLine($"{item.Variant} Bagel   {item.Count}   £{item.TotalPrice:F2}");
                totalcost += item.TotalPrice;
            }

            // Add separator
            sb.AppendLine(new string('-', 28));

            // Add total
            sb.AppendLine($"Total                 £{totalcost}");
            sb.AppendLine();

            // Add footer
            sb.AppendLine("        Thank you");
            sb.AppendLine("      for your order!");

            return sb.ToString();
        }
    }
}
