using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{


    public class ProductList
    {

       

        public List<Product> products;
        public ProductList()
        {
            products = new List<Product>();
            products.Add(new Product("BGLO", 0.49, "Bagel", "Onion"));
            products.Add(new Product("BGLP", 0.39, "Bagel", "Plain"));
            products.Add(new Product("BGLE", 0.49, "Bagel", "Everything"));
            products.Add(new Product("BGLS", 0.49, "Bagel", "Sesame"));
            products.Add(new Product("COFB", 0.99, "Coffee", "Black"));
            products.Add(new Product("COFW", 1.19, "Coffee", "White"));
            products.Add(new Product("COFC", 1.29, "Coffee", "Cappucino"));
            products.Add(new Product("COFL", 1.29, "Coffee", "Latte"));
            products.Add(new Product("FILB", 0.12, "Filling", "Bacon"));
            products.Add(new Product("FILE", 0.12, "Filling", "Egg"));
            products.Add(new Product("FILC", 0.12, "Filling", "Cheese"));
            products.Add(new Product("FILX", 0.12, "Filling", "Cream Cheese"));
            products.Add(new Product("FILS", 0.12, "Filling", "Smoked Salmon"));
            products.Add(new Product("FILH", 0.12, "Filling", "Ham"));

           

        }


    }
}



//  public List<Dictionary<string, Tuple<double, string, string>>> products;
//  public Dictionary<string, Tuple<double, string, string>> products;
//  public Tuple<double, string, string> PNV

/*   public bool SearchList(string SKU, out Tuple<double, string, string> product)
      {
         bool s = products.TryGetValue(SKU, out var item);
          product = item;
          return s;
      }


      public Dictionary<string, Tuple<double, string, string>> IntializeProductList()
      {

          products = new Dictionary<string, Tuple<double, string, string>>();
          products.Add("BGLO", new Tuple<double, string, string>(0.49, "Bagel", "Onion"));
          products.Add("BGLP", new Tuple<double, string, string>(0.39, "Bagel", "Plain"));
          products.Add("BGLE", new Tuple<double, string, string>(0.49, "Bagel", "Everything"));
          products.Add("COFB", new Tuple<double, string, string>(0.99, "Coffee", "Black"));
          products.Add("COFW", new Tuple<double, string, string>(1.19, "Coffee", "White"));
          products.Add("COFC", new Tuple<double, string, string>(1.29, "Coffee", "Capuccino"));
          products.Add("COFL", new Tuple<double, string, string>(1.29, "Coffee", "Latte"));
          products.Add("FILB", new Tuple<double, string, string>(0.12, "Filling", "Bacon"));
          products.Add("FILE", new Tuple<double, string, string>(0.12, "Filling", "Egg"));
          products.Add("FILC", new Tuple<double, string, string>(0.12, "Filling", "Cheese"));
          products.Add("FILX", new Tuple<double, string, string>(0.12, "Filling", "Cream Cheese"));
          products.Add("FILS", new Tuple<double, string, string>(0.12, "Filling", "Smoked Salmon"));
          products.Add("FILH", new Tuple<double, string, string>(0.12, "Filling", "Ham"));

          return products;
      } */