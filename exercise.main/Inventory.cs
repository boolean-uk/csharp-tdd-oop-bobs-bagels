using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Inventory
    {
        private List<Product> _productList = new List<Product>();

        public Inventory()
        {
            _productList.Add(new Product() { SKU = "BGLO" , Price = 0.49M, Name = "Bagel" , Variant = "Onion" });
            _productList.Add(new Product() { SKU = "BGLP" , Price = 0.39M, Name = "Bagel" , Variant = "Plain" });
            _productList.Add(new Product() { SKU = "BGLE" , Price = 0.49M, Name = "Bagel" , Variant = "Everything" });
            _productList.Add(new Product() { SKU = "BGLS" , Price = 0.49M, Name = "Bagel" , Variant = "Sesame" });
            _productList.Add(new Product() { SKU = "COFB" , Price = 0.99M, Name = "Coffee" , Variant = "Black" });
            _productList.Add(new Product() { SKU = "COFW" , Price = 1.19M, Name = "Coffee" , Variant = "White" });
            _productList.Add(new Product() { SKU = "COFC" , Price = 1.29M, Name = "Coffee" , Variant = "Capuccino" });
            _productList.Add(new Product() { SKU = "COFL" , Price = 1.29M, Name = "Coffee" , Variant = "Latte" });
            _productList.Add(new Product() { SKU = "FILB" , Price = 0.12M, Name = "Filling" , Variant = "Bacon" });
            _productList.Add(new Product() { SKU = "FILE" , Price = 0.12M, Name = "Filling" , Variant = "Egg" });
            _productList.Add(new Product() { SKU = "FILC" , Price = 0.12M, Name = "Filling" , Variant = "Cheese" });
            _productList.Add(new Product() { SKU = "FILX" , Price = 0.12M, Name = "Filling" , Variant = "Cream Cheese" });
            _productList.Add(new Product() { SKU = "FILS" , Price = 0.12M, Name = "Filling" , Variant = "Smoked Salmon" });
            _productList.Add(new Product() { SKU = "FILH" , Price = 0.12M, Name = "Filling" , Variant = "Ham" });
            
        }
        public List<Product> Products { get { return _productList; } }
    }
}
