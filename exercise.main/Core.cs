using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace exercise.main
{
    /*
    internal class Core
    {
    }
    */

    public class Store
    {

        public static Tuple<string, double, string, string> getSkuInfo(string sku)
        {
            sku = sku.ToUpper();

            List<Tuple<string, double, string, string>> skuList = new List<Tuple<string, double, string, string>>
            {
                new Tuple<string, double, string, string>("BGLO", 0.49,  "Bagel",   "Onion"         ),
                new Tuple<string, double, string, string>("BGLP", 0.39,  "Bagel",   "Plain"         ),
                new Tuple<string, double, string, string>("BGLE", 0.49,  "Bagel",   "Everything"    ),
                new Tuple<string, double, string, string>("BGLS", 0.49,  "Bagel",   "Sesame"        ),
                new Tuple<string, double, string, string>("COFB", 0.99,  "Coffee",  "Black"         ),
                new Tuple<string, double, string, string>("COFW", 1.19,  "Coffee",  "White"         ),
                new Tuple<string, double, string, string>("COFC", 1.29,  "Coffee",  "Capuccino"     ),
                new Tuple<string, double, string, string>("COFL", 1.29,  "Coffee",  "Latte"         ),
                new Tuple<string, double, string, string>("FILB", 0.12,  "Filling", "Bacon"         ),
                new Tuple<string, double, string, string>("FILE", 0.12,  "Filling", "Egg"           ),
                new Tuple<string, double, string, string>("FILC", 0.12,  "Filling", "Cheese"        ),
                new Tuple<string, double, string, string>("FILX", 0.12,  "Filling", "Cream Cheese"  ),
                new Tuple<string, double, string, string>("FILS", 0.12,  "Filling", "Smoked Salmon" ),
                new Tuple<string, double, string, string>("FILH", 0.12,  "Filling", "Ham"           )

            };

            return skuList.FirstOrDefault(t => t.Item1 == sku);
        }

        public bool ChangeBasketSize(bool isManager)
        {
            throw new NotImplementedException();
        }

        public bool IsProductInInventory(string v)
        {
            throw new NotImplementedException();
        }
    }

    public class Person
    {
        private Basket _basket;
        public Basket Basket { get { return _basket; } set { _basket = value; } }

        private bool _isManager;
        public bool IsManager { get { return _isManager; } set { _isManager = value; } }

        public Person(Basket basket = null, bool isManager = false)
        {
            Basket = basket;
            IsManager = isManager;
        }

        public bool IsProductInInventory(string v)
        {
            throw new NotImplementedException();
        }

        public bool ChangeBasketSize()
        {
            throw new NotImplementedException();
        }
    }

    public class Basket
    {
        List<Product> _products;
        List<Product> Products { get { return _products; } set { _products = value; } }

        public Basket()
        {
            Products = new List<Product>();
        }
        public bool AddProduct(Product product)
        {
            Products.Add(product);
            return Products.Contains(product);
        }

        public int CheckCurrentCapacity()
        {
            throw new NotImplementedException();
        }

        public double CheckTotalCost()
        {
            throw new NotImplementedException();
        }

        public bool IsProductInBasket(string v)
        {
            throw new NotImplementedException();
        }

        public bool RemoveProduct(string v)
        {
            throw new NotImplementedException();
        }

        public int TotalCapacity()
        {
            throw new NotImplementedException();
        }
    }



    //Abstract or Interface? Abstract... perchance
    public abstract class Product
    {
        private string _sku = string.Empty;
        public string SKU { get { return _sku; } set { _sku = value; } }

        private double _price;
        public double Price { get { return _price; } set { _price = value; } }

        private string _name = string.Empty;
        public string Name { get { return _name; } set { _name = value; } }

        private string _variant = string.Empty;
        public string Variant { get { return _variant; } set { _variant = value; } }

        protected Product(string sKU)
        {
            sKU = sKU.Trim().ToUpper();
            Tuple<string, double, string, string> skuInfo = Store.getSkuInfo(sKU);

            if (skuInfo != null)
            {
                InitializeProduct(sKU);
            }
            else
            {
                throw new ArgumentException("Invalid SKU");
            }
        }

        protected void InitializeProduct(string sKU)
        {
            Tuple<string, double, string, string> productInfo = Store.getSkuInfo(sKU);
            SKU = productInfo.Item1;
            Price = productInfo.Item2;
            Name = productInfo.Item3;
            Variant = productInfo.Item4;
        }

        public virtual double CheckPriceOfProduct()
        {
            throw new NotImplementedException();
        }
    }

    public class Bagel : Product
    {
        public Bagel(string sKU) : base(sKU)
        {

        }

        public bool ChooseFilling(string v)
        {
            throw new NotImplementedException();
        }
    }

    public class Coffee : Product
    {
        public Coffee(string sKU) : base(sKU)
        {

        }
    }

    public class Filling : Product
    {
        public Filling(string sKU) : base(sKU)
        {

        }
    }
}
