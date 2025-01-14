using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Classes.Products
{
    public class Bagel : Product
    {
        private List<Filling> fillings = new List<Filling>();

        public Bagel() {}

        public void AddFilling(string sku, Inventory inventory)
        {
            Product? product = inventory.GetProduct(sku.ToUpper());
            if (product != null)
            {
                Console.WriteLine($"{product.Variant} {product.Name} added to bagel!");
                fillings.Add((Filling) product);
            }
            else
            {
                Console.WriteLine($"Filling not found!");
            }
        }

        public void RemoveFilling(string sku)
        {
            Filling? filling = GetFilling(sku.ToUpper());
            if (filling == null)
            {
                Console.WriteLine($"Filling not found in bagel!");
            }
            else
            {
                Console.WriteLine($"{filling.Variant} {filling.Name} removed from bagel!");
                fillings.Remove(filling);
            }
        }

        public Filling? GetFilling(string sku)
        {
            Filling? foundFilling = null;
            fillings.ForEach(filling => { if (filling.Sku == sku) { foundFilling = filling; } });
            return foundFilling;
        }

        public decimal TotalFillingCost()
        {
            decimal totalCost = fillings.Sum(f => f.Price);
            return totalCost;
        }

        public void DisplayTotalFillingCost()
        {
            Console.WriteLine($"Total cost of {fillings.Count} fillings is {TotalFillingCost()}!");
        }

        public List<Filling> GetFillings() { return fillings; }

        public string FillingVariantsToString()
        {
            List<string> fillingVariants = new List<string>();

            foreach ( var ftl in fillings)
            {
                fillingVariants.Add(ftl.Variant);
            }

            string fillingVariantsString = string.Join(",", fillingVariants);

            return fillingVariantsString;
        }

        public void DisplayBagel()
        {
            Console.WriteLine($"\n-\nType: {Variant} bagel\nBagel price: {Price}\nFillings: {FillingVariantsToString()}\nFillings price: {TotalFillingCost()}\nTotal cost: {Price + TotalFillingCost()}\n-\n");
        }
    }
}
