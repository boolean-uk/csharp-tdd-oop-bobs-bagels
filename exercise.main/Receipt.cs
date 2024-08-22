using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Receipt
    {
        private Basket _basket;
        private double _total;
        private double _discount;
        
        public Receipt(Basket basket)
        {
            this._basket = basket;
            this._total = Math.Round(this._basket.CheckBasketCostDiscounted(),2);
            this._discount = Math.Round(this._basket.CheckBasketCost() - this._basket.CheckBasketCostDiscounted(), 2);
        }

        public string GenerateReceipt()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("    ~~~ Bob's Bagels ~~~\r\n");
            sb.AppendLine("   " + DateTime.Now.ToString() + "\r\n");
            sb.AppendLine("----------------------------\r\n");

            var groupedBagels = this._basket.Items
                .GroupBy(b => b.Sku)
                .Select(group =>
                {

                    double price = 0;
                    foreach (Item b in group)
                    {
                        price += b.Price;
                    }

                    List<Filling> fillings = group.OfType<Bagel>().SelectMany(x => x.Fillings).ToList();
                    var groupedFillings = fillings
                        .GroupBy(f => f.Variant)
                        .Select(group =>
                        {
                            double fillingsPrice = 0;
                            foreach (Filling filling in group)
                            {
                                fillingsPrice += filling.Price;
                            }
                            return new
                            {
                                Price = fillingsPrice,
                                Name = group.Key,
                                Quantity = group.Count()
                            };
                        });

                    return new
                    {
                        Name = $"{group.First().Variant} {group.First().Name}",
                        Fillings = groupedFillings,
                        Quantity = group.Count(),
                        Price = Math.Round(price, 2),
                    };

                });

            foreach (var b in groupedBagels)
            {
                sb.AppendFormat("{0,-18} {1,-1} {2,-10}", $"{b.Name} ", b.Quantity, $"£{b.Price}");
                sb.AppendLine();
                foreach (var f in b.Fillings)
                {
                    sb.AppendFormat("{0,-18} {1,-1} {2,-10}", $" - {f.Name}", f.Quantity, $"£{f.Price}");
                    sb.AppendLine();
                }
            }

            sb.AppendLine("----------------------------\r");
            sb.AppendFormat("{0,-18} {1,-1:C} {2,-10}", $"Total price", "", $"£{_total}");
            sb.AppendLine();
            if (_discount > 0)
            {
                sb.AppendFormat("{0,-16} {1,-1:C} {2,-10}", $"", "", $"(-£{Math.Round(this._basket.CheckBasketCost() - _total, 2)})\n");
                sb.AppendLine();

                sb.AppendLine($" You saved a total of £{_discount}");
                sb.AppendLine("        on this order\r\n");
            }
            else
            {
                sb.AppendLine("");
            }

            sb.AppendLine("        Thank you\r");
            sb.AppendLine("for shopping at Bobs Bagels!\r\n");
            return sb.ToString();
        }
        
        public void PrintReceipt()
        {
            Console.WriteLine(GenerateReceipt());
        }

        public void SendReceipt()
        {
            NotificationSender.SendReceipt(GenerateReceipt());
        }
    }
}
