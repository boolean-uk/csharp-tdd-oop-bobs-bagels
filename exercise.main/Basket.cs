using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        public string Add(string productID)
        {
            if (capacity <= productCount) { return "your basket is full"; }
            if (!inventoryProductIds.Contains(productID)) { return "product does not exist in the inventory"; }

            Product product = GetFromInventory(productID);
            _basket.Add(product);
            return "product added to basket";
        }
 
        public bool Remove(string productID)
        {
            if (!basketProductIds.Contains(productID)) { return false; }
            
            Product product = GetFromInventory(productID);
            _basket.Remove(product);
            return true;
        }

        public Product GetFromInventory(string productID)
        {
            return _inventory.First(item => item.SKU == productID);
        }


        public int ChangeCapacity(int c, string adminPassword)
        {
            //Just returns the current capacity if not admin for now
            if (adminPassword == "admin"){ capacity = c;}

            return capacity;
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
            if (_basket.All(product => product.Discount == null)) { return totalCost; }

            foreach (var product in _basket)
            {
                if (product.Discount == null) { continue; }
                foreach (var discount in product.Discount.DiscountProducts)
                {
                    int discountProductCount = _basket.Select(item => item.SKU).Where(item => item.Contains(discount.Key)).Count();
                    if(discountProductCount >= discount.Value)
                    {
                        //Gjør om til tilbudet
                    }
                }
            }
            return 0;
        }

        public int GetProductCount(string product)
        {
            return _basket.Count(product => product.Name == product.Name);
        }

        private List<Product> _inventory = new Inventory().inventory; 
        public int capacity { get; set; } = 5;
        public int productCount { get { return _basket.Count; } }
        public List<Product> _basket { get; set; } = new List<Product>();

        public List<string> basketProductIds { get { return _basket.Select(item => item.SKU).ToList(); } }

        public List<string> inventoryProductIds { get { return _inventory.Select(item => item.SKU).ToList();  } }
        public double totalCost { get { return _basket.Select(item => item.Price).Sum(); } }

        public Dictionary<string, double> priceList { get { return _inventory.ToDictionary(item => item.Variant, item => item.Price); } }
        public Dictionary<string, double> fillingPriceList { get { return  _inventory.Where(item => item.Name == "filling").ToDictionary(item => item.Variant, item => item.Price); } }
    }
}
