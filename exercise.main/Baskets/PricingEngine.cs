using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Inventories;
using exercise.main.Products;

namespace exercise.main.Baskets
{
    public class PricingEngine
    {
        private readonly List<DiscountRule> _discountRules;

        public PricingEngine()
        {
            _discountRules = new List<DiscountRule>();
            populateDiscountRules();
        }

        private void populateDiscountRules()
        {
            _discountRules.Add(new DiscountRule(new Dictionary<Type, int> { {  typeof(Bagel), 12 } }, 3.99));
            _discountRules.Add(new DiscountRule(new Dictionary<Type, int> { { typeof(Bagel), 6 } }, 2.49));
            _discountRules.Add(new DiscountRule(new Dictionary<Type, int> { { typeof(Bagel), 1 }, { typeof(Coffee), 1 } }, 1.25));
        }

        public Dictionary<Type, int> GroupProductsByType(List<Product> products)
        {
            return products
                .GroupBy(product => product.GetType())
                .ToDictionary(g => g.Key, g => g.Count());
        }

        public Dictionary<Type, int> GroupProductsBy(List<Product> products)
        {
            return products
                .GroupBy(product => product.GetType())
                .ToDictionary(g => g.Key, g => g.Count());
        }

        public double CalculatePrice(List<Product> products)
        {
            var groupedBasketContent = GroupProductsByType(products);

            double totalPrice = 0;

            foreach (DiscountRule rule in _discountRules)
            {
                while (CanApplyDiscount(groupedBasketContent, rule.ProductQuantities))
                {
                    totalPrice += rule.DiscountPrice;
                    removeDiscountedItems(groupedBasketContent, rule.ProductQuantities);
                }
            }


            totalPrice += AddNonDiscountProducts(products, groupedBasketContent);

            return totalPrice;
        }

        public void removeDiscountedItems(Dictionary<Type, int> groupedBasket, Dictionary<Type, int> productQuantities) 
        {
            foreach (var (key, value) in productQuantities) 
            {
                groupedBasket[key] -= value;
            }
        }

        public double AddNonDiscountProducts(List<Product> products, Dictionary<Type, int> groupedBasket)
        {
            double totalPrice = 0;

            foreach (var entry in groupedBasket)
            {
                Type productType = entry.Key; 
                int quantityToAdd = entry.Value;

                totalPrice += products
                    .Where(product => product.GetType() == productType)
                    .Take(quantityToAdd)
                    .ToList().Select(product => product.Price).Sum();
            }

            return totalPrice;
        }


        public bool CanApplyDiscount(Dictionary<Type, int> groupedBasket, Dictionary<Type, int> productQuantities)
        {
            return productQuantities.All(discountItemType => groupedBasket
                                        .ContainsKey(discountItemType.Key) 
                                        && groupedBasket[discountItemType.Key] >= discountItemType.Value);
        }

    }
}
