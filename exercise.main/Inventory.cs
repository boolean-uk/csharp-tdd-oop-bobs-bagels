using System.Collections.Generic;
using System.Linq;
using tdd_bobs_bagels.CSharp.Main;


namespace tdd_bobs_bagels.CSharp.Main
{
public class Inventory
    {
        private Dictionary<string, Item> items = new Dictionary<string, Item>{
            {"1", new Item("BGLP", "Bagel", "plain", 1.00f)},
            {"2", new Item("BGLS", "Bagel", "Sesame", 1.10f)},
            {"3", new Item("BGLC", "Bagel", "Cinnamon", 1.20f)},
            {"4", new Item("FILC", "Filling", "Cheese", 0.50f)},
            {"5", new Item("FILJ", "Filling", "Jam", 0.50f)},
            {"6", new Item("FILS", "Filling", "Salmon", 1.00f)},
            {"7", new Item("COFB", "Coffee", "Black", 1.00f)},
            {"8", new Item("COFW", "Coffee", "White", 2.00f)},
            {"9", new Item("COFL", "Coffee", "Latte", 3.00f)}
        };

        public List<Item> Bagels {get {return items.Values.Where(i => i.Name == "Bagel").ToList();}}
        public List<Item> Fillings {get {return items.Values.Where(i => i.Name == "Filling").ToList();}}
        public List<Item> Coffees {get {return items.Values.Where(i => i.Name == "Coffee").ToList();}}

        public Item ItemDetails(string sku){
            if(items.ContainsKey(sku)){
                return items[sku];
            }
            return null;
        }
    }
}