using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private List<Product> _productList { get; set; } = new List<Product>();


        //adds item to list if there is room
        public bool Add(Product product)
        {
            Inventory inventory = new Inventory();

            //ugly but works
            if (_productList.Count < MaxCapacity && inventory.Products.Find(p => p.SKU == product.SKU).SKU == product.SKU) 
            {
                _productList.Add(product);
                return true;
            }

            //add max cap check
            return false;
        }

        //better add method for filling and stuff
        /*
        public decimal GetTotalCost()
        {
            decimal totalCost = 0M;

            foreach(Product Product in _productList)
            {
                totalCost += Product.Price;
            }

            return totalCost;      
        }*/

        public bool Remove(Product removableItem)
        {
            if (_productList.Contains(removableItem))
            {
                _productList.Remove(removableItem);
                return true;
            }

            return false;
        }

        public decimal GetTotalCost()
        {
            decimal totalCost = 0M;
            //maybe take in total monaey saved for the receipt later?
            (List<Product> noDiscountList, decimal discontShmoney) = CheckForDiscount();

            totalCost += discontShmoney;

            foreach (Product p in noDiscountList)
            {
                totalCost += p.Price;
            }

            //some random tests
            Console.WriteLine($"total cost {totalCost}");
            Console.WriteLine(discontShmoney);
            Console.WriteLine(noDiscountList.Count());
            return totalCost;
        }

        public (List<Product> noDiscountList, decimal totalDiscount) CheckForDiscount()
        {
            //new temp list of all items in basket
            List<Product> product = _productList;

            decimal totalDiscount = 0;
            decimal totalMoneySaved = 0;
            bool discountsExist = true;

            //list of bagel SKU's, maybe change to get only the SKUs of bagels in the basket?
            List<string> bagelSKUList  = new List<string> { "BGLO", "BGLP", "BGLE", "BGLS" };

            //loop through tempList (while there is discountable(?) items in list)
            while (discountsExist)
            {
                //loop through bagel SKUs 
                foreach (string bagelSKU in bagelSKUList)
                {
                    //check if there is 12 bagels of same type
                    if (product.Where(p => p.SKU == bagelSKU).Count() >= 12)
                    {
                        //price of product times 12 - discounted price
                        totalMoneySaved += ((product.Where(p => p.SKU == bagelSKU).First().Price) * 12) - 3.99M;

                        //remove 12 bagels of said type
                        for (int i = 0; i < 12; i++)
                        {
                            product.Remove(product.Where(p => p.SKU == bagelSKU).First());
                        }
                        //add discount price to total
                        totalDiscount += 3.99M;
                        discount = true;

                    }
                    if (product.Where(p => p.SKU == bagelSKU).Count() >= 6)
                    {
                        //price of product times 6 - discounted price
                        totalMoneySaved += ((product.Where(p => p.SKU == bagelSKU).First().Price) * 6) - 2.49M;

                        //remove 6 bagels of same type
                        for (int i = 0; i < 6; i++)
                        {
                            product.Remove(product.Where(p => p.SKU == bagelSKU).First());
                        }
                        //add discount
                        totalDiscount += 2.49M;
                        discount = true;
                        
                        continue; 
                    }
                }

                //bagel + coffee check for only 1.25$ wow! what a deal!
                if (product.Where(p => p.Name == "Bagel").Count() > 0 && product.Where(p => p.Name == "Coffee").Count() > 0)
                {
                    //price of coffee + bagel - discounted price
                    decimal bagelPrice = product.Where(p => p.Name == "Bagel").First().Price;
                    decimal coffeePrice = product.Where(p => p.Name == "Coffee").First().Price;
                    totalMoneySaved = bagelPrice + coffeePrice - 1.25M;

                    //remove one bagel and one coffee
                    product.Remove(product.Where(p => p.Name == "Bagel").First());
                    product.Remove(product.Where(p => p.Name == "Coffee").First());

                    //"add discount" aka replace items with discount price
                    totalDiscount += 1.25M;
                    discount = true;

                    continue;
                }

                //break 
                discountsExist = false;
            }

            return (product, totalDiscount);
        }

        public void PrintReceipt()
        {
            List<Product> uniqueProduct = _productList.Distinct().ToList();

            Console.WriteLine("    ~~~ Bob's Bagels ~~~    ");
            Console.WriteLine("");
            Console.WriteLine($"   {DateTime.Now}");
            Console.WriteLine($"");
            Console.WriteLine($"----------------------------");
            Console.WriteLine($"");

            int numOfItems = 0;
            decimal totalCost = 0;
            //Loop that prints items in basket
            foreach(Product p in uniqueProduct)
            {
                numOfItems = _productList.Where(prod => p.SKU == prod.SKU).Count();
                Console.WriteLine($"{p.Variant} {p.Name}\t{numOfItems}\t{p.Price * (numOfItems)}$");
                totalCost += p.Price;
            }

            Console.WriteLine($"");
            Console.WriteLine($"----------------------------");
            Console.WriteLine($"Total\t\t\t{totalCost}$");

            if(discount == true)
            {
                Console.WriteLine($" You saved a total of {5}$ ");
            }
            Console.WriteLine($"        Thank you        ");
            Console.WriteLine($"      for your order!      ");
            
        }

        public int MaxCapacity { get; set; } = 20;
        
        public bool discount = false;
        public List<Product> ProductList { get { return _productList; } }

        public int totalCost { get; set; }

    
    }
}
