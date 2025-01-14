using exercise.main.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Inventory
    {
        public List<IProduct> items { get; private set; }
        public Inventory()
        {
            items = new List<IProduct>
            {
                new Bagel("BGLO", 0.49, "Bagel", "Onion"),
                new Bagel("BGLP", 0.39, "Bagel", "Plain"),
                new Bagel("BGLE", 0.49, "Bagel", "Everything"),
                new Bagel("BGLS", 0.49, "Bagel", "Sesame"),
                new Coffee("COFB", 0.99, "Coffee", "Black"),
                new Coffee("COFW", 1.19, "Coffee", "White"),
                new Coffee("COFC", 1.29, "Coffee", "Capuccino"),
                new Coffee("COFL", 1.29, "Coffee", "Latte"),
                new Filling("FILB", 0.12, "Filling", "Bacon"),
                new Filling("FILE", 0.12, "Filling", "Egg"),
                new Filling("FILC", 0.12, "Filling", "Cheese"),
                new Filling("FILX", 0.12, "Filling", "Cream Cheese"),
                new Filling("FILS", 0.12, "Filling", "Smoked Salmon"),
                new Filling("FILH", 0.12, "Filling", "Ham")
            };
        }

        public IProduct? GetItem(string sku)
        {
            return items.FirstOrDefault(x => x.Sku == sku);
        }

        public List<IProduct> GetFillings()
        {
            return items.FindAll(item => item.Type == "Filling");
        }

        public bool ValidateItem(IProduct item)
        {
            IProduct? validItem = GetItem(item.Sku);

            if (validItem == null)
            {
                return false;
            }

            return true;
        }

    }
}
