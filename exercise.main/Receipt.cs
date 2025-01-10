using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Items;

namespace exercise.main
{
    public class Pair<T1, T2>
    {
        public required T1 Left { get; set; }
        public required T2 Right { get; set; }
    }
    public class Receipt
    {
        //public static 

        private Dictionary<string, Pair<Item, int>> _itemList;
        public Dictionary<string, Pair<Item, int>> ItemList {  get { return _itemList; } }
        private Receipt(Dictionary<string, Pair<Item, int>> itemList)
        {
            _itemList = itemList;
        }

        public float GetTotalPriceWithoutDiscounts()
        {
            return _itemList.Select(a => a.Value.Right * a.Value.Left.Price).Sum();
        }

        public static Receipt GetReceipt(List<Item> basket)
        {
            Dictionary<string, Pair<Item, int>> itemList = [];
            var AddItemToList = (Item i) =>
            {
                if (itemList.ContainsKey(i.Id))
                {
                    itemList[i.Id].Right += 1;
                }
                else
                {
                    itemList.Add(i.Id, new Pair<Item, int> { Left = i, Right = 1 });
                }
            };

            foreach (Item item in basket)
            {
                if (item is Bagel)
                {
                    ((Bagel)item).Fillings.ForEach(AddItemToList);
                }
                AddItemToList(item);
            }

            return new Receipt(itemList);
        }
    }
}
