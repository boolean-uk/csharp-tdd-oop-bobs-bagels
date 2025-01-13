using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Models
{
    public static class Inventory
    {
        public static Dictionary<string, Product> inventory = new Dictionary<string, Product>
            {
                {"BGLO", new Bagel("BGLO", "Onion Bagel", 0.49M)},
                {"BGLP", new Bagel("BGLP", "Plain Bagel", 0.39M)},
                {"BGLE", new Bagel("BGLE", "Everything Bagel", 0.49M)},
                {"BGLS", new Bagel("BGLS", "Sesame", 0.49M)},
                {"COFB", new Coffee("COFB", "Black Coffee", 0.99M)},
                {"COFW", new Coffee("COFW", "White Coffee", 1.19M)},
                {"COFC", new Coffee("COFC", "Capuccino", 1.29M)},
                {"COFL", new Coffee("COFL", "Latte", 1.29M)},
                {"FILB", new Filling("FILB", "Bacon", 0.12M)},
                {"FILE", new Filling("FILE", "Egg", 0.12M)},
                {"FILC", new Filling("FILC", "Cheese", 0.12M)},
                {"FILX", new Filling("FILX", "Cream Cheese", 0.12M)},
                {"FILS", new Filling("FILS", "Smoked Salmon", 0.12M)},
                {"FILH", new Filling("FILH", "Ham", 0.12M)},
            };

        public static List<Product> GetProducts()
        {
            return inventory.Values.ToList();
        }

        public static List<Filling> GetFillings()
        {
            return inventory.Values.Where(p => p is Filling).Cast<Filling>().ToList();
        }

        public static List<Product> GetStandaloneProducts()
        {
            return inventory.Values.Where(p => !(p is Filling)).ToList();
        }
    }
}
