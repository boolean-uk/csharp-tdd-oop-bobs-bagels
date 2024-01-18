using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Products
    {
        public List<Product> productList { get; set; }

        public Products()
        {
            Product p1 = new Product() { Id = 1, SKU = "BGLO", Price = 0.49, Name = "Bagel", Variant = "Onion" };
            Product p2 = new Product() { Id = 2, SKU = "BGLP", Price = 0.39, Name = "Bagel", Variant = "Plain" };
            Product p3 = new Product() { Id = 3, SKU = "BGLE", Price = 0.49, Name = "Bagel", Variant = "Everything" };
            Product p4 = new Product() { Id = 4, SKU = "BGLS", Price = 0.49, Name = "Bagel", Variant = "Sesame" };



            Product p5 = new Product() { Id = 5, SKU = "COFB", Price = 0.99, Name = "Coffee", Variant = "Black" };
            Product p6 = new Product() { Id = 6, SKU = "COFW", Price = 1.19, Name = "Coffee", Variant = "White" };
            Product p7 = new Product() { Id = 7, SKU = "COFC", Price = 1.29, Name = "Coffee", Variant = "Capuccino" };
            Product p8 = new Product() { Id = 8, SKU = "COFL", Price = 1.29, Name = "Coffee", Variant = "Latte" };


            Product p9 = new Product() { Id = 9, SKU = "FILB", Price = 0.12, Name = "Filling", Variant = "Bacon" };
            Product p10 = new Product() { Id = 10, SKU = "FILE", Price = 0.12, Name = "Filling", Variant = "Egg" };
            Product p11 = new Product() { Id = 11, SKU = "FILC", Price = 0.12, Name = "Filling", Variant = "Cheese" };
            Product p12 = new Product() { Id = 12, SKU = "FILX", Price = 0.12, Name = "Filling", Variant = "Cream Cheese" };
            Product p13 = new Product() { Id = 13, SKU = "FILS", Price = 0.12, Name = "Filling", Variant = "Smoked Salmon" };
            Product p14 = new Product() { Id = 14, SKU = "FILH", Price = 0.12, Name = "Filling", Variant = "Ham" };
            this.productList = new List<Product>() { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14 };
        }
    }
}
