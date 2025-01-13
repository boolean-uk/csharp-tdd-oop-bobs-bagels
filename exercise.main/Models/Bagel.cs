using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Models
{
    public class Bagel : Product
    {
        public List<Filling> Fillings { get; set; }
        public Bagel(string sku, string variant, decimal price)
        {
            SKU = sku;
            Variant = variant;
            Price = price;
            Fillings = new List<Filling>();
        }
        public Bagel(string sku)
        {
            SKU = sku;
            Variant = Inventory.inventory[sku].Variant;
            Price = Inventory.inventory[sku].Price;
            Fillings = new List<Filling>();
        }
        public void AddFilling(Filling filling)
        {
            Fillings.Add(filling);

        }

        public decimal GetTotalPrice()
        {
            return Price + Fillings.Sum(f => f.Price);
        }
    
        public override string ToString()
        {
            string result = $"{Variant} - ${Price}";
            if(Fillings.Count > 0)
            {
                foreach (var filling in Fillings)
                {
                    result += $"\n\t{filling.Variant} - ${filling.Price}\n";
                }
            }
            
            return result;
        }
    }


}
