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
        private static List<Tuple<string, double, string, string>> _skuList;
        public static List<Tuple<string, double, string, string>> SkuList { get { return _skuList; } set { _skuList = value; } }

        static Store()
        {
            //Weakness: no quantity and not mutable. But I decided I won't implement that unless I have to.
            SkuList = new List<Tuple<string, double, string, string>>
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
        }
        public Store()
        {

        }

        public static Tuple<string, double, string, string> getSkuInfo(string sku)
        {
            sku = sku.ToUpper();

            return SkuList.FirstOrDefault(t => t.Item1 == sku);
        }

        public static bool IsProductInInventory(string sKU)
        {
            bool isThere = false;
            foreach (Tuple<string, double, string, string> sku in SkuList)
            {
                if (sku.Item1 == sKU)
                {
                    isThere = true;
                    break;
                }
            }
            return isThere;
        }

        public static bool ChangeBasketSize(bool isManager, int newCapacity)
        {
            if (isManager && newCapacity > 0)
            {
                Basket.BasketCapacity = newCapacity;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    //Finne discount = modulo?
    public static class CashRegister
    {

        public static double CalculateReceipt(List<Product> products)
        {
            Dictionary<string, int> discountTracker = PopulateTracker();
            double total = 0;
            if (!products.Any())
            {
                return total;
            }

            foreach (Product product in products)
            {
                discountTracker.Add(product.SKU, +1); //fINNE KODEN, ADDERE OPP VALUE ISTEDEN. DENNE ER FEIL
            }
            total = products.Sum(product => product.Price);
            return total;


        }

        public static Dictionary<string, int> PopulateTracker()
        {
            Dictionary<string, int> discountTracker = new Dictionary<string, int>
            {
                {"BGLO", 0},
                {"BGLP", 0},
                {"BGLE", 0},
                {"BGLS", 0},
                {"COFB", 0},
                {"COFW", 0},
                {"COFC", 0},
                {"COFL", 0},
                {"FILB", 0},
                {"FILE", 0},
                {"FILC", 0},
                {"FILX", 0},
                {"FILS", 0},
                {"FILH", 0}
            };

            return discountTracker;
        }

        public static string PrintReceipt()
        {
            return "receipt";
        }
    }

    public class Basket
    {
        List<Product> _products;
        List<Product> Products { get { return _products; } set { _products = value; } }

        private static int _basketCapacity = 12;
        public static int BasketCapacity { get { return _basketCapacity; } set { _basketCapacity = value; } }

        public Basket()
        {
            Products = new List<Product>();
        }
        public bool AddProduct(Product product)
        {
            if (Products.Count < BasketCapacity)
            {
                Products.Add(product);
                return Products.Contains(product);
            }
            else
            {
                return false;
            }

        }

        public bool RemoveProduct(Product product)
        {
            return Products.Remove(product);
        }

        public bool IsProductInBasket(Product product)
        {
            return Products.Contains(product);
        }

        public int TotalCapacity()
        {
            return BasketCapacity;
        }

        public int CheckCurrentCapacity()
        {
            return TotalCapacity() - Products.Count();
        }

        public double CheckTotalCost()
        {
            return CashRegister.CalculateReceipt(Products);
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

        public bool IsProductInInventory(string sKU)
        {
            return Store.IsProductInInventory(sKU);
        }

        public bool ChangeBasketSize(bool isManager, int newCapacity)
        {
            return Store.ChangeBasketSize(isManager, newCapacity);
        }
    }


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
            return Price;
        }
    }

    public class Bagel : Product
    {
        private Filling _filling;
        public Filling Filling { get { return _filling; } set { _filling = value; } }

        public Bagel(string sKU) : base(sKU)
        {

        }

        public bool ChooseFilling(Filling filling)
        {
            Filling = filling;
            return Filling != null;
        }

        public virtual double CheckPriceOfProduct()
        {
            return Filling != null ? (Price + Filling.Price) : Price;
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
