using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using exercise.main.Products;

namespace exercise.main
{
    public class Receipt
    {

        private Basket _basket;
        private string _receipt;

        public Receipt(Basket basket)
        {
            _basket = basket;
            _receipt = string.Empty;
        }

        public void GenerateReceipt()
        {

            var productCounts = _basket.ProductCount();
            var priceWithDiscount = this.ComboThenBulkDiscountTotal();
            string receipt = $"\n\n    ~~~ Bob's Bagels ~~~    \n\n    {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}    \n\n-----------------------------\n\n\n";

            foreach(var (product, quantity) in productCounts)
            {
                var (discountedPrice, discount) = this.BulkDiscountSingleItem(product, quantity);
                receipt += $"{product.Variant,-5} {product.Name, -10}{quantity, 3}    £{discountedPrice,4:F2} \n";
                if (discount == 0.0m) continue;
                receipt += $"{" ",21}(-£{discount,4:F2}) \n";
            }

            receipt += $"\n\n-----------------------------\n Total{" ",17}£{this.BulkDiscountTotal(),4:F2} \n";
            if (_basket.Total > priceWithDiscount)
            {
                receipt += $"\n\n You saved a total of £{_basket.Total - priceWithDiscount} \n";
                receipt += "        on this shop\n";
            }

            receipt += "\n         Thank you\n";
            receipt += "      for your order\n";
            receipt += "\n    ~~~ Bob's Bagels ~~~\n";
            _receipt = receipt ;
        }

        public void PrintReceipt()
        {
            GenerateReceipt();
            Console.WriteLine(_receipt);
        }

        public (decimal discountedPrice, decimal discount) BulkDiscountSingleItem(IProduct product, int quantity)
        {
            if (product is Bagel b)
            {
                var originalPrice = quantity * b.Price;
                int numberOfDiscounts = quantity / b.BulkSize;
                int remainder = quantity - numberOfDiscounts * b.BulkSize;

                decimal discountedPrice = numberOfDiscounts * b.BulkDiscountPrice + remainder * b.Price;

                var discount = originalPrice - discountedPrice;

                return (discountedPrice, discount);
            }
            else
            {
                return (product.Price * quantity, 0.0m);
            }
        }

        public decimal BulkDiscountTotal()
        {

            var productCount = _basket.ProductCount();
            decimal totalPrice = 0.0m;
            foreach (var (product, quantity) in productCount)
            {

                if (product is Bagel b)
                {
                    var originalPrice = quantity * b.Price;
                    int numberOfDiscounts = quantity / b.BulkSize;
                    int remainder = quantity - numberOfDiscounts * b.BulkSize;

                    decimal discountedPrice = numberOfDiscounts * b.BulkDiscountPrice + remainder * b.Price;

                    var discount = originalPrice - discountedPrice;

                    totalPrice += discountedPrice;
                }
            }
            return totalPrice;
        }

        public decimal ComboDealTotal()
        {
            var productCount = _basket.ProductCount();
            const decimal comboPrice = 1.25m;
            decimal totalPrice = 0;


            var bagels = productCount
                .Where(p => p.Key is Bagel)
                .OrderBy(p => ((Bagel)p.Key).Price)
                .ToList();

            int totalBlackCoffees = productCount
                .Where(p => p.Key.SKU == "COFB")
                .Sum(p => p.Value);


            // Apply combodeal first
            foreach (var (product, quantity) in bagels)
            {
                if (totalBlackCoffees == 0) break;

                int combos = Math.Min(quantity, totalBlackCoffees);
                totalPrice += combos * comboPrice;

                totalBlackCoffees -= combos;
                productCount[product] -= combos;
            }

            return totalPrice;
        }

        public decimal ComboThenBulkDiscountTotal()
        {
            var productCount = _basket.ProductCount();
            const decimal comboPrice = 1.25m;
            decimal totalPrice = 0;


            var bagels = productCount
                .Where(p => p.Key is Bagel)
                .OrderBy(p => ((Bagel)p.Key).Price)
                .ToList();

            int totalBlackCoffees = productCount
                .Where(p => p.Key.SKU == "COFB")
                .Sum(p => p.Value);


            // Apply combodeal first
            foreach (var (product, quantity) in bagels)
            {
                if (totalBlackCoffees == 0) break;

                int combos = Math.Min(quantity, totalBlackCoffees);
                totalPrice += combos * comboPrice;

                totalBlackCoffees -= combos;
                productCount[product] -= combos;
            }

            // Apply bulk discount on the rest
            foreach (var (product, quantity) in productCount)
            {
                if (quantity <= 0) continue;

                if (product is Bagel b)
                {
                    int numberOfDiscounts = quantity / b.BulkSize;
                    int remainder = quantity % b.BulkSize;

                    totalPrice += (numberOfDiscounts * b.BulkDiscountPrice) + (remainder * b.Price);
                }
                else if (product.SKU == "COFB")
                {
                    totalPrice += totalBlackCoffees * product.Price;
                }
                else
                {
                    totalPrice += quantity * product.Price;
                }
            }

            return totalPrice;
        }
    }
}