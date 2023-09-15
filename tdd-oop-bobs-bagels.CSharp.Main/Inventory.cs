using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd.oop.bobs.bagels.CSharp.Main
{
    public class Inventory
    {
        private List<Item> _items = new List<Item>(); //stores what is in the shop / pantry 

        public Inventory()
        {
            _items.Add(new Item() {SKU = "BGLO", Price = 0.49m, Name = "Bagel", Variant= "Onion"});
            _items.Add(new Item() { SKU = "BGLP", Price = 0.39m, Name = "Bagel", Variant = "Plain" });
            _items.Add(new Item() { SKU = "BGLE", Price = 0.49m, Name = "Bagel", Variant = "Everything" });
            _items.Add(new Item() { SKU = "BGLS", Price = 0.49m, Name = "Bagel", Variant = "Sesame" });
            _items.Add(new Item() { SKU = "COFB", Price = 0.99m, Name = "Coffee", Variant = "Black" });
            _items.Add(new Item() { SKU = "COFW", Price = 1.19m, Name = "Coffee", Variant = "White" });
            _items.Add(new Item() { SKU = "COFC", Price = 1.29m, Name = "Coffee", Variant = "Cappuccino" });
            _items.Add(new Item() { SKU = "COFL", Price = 1.29m, Name = "Coffee", Variant = "Latte" });
            _items.Add(new Item() { SKU = "FILB", Price = 0.12m, Name = "Filling", Variant = "Bacon" });
            _items.Add(new Item() { SKU = "FILE", Price = 0.12m, Name = "Filling", Variant = "Egg" });
            _items.Add(new Item() { SKU = "FILC", Price = 0.12m, Name = "Filling", Variant = "Cheese" });
            _items.Add(new Item() { SKU = "FILX", Price = 0.12m, Name = "Filling", Variant = "Cream Cheese" });
            _items.Add(new Item() { SKU = "FILS", Price = 0.12m, Name = "Filling", Variant = "Smoked Salmon" });
            _items.Add(new Item() { SKU = "FILH", Price = 0.12m, Name = "Filling", Variant = "Ham" });


        }




        public List<Item> Items {  get { return _items; } } 

        //thoughts?
        //Storing the inventory of bob's bagels in here 

        /*
         Some sort of collection where everything is being put in 
        Properties? // contains value of something 
        Directory?
        List?
         */

    }
}
