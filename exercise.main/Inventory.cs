using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Inventory
    {
        public List<Item> inventory { get; } = new List<Item>();
        public Inventory()
        {
            inventory.Add(new Bagel("Onion"));
            inventory.Add(new Bagel("Plain"));
            inventory.Add(new Bagel("Everything"));
            inventory.Add(new Bagel("Sesame"));
            inventory.Add(new Coffee("Black"));
            inventory.Add(new Coffee("White"));
            inventory.Add(new Coffee("Capuccino"));
            inventory.Add(new Coffee("Latte"));
            inventory.Add(new Filling("Bacon"));
            inventory.Add(new Filling("Egg"));
            inventory.Add(new Filling("Cheese"));
            inventory.Add(new Filling("Cream Cheese"));
            inventory.Add(new Filling("Smoked Salmon"));
            inventory.Add(new Filling("Ham"));
        }
    }
}
