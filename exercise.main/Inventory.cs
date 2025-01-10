using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public static class Inventory
    {
        private static List<Item> _items = new List<Item>();

        public static List<Item> GetInventory()
        {

            Bagel onion = new Bagel("BGLO", 0.49, "Bagel", "Onion");
            Bagel plain = new Bagel("BGLP", 0.39, "Bagel", "Plain");
            Bagel everything = new Bagel("BGLE", 0.49, "Bagel", "Everything");
            Bagel sesame = new Bagel("BGLS", 0.49, "Bagel", "Sesame");

            Coffee black = new Coffee("COFB", 0.99, "Coffee", "Black");
            Coffee white = new Coffee("COFW", 1.19, "Coffee", "White");
            Coffee capuccino = new Coffee("COFC", 1.29, "Coffee", "Capuccino");
            Coffee latte = new Coffee("COFL", 1.29, "Coffee", "Latte");

            Filling bacon = new Filling("FILB", 0.12, "Filling", "Bacon");
            Filling egg = new Filling("FILE", 0.12, "Filling", "Egg");
            Filling cheese = new Filling("FILC", 0.12, "Filling", "Cheese");
            Filling creamCheese = new Filling("FILX", 0.12, "Filling", "Cream Cheese");
            Filling smokedSalmon = new Filling("FILS", 0.12, "Filling", "Smoked Salmon");
            Filling ham = new Filling("FILH", 0.12, "Filling", "Ham");

            _items.Add(onion);
            _items.Add(plain);
            _items.Add(everything);
            _items.Add(sesame);
            _items.Add(black);
            _items.Add(white);
            _items.Add(capuccino);
            _items.Add(latte);
            _items.Add(bacon);
            _items.Add(egg);
            _items.Add(cheese);
            _items.Add(creamCheese);
            _items.Add(smokedSalmon);
            _items.Add(ham);

            return _items;


        }

        
    }
}
