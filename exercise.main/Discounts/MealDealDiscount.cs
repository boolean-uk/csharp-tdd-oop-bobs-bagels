using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Items;

namespace exercise.main.Discounts
{
    public class MealDealDiscount : Discount
    {
        private string _firstKey;
        private string _secondKey;
        private int _firstCount;
        private int _secondCount;
        private float _price;
        public MealDealDiscount(string firstKey, string secondKey, int firstCount, int secondCount, float price)
        {
            _firstKey = firstKey;
            _secondKey = secondKey;
            _firstCount = firstCount;   
            _secondCount = secondCount;
            _price = price;
        }

        public override void GetDiscount(Dictionary<string, List<Item>> itemList, List<Tuple<List<Item>, int, float>> log)
        {
            var firstList = itemList.Where(i => i.Key.Contains(_firstKey) && i.Value.Count >= _firstCount).SelectMany(i => i.Value);
            var secondList = itemList.Where(i => i.Key.Contains(_secondKey) && i.Value.Count >= _secondCount).SelectMany(i => i.Value);

            int repeats = Math.Min(firstList.Count() / _firstCount, secondList.Count() / _secondCount);
            for (int i = 0; i < repeats; i++)
            {
                var first = firstList.Take(_firstCount).ToList();
                var second = secondList.Take(_secondCount).ToList();
                log.Add(new Tuple<List<Item>, int, float>(first.Concat(second).ToList(), 1, _price));
                foreach (var item in first)
                {
                    itemList[item.Id].RemoveAt(itemList[item.Id].Count - 1);
                    if (itemList[item.Id].Count == 0) itemList.Remove(item.Id);
                }
                foreach (var item in second)
                {
                    itemList[item.Id].RemoveAt(itemList[item.Id].Count - 1);
                    if (itemList[item.Id].Count == 0) itemList.Remove(item.Id);
                }
            }
        }
    }
}
