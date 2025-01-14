using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Classes.Products;

namespace exercise.main.Classes
{
    public class Order
    {
        private List<Tuple<string, string, string>> items = new List<Tuple<string, string, string>>();
        private List<string> skus = new List<string>();
        private decimal orderTotal = 0;

        public Order(Basket basket, Inventory inventory)
        {
            decimal currentTotal = 0;

            foreach (Product product in basket.GetProducts())
            {
                skus.Add(product.Sku);
                if (product.Name == "Bagel")
                {
                    Bagel bagel = (Bagel) product;
                    bagel.GetFillings().ForEach(f => skus.Add(f.Sku));
                }
            }

            foreach(string sku in skus)
            {
                currentTotal += inventory.GetProductPrice(sku) ?? 0;
            }

            UpdateOrderTotal(currentTotal);
        }

        public List<string> GetSkus() { return skus; }

        public decimal GetOrderTotal() { return orderTotal; }

        public void UpdateOrderTotal(decimal newOrderTotal) {  orderTotal = newOrderTotal; }

        public decimal CalculateDiscount(string sku, int quantity)
        {
            if (sku == null || quantity == 0) return 0;

            decimal discount = 0;

            if (sku == "BGLP")
            {
                if (quantity >= 12)
                {
                    int full12Sets = quantity / 12;
                    discount += 0.69M * full12Sets;
                }

                int remainingAfter12 = quantity % 12;
                // 6 plain bagels will be more expensive for 2.49.
                /*if (remainingAfter12 >= 6)
                {
                    int full6Sets = remainingAfter12 / 6;
                    discount += 0.45M * full6Sets;
                }*/
            }
            else if (sku.StartsWith("BGL"))
            {
                if (quantity >= 12)
                {
                    int full12Sets = quantity / 12;
                    discount += 1.89M * full12Sets;
                }

                int remainingAfter12 = quantity % 12;
                if (remainingAfter12 >= 6)
                {
                    int full6Sets = remainingAfter12 / 6;
                    discount += 0.45M * full6Sets;
                }
            }

            return discount;
        }

        public void ApplyDiscounts(Basket basket, Inventory inventory)
        {
            decimal totalDiscount = 0;
            decimal currentTotal = 0;

            List<string> uniqueSkus = new List<string>();
            basket.GetProducts().ForEach(p => { if (!uniqueSkus.Contains(p.Sku)) { uniqueSkus.Add(p.Sku); } });

            foreach (string sku in uniqueSkus)
            {
                int skuCount = basket.GetProducts().Count(p => p.Sku == sku);
                decimal skuPrice = inventory.GetProductPrice(sku) ?? 0;

                currentTotal += skuPrice * skuCount;

                decimal discount = CalculateDiscount(sku, skuCount);
                totalDiscount += discount;
            }

            UpdateOrderTotal(currentTotal - totalDiscount);
        }
    }
}
