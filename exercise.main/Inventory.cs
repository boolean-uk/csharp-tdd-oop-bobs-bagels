using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Inventory
    {

        private Dictionary<Item, string> items = new Dictionary<Item, string>();

        public Inventory()
        {
            items.Add(new Item(0.49f, "BagelOnion", "BGLO"), "BGLO");
            items.Add(new Item(0.39f, "BagelPlain", "BGLP"), "BGLP");
            items.Add(new Item(0.49f, "BagelEverything", "BGLE"), "BGLE");
            items.Add(new Item(0.49f, "BagelSesame", "BGLS"), "BGLS");
            items.Add(new Item(0.99f, "CoffeeBlack", "COFB"), "COFB");
            items.Add(new Item(1.19f, "CoffeeWhite", "COFW"), "COFW");
            items.Add(new Item(1.29f, "CoffeeCapuccino", "COFC"), "COFC");
            items.Add(new Item(1.29f, "CoffeLatte", "COFL"), "COFL");
            items.Add(new Item(0.12f, "FillingBacon", "FILB"), "FILB");
            items.Add(new Item(0.12f, "FillingEgg", "FILE"), "FILE");
            items.Add(new Item(0.12f, "FillingCheese", "FILC"), "FILC");
            items.Add(new Item(0.12f, "FillingCreamCheese", "FILX"), "FILX");
            items.Add(new Item(0.12f, "FillingSmokedSalmon", "FILS"), "FILS");
            items.Add(new Item(0.12f, "FillingHam", "FILH"), "FILH");

        }



    }
}
