namespace exercise.main
{
    public class Inventory
    {
        private Dictionary<string, Item> _items;
        private List<Discount> _dicounts;

        public Inventory()
        {
            this._items = new Dictionary<string, Item>
            {
                { "BGLO", new Bagel("BGLO", 0.49m, "Bagel", "Onion") },
                { "BGLP", new Bagel("BGLP", 0.39m, "Bagel", "Plain") },
                { "BGLE", new Bagel("BGLE", 0.49m, "Bagel", "Everything") },
                { "BGLS", new Bagel("BGLS", 0.49m, "Bagel", "Sesame") },
                { "COFB", new Coffee("COFB", 0.99m, "Coffee", "Black") },
                { "COFW", new Coffee("COFW", 1.19m, "Coffee", "White") },
                { "COFC", new Coffee("COFC", 1.29m, "Coffee", "Cappuccino") },
                { "COFL", new Coffee("COFL", 1.29m, "Coffee", "Latte") },
                { "FILB", new Filling("FILB", 0.12m, "Filling", "Bacon") },
                { "FILE", new Filling("FILE", 0.12m, "Filling", "Egg") },
                { "FILC", new Filling("FILC", 0.12m, "Filling", "Cheese") },
                { "FILX", new Filling("FILX", 0.12m, "Filling", "Cream Cheese") },
                { "FILS", new Filling("FILS", 0.12m, "Filling", "Smoked Salmon") },
                { "FILH", new Filling("FILH", 0.12m, "Filling", "Ham") }
            };

            this._dicounts = new List<Discount> {
                {new Discount(_items["BGLO"], 3.99m, new List<RequiredItemsForDiscount> { { new RequiredItemsForDiscount(_items["BGLO"], 12) } })},
                {new Discount(_items["BGLO"], 2.49m, new List<RequiredItemsForDiscount> { { new RequiredItemsForDiscount(_items["BGLO"], 6) } })},

                {new Discount(_items["BGLP"], 3.99m, new List<RequiredItemsForDiscount> { { new RequiredItemsForDiscount(_items["BGLP"], 12) } })},
                {new Discount(_items["BGLP"], 2.49m, new List<RequiredItemsForDiscount> { { new RequiredItemsForDiscount(_items["BGLP"], 6) } })},

                {new Discount(_items["BGLE"], 3.99m, new List<RequiredItemsForDiscount> { { new RequiredItemsForDiscount(_items["BGLE"], 12) } })},
                {new Discount(_items["BGLE"], 2.49m, new List<RequiredItemsForDiscount> { { new RequiredItemsForDiscount(_items["BGLE"], 6) } })},

                {new Discount(_items["BGLS"], 3.99m, new List<RequiredItemsForDiscount> { { new RequiredItemsForDiscount(_items["BGLS"], 12) } })},
                {new Discount(_items["BGLS"], 2.49m, new List<RequiredItemsForDiscount> { { new RequiredItemsForDiscount(_items["BGLS"], 6) } })},

                {new Discount(_items["COFB"], 1.25m, new List<RequiredItemsForDiscount> { { new RequiredItemsForDiscount(_items["COFB"], 1) },{ new RequiredItemsForDiscount(_items["BGLO"], 1) } })},
            };
            //TODO Sort based on best deal & add method to easily add generic discounts
            //_dicounts = _dicounts.OrderDescending(d => d.GetDiscount()).ToList();

        }

        public bool ItemExists(string sku)
        {
            return _items.ContainsKey(sku);
        }

        public decimal GetPrice(string sku)
        {
            if (this.ItemExists(sku))
            {
                return _items[sku].GetPrice();
            }
            else
            {
                return 0;
            }
        }

        public Item? GetItem(string sku)
        {
            if (this.ItemExists(sku))
            {
                return _items[sku];
            }
            else return null;
        }

        public Dictionary<string, BasketItem> GetDiscountedBasket(Dictionary<string, BasketItem> basket)
        {
            var discountedBasket = new Dictionary<string, BasketItem>(basket);

            foreach (var discount in _dicounts)
            {
                var updatedDiscountBasket = new Dictionary<string, BasketItem>(discountedBasket);
                int nrOfTimesDiscountApplied = TryApplyDiscount(discount, updatedDiscountBasket);

                if (nrOfTimesDiscountApplied > 0)
                {
                    string discountSku = discount.ItemWithDeal.Sku;
                    discountedBasket = new Dictionary<string, BasketItem>(updatedDiscountBasket);

                    var discountAmount = discount.GetDiscountedPrice() * nrOfTimesDiscountApplied;
                    var discountedItem = discountedBasket[discountSku];

                    discountedItem.TotalCost -= discountAmount;
                    discountedBasket[discountSku] = discountedItem;
                }
            }

            return discountedBasket;
        }

        private int TryApplyDiscount(Discount discount, Dictionary<string, BasketItem> basket)
        {
            int discountAppliedTimes = 0;

            while (IsDiscountValid(discount, basket))
            {
                discountAppliedTimes++;

                foreach (var discountItem in discount.RequiredItemsForDiscount)
                {
                    string discountItemSku = discountItem.Item.Sku;

                    var temp = basket[discountItemSku];
                    temp.Quantity -= discountItem.Quantity;
                    basket[discountItemSku] = temp;
                }
            }

            return discountAppliedTimes;
        }

        private bool IsDiscountValid(Discount discount, Dictionary<string, BasketItem> basket)
        {
            foreach (var discountItem in discount.RequiredItemsForDiscount)
            {
                string discountItemSku = discountItem.Item.Sku;

                if (!basket.ContainsKey(discountItemSku) || basket[discountItemSku].Quantity < discountItem.Quantity)
                {
                    return false;
                }
            }

            return true;
        }
    }
}