using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Inventory
    {
        Dictionary<string, float> inventory;

        public Inventory()
        {
            inventory = new Dictionary<string, float>();
            inventory.Add("BGLO", 0.49f);
            inventory.Add("BGLP", 0.39f);
            inventory.Add("BGLE", 0.49f);
            inventory.Add("BGLS", 0.49f);
            inventory.Add("COFB", 0.99f);
            inventory.Add("COFW", 1.19f);
            inventory.Add("COFC", 1.29f);
            inventory.Add("COFL", 1.29f);
            inventory.Add("FILB", 0.12f);
            inventory.Add("FILE", 0.12f);
            inventory.Add("FILC", 0.12f);
            inventory.Add("FILX", 0.12f);
            inventory.Add("FILS", 0.12f);
            inventory.Add("FILH", 0.12f);
        }

        public Dictionary<string, float> GetInventory()
        {
            return inventory;
        }

        public float CostOfBagel(string SKU)
        {
            return inventory[SKU];
        }

        public string GetFillings()
        {
            //Prints out the fillings
            string fillings = "";
            for (int i = 0; i < inventory.Count(); i++)
            {
                if (inventory.ElementAt(i).Key[0] == 'F')
                    fillings += inventory.ElementAt(i).Key;

                if (fillings != "" && (i + 1) < inventory.Count())
                    fillings += ", ";
            }

            return fillings;
        }

        public string GetFillingsCosts()
        {
            //Prints out all filling costs
            string fillings = "";
            for (int i = 0; i < inventory.Count(); i++)
            {
                if (inventory.ElementAt(i).Key[0] == 'F')
                {
                    fillings += inventory.ElementAt(i).Key;
                    fillings += ":";
                    fillings += inventory.ElementAt(i).Value;
                }

                if (fillings != "" && (i + 1) < inventory.Count())
                    fillings += ", ";
            }

            return fillings;
        }

        public string PrintInventory()
        {
            string printed = "";

            for (int i = 0; i < inventory.Count(); i++)
            {
                printed += inventory.ElementAt(i).Key;

                if (printed != "" && (i + 1) < inventory.Count())
                    printed += ", ";
            }

            return printed;
        }
    }
}