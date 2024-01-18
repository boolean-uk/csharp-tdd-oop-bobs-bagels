using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Core;
using exercise.main.Objects.People;
using exercise.main.Objects.Products;
using exercise.main.Objects.Tools;
using Microsoft.VisualBasic;


namespace exercise.main.Objects.Containers
{

    public struct Requirement(string sku, int amount)
    {
        public string SKU { get; } = sku;
        public int Amount { get; } = amount;
    }

    public struct Discount(List<Requirement> requirements, double price)
    {
        public List<Requirement> Requirement = requirements;
        public double Price = price;
        public bool IsMultipleUse = true;
    }

    public struct Stock(Product product, int amount)
    {
        public Product Product = product;
        public int Amount = amount;
    }

    public class Store
    {
        protected Checkout Checkout = new Checkout();

        // List contains product, amount
        private List<Stock> _stock = new List<Stock>()
        {
            new Stock(new Bagel(   "BGLO", 0.49d, "Onion"),          99),
            new Stock(new Bagel(   "BGLP", 0.39d, "Plain"),          99),
            new Stock(new Bagel(   "BGLE", 0.49d, "Everything"),     99),
            new Stock(new Bagel(   "BGLS", 0.49d, "Sesame"),         99),
            new Stock(new Coffee(  "COFB", 0.99d, "Black"),          99),
            new Stock(new Coffee(  "COFW", 1.19d, "White"),          99),
            new Stock(new Coffee(  "COFC", 1.29d, "Capuccino"),      99),
            new Stock(new Coffee(  "COFL", 1.29d, "Latte"),          99),
            new Stock(new Filling( "FLIB", 0.12d, "Bacon"),          99),
            new Stock(new Filling( "FILE", 0.12d, "Egg"),            99),
            new Stock(new Filling( "FILC", 0.12d, "Cheese"),         99),
            new Stock(new Filling( "FILX", 0.12d, "Cream Cheese"),   99),
            new Stock(new Filling( "FILS", 0.12d, "Smoked Salmon"),  99),
            new Stock(new Filling( "FILH", 0.12d, "Ham"),            99),
        };

        private List<Discount> _discounts = new List<Discount>()
        {
            {new Discount( new List<Requirement> {new Requirement("BGL",  12)},  3.99d) },
            {new Discount( new List<Requirement> {new Requirement("BGL",   6)},   2.49d) },
            {new Discount( new List<Requirement> {new Requirement("BGLO",  6)},  2.49d) },
            {new Discount( new List<Requirement> {new Requirement("BGLP", 12)}, 3.99d) },
            {new Discount( new List<Requirement> {new Requirement("BGLE",  6)},  2.49d) },
            {new Discount( new List<Requirement> {new Requirement("COFB",  1),
                                                  new Requirement("BGL",   1) },  1.25d) }
        };
        public Store()
        {

        }

        public Product GetProduct(string productSKU)
        {
            if (_stock.Where(x => x.Product.SKU == productSKU).ToList().Count() == 0)
            {
                return null;
            }

            return _stock.Where(x => x.Product.SKU == productSKU).ToList().First().Product;
        }
        public double GetPrice(string productSKU)
        {
            
            if (_stock.Where(x => x.Product.SKU == productSKU).ToList().Count() == 0)
            {
                return -1.0d;
            }

            return _stock.Where(x => x.Product.SKU == productSKU).ToList().First().Product.GetPrice();
        }
        public bool BuyWares(Customer customer)
        {
            return Checkout.PurchaseWares(customer, _discounts);
        }
    }
}
