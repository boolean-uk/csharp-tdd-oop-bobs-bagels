using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Inventory {
        public List<Item> _inventory = new List<Item> {
            new Item("BGLO", 0.49f, "Bagel", "Onion"),
            new Item("BGLP", 0.39f, "Bagel", "Plain"),
            new Item("BGLE", 0.49f, "Bagel", "Everything"),
            new Item("BGLS", 0.49f, "Bagel", "Sesame"),
            
            
        };
    }
}