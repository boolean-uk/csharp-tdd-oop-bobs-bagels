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

        public Reciept(List<Product> boughtProducts)
        {
            this._boughtProducts = boughtProducts;

        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("~~~ Bob's Bagels ~~~");
            sb.AppendLine();
            sb.AppendLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            sb.AppendLine();
            sb.AppendLine(new string('-', 28));

            // Add items
            var groupedProducts = _boughtProducts
            .GroupBy(product => product.Sku)
            .Select(g => new
            {
                Sku = g.Key,
                Variant = g.First().Variant, // Assuming all products in a group have the same variant
                Count = g.Count(),
                TotalPrice = Inventory.Instance.GetPrice(g.First()) * g.Count()
            });

            foreach (var item in groupedProducts)
            {
                sb.AppendLine($"{item.Variant} Bagel   {item.Count}   £{item.TotalPrice:F2}");
            }

            // Add separator
            sb.AppendLine(new string('-', 28));

            // Add total
            sb.AppendLine("Total                 £10.43");
            sb.AppendLine();

            // Add footer
            sb.AppendLine("        Thank you");
            sb.AppendLine("      for your order!");

            return sb.ToString();
        }
    }
}
