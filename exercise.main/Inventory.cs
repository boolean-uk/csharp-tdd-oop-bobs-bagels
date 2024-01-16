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
        };

        private Dictionary<string, Item> coffees = new Dictionary<string, Item>
        {
            {"COFB", new Item("COFB", "Coffee", 0.99F, "Black", null) },
        };
        private Dictionary<string, Item> fillings = new Dictionary<string, Item>
        {
            {"FILB", new Item("COFB", "Filling", 0.12F, "Bacon", null) },
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
