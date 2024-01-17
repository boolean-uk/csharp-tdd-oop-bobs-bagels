using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Objects
{
    public class Basket
    {
        public List<Product> basket { get; } = new List<Product>();
        public List<Product> discountBasket { get; } = new List<Product>();
        public Inventory inventory = new Inventory();
        public static int limit = 30;
        public struct Discount (string sku, int amount, double price)
        {
            public string SKU = sku;
            public int amountRequired = amount;
            public double price = price;
        }

        private List<Discount> _bagelDiscounts = new List<Discount>()
        {
            new Discount("BGLP",12,3.99d),
            new Discount("BGLO",6,2.49d),
            new Discount("BGLE",6,2.49d)
        };
        
        public Basket()
        {

        }
        public bool Add(string SKU)
        {
            Product foundItem = inventory.items.FirstOrDefault(item => item.SKU == SKU);

            int bagelAmount = basket.Count(t => t.Type == Product.pType.Bagel);
            //check if basket is full, if string is empty and if item exists in inventory
            if (foundItem != null && (bagelAmount <= limit))
            {
                basket.Add(foundItem);
                return true;
            }         
            return false;
            
        }
        public bool Remove(string SKU)
        {
            Product foundItem = basket.FirstOrDefault(item => item.SKU == SKU);
            if (foundItem != null)
            {
                basket.Remove(foundItem);
                return true;
            }
            return false;
        }
        protected internal bool BasketSize(int newSize)
        {
            if (newSize < 0)
                return false;

            limit = newSize;
            return true;
        }

        public double Sum()
        {
            var result = checkDiscountsBagels();
            List<Product> filling = result.Item1;
            List<Discount> DiscountedBagelPrices = result.Item2;

            var coffee = coffeeBagelDeal();

            double sum = 0;

            sum += DiscountedBagelPrices.Sum(item => item.price);
            sum += filling.Sum(item => item.Price);

            sum += coffee.Item1;
            sum += coffee.Item2.Sum(item => item.Price);
            
            
            //Add the non discounted basket to the sum
            sum += basket.Sum(item => item.Price);
            foreach (var item in basket)
            {

                if(item.Filling.Count > 0)
                {
                    sum += item.Filling.Sum(t => t.Price);
                }
            }
            

            return Math.Round(sum,2);
        }

        public (double, List<Product>) coffeeBagelDeal()
        {
            double sum = 0;
            List<Product> filling = new();
            while (basket.Exists(t => t.SKU == "COFB") && basket.Exists(t => t.Type == Product.pType.Bagel))
            {
                var bagel = basket.FirstOrDefault(t => t.Type == Product.pType.Bagel);
                var coffee = basket.FirstOrDefault(t => t.SKU == "COFB");
                if (bagel.Filling.Count > 0)
                {
                    filling.AddRange(bagel.Filling);
                }
                discountBasket.Add(bagel);
                discountBasket.Add(coffee);

                sum += 1.25d;
                
                
                basket.Remove(bagel);
                basket.Remove(coffee);
            }
            return (sum, filling);
        }
        public (List<Product>,List<Discount>) checkDiscountsBagels()
        {
            List<Discount> prices = new() ;
            List<Product> filling = new();

            //Check each of our Bagel discount structs
            foreach (var discount in _bagelDiscounts)
            {
                int amount = basket.Where(t => t.SKU == discount.SKU).Count();
                if (amount >= discount.amountRequired)
                {
                    //Check if the condition is met multiple times
                    int mod = amount % discount.amountRequired;
                    //This will be 1 if the condition is only met once, never zero
                    int repeated = (amount - mod) / discount.amountRequired;
                    //Add the group to a separate list, remove them from basket
                    MoveProduct(discount.SKU, discount.amountRequired * repeated);
                    prices.Add(new Discount(discount.SKU,discount.amountRequired*repeated,discount.price*repeated));
                    
                }
            }
            foreach (var item in discountBasket)
            {
                if (item.Filling.Count>0)
                {
                    //If there is filling, add it to the filling list, remove the filling from 
                    filling.AddRange(item.Filling);
                    item.Filling.Remove(item);
                }
            }


            return (filling,prices);
        }

        public bool MoveProduct(string productSKU, int quantityToMove)
        {
            if (!basket.Any(t=> t.SKU == productSKU) || quantityToMove <= 0)
            {
                return false;
            }
            int movedCount = 0;

            // Iterate through the source basket and move products to the target basket
            for (int i = basket.Count - 1; i >= 0 && movedCount < quantityToMove; i--)
            {
                if (basket[i].SKU == productSKU)
                {
                    // Move the product from the source to the target basket
                    discountBasket.Add(basket[i]);
                    basket.RemoveAt(i);

                    movedCount++;
                }
            }
            return true;
        }





    }
}
