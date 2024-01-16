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
            string border = new string('-', title.Length * 2);
            Console.WriteLine(
                $"\t{title, 10}\n\n" +
                $"\t{date, 10}\n\n" +
                $"{border, 10}\n");
            foreach(IFood item in content)
            {
                Console.WriteLine(
                    $"{item.Name, -10}{content.Count(x => x.Equals(item)), 10}\n");
            }
            Console.WriteLine(
                $"{border}\n" +
                $"Total:" +
                $"\t{Basket.GetTotalPrice(), 30}$");
            Console.WriteLine($"\n\t{"Thank you\n",16}" + $"\t{"for your order!",18}");
        }
    }
}
