using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {

        public Basket() 
        { 
            Inventory inventory = new Inventory();
            _inventory = inventory.inventory;
            _discounts = inventory.Discounts;
        }

        public string Add(string productID)
        {
            if (_capacity <= ProductCount) { return "your basket is full"; }
            if (!InventoryProductIds.Contains(productID)) { return "product does not exist in the inventory"; }

            Product product = GetFromInventory(productID);
            _basket.Add(product);
            return "product added to basket";
        }

        public void AddMultible(string productID, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Add(productID);
            }

        }
        public bool Remove(string productID)
        {
            if (!BasketProductIds.Contains(productID)) { return false; }
            
            Product product = GetFromInventory(productID);
            _basket.Remove(product);
            return true;
        }

        public Product GetFromInventory(string productID)
        {
            return _inventory.First(item => item.SKU.Contains(productID));
        }


        public int ChangeCapacity(int c, string adminPassword)
        {
            //Just returns the current capacity if not admin for now
            if (adminPassword == "admin"){ _capacity = c;}

            return _capacity;
        }

        public double GetCostOfProduct(string productId)
        {
            return GetFromInventory(productId).Price;
        }

        //For the extension 1
        //I will come back to it later =)

        public double GetTotalCost()
        {
            if (!_basket.Any()) {  return 0; }

            List<string> discountProducts = _discounts.SelectMany(item => item.Products).ToList();
            List<Product> productsWithDiscount = _basket.Where(product => discountProducts.Contains(product.SKU)).ToList();

            if (!productsWithDiscount.Any()) { return TotalCost; }

            double sum = 0;
            int c = 0;

            while (c < _discounts.Count) 
            {
                //Checks for valid discount
                Discount discount = _discounts[c];
                List<string> requirement = discount.Products;
                List<string> productSKUs = productsWithDiscount.Select(item => item.SKU).ToList();
                List<string> uniqueItems = requirement.Distinct().ToList();

                bool validDiscount = true;

                foreach (string item in uniqueItems) 
                {
                    int requirementCount = requirement.Where(x => x.Contains(item)).Count();
                    int productWithDiscountCount = productSKUs.Where(x => x.Contains(item)).Count();

                    if (requirementCount > productWithDiscountCount)
                    {
                        validDiscount = false;
                    }
                }
                
                //Adds discount price
                if (validDiscount)
                {
                    sum += discount.price;
                    for (int i = 0; i < requirement.Count; i++)
                    {
                        productsWithDiscount.Remove(GetFromInventory(requirement[i]));
                    }
                }
                else
                {
                    c++;
                }
            }

            //The rest
            sum += productsWithDiscount.Select(item => item.Price).Sum();
            sum += _basket.Where(product => !discountProducts.Contains(product.SKU)).Select(product => product.Price).Sum();

            return sum;
        }

        public int GetProductCount(string product)
        {
            return _basket.Count(product => product.Name == product.Name);
        }

        private List<Product> _basket { get; set; } = new List<Product>();

        public List<Product> basket { get => _basket; }

        //I know theese are bad, but I do not want to change every basket constructor atm
        private List<Product> _inventory; 

        private List<Discount> _discounts;
        private int _capacity { get; set; } = 50;

        public int Capacity { get => _capacity; }
        public int ProductCount { get { return _basket.Count; } }

        public List<string> BasketProductIds { get { return _basket.Select(item => item.SKU).ToList(); } }

        public List<string> InventoryProductIds { get { return _inventory.Select(item => item.SKU).ToList();  } }
        public double TotalCost { get { return _basket.Select(item => item.Price).Sum(); } }

        public Dictionary<string, double> PriceList { get { return _inventory.ToDictionary(item => item.Variant, item => item.Price); } }
        public Dictionary<string, double> FillingPriceList { get { return  _inventory.Where(item => item.Name == "filling").ToDictionary(item => item.Variant, item => item.Price); } }
    }
}
