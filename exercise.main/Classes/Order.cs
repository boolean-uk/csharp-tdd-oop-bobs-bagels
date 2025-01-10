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
        private List<string> skus = new List<string>();
        private decimal orderTotal = 0;

        public Order(Basket basket)
        {
            decimal currentTotal = 0;

            foreach (Bagel bagel in basket.GetBagels())
            {
                skus.Add(bagel.Sku);
                bagel.GetFillings().ForEach(f => skus.Add(f.Sku));
            }

            foreach(string sku in skus)
            {
                currentTotal += SkuToPrice(sku);
            }

            UpdateOrderTotal(currentTotal);
        }

        public List<string> GetSkus() { return skus; }

        public decimal GetOrderTotal() { return orderTotal; }

        public void UpdateOrderTotal(decimal newOrderTotal) {  orderTotal = newOrderTotal; }

        public decimal SkuToPrice(string sku)
        {
            switch (sku.ToLower())
            {
                case "bglo":
                    return 0.49M;
                case "bglp":
                    return 0.39M;
                case "bgle":
                    return 0.49M;
                case "bgls":
                    return 0.49M;
                case "cofb":
                    return 0.99M;
                case "cofw":
                    return 1.19M;
                case "cofc":
                    return 1.29M;
                case "cofl":
                    return 1.29M;
                default:
                    return 0.12M;
            }
        }

        public void ApplyDiscounts()
        {

        }
    }
}
