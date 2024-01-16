using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Inventory
    {

        private Dictionary<string, Item> items = new Dictionary<string, Item>();

        public Inventory()
        {
            items.Add("BGLO", new Item(0.49f, "BagelOnion", "BGLO"));
            items.Add("BGLP", new Item(0.39f, "BagelPlain", "BGLP"));
            items.Add("BGLE", new Item(0.49f, "BagelEverything", "BLE"));
            items.Add("BGLS", new Item(0.49f, "BagelSesame", "BGLS"));
            items.Add("COFB", new Item(0.99f, "CoffeeBlack", "COFB"));
            items.Add("COFW", new Item(1.19f, "CoffeeWhite", "COFW"));
            items.Add("COFC", new Item(1.29f, "CoffeeCapuccino", "COFC"));
            items.Add("COFL", new Item(1.29f, "CoffeLatte", "COFL"));
            items.Add("FILB", new Item(0.12f, "FillingBacon", "FILB"));
            items.Add("FILE", new Item(0.12f, "FillingEgg", "FILE"));
            items.Add("FILC", new Item(0.12f, "FillingCheese", "FILC"));
            items.Add("FILX", new Item(0.12f, "FillingCreamCheese", "FILX"));
            items.Add("FILS", new Item(0.12f, "FillingSmokedSalmon", "FILS"));
            items.Add("FILH", new Item(0.12f, "FillingHam", "FILH"));
        }



    }
}
