using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Inventory
    {

        public static List<Item> inventoryList = new List<Item>
          
            {
                new Item("BGLO", 0.49M, "Bagel", "Onion"),
                new Item("BGLP", 0.39M, "Bagel", "Plain"),
                new Item("BGLE", 0.49M, "Bagel", "Everything"),
                new Item("BGLS", 0.49M, "Bagel", "Sesame"),
                new Item("FILB", 0.12M, "Filling", "Bacon"),
                new Item("FILE", 0.12M, "Filling", "Egg"),
                new Item("FILC", 0.12M, "Filling", "Cheese"),
                new Item("FILX", 0.12M, "Filling", "Cream Cheese"),
                new Item("FILS", 0.12M, "Filling", "Smoked Salmon"),
                new Item("FILH", 0.12M, "Filling", "Ham"),
                new Item("COFB", 0.99M, "Coffee", "Black"),
                new Item("COFW", 1.19M, "Coffee", "White"),
                new Item("COFC", 1.29M, "Coffee", "Capuccino"),
                new Item("COFL", 1.29M, "Coffee", "Latte"),
               
            };

    } 

}



        
    
        
  
