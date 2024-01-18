using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Menu
    {
        public List<Product> menuList = new List<Product>();
        public List<Product> MenuList { get { return menuList;} }
        
        public Menu() 
        {
            menuList = CreateMenu();
        }

        public string stringifyMenu() 
        {
            StringBuilder sb = new StringBuilder();
            foreach (Product item in menuList)
            {
                sb.Append(item);
            }
            return sb.ToString();
        }

        public void printMenu()
        {
            Console.WriteLine($"         ~~ Bob's Bagels Menu~~");
            Console.WriteLine();
            Console.WriteLine("{0,10}    {1,10}       {2,10}     {3,10} ", "SKU", "Product", "Variant", "Price");
            Console.WriteLine();
            foreach (Product prod in menuList)
            {
                Console.WriteLine("{0,10}    {1,10}       {2,10}     {3,10}", prod._sku, prod._name, prod._variant, $"£{prod._price}");

            }


        }

        public static List<Product> CreateMenu()
        {
            return new List<Product>
            {
                new Product("BGLO", 0.49d, "Bagel", "Onion"),
                new Product("BGLP", 0.39d, "Bagel", "Plain"),
                new Product("BGLE", 0.49d, "Bagel", "Everything"),
                new Product("BGLS", 0.49d, "Bagel", "Sesame"),
                new Product("COFB", 0.99d, "Coffee", "Black"),
                new Product("COFW", 1.19d, "Coffee", "White"),
                new Product("COFC", 1.29d, "Coffee", "Cappuccino"),
                new Product("COFL", 1.29d, "Coffee", "Latte"),
                new Product("FILB", 0.12d, "Filling", "Bacon"),
                new Product("FILE", 0.12d, "Filling", "Egg"),
                new Product("FILC", 0.12d, "Filling", "Cheese"),
                new Product("FILX", 0.12d, "Filling", "Cream Cheese"),
                new Product("FILS", 0.12d, "Filling", "Smoked Salmon"),
                new Product("FILH", 0.12d, "Filling", "Ham")
            };
        }




    }
}
