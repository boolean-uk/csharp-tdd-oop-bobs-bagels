using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class BagelShop
    {
        private Dictionary<string, Product> _category = new Dictionary<string, Product>();

        public BagelShop()
        {
            _category.Add("BGLO", CreateProduct("BGLO", 0.49, "Bagel", "Onion"));
            _category.Add("BGLP", CreateProduct("BGLP", 0.39, "Bagel", "Plain"));
            _category.Add("BGLE", CreateProduct("BGLE", 0.49, "Bagel", "Everything"));
            _category.Add("BGLS", CreateProduct("BGLS", 0.49, "Bagel", "Sesame"));

            _category.Add("COFB", CreateProduct("COFB", 0.99, "Coffee", "Black"));
            _category.Add("COFW", CreateProduct("COFW", 1.19, "Coffee", "White"));
            _category.Add("COFC", CreateProduct("COFC", 1.29, "Coffee", "Capuccino"));
            _category.Add("COFL", CreateProduct("COFL", 1.29, "Coffee", "Latte"));

            _category.Add("FILB", CreateProduct("FILB", 0.12, "Filling", "Bacon"));
            _category.Add("FILE", CreateProduct("FILE", 0.12, "Filling", "Egg"));
            _category.Add("FILC", CreateProduct("FILC", 0.12, "Filling", "Cheese"));
            _category.Add("FILX", CreateProduct("FILX", 0.12, "Filling", "Cream Cheese"));
            _category.Add("FILS", CreateProduct("FILS", 0.12, "Filling", "Smoked Salmon"));
            _category.Add("FILH", CreateProduct("FILH", 0.12, "Filling", "Ham"));
        }

        // Maybe add terminal interaction to main
        public static void Main(string[] args)
        {
            BagelShop shop = new BagelShop();
            Basket basket = shop.GrabBasket();
            basket.ChangeCapacity(100);

            bool result1 = basket.Add("BGLO", 2);
            bool result2 = basket.Add("BGLP", 12);
            bool result3 = basket.Add("BGLE", 6);
            bool result4 = basket.Add("COFB", 3);

            var sb = shop.ReceiptPrinter(basket);
            Console.WriteLine(sb);
        }

        public StringBuilder ReceiptPrinter(Basket basket)
        {
            var sb = new StringBuilder();
            Dictionary<string, ProductOrder> orders = basket.ProductOrders;

            sb.AppendLine("    ~~~ Bob's Bagels~~~    \n");
            sb.AppendLine($"    {DateTime.Now.ToString()}    \n");
            sb.AppendLine("----------------------------\n");

            double discount = 0;

            foreach (var (sku, po) in orders) {
                string orderName = $"{po.Product.Variant} {po.Product.Name}".PadRight(18);
                string orderAmount = $"{po.Amount}".PadRight(5);
                string orderPrice = $"£{Math.Round(po.Cost - po.Discount, 2)}";
                sb.AppendLine(orderName + orderAmount + orderPrice);
                if (po.Discount > 0)
                {
                    sb.AppendLine($"(-£{po.Discount})".PadLeft(29));
                    discount += po.Discount;
                }
            }
            sb.AppendLine("----------------------------\n");

            if (discount > 0)
            {
                sb.AppendLine($" You saved a total of £{discount}");
                sb.AppendLine("".PadRight(6) + "on this purchase!\n");
            }

            string total = "Total" + $"£{basket.SumOfItems}".PadLeft(23);
            sb.AppendLine(total + "\n");

            sb.AppendLine("".PadRight(9) + "Thank you");
            sb.AppendLine("".PadRight(6) + "for your order!");
            return sb;
        }

        private Product CreateProduct(string sku, double price, string name, string variant)
        {
            switch (name)
            {
                case "Bagel":
                    return new Bagel(sku, price, name, variant);
                case "Coffee":
                    return new Coffee(sku, price, name, variant);
                case "Filling":
                    return new Filling(sku, price, name, variant);
            }
            return null;
        }
        public Basket GrabBasket()
        {
            return new Basket(_category);
        }

        public Dictionary<string, Product> Category { get { return _category; } }
    }
}
