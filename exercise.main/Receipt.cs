namespace exercise.main
{
    public static class Receipt
    {
        public static void Print(Basket basket)
        {
            var content = basket.GetContents();
            string title = "~~~ Bob's Bagels ~~~";
            string date = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            string border = new('-', title.Length * 2);
            float totalDiscount = PriceCalculator.CalculateDiscounts(basket.GetContents());
            var foodGroups = content.GroupBy(x => x.FullName)
                .Select(group => new
                {
                    Name = group.Key,
                    Count = group.Count(),
                    Price = PriceCalculator.GetTotalPrice([..group]),
                    Discount = PriceCalculator.CalculateDiscounts([..group])
                });

            Console.WriteLine(
                $"\t{title, 10}\n\n" +
                $"\t{date, 10}\n\n" +
                $"{border, 10}\n");
            foreach (var group in foodGroups)
            {
                Console.WriteLine(
                    $"{group.Name, -10}{group.Count, 10}{group.Price, 18:0.00}$");
                if (group.Discount > 0)
                {
                    Console.Write("\t{0, 35}", $"-({group.Discount:0.00}$)\n");
                }
            }
            Console.WriteLine(
                $"{border}\n" +
                $"Total:" +
                $"\t{basket.GetTotalPrice(), 30:0.00}$");
            Console.WriteLine("{0,25}\n{1,25}", $"You saved {totalDiscount:0.00}$", "on this purchase.");
            Console.WriteLine($"\n\t{"Thank you\n", 16}" + $"\t{"for your order!", 18}");
        }
    }
}
