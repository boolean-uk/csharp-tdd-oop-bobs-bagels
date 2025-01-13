using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Discounts;
using exercise.main.Items;

namespace exercise.tests
{
    public class DiscountTest
    {
        private Dictionary<string, List<Item>> items;

        [SetUp]
        public void SetUp()
        {
            items = new();
            AddNItem(items, new Bagel("Everything", .49f), 13);
            AddNItem(items, new Bagel("Plain", .39f), 9);
            AddNItem(items, new Coffee("White", 1.19f), 1);
        }

        public void AddNItem(Dictionary<string, List<Item>> items, Item item, int count)
        {
            if (!items.ContainsKey(item.Id))
            {
                items[item.Id] = new List<Item>();
            }
            for (int i = 0; i < count; i++)
            {
                items[item.Id].Add(item);
            }
        }

        [TestCase("BGL", 12, 3.99f, 1)]
        [TestCase("BGLP", 3, 1.49f, 3)]
        [TestCase("COF", 3, 2.49f, 0)]
        public void TestAmountDiscount(string key, int count, float price, int successCount)
        {
            int totalItems = items.Sum(i => i.Value.Count);
            Discount discount = new AmountDiscount(key, count, price);
            List<Tuple<List<Item>, int, float>> log = new();
            discount.GetDiscount(items, log);
            Assert.That(log, Has.Exactly(successCount).Items);
            if (successCount == 0) return;
            Assert.That(log.First().Item1.First().Id, Does.Contain(key));
            Assert.That(log.First().Item2, Is.EqualTo(count));
            Assert.That(log.First().Item3, Is.EqualTo(price));
            Assert.That(log.Sum(i => i.Item2) + items.Sum(i => i.Value.Count), Is.EqualTo(totalItems));
        }

        [TestCase("BGL", "COF", 1, 1, 1.99f, 1)]
        [TestCase("BGLE", "BGLP", 6, 1, 1.99f, 2)]
        [TestCase("COFB", "BGLP", 6, 3, 1.99f, 0)]
        public void TestMealDealDiscount(string key1, string key2, int count1, int count2, float price, int successCount)
        {
            int totalItems = items.Sum(i => i.Value.Count);
            Discount discount = new MealDealDiscount(key1, key2, count1, count2, price);
            List<Tuple<List<Item>, int, float>> log = new();
            discount.GetDiscount(items, log);
            Assert.That(log, Has.Exactly(successCount).Items);
            if (successCount == 0) return;
            Assert.That(log.First().Item1, Has.Exactly(count1 + count2).Items);
            Assert.That(log.First().Item2, Is.EqualTo(1));
            Assert.That(log.First().Item3, Is.EqualTo(price));
            Assert.That(log.Sum(i => i.Item1.Count) + items.Sum(i => i.Value.Count), Is.EqualTo(totalItems));
        }
    }
}
