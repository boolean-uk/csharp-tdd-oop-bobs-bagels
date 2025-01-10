using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Classes.Products;
using exercise.main.Classes.Products.Bagels;

namespace exercise.main.Classes
{
    public class BagelBasket
    {
        public List<Bagel> Bagels { get; set; }
        public int Capacity { get; set; }

        public BagelBasket()
        {
            Bagels = new List<Bagel>();
            Capacity = 5;
        }

        public void AddBagel(string bagelType)
        {
            if (Bagels.Count >= Capacity)
            {
                Console.WriteLine("Basket is full!");
                return;
            }

            string btl = bagelType.ToLower();

            if (btl == "bglo" || btl == "onion")
            {
                Bagel bagel = new Bagel()
                {
                    Sku = "bglo",
                    Price = 0.49M,
                    Name = "bagel",
                    Variant = "onion"
                };
                Bagels.Add(bagel);
                Console.WriteLine("Added onion bagel!");
            }
            else if (btl == "bglp" || btl == "plain")
            {
                Bagel bagel = new Bagel()
                {
                    Sku = "bglp",
                    Price = 0.39M,
                    Name = "bagel",
                    Variant = "plain"
                };
                Bagels.Add(bagel);
                Console.WriteLine("Added plain bagel!");
            }
            else if (btl == "bgle" || btl == "everything")
            {
                Bagel bagel = new Bagel()
                {
                    Sku = "bgle",
                    Price = 0.49M,
                    Name = "bagel",
                    Variant = "everything"
                };
                Bagels.Add(bagel);
                Console.WriteLine("Added everything bagel!");
            }
            else if (btl == "bgls" || btl == "sesame")
            {
                Bagel bagel = new Bagel()
                {
                    Sku = "bgls",
                    Price = 0.49M,
                    Name = "bagel",
                    Variant = "sesame"
                };
                Bagels.Add(bagel);
                Console.WriteLine("Added sesame bagel!");
            }
            else
            {
                Console.WriteLine($"{bagelType} bagels is not available here!");
                return;
            }
        }

        public void RemoveBagel(string bagelType)
        {
            if (Bagels.Count <= 0)
            {
                Console.WriteLine("No bagels to remove!");
                return;
            }

            string btl = bagelType.ToLower();

            if (btl.Length == 4)
            {
                var foundBagel = Bagels.FirstOrDefault(b => b.Sku == btl);
                if (foundBagel != null)
                {
                    Console.WriteLine($"Bagel with SKU {btl} removed!");
                    Bagels.Remove(foundBagel); 
                }
                else
                {
                    Console.WriteLine($"No bagels with SKU {btl} in basket!");
                }
            }
            else
            {
                var foundBagel = Bagels.FirstOrDefault(b => b.Variant == btl);
                if (foundBagel != null)
                {
                    Console.WriteLine($"{btl} bagel removed!");
                    Bagels.Remove(foundBagel);
                }
                else
                {
                    Console.WriteLine($"No {btl} bagels in your basket!");
                }
            }
        }

        public void Clear()
        {
            Console.WriteLine($"Cleared {Bagels.Count} bagels from basket!");
            Bagels.Clear(); 
        }

        public decimal TotalCost()
        {
            decimal totalCost = Bagels.Sum(b => b.Price);
            Console.WriteLine($"Total cost of bagels: " + totalCost);
            return totalCost;
        }

        public bool IsFull()
        {   
            Console.WriteLine("Basket it full!");
            return Bagels.Count >= Capacity;
        }

        public List<Bagel> GetBagels() {  return Bagels; }

        public void ChangeCapacity(int newCapacity) {  Capacity = newCapacity; }
    }
}
