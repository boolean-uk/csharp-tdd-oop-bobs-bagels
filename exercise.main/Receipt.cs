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
        private double total;
        private double discount;
        
        public Receipt(Basket basket)
        {
            this._basket = basket;
            total = Math.Round(this._basket.CheckBasketCostDiscounted(),2);
            discount = Math.Round(this._basket.CheckBasketCost() - this._basket.CheckBasketCostDiscounted(), 2);
        }

        public void PrintReceipt()
        {
            Console.WriteLine("    ~~~ Bob's Bagels ~~~\r\n");
            Console.WriteLine("   " + DateTime.Now.ToString() + "\r\n");
            Console.WriteLine("----------------------------\r\n");

            List<Item> basketBagels = this._basket.Items.Where(i => i.GetType() == typeof(Bagel)).ToList();
            List<Bagel> bagels = new List<Bagel>();

            var groupedBagels = this._basket.Items
                .GroupBy(b => b.Sku)
                .Select(group =>
                {

                    double price = 0;
                    foreach(Item b in group)
                    {
                        price += b.Price;
                    }

                    List<Filling> fillings = group.OfType<Bagel>().SelectMany(x => x.Fillings).ToList();
                    var groupedFillings = fillings
                        .GroupBy(f => f.Variant)
                        .Select(group =>
                        {
                            double fillingsPrice = 0;
                            foreach(Filling filling in group)
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

            foreach(var b in groupedBagels)
            {
                Console.WriteLine("{0,-18} {1,-1} {2,-10}", $"{b.Name} ", b.Quantity, $"£{b.Price}");
                foreach(var f in b.Fillings)
                {
                    Console.WriteLine("{0,-18} {1,-1} {2,-10}", $" - {f.Name}", f.Quantity , $"£{f.Price}");

                }
            }

            Console.WriteLine("----------------------------\r");
            Console.WriteLine("{0,-18} {1,-1:C} {2,-10}", $"Total price", "", $"£{total}");
            if(discount > 0)
            {
                Console.WriteLine("{0,-16} {1,-1:C} {2,-10}", $"", "", $"(-£{Math.Round(this._basket.CheckBasketCost() - total, 2)})\n");

                Console.WriteLine($" You saved a total of £{discount}");
                Console.WriteLine("        on this shop\r\n");
            } else
            {
                Console.WriteLine("");
            }

            Console.WriteLine("        Thank you\r");
            Console.WriteLine("      for your order!\r\n");
            
        }
    }
}
