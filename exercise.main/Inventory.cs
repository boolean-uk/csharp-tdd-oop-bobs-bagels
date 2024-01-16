using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    internal class Inventory
    {
        private Dictionary<string, Item> bagels = new Dictionary<string, Item> {
            {"BGLO", new Item("BGLO", "Bagel", 0.49F, "Onion", null) },
            {"BGLP", new Item("BGLP", "Bagel", 0.39F, "Plain", null) },
            {"BGLE", new Item("BGLE", "Bagel", 0.49F, "Everything", null) },
            {"BGLS", new Item("BGLS", "Bagel", 0.49F, "Sesame", null) }
        };

        private Dictionary<string, Item> coffees = new Dictionary<string, Item>
        {
            {"COFB", new Item("COFB", "Coffee", 0.99F, "Black", null) },
            {"COFW", new Item("COFW", "Coffee", 1.19F, "White", null) },
            {"COFC", new Item("COFC", "Coffee", 1.29F, "Cappucino", null) },
            {"COFL", new Item("COFL", "Coffee", 1.29F, "Latte", null) }
        };
        private Dictionary<string, Item> fillings = new Dictionary<string, Item>
        {
            {"FILB", new Item("FILB", "Filling", 0.12F, "Bacon", null) },
            {"FILE", new Item("FILE", "Filling", 0.12F, "Egg", null) },
            {"FILC", new Item("FILC", "Filling", 0.12F, "Cheese", null) },
            {"FILX", new Item("FILX", "Filling", 0.12F, "Cream Cheese", null) },
            {"FILS", new Item("FILS", "Filling", 0.12F, "Smoked Salmon", null) },
            {"FILH", new Item("FILH", "Filling", 0.12F, "Ham", null) }
        };


        public Inventory() 
        { 
        }

        public List<Item> listBagels()
        {
            return bagels.Values.ToList();
        }

        public List<Item> listCoffees()
        {
            return coffees.Values.ToList();
        }

        public List<Item> listFillings()
        {
            return fillings.Values.ToList();
        }

    }
}
