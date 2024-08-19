using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class BagelShop
    {
        private Dictionary<string, Product> _category = new Dictionary<string, Product>();

        public BagelShop()
        {
            _category.Add("BGLO", CreateProduct("BGLO", 0.49, "Bagel", "Onion"));
            _category.Add("BGLP", CreateProduct("BGLP", 0.39, "Bagel", "Plain"));
            _category.Add("BGLE", CreateProduct("BGLE", 0.49, "Bagel", "Everything"));
            _category.Add("BGLS", CreateProduct("BGLS", 0.49, "Bagel", "Sesame"));

            _category.Add("COFB", CreateProduct("COFB", 0.99, "Coffee", "Black"));
            _category.Add("COFW", CreateProduct("COFW", 1.19, "Coffee", "White"));
            _category.Add("COFC", CreateProduct("COFC", 1.29, "Coffee", "Capuccino"));
            _category.Add("COFL", CreateProduct("COFL", 1.29, "Coffee", "Latte"));

            _category.Add("FILB", CreateProduct("FILB", 0.12, "Filling", "Bacon"));
            _category.Add("FILE", CreateProduct("FILE", 0.12, "Filling", "Egg"));
            _category.Add("FILC", CreateProduct("FILC", 0.12, "Filling", "Cheese"));
            _category.Add("FILX", CreateProduct("FILX", 0.12, "Filling", "Cream Cheese"));
            _category.Add("FILS", CreateProduct("FILS", 0.12, "Filling", "Smoked Salmon"));
            _category.Add("FILH", CreateProduct("FILH", 0.12, "Filling", "Ham"));
        }

        // Maybe add terminal interaction to main
        public static void Main(string[] args)
        {

        }

        private Product CreateProduct(string sku, double price, string name, string variant)
        {
            switch (name)
            {
                case "Bagel":
                    return new Bagel(sku, price, name, variant);
                case "Coffee":
                    return new Coffee(sku, price, name, variant);
                case "Filling":
                    return new Filling(sku, price, name, variant);
            }
            return null;
        }
        public Basket GrabBasket()
        {
            return new Basket(_category);
        }

        public Dictionary<string, Product> Category { get { return _category; } }
    }
}
