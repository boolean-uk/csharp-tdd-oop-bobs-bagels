using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public static class Inventory
    {
        public static List<Item> inventory { get; } = new List<Item>()
        {
            {new Bagel("Onion") },
            {new Bagel("Plain") },
            {new Bagel("Everything") },
            {new Bagel("Sesame") },
            {new Coffee("Black") },
            {new Coffee("White") },
            {new Coffee("Capuccino") },
            {new Coffee("Latte") },
            {new Filling("Bacon") },
            {new Filling("Egg") },
            {new Filling("Cheese") },
            {new Filling("Cream Cheese") },
            {new Filling("Smoked Salmon") },
            {new Filling("Ham") },
        };

        public static bool CheckIfInInventory(Item item)
        {
            foreach (Item itm in inventory)
                if (itm.sKU == item.sKU)
                    return true;

            return false;
        }
    }
}
