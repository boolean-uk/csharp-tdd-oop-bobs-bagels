using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Items;

namespace exercise.main.Discounts
{
    public abstract class Discount
    {
        public abstract void GetDiscount(Dictionary<string, List<Item>> itemList, List<Tuple<List<Item>, int, float>> log);
    }
}
