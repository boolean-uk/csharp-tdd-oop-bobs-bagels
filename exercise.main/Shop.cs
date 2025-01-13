using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Items;

namespace exercise.main
{
    public class Shop
    {
        private const int width = 40;

        private readonly Dictionary<string, List<Item>> _inventory = new()
        {
            { "Bagel", new() {
                    new Bagel("Onion", .49f),
                    new Bagel("Plain", .39f),
                    new Bagel("Everything", .49f),
                    new Bagel("Sesame", .49f),
            } },
            { "Coffee", new()
            {
                new Coffee("Black", .99f),
                new Coffee("White", 1.19f),
                new Coffee("Capuccino", 1.29f),
                new Coffee("Latte", 1.29f),
            } },
            { "Filling", new()
            {
                new Filling("Bacon", .12f),
                new Filling("Egg", .12f),
                new Filling("Cheese", .12f),
                new Filling("Cream Cheese", .12f),
                new Filling("Smoked Salmon", .12f),
                new Filling("Ham", .12f),
            } }
        };
        private Role _role;
        private Basket _basket;

        public Shop(Role role)
        {
            _role = role;
            _basket = new Basket();
        }

        #region Private methods
        private void PlacementHelper(string message, int lineLength, string alignment, StringBuilder o)
        {
            int centerIdx = lineLength / 2;
            string edge;
            switch (alignment)
            {
                case "center":
                    edge = new string(' ', centerIdx - (message.Length / 2));
                    o.AppendLine($"{edge}{message}{edge}");
                    break;
                case "right":
                    edge = new string(' ', lineLength - message.Length);
                    o.AppendLine($"{edge}{message}");
                    break;
                default:
                    edge = new string(' ', lineLength - message.Length);
                    o.AppendLine($"{message}{edge}");
                    break;
            }
        }
        private void PlacementHelper(string left, string center, string right, int lineLength, int centerRightDistance, StringBuilder o)
        {
            o.Append(left);
            o.Append(new string(' ', lineLength - left.Length - center.Length - right.Length - centerRightDistance));
            o.Append(center);
            o.Append(new string(' ', centerRightDistance));
            o.Append(right);
            o.Append('\n');
        }

        #endregion

        public void PrintInventory()
        {
            var sb = new StringBuilder();
            int idx = 1;
            PlacementHelper("~~~ Inventory ~~~", width, "center", sb);
            sb.AppendLine();
            foreach (var item in _inventory)
            {
                sb.AppendLine(new string('-', width));
                int localIdx = 1;
                item.Value.ForEach(item =>
                {
                    sb.AppendLine($"{idx}{localIdx++} - {item}");
                });
                idx++;
            }
            sb.AppendLine(new string('-', width));
            PlacementHelper("Fillings can only be", width, "center", sb);
            PlacementHelper("bought with bagels!", width, "center", sb);
            sb.AppendLine();
        
            Console.WriteLine(sb.ToString());
        }

        public Item? AddItem(string key)
        {
            string mainKey = _inventory.Keys.ToList()[Int32.Parse(key[0].ToString()) - 1];
            Item item = _inventory[mainKey][Int32.Parse(key[1].ToString()) - 1];
            if (!_basket.Add(item)) {Console.WriteLine("Your basket is full!"); return null; }
            return item;
        }

        public void PrintBasket()
        {
            var sb = new StringBuilder();
            PlacementHelper("~~~ Basket ~~~", width, "center", sb);
            sb.AppendLine();
            sb.AppendLine(new string('-', width));
            _basket.Items.ForEach(item => {
                sb.AppendLine($"{item.Name} {item.Variant}");
            });
            sb.AppendLine(new string('-', width));
            Console.WriteLine(sb.ToString());
        }

        public void PrintReceipt()
        {
            const int centerRightDistance = 7;
            Receipt receipt = _basket.TotalCost;
            var outReceipt = new StringBuilder();
            PlacementHelper("~~~ Bob's Bagels ~~~", width, "center", outReceipt);
            outReceipt.AppendLine();
            PlacementHelper(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), width, "center", outReceipt);
            outReceipt.AppendLine();
            outReceipt.AppendLine(new string('-', width));
            outReceipt.AppendLine();

            float preDiscountTotal = receipt.GetTotalPriceWithoutDiscounts();
            float total = receipt.GetTotalPrice();
            foreach (var row in receipt.PriceLog)
            {
                float saved = row.Item1.Sum(a => a.Price) - row.Item3;
                if (saved > 0)
                {
                    string name = string.Join(", ", row.Item1.Select(i => $"{i.Name} {i.Variant}").Distinct());
                    PlacementHelper(name, row.Item2.ToString(), $"£{row.Item3}", width, centerRightDistance, outReceipt);
                    PlacementHelper($"(-£{saved:F2})", width, "right", outReceipt);
                } else
                {
                    Item item = row.Item1.First();
                    PlacementHelper($"{item.Name} {item.Variant}", row.Item2.ToString(), $"£{row.Item3}", width, centerRightDistance, outReceipt);
                }
            }
            outReceipt.AppendLine();
            outReceipt.AppendLine(new string('-', width));
            PlacementHelper("Total", "", $"£{total}", width, centerRightDistance, outReceipt);
            outReceipt.AppendLine();

            if (preDiscountTotal - total > 0) PlacementHelper($"You saved a total of £{preDiscountTotal - total:F2}", width, "center", outReceipt);
            outReceipt.AppendLine();
            PlacementHelper($"Thank you", width, "center", outReceipt);
            PlacementHelper($"for your order!", width, "center", outReceipt);

            Console.WriteLine(outReceipt.ToString());  
        }

        public void DoShopping()
        {
            bool exit = false;
            while (!exit)
            {
                PrintInventory();
                PrintBasket();
                Console.WriteLine("What do you want to buy?");
                Console.Write("Item ID (e.g. 11) to buy, or \"exit\" to exit: ");
                string input = Console.ReadLine().ToLower();
                if (input.Length == 2)
                {
                    try
                    {
                        Item item = AddItem(input);
                        if (item is Bagel)
                        {
                            Console.WriteLine($"Do you want any filling with this {item.Name} {item.Variant}?");
                            Console.Write("The id (e.g. 31) of filling or anything else to exit: ");
                            string fillingInput = Console.ReadLine().ToLower();
                            try
                            {
                                int firstNum = Int32.Parse(fillingInput[0].ToString());
                                if (firstNum != 3) throw new Exception("Not a filling!");
                                Filling filling = (Filling) _inventory["Filling"][Int32.Parse(fillingInput[1].ToString()) - 1];
                                ((Bagel) item).AddFilling(filling);
                            } catch
                            {
                                Console.WriteLine("No filling it is!");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Either we dont have that item or the ID is misformated!");
                    }
                }
                else if (input == "exit") { break; 
                } else {
                    Console.WriteLine("I'm sorry, I did not understand that. Please try again...");
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine("Thank you for shopping!");
            Console.WriteLine("Here is your receipt!");
            PrintReceipt();
        }
    }
}
