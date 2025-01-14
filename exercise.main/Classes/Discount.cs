using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Classes
{
    public class Discount
    {
        private Dictionary<(string SKU, int Quantity), double> _quantityDiscounts;

        private Dictionary<List<string>, double> _comboDiscounts;

        public Discount()
        {
            _quantityDiscounts = new Dictionary<(string, int), double>();
            _comboDiscounts = new Dictionary<List<string>, double>();
        }

        public void AddQuantityDiscount(string sku, int quantity, double discountedPrice)
        {
            _quantityDiscounts.Add((sku, quantity), discountedPrice);
        }

        public void AddComboDiscount(List<string> combo, double value)
        {
            _comboDiscounts.Add(combo, value);
        }
        public double CalculateDiscount(BasketItem item)
        {
            double totalDiscount = 0.0;

            // If we find a discount with a higher quantity, prioritize that one
            int foundDiscountQuantity = 0;

            string sku = item.Product.SKU;


            foreach (var discount in _quantityDiscounts)
            {
                int quantity = item.Amount;
                var (discountSku, discountQuantity) = discount.Key;
                if (discountSku == sku && quantity >= discountQuantity)
                {
                    if (discountQuantity > foundDiscountQuantity)
                    {
                        totalDiscount = 0.0;
                    }
                    foundDiscountQuantity = discountQuantity;
                    int applicableTimes = quantity / discountQuantity;
                    totalDiscount += applicableTimes * discount.Value;

                    quantity %= discountQuantity;
                }
            }

            return totalDiscount;
        }

        public double GetComboDiscount(List<BasketItem> items)
        {
            foreach (var combo in _comboDiscounts)
            {
                var comboProducts = combo.Key;
                double discount = combo.Value;

                bool isValidCombo = comboProducts.All(productId =>
                    items.Any(item => item.Product.SKU == productId));

                if (isValidCombo)
                {
                    return discount;
                }
            }

            return 0.0;
        }

        public void RemoveQuantityDiscount(string sku, int quantity)
        {
            _quantityDiscounts.Remove((sku, quantity));
        }

        public void RemoveComboDiscount(List<string> combo)
        {
            _comboDiscounts.Remove(combo);
        }
    }

}
