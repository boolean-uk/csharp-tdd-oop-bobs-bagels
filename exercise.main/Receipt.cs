using exercise.main.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Receipt(Basket basket)
    {
        public Basket Basket { get; set; } = basket;

        public void Print()
        {
            var content = Basket.GetContents();
            string title = "~~~ Bob's Bagels ~~~";
            string date = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            string border = new('-', title.Length * 2);
            float discount = 0f;
            var foodGroups = content.GroupBy(x => x.FullName)
                .Select(group => new { Name = group.Key, Count = group.Count(), Price = Basket.GetTotalPrice(group.ToList()), Discount = Basket.CalculateDiscounts(group.ToList()) });

            Console.WriteLine(
                $"\t{title,10}\n\n" +
                $"\t{date,10}\n\n" +
                $"{border,10}\n");
            foreach (var group in foodGroups)
            {
                Console.WriteLine(
                    $"{group.Name,-10}{group.Count,10}{group.Price,18:0.00}$");
                if (group.Discount > 0)
                {
                    Console.Write("\t{0, 35}", $"-({group.Discount}$)\n");
                }
            }
            Console.WriteLine(
                $"{border}\n" +
                $"Total:" +
                $"\t{Basket.GetTotalPrice(),30:0.00}$");
            Console.WriteLine("{0,25}\n{1,25}", $"You saved {Basket.CalculateDiscounts(Basket.GetContents())}$", "on this purchase.");
            Console.WriteLine($"\n\t{"Thank you\n",16}" + $"\t{"for your order!",18}");
        }
    }
}
