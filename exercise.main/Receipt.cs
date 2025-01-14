using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Items;
using exercise.main.Discounts;

namespace exercise.main
{
    public class Receipt
    {
        private List<Discount> discounts = [
            new AmountDiscount("BGL", 12, 3.99f),
            new AmountDiscount("BGL", 6, 2.49f),
            new MealDealDiscount("BGL", "COF", 1, 1, 1.25f),
        ];

        private List<Tuple<List<Item>, int, float>> _priceLog = new();

        public List<Tuple<List<Item>, int, float>> PriceLog { get { return _priceLog; } }

        private Dictionary<string, List<Item>> _itemList;
        public Dictionary<string, List<Item>> ItemList {  get { return _itemList; } }
        public Receipt(List<Item> basket)
        {
            _itemList = SetUp(basket);
        }

        public float GetTotalPriceWithoutDiscounts()
        {
            _priceLog.Clear();
            var items = _itemList.ToDictionary(entry => entry.Key, entry => entry.Value.ToList());
            foreach (var row in items)
            {
                _priceLog.Add(new Tuple<List<Item>, int, float>([row.Value.First()], row.Value.Count, row.Value.Sum(i => i.Price)));
            }
            return _priceLog.Sum(i => i.Item3);
        }

        public float GetTotalPrice()
        {
            _priceLog.Clear();
            var items = _itemList.ToDictionary(entry => entry.Key, entry => entry.Value.ToList());
            discounts.ForEach(discount => discount.GetDiscount(items, _priceLog));
            foreach (var row in items)
            {
                _priceLog.Add(new Tuple<List<Item>, int, float>([row.Value.First()], row.Value.Count, row.Value.Sum(i => i.Price)));
            }
            return _priceLog.Sum(i => i.Item3);
        }

        private Dictionary<string, List<Item>> SetUp(List<Item> basket)
        {
            Dictionary<string, List<Item>> itemList = [];

            basket.ForEach(item =>
            {
                item.GetItems().ForEach(i =>
                {
                    if (!itemList.ContainsKey(i.Id))
                    {
                        itemList[i.Id] = new List<Item>();
                    }
                    itemList[i.Id].Add(i);
                });
            });

            return itemList;
        }
    }
}
