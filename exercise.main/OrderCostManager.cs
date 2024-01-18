using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static exercise.main.BasketManager;
using static exercise.main.Inventory;

namespace exercise.main
{
    public class OrderCostManager
    {
        public class Discount
        {
            public string Name  { get; private set; }
            public int Quantity { get; private set; }
            public double Price { get; private set; }

            public Discount(string name, int quantity, double price)
            { 
                Name = name;
                Quantity = quantity;
                Price = price;
            }
        }

        //The order determines priority.
        private static readonly List<Discount> RunningDiscounts = new List<Discount>
        {
            new Discount("Onion", 6, 2.49),
            new Discount("Plain", 12, 3.99),
            new Discount("Everything", 6, 2.49),
            new Discount("Coffee & Bagel", 1, 1.25)
        };

        public List<Discount> GetDiscounts(Order order)
        {
            List<Discount> discounts = new List<Discount>();

            // Apply bagel discounts
            foreach (var runningDiscount in RunningDiscounts)
            {
                int bagelVariantQuantity = order.Bagels.Count(bagel => bagel.Variant.Name == runningDiscount.Name);
                int howManyTimesDoesItApply = bagelVariantQuantity / runningDiscount.Quantity;

                if (howManyTimesDoesItApply > 0)
                {
                    double discountCost = howManyTimesDoesItApply * runningDiscount.Price;
                    discounts.Add(new Discount(runningDiscount.Name, howManyTimesDoesItApply * runningDiscount.Quantity, discountCost));
                }
            }

            // Apply 'Coffee & Bagel' discount
            Discount? coffeeBagelDiscount = RunningDiscounts.FirstOrDefault(d => d.Name == "Coffee & Bagel");
            if (coffeeBagelDiscount == null || order.Coffees.Count <= 0)
                return discounts;

            List<Bagel>? eligibleBagels = order.Bagels.Where(bagel =>
                !discounts.Any(d => d.Name == bagel.Variant.Name && order.Bagels.Count(b => b.Variant.Name == bagel.Variant.Name) 
                <= d.Quantity)
            ).ToList();

            if (eligibleBagels == null)
                return discounts;

            int discountApplies = Math.Min(order.Coffees.Count, eligibleBagels.Count);

            if (discountApplies > 0)
            {
                double discountCost = discountApplies * coffeeBagelDiscount.Price;
                discounts.Add(new Discount("Coffee & Bagel", discountApplies, discountCost));
            }
            

            return discounts;
        }

        public double Cost(Order order)
        {
            double result = 0;

            List<Discount> discounts = GetDiscounts(order);

            // Handle discounts 
            result += discounts.Sum(d => d.Price);

            // Handle coffees that are not dicounted
            int coffeeAndBagelDiscountCount = discounts.Count(d => d.Name == "Coffee & Bagel");
            result += order.Coffees.Skip(coffeeAndBagelDiscountCount).Sum(c => c.Variant.Price);

            // Handle bagel that are not discounted
            Dictionary<string, int> bagelsInDiscount = discounts
                .Where(d => d.Name != "Coffee & Bagel")
                .ToDictionary(d => d.Name, d => d.Quantity);

            foreach (var bagel in order.Bagels)
            {
                string bagelName = bagel.Variant.Name;

                if (coffeeAndBagelDiscountCount > 0) // Deduct bagels used in 'Coffee & Bagel' discount.
                {
                    coffeeAndBagelDiscountCount--;  
                }
                else if (!bagelsInDiscount.ContainsKey(bagelName) || bagelsInDiscount[bagelName] <= 0)
                {
                    result += bagel.Cost(); 
                }
                else
                {
                    bagelsInDiscount[bagelName] -= 1;  // Deduct from specific bagel discount count
                }
            }         

            return result;
        }
    }
}
