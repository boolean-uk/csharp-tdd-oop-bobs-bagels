using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Classes.Products
{
    public class Bagel : Product
    {

        private List<Filling> Fillings;

        public Bagel()
        {
            Fillings = new List<Filling>();
        }

        public void AddFilling(string fillingType)
        {
            if (fillingType == null)
            {
                Console.WriteLine("No fillings of that type exist!");
                return;
            }

            string ftl = fillingType.ToLower().Replace(" ", "");

            if (ftl == "filb" || ftl == "bacon")
            {
                Filling filling = new Filling()
                {
                    Sku = "filb",
                    Price = 0.12M,
                    Name = "filling",
                    Variant = "bacon"
                };
                Fillings.Add(filling);
                Console.WriteLine("Added bacon on bagel!");
            }
            else if (ftl == "file" || ftl == "egg")
            {
                Filling filling = new Filling()
                {
                    Sku = "file",
                    Price = 0.12M,
                    Name = "filling",
                    Variant = "egg"
                };
                Fillings.Add(filling);
                Console.WriteLine("Added egg on bagel!");
            }
            else if (ftl == "filc" || ftl == "cheese")
            {
                Filling filling = new Filling()
                {
                    Sku = "filc",
                    Price = 0.12M,
                    Name = "filling",
                    Variant = "cheese"
                };
                Fillings.Add(filling);
                Console.WriteLine("Added cheese on bagel!");
            }
            else if (ftl == "filx" || ftl == "creamcheese")
            {
                Filling filling = new Filling()
                {
                    Sku = "filx",
                    Price = 0.12M,
                    Name = "filling",
                    Variant = "creamcheese"
                };
                Fillings.Add(filling);
                Console.WriteLine("Added cream cheese on bagel!");
            }
            else if (ftl == "fils" || ftl == "smokedsalmon")
            {
                Filling filling = new Filling()
                {
                    Sku = "fils",
                    Price = 0.12M,
                    Name = "filling",
                    Variant = "smokedsalmon"
                };
                Fillings.Add(filling);
                Console.WriteLine("Added smoked salmon on bagel!");
            }
            else if (ftl == "filh" || ftl == "ham")
            {
                Filling filling = new Filling()
                {
                    Sku = "filh",
                    Price = 0.12M,
                    Name = "filling",
                    Variant = "ham"
                };
                Fillings.Add(filling);
                Console.WriteLine("Added ham on bagel!");
            }
            else
            {
                Console.WriteLine("That filling is not available here!");
            }
        }

        public void RemoveFilling(string fillingType)
        {
            if (Fillings.Count <= 0)
            {
                Console.WriteLine("No fillings to remove!");
                return;
            }

            string ftl = fillingType.ToLower().Replace(" ", "");

            if (ftl.Length == 4)
            {
                var foundFilling = Fillings.FirstOrDefault(f => f.Sku == ftl);
                if (foundFilling != null)
                {
                    Console.WriteLine($"Filling with SKU {ftl} removed!");
                    Fillings.Remove(foundFilling);
                }
                else
                {
                    Console.WriteLine($"No filling with SKU {ftl} on your bagel!");
                }
            }
            else
            {
                var foundFilling = Fillings.FirstOrDefault(f => f.Variant == ftl);
                if (foundFilling != null)
                {
                    Console.WriteLine($"{ftl} filling removed!");
                    Fillings.Remove(foundFilling);
                }
                else
                {
                    Console.WriteLine($"There is no {ftl} filling on your bagel!");
                }
            }
        }
        public decimal FillingCost()
        {
            decimal totalCost = Fillings.Sum(f => f.Price);
            return totalCost;
        }

        public void DisplayFillingCost()
        {
            Console.WriteLine($"Total cost of {Fillings.Count} fillings is {FillingCost()}!");
        }

        public List<Filling> GetFillings() { return Fillings; }

        public string FillingVariantsToString()
        {
            List<string> fillingVariants = new List<string>();

            foreach ( var ftl in Fillings)
            {
                fillingVariants.Add(ftl.Variant);
            }

            string fillingVariantsString = string.Join(",", fillingVariants);

            return fillingVariantsString;
        }

        public void DisplayBagel()
        {
            Console.WriteLine($"\n-\nType: {Variant} bagel\nBagel price: {Price}\nFillings: {FillingVariantsToString()}\nFillings price: {FillingCost()}\nTotal cost: {Price + FillingCost()}\n-\n");
        }
    }
}
