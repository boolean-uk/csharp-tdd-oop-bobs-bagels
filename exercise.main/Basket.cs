using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace exercise
{
    public class Basket
    {
        private Inventory inventory = new Inventory();
        public List<Product> products { get; set; } = new List<Product>();

        public int MaxCapacity { get; set; } = 3;

        public bool AddProduct(string sku)
        {
            if (products.Count() == MaxCapacity)
            {
                return false; //Basket is full
            }

            Product? item = inventory.Items.Find(item => item.SKU == sku);

            if (item == null)
                return false; //Product doesn't exist

            Product productClone = new Product(item.SKU, item.Price, item.Name, item.Variant);
            
            products.Add(productClone);
            return true;
        }

        public bool RemoveProduct(string sku)
        {
            Product? item = inventory.Items.Find(item => item.SKU == sku);

            if (item == null)
                return false; //Such item does not exist

            Product? toRemove = products.Find(item => item.SKU == sku);

            if (toRemove == null)
            {
                Console.WriteLine($"Could not find {item.Variant} in your basket.");
                return false;
            }

            products.Remove(toRemove);
            return true;
        }

        public decimal GetTotalCost()
        {
            var discountedCart = ApplyDiscounts(products);

            decimal total = 0;
           
            discountedCart.ForEach(product => total += product.Price);

            return total;
        }

        public decimal GetPrice(string sku)
        {
            Product? item = inventory.Items.Find(item => item.SKU == sku);

            if (item == null)
                return 0;

            return item.Price;
        }

        //Applies discounts to the basket.
        //Assumption: All bagels and coffees included.
        public List<Product> ApplyDiscounts(List<Product> basketItems)
        {
            List<string> bagelTypes = new List<string> { "BGLO", "BGLP", "BGLE", "BGLS" };
            List<Product>? extraBagels = new List<Product>(); //Pair with coffee, if not part of x bagel discount so they don't stack

            foreach (string bagelType in bagelTypes)
            {
                var bagels = basketItems.FindAll(product => product.SKU.StartsWith(bagelType));
                if (bagels == null) continue; //No bagels of that type found

                int bagelCount = bagels.Count();
                int index = 0;
                var remainder = bagels;

                //Check for 12 discount first
                if (bagelCount / 12 > 0)
                {
                    //Calculate amount of times to apply the discount
                    int multiplier = bagelCount / 12;

                    while (index < (12 * multiplier))
                    {
                        var currentBagel = bagels[index];
                        currentBagel.Discount = (currentBagel.Price - 0.3325m); //set discount
                        currentBagel.Price = 0.3325m; //individual price 12 for 3.99
                        
                        index++;
                    }

                    if (bagelCount % 12 == 0)
                        continue; //No more bagels, don't check for 6
                    else
                        remainder = bagels.Slice(index, bagels.Count - 1);
                }

                //check for any remaining 6 discounts in the sliced list
                if (remainder.Count / 6 > 0)
                {
                    int times = 0;

                    while (times < 6)
                    {
                        var currentBagel = bagels[times];
                        
                        currentBagel.Discount =currentBagel.Price - 0.415m; //set discount
                        currentBagel.Price = 0.415m; //individual price 12 for 3.
                        times++;
                    }
                }
                else
                    extraBagels.AddRange(remainder);
            }

            //Coffee and bagel discount
            List<Product> coffees = basketItems.FindAll(product => product.SKU.StartsWith("COF"));
            if (coffees == null || extraBagels.Count == 0)
                return basketItems;

            while (coffees.Count() > 0 && extraBagels.Count() > 0)
            {
                var currentBagel = extraBagels[0];
                var currentCoffee = coffees[0];
                currentBagel.Discount = currentBagel.Price - 0.625m;
                currentCoffee.Discount = currentCoffee.Price - 0.625m;
                currentCoffee.Price = 0.625m;
                currentBagel.Price = 0.625m;

                coffees.RemoveAt(0);
                extraBagels.RemoveAt(0);
            }

            return basketItems;
        }
    }
}
