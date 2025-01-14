using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using exercise.main.Products;

namespace exercise.main
{
    public class Store
    {

        private Inventory _storeInventory = new Inventory();

        public Inventory Inventory { get { return _storeInventory; } }
        
        public Store() 
        {
            Bagel onionBagel = new Bagel("BGLO", 0.49m, "Bagel", "Onion", 6, 2.49m);
            Bagel sesameBagel = new Bagel("BGLS", 0.49m, "Bagel", "Sesame");
            Bagel plainBagel = new Bagel("BGLP", 0.39m, "Bagel", "Plain", 12, 3.99m);
            Bagel everythingBagel = new Bagel("BGLE", 0.49m, "Bagel", "Everything",6, 2.49m);

            Coffee blackCoffee = new Coffee("COFB", 0.99m, "Coffee", "Black");
            Coffee whiteCoffee = new Coffee("COFW", 1.19m, "Coffee", "White");
            Coffee capuccinoCoffe = new Coffee("COFC", 1.29m, "Coffee", "Capuccino");
            Coffee latteCoffee = new Coffee("COFL", 1.29m, "Coffee", "Latte");

            Filling bacon = new Filling("FILB", 0.12m, "Filling", "Bacon");
            Filling egg = new Filling("FILE", 0.12m, "Filling", "Egg");
            Filling cheese = new Filling("FILC", 0.12m, "Filling", "Cheese");
            Filling creamCheese = new Filling("FILX", 0.12m, "Filling", "Cream Cheese");
            Filling smokedSalmon = new Filling("FILS", 0.12m, "Filling", "Smoked Salmon");
            Filling ham = new Filling("FILH", 0.12m, "Filling", "Ham");

            _storeInventory.AddProduct(onionBagel.SKU, onionBagel);
            _storeInventory.AddProduct(plainBagel.SKU, plainBagel);
            _storeInventory.AddProduct(sesameBagel.SKU, sesameBagel);
            _storeInventory.AddProduct(everythingBagel.SKU, everythingBagel);

            _storeInventory.AddProduct(blackCoffee.SKU, blackCoffee);
            _storeInventory.AddProduct(whiteCoffee.SKU, whiteCoffee);
            _storeInventory.AddProduct(capuccinoCoffe.SKU, capuccinoCoffe);
            _storeInventory.AddProduct(latteCoffee.SKU, latteCoffee);

            _storeInventory.AddProduct(bacon.SKU, bacon);
            _storeInventory.AddProduct(egg.SKU, egg);
            _storeInventory.AddProduct(cheese.SKU, cheese);
            _storeInventory.AddProduct(creamCheese.SKU, creamCheese);
            _storeInventory.AddProduct(smokedSalmon.SKU, smokedSalmon);
            _storeInventory.AddProduct(ham.SKU, ham);
        }
    }
}