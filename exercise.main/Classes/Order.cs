using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Classes.Products;

namespace exercise.main.Classes
{
    public class Order
    {
        private List<OrderItem> items = new List<OrderItem>();
        private List<string> skus = new List<string>();
        private decimal? orderTotal = 0;

        public Order(Basket basket, Inventory inventory)
        {
            decimal? currentTotal = 0;

            foreach (Product product in basket.GetProducts())
            {
                skus.Add(product.Sku);
                if (product.Name == "Bagel")
                {
                    Bagel bagel = (Bagel)product;
                    bagel.GetFillings().ForEach(f => skus.Add(f.Sku));
                }
            }

            List<string> uniqueSkus = skus.Distinct().ToList();

            foreach (string uniqueSku in uniqueSkus)
            {
                int skuCount = skus.Count(sku => sku == uniqueSku);
                OrderItem item = skuToItem(uniqueSku, skuCount, inventory);
                addItem(item);
            }

            CreateCoffeeBagelCombinations(); // Not implemented

            foreach (OrderItem item in items)
            {
                currentTotal += item.Price;
            }

            UpdateOrderTotal(currentTotal);
        }

        public OrderItem skuToItem(string sku, int quantity, Inventory inventory)
        {
            string itemName = $"{inventory.GetProductVariant(sku)} {inventory.GetProductName(sku)}";
            decimal? originalPrice = inventory.GetProductPrice(sku) * quantity;
            decimal discount = CalculateDiscount(sku, quantity);
            decimal? finalPrice = originalPrice - discount;
            decimal? savings = originalPrice - finalPrice;

            decimal? itemPrice = originalPrice;

            return new OrderItem(sku, itemName, quantity, itemPrice, savings);
        }

        public void addItem(OrderItem item)
        {
            items.Add(item);
        }

        public List<string> GetSkus() { return skus; }

        public List<OrderItem> GetItems() { return items; }
        
        public decimal? GetOrderTotal() { return orderTotal; }

        public void UpdateOrderTotal(decimal? newOrderTotal) { orderTotal = newOrderTotal; }

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

        public void ApplyDiscounts()
        {
            decimal totalDiscount = 0;

            foreach (OrderItem item in items)
            {
                totalDiscount += item.Savings ?? 0m;
            }

            decimal currentTotal = GetOrderTotal() ?? 0m;
            UpdateOrderTotal(currentTotal - totalDiscount);
        }

        public string OrderToSms()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Order Summary:");

            foreach (var item in items)
            {
                sb.AppendLine($"{item.ItemName} x{item.Quantity} - {item.Price:C2}");
                if (item.Savings > 0)
                {
                    sb.AppendLine($"   Savings: {item.Savings:C2}");
                }
            }

            sb.AppendLine($"Total: {GetOrderTotal():C2}");
            sb.AppendLine($"Estimated Delivery: {DateTime.Now.AddMinutes(30):hh:mm tt}");
            return sb.ToString();
        }

        public void CreateCoffeeBagelCombinations()
        {
            
        }
    }
}
