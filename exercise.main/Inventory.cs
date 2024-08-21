using exercise.main.Interfaces;
using exercise.main.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Inventory
    {
        private List<IProduct> _inventory { get; set; } = new List<IProduct>()
        {
            new Bagel("BGLO", 0.49, "bagel","onion"),
            new Bagel("BGLP", 0.39, "bagel","plain"),
            new Bagel("BGLE", 0.49, "bagel", "everything"),
            new Bagel("BGLS", 0.49, "bagel", "sesame"),
            new Coffee("COFB", 0.99, "coffee", "black"),
            new Coffee("COFW", 1.19, "coffee", "white"),
            new Coffee("COFC", 1.29, "coffee", "capuccino"),
            new Coffee("COFL", 1.29, "coffee", "latte"),
            new Filling("FILB", 0.12, "filling", "bacon"),
            new Filling("FILE", 0.12, "filling", "egg"),
            new Filling("FILC", 0.12, "filling", "cheese"),
            new Filling("FILX", 0.12, "filling", "cream cheese"),
            new Filling("FILS", 0.12, "filling", "smoked salmon"),
            new Filling("FILB", 0.12, "filling", "ham"),
        };

        private List<Discount> _discounts = new List<Discount>()
        {
            new Discount(new List<string>() { "BGLO", "BGLO", "BGLO", "BGLO", "BGLO", "BGLO" }, 2.49),
            new Discount(new List<string>() { "BGLP" , "BGLP" , "BGLP"  , "BGLP"  , "BGLP", "BGLP", "BGLP", "BGLP", "BGLP", "BGLP", "BGLP", "BGLP" }, 3.99),
            new Discount(new List<string>() { "BGLE", "BGLE", "BGLE","BGLE", "BGLE", "BGLE" }, 2.49),
            new Discount(new List<string>() { "COFB", "BGL" }, 1.25)
        };

        //The coffee and bagel discount was quite difficult, will do that later
        // Will probably have a list of discounts instead of adding them to the product

        public IProduct GetFromInventory(string productID)
        {
            return _inventory.First(item => item.SKU == productID);
        }

        public List<IProduct> GetListFromInventory(string productID)
        {
            return _inventory.Where(item =>  item.SKU == productID).ToList();
        }

        public double GetCostOfProduct(string productId)
        {
            return GetFromInventory(productId).Price;
        }

        public List<IProduct> inventory { get { return _inventory; } }

        public List<Discount> Discounts { get { return _discounts; } }
    }
        

}
