using static exercise.main.PriceCalculator;

namespace exercise.main
{
    public static class Receipt
    {
        private static void PrintFoodItems(IEnumerable<dynamic> foodGroups)
        {
            Console.WriteLine("{0,12}{1,12}{2,12}", "Product", "Amount", "Price");
            foreach (var group in foodGroups)
            {
                Console.WriteLine("{0,12}{1,12}{2,12:0.00}", group.Name, group.Count, group.Price);
                if (group.Discount > 0)
                {
                    Console.Write("{0,40}", $"-({group.Discount:0.00}$)\n");
                }
            }
        }
        public static void Print(Basket basket)
        {
            var content = basket.GetContents();
            string title = "~~~ Bob's Bagels ~~~";
            string date = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            string border = new('-', title.Length * 2);
            float totalDiscount = CalculateDiscounts(basket.GetContents());
            var foodGroups = content.GroupBy(x => x.FullName)
                .Select(group => new
                {
                    Name = group.Key,
                    Count = group.Count(),
                    Price = GetTotalPrice([..group]),
                    Discount = CalculateDiscounts([..group])
                });

            Console.WriteLine(
                $"{title, 30}\n\n" +
                $"{date, 30}\n\n" +
                $"{border, 30}");

            PrintFoodItems(foodGroups);

            Console.WriteLine(
                $"{border}\n" +
                $"Total:" +
                $"{basket.GetTotalPrice(), 30:0.00}$");
            Console.WriteLine("{0,26}\n{1,26}", $"You saved {totalDiscount:0.00}$", "on this purchase.");
            Console.WriteLine($"\n{"Thank you\n", 23}" + $"{"for your order!", 26}");
            Console.WriteLine($"{border,30}");
        }
    }
}
