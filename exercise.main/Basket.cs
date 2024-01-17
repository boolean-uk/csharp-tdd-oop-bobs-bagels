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
            Console.WriteLine("           Bob's Bagels ");
            Console.WriteLine($"        {DateTime.Now}");
            Dictionary<string, int> x = Items.GroupBy(x => x.Name).ToDictionary(g => g.Key, g => g.Count());
            Console.WriteLine("-----------------------------------");
            foreach (KeyValuePair<string, int> item in x)
            {
                string type = Items.Where(x => x.Name == item.Key).Select(x => x.Type).First();
                string spacing = new(' ', 24 - (item.Key.Length + type.Length));
                Console.WriteLine($"{item.Key} {type}{spacing}{item.Value}    £{Items.Where(x => x.Name == item.Key).Sum(x => x.GetPrice())}");
            }
            Console.WriteLine("-----------------------------------");
            var counts = GetDiscountCounts();
            var amounts = GetDiscountAmounts();
            foreach (DiscountTypes item in Enum.GetValues(typeof(DiscountTypes)).Cast<DiscountTypes>())
            {
                int count = counts[item];
                if (count == 0) continue;
                double amount = amounts[item];
                string discountTypeString = Discounts.EnumToString(item);
                string spacing = new(' ', 25 - (discountTypeString.Length));
                Console.WriteLine($"{discountTypeString}{spacing}{count}   -£{Math.Round(amount, 2)}");
            }
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"Sum                           £{Math.Round(GetBasketCost(), 2)}");
            Console.WriteLine($"Total Discount               -£{Math.Round(GetTotalDiscount(), 2)}");
            Console.WriteLine($"Total                         £{Math.Round(GetDiscountBasketCost(), 2)}");
            Console.WriteLine($"            Thank you\n         for your order!     ");
        }
    }
}
