using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Items;

namespace exercise.main.Discounts
{
    public class AmountDiscount : Discount
    {
        private string _productKey;
        private int _count;
        private float _price;
        public AmountDiscount(string productKey, int count, float price)
        {
            _productKey = productKey;
            _count = count;
            _price = price;
        }
        public override void GetDiscount(Dictionary<string, List<Item>> itemList, List<Tuple<List<Item>, int, float>> log)
        {
            foreach (var row in itemList)
            {
                if (row.Key.Contains(_productKey) && row.Value.Count >= _count)
                {
                    int repeats = row.Value.Count / _count;
                    for (int i = 0; i < repeats; i++)
                    {
                        log.Add(new Tuple<List<Item>, int, float>(row.Value.Slice(0, _count), _count, _price));
                        row.Value.RemoveRange(row.Value.Count - _count, _count);
                    }
                    if (row.Value.Count == 0) itemList.Remove(row.Key);
                }
            }
        }
    }
}
