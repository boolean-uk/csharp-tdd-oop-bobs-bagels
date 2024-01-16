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
        private Dictionary<string, Item> _bagels = new Dictionary<string, Item> {
            {"BGLO", new Item("BGLO", "Bagel", 0.49F, "Onion") },
            {"BGLP", new Item("BGLP", "Bagel", 0.39F, "Plain") },
            {"BGLE", new Item("BGLE", "Bagel", 0.49F, "Everything") },
            {"BGLS", new Item("BGLS", "Bagel", 0.49F, "Sesame") }
        };

        private Dictionary<string, Item> _coffees = new Dictionary<string, Item>
        {
            {"COFB", new Item("COFB", "Coffee", 0.99F, "Black") },
            {"COFW", new Item("COFW", "Coffee", 1.19F, "White") },
            {"COFC", new Item("COFC", "Coffee", 1.29F, "Cappucino") },
            {"COFL", new Item("COFL", "Coffee", 1.29F, "Latte") }
        };
        private Dictionary<string, Item> _fillings = new Dictionary<string, Item>
        {
            {"FILB", new Item("FILB", "Filling", 0.12F, "Bacon") },
            {"FILE", new Item("FILE", "Filling", 0.12F, "Egg") },
            {"FILC", new Item("FILC", "Filling", 0.12F, "Cheese") },
            {"FILX", new Item("FILX", "Filling", 0.12F, "Cream Cheese") },
            {"FILS", new Item("FILS", "Filling", 0.12F, "Smoked Salmon") },
            {"FILH", new Item("FILH", "Filling", 0.12F, "Ham") }
        };


        public Inventory() 
        { 
        }

        public List<Item> listBagels()
        {
            return _bagels.Values.ToList();
        }

        public List<Item> listCoffees()
        {
            return _coffees.Values.ToList();
        }

        public List<Item> listFillings()
        {
            return _fillings.Values.ToList();
        }

    }
}
