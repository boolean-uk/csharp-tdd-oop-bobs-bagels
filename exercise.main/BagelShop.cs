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
        }

        // Maybe add terminal interaction to main
        public static void Main(string[] args)
        {

        }

        private Product createProduct(string sku, double price, string name, string variant)
        {
            return new Product(sku, price, name, variant, null);
        }
        public Basket grabBasket()
        {
            return new Basket();
        }

        public static Dictionary<string, Product> Category { get { return _category; } }
    }
}
