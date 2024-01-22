using exercise.main.Products;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace exercise.main
{
    public class Inventory
    {
        private int uniqueId = 100;
        public List<InventoryProduct> items; 

        public InventoryProduct OnionBagel = new Bagel("BGLO","Onion",0.49);
        public InventoryProduct PlainBagel = new Bagel("BGLP", "Plain", 0.39);
        public InventoryProduct EverythinBagel = new Bagel("BGLE", "Everything", 0.49);
        public InventoryProduct SesameBagel = new Bagel("BGLS", "Sesame", 0.49);
        public InventoryProduct BlackCoffee = new Coffee("COFB", "Black", 0.99);
        public InventoryProduct WhiteCoffee = new Coffee("COFW", "White", 1.19);
        public InventoryProduct Cappucino = new Coffee("COFC", "Cappucion", 1.29);
        public InventoryProduct Latte = new Coffee("COFL", "Latte", 1.29);

        public InventoryProduct Bacon = new Filling("FILB", "Bacon", 0.12);
        public InventoryProduct Egg = new Filling("FILE", "Egg", 0.12);
        public InventoryProduct Cheese = new Filling("FILC", "Cheese", 0.12);
        public InventoryProduct CreamCheese = new Filling("FILX", "Cream Cheese", 0.12);
        public InventoryProduct SmokedSalmon = new Filling("FILS", "Smoked Salmon", 0.12);
        public InventoryProduct Ham = new Filling("FILH", "Ham", 0.12);
         
        public Inventory()
        {
            
            items = [OnionBagel, PlainBagel, EverythinBagel, SesameBagel, BlackCoffee, WhiteCoffee, Cappucino, Latte, Bacon, Egg, Cheese, CreamCheese, SmokedSalmon, Ham];
            
        }

        public bool checkInventory(InventoryProduct product)
        {
            foreach (InventoryProduct item in items)
            {
                if (item.Sku == product.Sku)
                {
                    return true;
                }
            }
          
            return false;
        }

        public List<InventoryProduct> Items {  get { return items; } }  
        public int ID { get => uniqueId; set => uniqueId = value; }

    }

    
}
