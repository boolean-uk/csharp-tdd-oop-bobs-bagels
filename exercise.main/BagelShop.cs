using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class BagelShop
    {
        private static Dictionary<string, Product> _category = new Dictionary<string, Product>();

        public BagelShop()
        {
            _category.Add("BGLO", createProduct("BGLO", 0.49, "Bagel", "Onion"));
            _category.Add("BGLP", createProduct("BGLP", 0.39, "Bagel", "Plain"));
            _category.Add("BGLE", createProduct("BGLE", 0.49, "Bagel", "Everything"));
            _category.Add("BGLS", createProduct("BGLS", 0.49, "Bagel", "Sesame"));

            _category.Add("COFB", createProduct("COFB", 0.99, "Coffee", "Black"));
            _category.Add("COFW", createProduct("COFW", 1.19, "Coffee", "White"));
            _category.Add("COFC", createProduct("COFC", 1.29, "Coffee", "Capuccino"));
            _category.Add("COFL", createProduct("COFL", 1.29, "Coffee", "Latte"));

            _category.Add("FILB", createProduct("FILB", 0.12, "Filling", "Bacon"));
            _category.Add("FILE", createProduct("FILE", 0.12, "Filling", "Egg"));
            _category.Add("FILC", createProduct("FILC", 0.12, "Filling", "Cheese"));
            _category.Add("FILX", createProduct("FILX", 0.12, "Filling", "Cream Cheese"));
            _category.Add("FILS", createProduct("FILS", 0.12, "Filling", "Smoked Salmon"));
            _category.Add("FILH", createProduct("FILH", 0.12, "Filling", "Ham"));
        }

        // Maybe add terminal interaction to main
        public static void Main(string[] args)
        {

        }

        private Product createProduct(string sku, double price, string name, string variant)
        {
            return new Product(sku, price, name, variant);
        }
        public Basket grabBasket()
        {
            return new Basket();
        }

        public static Dictionary<string, Product> Category { get { return _category; } }
    }
}
