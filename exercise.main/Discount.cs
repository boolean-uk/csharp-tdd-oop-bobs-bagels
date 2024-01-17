namespace exercise.main
{
    public enum DiscountTypes
    {
        TwelveBagels,
        SixBagels,
        CoffeeAndBagel
    }
    public class Discount
    {
        private double _amount = 0;
        private Dictionary<DiscountTypes, int> _discountCount = [];
        private Dictionary<DiscountTypes, double> _discountPrice = [];
        private double _totalPrice = 0;

        public double GetDiscountAmount()
        {
            return _amount;
        }

        public double GetTotalPrice()
        {
            return _totalPrice;
        }

        public Dictionary<DiscountTypes, int> GetDiscountCounts()
        {
            return _discountCount;
        }

        public Dictionary<DiscountTypes, double> GetDiscountPrices()
        {
            return _discountPrice;
        }

        public void CalculateDiscounts(List<Item> items)
        {
            double total = 0;
            Dictionary<DiscountTypes, int> discountCounts = new() { { DiscountTypes.TwelveBagels, 0 }, { DiscountTypes.SixBagels, 0 }, { DiscountTypes.CoffeeAndBagel, 0 } };
            Dictionary<DiscountTypes, double> discountPrices = new() { { DiscountTypes.TwelveBagels, 0 }, { DiscountTypes.SixBagels, 0 }, { DiscountTypes.CoffeeAndBagel, 0 } };
            List<Bagel> bagels = items.Where(x => x.Sku.StartsWith("BGL")).OrderBy(x => x.Sku).Select(x => (Bagel)x).ToList();
            List<Coffee> coffee = items.Where(x => x.Sku.StartsWith("COF")).OrderBy(x => x.Sku).Select(x => (Coffee)x).ToList();
            while (bagels.Count >= 12)
            {
                double difference = bagels.Take(12).Sum(x => x.GetBasePrice()) - 3.99;
                discountPrices[DiscountTypes.TwelveBagels] = difference;
                discountCounts[DiscountTypes.TwelveBagels] += 1;
                total += 3.99;
                total += bagels.Take(12).Sum(x => x.GetFillingPrice());
                bagels.RemoveRange(0, 12);
            }
            while (bagels.Count >= 6)
            {
                double difference = bagels.Take(6).Sum(x => x.GetBasePrice()) - 2.49;
                discountPrices[DiscountTypes.SixBagels] = difference;
                discountCounts[DiscountTypes.SixBagels] += 1;
                total += 2.49;
                total += bagels.Take(6).Sum(x => x.GetFillingPrice());
                bagels.RemoveRange(0, 6);
            }
            while (coffee.Count >= 1 && bagels.Count >= 1)
            {
                double difference = (bagels[0].GetBasePrice() + coffee[0].GetPrice()) - 1.25;
                discountPrices[DiscountTypes.CoffeeAndBagel] = difference;
                discountCounts[DiscountTypes.CoffeeAndBagel] += 1;
                total += 1.25;
                total += bagels[0].GetFillingPrice();
                coffee.RemoveRange(0, 1);
                bagels.RemoveRange(0, 1);
            }
            bagels.ForEach(x => { total += x.GetPrice(); });
            coffee.ForEach(x => { total += x.GetPrice(); });
            _discountCount = discountCounts;
            _discountPrice = discountPrices;
            _amount = discountPrices.Sum(x => x.Value);
            _totalPrice = total;
        }

        public void GetValidDiscounts()
        {
            Console.WriteLine($"Current promotions:\n");
            foreach (var item in Enum.GetValues(typeof(DiscountTypes)).Cast<DiscountTypes>())
            {
                Console.WriteLine($"- {EnumToString(item)}");
            }
        }

        public string EnumToString(DiscountTypes type)
        {
            if (type == DiscountTypes.TwelveBagels)
            {
                return "Bagel x12 for £3.99";
            }
            else if (type == DiscountTypes.SixBagels)
            {
                return "Bagel x6 for £2.49";
            }
            else
            {
                return "Coffee+Bagel for £1.25";
            }
        }
    }
}
