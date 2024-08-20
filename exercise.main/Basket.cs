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

            //pass in from ctor ^

            //ugly but works
            if (_productList.Count < MaxCapacity && inventory.Products.Find(p => p.SKU == product.SKU).SKU == product.SKU) 
            {
                _productList.Add(product);
                return true;
            }

            //add max cap check
            return false;
        }

        //better add method for filling and stuff?
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
            //maybe take in total money saved for the receipt later?
            (List<Product> noDiscountList, decimal discontShmoney) = CheckForDiscount();

            totalCost += discontShmoney;

            foreach (Product p in noDiscountList)
            {
                totalCost += p.Price;
            }

            return totalCost;
        }

        public (List<Product> noDiscountList, decimal totalDiscount) CheckForDiscount()
        {
            //new temp list of all items in basket
            List<Product> product = new List<Product>();
            foreach(Product p  in _productList)
            {
                product.Add(p);
            }

            decimal totalDiscount = 0; //The new price for items added up
            decimal totalMoneySaved = 0; //the actual savings (discount price - full price)
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
                        decimal moneySaved = ((product.Where(p => p.SKU == bagelSKU).First().Price) * 12) - 3.99M;
                        totalMoneySaved += moneySaved;

                        //remove 12 bagels of said type
                        for (int i = 0; i < 12; i++)
                        {
                            product.Remove(product.Where(p => p.SKU == bagelSKU).First());
                        }
                        //add discount price to total
                        totalDiscount += 3.99M;
                        DiscountDict[bagelSKU] += moneySaved;
                        discount = true;

                    }
                    if (product.Where(p => p.SKU == bagelSKU).Count() >= 6)
                    {
                        //price of product times 6 - discounted price
                        decimal moneySaved = ((product.Where(p => p.SKU == bagelSKU).First().Price) * 6) - 2.49M;
                        totalMoneySaved += moneySaved;

                        //remove 6 bagels of same type
                        for (int i = 0; i < 6; i++)
                        {
                            product.Remove(product.Where(p => p.SKU == bagelSKU).First());
                        }
                        //add discount
                        totalDiscount += 2.49M;
                        DiscountDict[bagelSKU] += moneySaved;
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
                    decimal moneySaved = bagelPrice + coffeePrice - 1.25M;
                    totalMoneySaved = moneySaved;

                    //remove one bagel and one coffee
                    product.Remove(product.Where(p => p.Name == "Bagel").First());
                    product.Remove(product.Where(p => p.Name == "Coffee").First());

                    //"add discount" aka replace items with discount price
                    totalDiscount += 1.25M;
                    DiscountDict["Coffee and Bagel combo"] += moneySaved;
                    discount = true;

                    continue;
                }

                //break 
                discountsExist = false;
            }

            return (product, totalDiscount);
        }


        public string PrintReceipt() 
        {
            List<Product> uniqueProduct = _productList.Distinct().ToList();

            //stringbuilder
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("    ~~~ Bob's Bagels ~~~    ");
            sb.AppendLine("");
            sb.AppendLine($"   {DateTime.Now}");
            sb.AppendLine($"");
            sb.AppendLine($"----------------------------");
            sb.AppendLine($"");

            int numOfItems = 0;
            decimal totalCost = 0;
            decimal totalDiscount = 0;

            //Get total discount
            foreach (KeyValuePair<string, decimal> kvp in DiscountDict)
            {
                totalDiscount += kvp.Value;
            }

            //Loop that prints items in basket
            foreach (Product p in uniqueProduct)
            {
                numOfItems = _productList.Where(prod => p.SKU == prod.SKU).Count(); //change
                sb.AppendLine($"{p.Variant} {p.Name}\t{numOfItems}\t${p.Price * (numOfItems)}");
                //if discount on curent item. Print discount
                if (p.Name == "Bagel" && DiscountDict[p.SKU] != 0.0M)
                {
                    sb.AppendLine($"\t\t\t(-${DiscountDict[p.SKU]})");
                }

                totalCost += p.Price;
            }
            sb.AppendLine($"");
            sb.AppendLine($"Coffee and Bagel combo discount");
            sb.AppendLine($"\t\t\t(-${DiscountDict["Coffee and Bagel combo"]})");
           
            sb.AppendLine($"");
            sb.AppendLine($"----------------------------");
            sb.AppendLine($"Total\t\t\t${totalCost}");
            sb.AppendLine($"");


            if (discount == true)
            {
                sb.AppendLine($" You saved a total of ${totalDiscount} ");
            }

            sb.AppendLine($"");
            sb.AppendLine($"        Thank you        ");
            sb.AppendLine($"      for your order!      ");

            return sb.ToString();
        }

        public int MaxCapacity { get; set; } = 20;
        
        public bool discount = false;
        public List<Product> ProductList { get { return _productList; } }

        //static for now. maybe change later to add only SKUs from basket?
        public Dictionary<string, decimal> DiscountDict = 
            new Dictionary<string, decimal> { {"BGLO", 0 },{"BGLP", 0 },{"BGLE", 0 },{"BGLS", 0 }, { "Coffee and Bagel combo", 0 } };

        public int totalCost { get; set; }

    
    }
}
