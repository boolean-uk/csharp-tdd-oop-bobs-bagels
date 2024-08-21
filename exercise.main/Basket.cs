using exercise.main.Additions;
using exercise.main.Interfaces;
using exercise.main.Products;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace exercise.main
{
    public class Basket
    {

        public Basket() 
        { 
            Inventory inventory = new Inventory();
            _inventory = inventory.inventory;
            _discounts = inventory.Discounts;
            _additions = inventory.Additions;
        }

        public string Add(string productID)
        {
            if (_capacity <= ProductCount) { return "your basket is full"; }
            if (!InventoryProductIds.Contains(productID)) { return "product does not exist in the inventory"; }

            IProduct product = GetFromInventory(productID);
            _basket.Add(product);
            return "product added to basket";
        }

        public string AddAddition(string productId, string additionId)
        {
            if (!_basket.Select(item => item.SKU).Contains(productId)) { return "Product does not exist in basket";  }
            if (!_additions.Select(item => item.SKU).Contains(additionId)) { return "Addition is not in inventory";  }

            IProduct product = GetFromInventory(productId);
            IAddition addition = GetFromAdditionInventory(additionId);

            if(!(addition.AvailableToProduct == product.Name))
            {
                return "Addition cannot be added to selected product";
            }

            //Maybe a filling capacity
            product.Additions.Add(addition);
            return "Filling added";
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
               
            IProduct product = GetFromInventory(productID);
            _basket.Remove(product);

            return true;
        }

        public IProduct GetFromInventory(string productID)
        {
            return _inventory.First(item => item.SKU.Contains(productID));
        }

        public IAddition GetFromAdditionInventory(string additionId)
        {
            return _additions.First(item => item.SKU.Contains(additionId));
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
        public double GetTotalCostNoDiscount()
        {
            double sum = 0;
            foreach (var product in _basket)
            {
                sum += product.Price;
                sum += product.Additions.Select(a => a.Price).Sum();
            }
            return sum;
        }


        public double GetTotalCost(List<IProduct> basket)
        {
            if (!basket.Any()) {  return 0; }

            List<string> discountProducts = Discounts.SelectMany(item => item.Products).ToList();
            List<IProduct> productsWithDiscount = basket.Where(product => discountProducts.Contains(product.SKU)).ToList();

            if (!productsWithDiscount.Any()) { return GetTotalCostNoDiscount(); }

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

            //Assumes the fillings are not on discount for now
            foreach(var product in _basket)
            {
                sum += product.Additions.Select(item => item.Price).Sum();
            }

            //The rest
            sum += productsWithDiscount.Select(item => item.Price).Sum();
            sum += basket.Where(product => !discountProducts.Contains(product.SKU)).Select(product => product.Price).Sum();

            return sum;
        }

        public string PrintReciept()
        {
            List<IProduct> uniqueProducts = _basket.Distinct().ToList();
            List<IProduct> tempProducts = _basket;
            StringBuilder recieptString = new StringBuilder();
            string title = String.Format("{0, 25}", "~~~ Bob's Bagels ~~~");
            string date = String.Format("{0, 24}" , DateTime.Now.ToString());
            string lineBreak = "------------------------------";
            double total = Math.Round(GetTotalCost(_basket), 2);
            double totalNoDisc = Math.Round(GetTotalCostNoDiscount(), 2);

            recieptString.AppendLine(title);
            recieptString.AppendLine();
            recieptString.AppendLine(date);
            recieptString.AppendLine();
            recieptString.AppendLine(lineBreak);
            recieptString.AppendLine();

            //Check for unique items
            foreach (IProduct product in uniqueProducts)
            {
                int productAmount = _basket.Where(item => product.SKU == item.SKU).Count();
                recieptString.Append(String.Format("{0, -19}", product.Name + " " + product.Variant));
                recieptString.Append(String.Format("{0, -7}", productAmount));
                double price = Math.Round(product.Price * productAmount, 2);
                recieptString.AppendLine(price.ToString());

                List<IProduct> toBeDiscounted = _basket.Where(item => item.SKU == product.SKU).ToList();
                double newPrice = Math.Round(GetTotalCost(toBeDiscounted), 2);
                double discountedPrice = Math.Round(price - newPrice, 2);

                if (discountedPrice > 0) 
                {
                    recieptString.AppendLine(String.Format("{0, 30}", "(-£" + discountedPrice + ")"));

                    for (int i = 0; i < toBeDiscounted.Count; i++)
                    {
                        tempProducts.Remove(toBeDiscounted[i]);
                    }

                    recieptString.AppendLine();
                }
            }

            //Check for coffee and bagel combo
            double moneySaved = 0;
            while (tempProducts.Count > 0)
            {   
                if (tempProducts.Any(item => item.SKU.Contains("BGL")) && tempProducts.Any(item => item.SKU.Contains("COFB")))
                {
                    IProduct bagel = tempProducts.First(item => item.SKU.Contains("BGL"));
                    IProduct coffee = tempProducts.First(item => item.SKU.Contains("COF"));

                    tempProducts.Remove(bagel);
                    tempProducts.Remove(coffee);

                    double oldPrice = bagel.Price + coffee.Price;
                    double newPrice = GetTotalCost(new List<IProduct>() { bagel, coffee });

                    moneySaved += Math.Round(oldPrice - newPrice, 2);
                }
                else break;
            }
            
            if (moneySaved > 0)
            {
                recieptString.AppendLine();
                recieptString.Append(String.Format("{0, -22}", "coffe + bagel combo"));
                recieptString.AppendLine("(-£" + moneySaved + ")");
            }

            recieptString.AppendLine(lineBreak);
            recieptString.Append(String.Format("{0, -25}", "Total"));
            recieptString.AppendLine("£" + total);
            recieptString.AppendLine();
            recieptString.AppendLine(String.Format("{0, 27}", "You saved a total of £" + Math.Round(totalNoDisc-total, 2)));
            recieptString.AppendLine(String.Format("{0, 23}", "with discounts"));

            Console.WriteLine(recieptString.ToString());

            return recieptString.ToString();
        }
        public int GetProductCount(string product)
        {
            return _basket.Count(product => product.Name == product.Name);
        }

        private List<IProduct> _basket { get; set; } = new List<IProduct>();

        public List<IProduct> basket { get => _basket; }

        //I know theese are bad, but I do not want to change every basket constructor atm
        private List<IProduct> _inventory; 

        private List<IAddition> _additions;

        private List<Discount> _discounts;

        public List<Discount> Discounts { get { return _discounts; } }
        private int _capacity { get; set; } = 50;

        public int Capacity { get => _capacity; }
        public int ProductCount { get { return _basket.Count; } }

        public List<string> BasketProductIds { get { return _basket.Select(item => item.SKU).ToList(); } }

        public List<string> InventoryProductIds { get { return _inventory.Select(item => item.SKU).ToList();  } }

        public Dictionary<string, double> PriceList { get { return _inventory.ToDictionary(item => item.Variant, item => item.Price); } }
        public Dictionary<string, double> FillingPriceList { get { return  _inventory.Where(item => item.Name == "filling").ToDictionary(item => item.Variant, item => item.Price); } }
    }
}
