using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket 
    {
        private List<Product> basketList = new List<Product>();
        private bool hasCoffeAndBagel = false;
        private bool hasCoffeAndBagelPlain = false;
        private int maxProducts = 40;
        public Basket() 
        {
        }

        public void AddProduct(string sku)
        {   
            if (basketList.Count >= maxProducts)
            {
                Console.WriteLine("Your basket is full!");
                return;
            }
            Product item;
            switch (sku)
            {
                case "BGLO":
                    item = new Bagel(0.49, "Onion");
                    basketList.Add(item);
                    break;

                case "BGLP":
                    item = new Bagel(0.39, "Plain");
                    basketList.Add(item);
                    break;

                case "BGLE":
                    item = new Bagel(0.49, "Everything");
                    basketList.Add(item);
                    break;

                case "BGLS":
                    item = new Bagel(0.49, "Sesame");
                    basketList.Add(item);
                    break;

                case "COFB":
                    item = new Coffe(0.99, "Black");
                    basketList.Add(item);
                    break;

                case "COFW":
                    item = new Coffe(1.19, "White");
                    basketList.Add(item);
                    break;

                case "COFC":
                    item = new Coffe(1.29, "Capuccino");
                    basketList.Add(item);
                    break;

                case "COFL":
                    item = new Coffe(1.29, "Latte");
                    basketList.Add(item);
                    break;

                case "FILB":
                    item = new Filling(0.12, "Bacon");
                    basketList.Add(item);
                    break;

                case "FILE":
                    item = new Filling(0.12, "Egg");
                    basketList.Add(item);
                    break;

                case "FILC":
                    item = new Filling(0.12, "Cheese");
                    basketList.Add(item);
                    break;

                case "FILX":
                    item = new Filling(0.12, "Cream Cheese");
                    basketList.Add(item);
                    break;

                case "FILS":
                    item = new Filling(0.12, "Smoked Salmon");
                    basketList.Add(item);
                    break;

                case "FILH":
                    item = new Filling(0.12, "Ham");
                    basketList.Add(item);
                    break;

                default:
                    Console.WriteLine(sku + " does not exist in our invetory.");
                    break;
            }
        }

        public bool RemoveProduct(string variant)
        {
            for (int i = 0; i < basketList.Count; i++)
            {
                if (basketList[i]._variant == variant)
                {
                    Console.WriteLine($"Removed one {variant} {basketList[i]._name}");
                    basketList.RemoveAt(i);
                    return true;
                }
            }
            Console.WriteLine("Product was not in your basket");
            return false;
        }

        public double TotalPrice()
        {
            double price = 0;
            foreach (Product product in basketList)
            {
                price += product.GetPrice();
            }

            return price;
        }

        public double DiscountedPrice()
        {
            double price = TotalPrice();
            hasCoffeAndBagel = false;
            hasCoffeAndBagelPlain = false;


            var countList = basketList.GroupBy(basketList => basketList._variant).Select(g => new
            {
                Variant = g.Key,
                variantCount = g.Count(),
                Price = g.First()._price,
                Name = g.First()._name

            }).ToList();

            countList.ForEach(x => { 
                if(6<= x.variantCount && x.variantCount < 12 && x.Name == "Bagel")
                {
                    price -= x.Price*6;
                    price += 2.49;
                } else if (x.variantCount >= 12 && x.Name == "Bagel")
                {  
                    price -= x.Price *12;
                    price += 3.99;
                }
            });

            var target = countList.FirstOrDefault(p => p.Name == "Bagel");

            if(countList.Any(p => p.Name == "Coffe") && target != null)
            {
                if(target.Variant == "Plain")
                    hasCoffeAndBagelPlain = true;
                else
                    hasCoffeAndBagel = true;

                price -= 0.99 + target.Price;
                price += 1.25;
            }

            
            


            return price;


        }

        public void PrintReceipt()
        {
            var result = basketList.GroupBy(x => x._variant).ToDictionary(y => y.Key, y => y.Count());
            var distinctBasketList = basketList.DistinctBy(x => x._variant).ToList();

            Console.WriteLine("    ~~~ Bob's Bagels ~~~");
            Console.WriteLine();
            Console.WriteLine($"    {DateTime.UtcNow.AddHours(1)}");
            Console.WriteLine();
            Console.WriteLine("----------------------------");
            Console.WriteLine();
            distinctBasketList.ForEach(p => Console.WriteLine(String.Format("{0,-16}{1,4} {2,7}", p._variant + " " + p._name, result.GetValueOrDefault(p._variant), "£"+p._price* result.GetValueOrDefault(p._variant))));
            Console.WriteLine();
            Console.WriteLine("----------------------------");
            Console.WriteLine($"Total                  £{(decimal)TotalPrice()}");
            Console.WriteLine();
            Console.WriteLine("        Thank you");
            Console.WriteLine("      for your order!\n");
        }

        public decimal getVarPrice(string variant)
        {
            //var test = DiscountedPrice();
            decimal variantPrice = 0;
            var countList = basketList.GroupBy(basketList => basketList._variant).Select(g => new
            {
                Variant = g.Key,
                variantCount = g.Count(),
                Price = g.First()._price,
                Name = g.First()._name

            }).ToList();

            var target = countList.FirstOrDefault(p => p.Variant == variant);

            if (target == null)
                return 0;

            variantPrice = target.variantCount * (decimal)target.Price;

            
                if (6 <= target.variantCount && target.variantCount < 12 && target.Name == "Bagel")
                {
                    variantPrice -= (decimal)target.Price * 6;
                    variantPrice += 2.49m;
                }
                else if (target.variantCount >= 12 && target.Name == "Bagel")
                {
                    variantPrice -= (decimal)target.Price * 12;
                    variantPrice += 3.99m;
                }

            if (target.Name == "Coffe" && hasCoffeAndBagel || hasCoffeAndBagelPlain)
            {
                if (hasCoffeAndBagel)
                {
                    variantPrice -= (decimal)target.Price;
                    variantPrice += 0.76m;
                }
                else if (hasCoffeAndBagelPlain)
                {
                    variantPrice -= (decimal)target.Price;
                    variantPrice += 0.86m;
                }
            }


            return variantPrice;

        }

        public void PrintReceiptDiscount()
        {
            var result = basketList.GroupBy(x => x._variant).ToDictionary(y => y.Key, y => y.Count());
            var distinctBasketList = basketList.DistinctBy(x => x._variant).ToList();
            decimal totalPrice = ((decimal)TotalPrice());
            decimal discountedPrice = ((decimal)DiscountedPrice());
            decimal diff = totalPrice - discountedPrice;
            

            Console.WriteLine("    ~~~ Bob's Bagels ~~~");
            Console.WriteLine();
            Console.WriteLine($"    {DateTime.UtcNow.AddHours(1)}");
            Console.WriteLine();
            Console.WriteLine("----------------------------");
            Console.WriteLine();
            distinctBasketList.ForEach(p => {
                Console.WriteLine(String.Format("{0,-16}{1,4} {2,7}", p._variant + " " + p._name, result.GetValueOrDefault(p._variant), "£" + getVarPrice(p._variant)));
                if(((decimal)(p._price * result.GetValueOrDefault(p._variant)) - getVarPrice(p._variant)) != 0)
                    Console.WriteLine($"                     (-£{((decimal)(p._price * result.GetValueOrDefault(p._variant)) - getVarPrice(p._variant))})");
            });
            Console.WriteLine("----------------------------");
            Console.WriteLine($"Total                  £{discountedPrice}");
            Console.WriteLine();
            Console.WriteLine($"You saved a total of £{diff}");
            Console.WriteLine($"       on this shop");
            Console.WriteLine();
            Console.WriteLine("        Thank you");
            Console.WriteLine("      for your order!\n");
        }

        public int MaxProducts  { set {  this.maxProducts = value; } }

        public List<Product> BasketList { get { return basketList; } }
    }
}
