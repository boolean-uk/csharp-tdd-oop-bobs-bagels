using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Discount
    {
        public string DiscountItemSKU { get; set; }
        public int ItemsHit { get; set; }
        public float DiscountPrice { get; set; }
        public int NumberOfDiscountsHit { get; set; }

        public float discountPrice { get; set; }
        public int NumberOfRequiredItems { get; set; }
        public Discount(string itemSKU, int numberOfRequiredItems, float discountPrice)
        {
            this.DiscountItemSKU = itemSKU;
            this.NumberOfRequiredItems = numberOfRequiredItems;
            this.DiscountPrice = discountPrice;
            this.NumberOfDiscountsHit = 0;
            this.ItemsHit = 0;
        }

        public bool CalculateDiscount(Dictionary<Item, int> items)
        {
            if (items.Keys.Where(x => x.SKU == this.DiscountItemSKU).ToList().Count() == 0)
            {
                return false;
            }

            Item foundItem = items.Keys.Where(x => x.SKU == this.DiscountItemSKU).ToList()[0];

            if (items[foundItem] < NumberOfRequiredItems)
            {
                return false;
            }

            while (items[foundItem] >= (ItemsHit + NumberOfRequiredItems))
            {
                NumberOfDiscountsHit++;
                ItemsHit += NumberOfRequiredItems;
            }

            return true;
        }

        public void ResetDiscount()
        {
            this.NumberOfDiscountsHit = 0;
            this.ItemsHit = 0;
        }
    }
}