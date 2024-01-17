using System.Text;

namespace exercise.main
{
    public class Basket
    {
        public List<Item> Items { get; set; }
        private int _capacity;
        public Discount Discounts { get; set; }

        public Basket()
        {
            Items = [];
            _capacity = 39; //Arbitrarily chosen default capacity
            Discounts = new Discount();
        }
        public Basket(int capacity)
        {
            Items = [];
            _capacity = capacity;
            Discounts = new Discount();
        }
        public void AddItem(Item item)
        {
            if (IsFull())
            {
                return;
            }
            Items.Add(item);
        }

        public void AddItems(List<Item> item)
        {
            if (IsFull())
            {
                return;
            }
            Items.AddRange(item);
        }

        public List<Item> GetBagels()
        {
            return Items;
        }

        public bool RemoveItem(Item item)
        {
            if (!Items.Contains(item))
            {
                Console.WriteLine("No such item");
                return false;
            }
            else
            {
                Items.Remove(item);
                return true;
            }
        }

        public bool IsFull()
        {
            return Items.Count >= _capacity;
        }

        public void ChangeBasketCapacity(int v)
        {
            _capacity = v;
        }

        public bool DoesItemExist(Item item)
        {
            return (Items.Contains(item));
        }

        public double GetBasketCost()
        {
            return Items.Sum(x => x.GetPrice());
        }

        public double GetDiscountBasketCost()
        {
            Discounts.CalculateDiscounts(Items);
            return Discounts.GetTotalPrice();
        }

        public Dictionary<DiscountTypes, int> GetDiscountCounts()
        {
            Discounts.CalculateDiscounts(Items);
            return Discounts.GetDiscountCounts();
        }

        public Dictionary<DiscountTypes, double> GetDiscountAmounts()
        {
            Discounts.CalculateDiscounts(Items);
            return Discounts.GetDiscountPrices();
        }

        public double GetTotalDiscount()
        {
            Discounts.CalculateDiscounts(Items);
            return Discounts.GetDiscountAmount();
        }

        public void CreateReceipt()
        {
            Console.WriteLine(ReturnReceipt());
        }

        public string ReturnReceipt()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("           Bob's Bagels ");
            sb.AppendLine($"        {DateTime.Now}");
            Dictionary<string, int> countItems = Items.GroupBy(x => x.Name).ToDictionary(g => g.Key, g => g.Count());
            List<Filling> fillings = Items.Where(x => x.Sku.StartsWith("BGL")).Select(x => (Bagel)x).SelectMany(x => x.GetFillings()).ToList();
            Dictionary<string, int> countFillings = fillings.GroupBy(x => x.Name).ToDictionary(g => g.Key, g => g.Count());

            sb.AppendLine("===================================");
            sb.AppendLine("Item                 Count    Price");
            sb.AppendLine("-----------------------------------");
            foreach (KeyValuePair<string, int> elem in countItems)
            {
                string type = Items.Where(x => x.Name == elem.Key).Select(x => x.Type).First();
                string spacing = new(' ', 24 - (elem.Key.Length + type.Length));
                sb.AppendLine($"{elem.Key} {type}{spacing}{elem.Value}    £{Math.Round(Items.Where(x => x.Name == elem.Key).Sum(x => x.GetPrice()), 2)}");
            }
            foreach (KeyValuePair<string, int> elem in countFillings)
            {
                string type = fillings.Where(x => x.Name == elem.Key).Select(x => x.Type).First();
                string spacing = new(' ', 24 - (elem.Key.Length + type.Length));
                sb.AppendLine($"{elem.Key} {type}{spacing}{elem.Value}    £{Math.Round(fillings.Where(x => x.Name == elem.Key).Sum(x => x.GetPrice()))}");
            }
            sb.AppendLine("-----------------------------------");
            sb.AppendLine("Discount:");
            var counts = GetDiscountCounts();
            var amounts = GetDiscountAmounts();
            foreach (DiscountTypes item in Enum.GetValues(typeof(DiscountTypes)).Cast<DiscountTypes>())
            {
                int count = counts[item];
                if (count == 0) continue;
                double amount = amounts[item];
                string discountTypeString = Discounts.EnumToString(item);
                string spacing = new(' ', 25 - (discountTypeString.Length));
                sb.AppendLine($"{discountTypeString}{spacing}{count}   -£{Math.Round(amount, 2)}");
            }
            sb.AppendLine("-----------------------------------");
            sb.AppendLine($"Sum                           £{Math.Round(GetBasketCost(), 2)}");
            sb.AppendLine($"Total Discount               -£{Math.Round(GetTotalDiscount(), 2)}");
            sb.AppendLine($"Total                         £{Math.Round(GetDiscountBasketCost(), 2)}");
            sb.AppendLine("===================================");
            sb.AppendLine($"            Thank you\n         for your order!     ");
            return sb.ToString();
        }
    }
}
