using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public interface IInventory
    {
        public Dictionary<string, Item> getInventory();
        public List<Item> listContents();
    }

    public class WholeInventory : IInventory
    {
        private Dictionary<string, Item> _all = new Dictionary<string, Item> {
            {"BGLO", new Bagel("BGLO", "Bagel", 0.49F, "Onion") },
            {"BGLP", new Bagel("BGLP", "Bagel", 0.39F, "Plain") },
            {"BGLE", new Bagel("BGLE", "Bagel", 0.49F, "Everything") },
            {"BGLS", new Bagel("BGLS", "Bagel", 0.49F, "Sesame") },
            {"COFB", new Coffee("COFB", "Coffee", 0.99F, "Black") },
            {"COFW", new Coffee("COFW", "Coffee", 1.19F, "White") },
            {"COFC", new Coffee("COFC", "Coffee", 1.29F, "Cappucino") },
            {"COFL", new Coffee("COFL", "Coffee", 1.29F, "Latte") },
            {"FILB", new Filling("FILB", "Filling", 0.12F, "Bacon") },
            {"FILE", new Filling("FILE", "Filling", 0.12F, "Egg") },
            {"FILC", new Filling("FILC", "Filling", 0.12F, "Cheese") },
            {"FILX", new Filling("FILX", "Filling", 0.12F, "Cream Cheese") },
            {"FILS", new Filling("FILS", "Filling", 0.12F, "Smoked Salmon") },
            {"FILH", new Filling("FILH", "Filling", 0.12F, "Ham") }


        };
        public Dictionary<string, Item> getInventory()
        {
            return _all;
        }

        public List<Item> listContents()
        {
            return _all.Values.ToList();
        }
    }

    public class BagelInventory : IInventory
    {
        private Dictionary<string, Item> _bagels = new Dictionary<string, Item> {
            {"BGLO", new Bagel("BGLO", "Bagel", 0.49F, "Onion") },
            {"BGLP", new Bagel("BGLP", "Bagel", 0.39F, "Plain") },
            {"BGLE", new Bagel("BGLE", "Bagel", 0.49F, "Everything") },
            {"BGLS", new Bagel("BGLS", "Bagel", 0.49F, "Sesame") }
        };
        public Dictionary<string, Item> getInventory()
        {
            return _bagels;
        }

        public List<Item> listContents()
        {
            return _bagels.Values.ToList();
        }
    }

    public class CoffeeInventory : IInventory
    {
        private Dictionary<string, Item> _coffees = new Dictionary<string, Item>
                {
                    {"COFB", new Coffee("COFB", "Coffee", 0.99F, "Black") },
                    {"COFW", new Coffee("COFW", "Coffee", 1.19F, "White") },
                    {"COFC", new Coffee("COFC", "Coffee", 1.29F, "Cappucino") },
                    {"COFL", new Coffee("COFL", "Coffee", 1.29F, "Latte") }
                };
        public Dictionary<string, Item> getInventory()
        {
            return _coffees;
        }

        public List<Item> listContents()
        {
            return _coffees.Values.ToList();
        }
    }
 
    public class FillingInventory : IInventory
    {

        private Dictionary<string, Item> _fillings = new Dictionary<string, Item>
        {
            {"FILB", new Filling("FILB", "Filling", 0.12F, "Bacon") },
            {"FILE", new Filling("FILE", "Filling", 0.12F, "Egg") },
            {"FILC", new Filling("FILC", "Filling", 0.12F, "Cheese") },
            {"FILX", new Filling("FILX", "Filling", 0.12F, "Cream Cheese") },
            {"FILS", new Filling("FILS", "Filling", 0.12F, "Smoked Salmon") },
            {"FILH", new Filling("FILH", "Filling", 0.12F, "Ham") }
        };

        public Dictionary<string, Item> getInventory()
        {
            return _fillings;
        }
        public List<Item> listContents()
        {
            return _fillings.Values.ToList();
        }

    }
    
}
