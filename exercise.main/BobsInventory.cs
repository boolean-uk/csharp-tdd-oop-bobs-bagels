using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using exercise.main.Inventory;


namespace exercise.main.Inventory
{

    public class BobsInventory
    {

        //List of all items in Bobs stock
        public static List<(string _SKU, double _price, Type _type, string _variant)> Inventory { get; }
                 = new List<(string _SKU, double _price, Type _type, string _variant)>()
                 {
                     ("BGLO", 0.49, Type.Bagel, "Onion"),
                     ("BGLP", 0.39, Type.Bagel, "Plain"),
                     ("BGLE", 0.49, Type.Bagel, "Everything"),
                     ("BGLS", 0.49, Type.Bagel, "Sesame"),
                     ("COFB", 0.99, Type.Coffee, "Black"),
                     ("COFW", 1.19, Type.Coffee, "White"),
                     ("COFC", 1.29, Type.Coffee, "Cappuccino"),
                     ("COFL", 1.29, Type.Coffee, "Latte"),
                     ("FILB", 0.12, Type.Filling, "Bacon"),
                     ("FILE", 0.12, Type.Filling, "Egg"),
                     ("FILC", 0.12, Type.Filling, "Cheese"),
                     ("FILX", 0.12, Type.Filling, "Cream Cheese"),
                     ("FILS", 0.12, Type.Filling, "Smoked Salmon"),
                     ("FILH", 0.12, Type.Filling, "Ham")
                 };


        Item Onion = new Bagel("BGLO", 0.49, Type.Bagel, "Onion");
        Item Plain = new Bagel("BGLP", 0.39, Type.Bagel, "Plain");
        Item Everything = new Bagel("BGLE", 0.49, Type.Bagel, "Everything");
        Item Sesame = new Bagel("BGLS", 0.49, Type.Bagel, "Sesame");
        Item Black = new Coffee("COFB", 0.99, Type.Coffee, "Black");
        Item White = new Coffee("COFW", 1.19, Type.Coffee, "White");
        Item Cappuccino = new Coffee("COFC", 1.29, Type.Coffee, "Cappuccino");
        Item Latte = new Coffee("COFL", 1.29, Type.Coffee, "Latte");
        Item Bacon = new Filling("FILB", 0.12, Type.Filling, "Bacon");
        Item Egg = new Filling("FILE", 0.12, Type.Filling, "Egg");
        Item Cheese = new Filling("FILC", 0.12, Type.Filling, "Cheese");
        Item CreamCheese = new Filling("FILX", 0.12, Type.Filling, "Cream Cheese");
        Item SmokedSalmon = new Filling("FILS", 0.12, Type.Filling, "Smoked Salmon");
        Item Ham = new Filling("FILH", 0.12, Type.Filling, "Ham");


        private List<Item> _stock = new List<Item>();

        public BobsInventory()
        {
            List<Item> BobsStock = new List<Item>()
            {
                Onion, Plain, Everything, Sesame, Black, White, Cappuccino, Latte, Bacon, Egg,  Cheese, CreamCheese, SmokedSalmon, Ham
            };

            _stock = BobsStock;

        }

        

        public List<Item> Stock { get { return _stock; } } 


    }
}
