using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Inventory
    {
        List<string> inventory;

        public Inventory() 
        {
            inventory = new List<string>();
            inventory.Add("Bagels");
            inventory.Add("Coffee");
            inventory.Add("Fillings");
        }

        public string PrintInventory()
        {
            string printed = "";

            for (int i = 0; i < inventory.Count(); i++)
            {
                if (i > 0)
                    printed += ", ";

                printed += inventory[i];
            }

            return printed;
        }
    }
}
