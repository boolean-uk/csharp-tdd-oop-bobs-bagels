using exercise.main.Interfaces;
using exercise.main.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Inventory2
    { 
    public List<IItem> _inventory = new List<IItem>();

    public List<IItem> getInventory2()
    {
        _inventory.Add(new Bagel("BGLO", 0.49, "Bagel", "Onion"));
        _inventory.Add(new Bagel("BGLP", 0.39, "Bagel", "Plain"));
        _inventory.Add(new Bagel("BGLE", 0.49, "Bagel", "Everything"));
        _inventory.Add(new Bagel("BGLS", 0.49, "Bagel", "Sesame"));
        _inventory.Add(new Coffee("COFB", 0.99, "Coffee", "Black"));
        _inventory.Add(new Coffee("COFW", 1.19, "Coffee", "White"));
        _inventory.Add(new Coffee("COFC", 1.29, "Coffee", "Capuccino"));
        _inventory.Add(new Coffee("COFL", 1.29, "Coffee", "Latte"));
        _inventory.Add(new Filling("FILB", 0.12, "Filling", "Bacon"));
        _inventory.Add(new Filling("FILE", 0.12, "Filling", "Egg"));
        _inventory.Add(new Filling("FILC", 0.12, "Filling", "Cheese"));
        _inventory.Add(new Filling("FILX", 0.12, "Filling", "Cream Cheese"));
        _inventory.Add(new Filling("FILS", 0.12, "Filling", "Smoked Salmon"));
        _inventory.Add(new Filling("FILH", 0.12, "Filling", "Ham"));

        return _inventory;
    }
}
}
