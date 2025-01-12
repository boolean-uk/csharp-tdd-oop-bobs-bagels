using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main
{
    public class Store
    {

        private Inventory _storeInventory = new Inventory();

        public Inventory Inventory { get { return _storeInventory; } }
        
        public Store() 
        {
            Bagel onionBagel = new Bagel("BGLO", 0.49, Bagel.BagelVariant.Onion);
            Bagel sesameBagel = new Bagel("BGLS", 0.49, Bagel.BagelVariant.Sesame);
            Bagel plainBagel = new Bagel("BGLP", 0.39, Bagel.BagelVariant.Plain);
            Bagel everythingBagel = new Bagel("BGLE", 0.49, Bagel.BagelVariant.Everything);

            Coffee blackCoffee = new Coffee("COFB", 0.99, Coffee.CoffeeVariant.Black);
            Coffee whiteCoffee = new Coffee("COFW", 1.19, Coffee.CoffeeVariant.White);
            Coffee capuccinoCoffe = new Coffee("COFL", 1.29, Coffee.CoffeeVariant.Capuccino);
            Coffee latteCoffee = new Coffee("COFL", 1.29, Coffee.CoffeeVariant.Latte);

            Filling bacon = new Filling("FILB", 0.12, Filling.FillingVariant.Bacon);
            Filling egg = new Filling("FILE", 0.12, Filling.FillingVariant.Egg);
            Filling cheese = new Filling("FILC", 0.12, Filling.FillingVariant.Cheese);
            Filling creamCheese = new Filling("FILX", 0.12, Filling.FillingVariant.CreamCheese);
            Filling smokedSalmon = new Filling("FILS", 0.12, Filling.FillingVariant.SmokedSalmon);
            Filling ham = new Filling("FILH", 0.12, Filling.FillingVariant.Ham);

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