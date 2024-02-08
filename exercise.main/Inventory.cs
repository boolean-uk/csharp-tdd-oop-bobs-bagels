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
                { "BGLO", new Bagel("BGLO", 0.49f, "Bagel", "Onion") },
                { "BGLP", new Bagel("BGLP", 0.39f, "Bagel", "Plain") },
                { "BGLE", new Bagel("BGLE", 0.49f, "Bagel", "Everything") },
                { "BGLS", new Bagel("BGLS", 0.49f, "Bagel", "Sesame") },
                { "COFB", new Coffee("COFB", 0.99f, "Coffee", "Black") },
                { "COFW", new Coffee("COFW", 1.19f, "Coffee", "White") },
                { "COFC", new Coffee("COFC", 1.29f, "Coffee", "Cappuccino") },
                { "COFL", new Coffee("COFL", 1.29f, "Coffee", "Latte") },
                { "FILB", new Filling("FILB", 0.12f, "Filling", "Bacon") },
                { "FILE", new Filling("FILE", 0.12f, "Filling", "Egg") },
                { "FILC", new Filling("FILC", 0.12f, "Filling", "Cheese") },
                { "FILX", new Filling("FILX", 0.12f, "Filling", "Cream Cheese") },
                { "FILS", new Filling("FILS", 0.12f, "Filling", "Smoked Salmon") },
                { "FILH", new Filling("FILH", 0.12f, "Filling", "Ham") }
            };

            this._dicounts = new List<Discount> {
                {new Discount(GetItem("BGLO"), 3.99f, new List<DiscountItem> { { new DiscountItem(GetItem("BGLO"), 12) } })},
                {new Discount(GetItem("BGLO"), 2.49f, new List<DiscountItem> { { new DiscountItem(GetItem("BGLO"), 6) } })},

                {new Discount(GetItem("BGLP"), 3.99f, new List<DiscountItem> { { new DiscountItem(GetItem("BGLP"), 12) } })},
                {new Discount(GetItem("BGLP"), 2.49f, new List<DiscountItem> { { new DiscountItem(GetItem("BGLP"), 6) } })},

                {new Discount(GetItem("BGLE"), 3.99f, new List<DiscountItem> { { new DiscountItem(GetItem("BGLE"), 12) } })},
                {new Discount(GetItem("BGLE"), 2.49f, new List<DiscountItem> { { new DiscountItem(GetItem("BGLE"), 6) } })},

                {new Discount(GetItem("BGLS"), 3.99f, new List<DiscountItem> { { new DiscountItem(GetItem("BGLS"), 12) } })},
                {new Discount(GetItem("BGLS"), 2.49f, new List<DiscountItem> { { new DiscountItem(GetItem("BGLS"), 6) } })},

                {new Discount(GetItem("COFB"), 1.25f, new List<DiscountItem> { { new DiscountItem(GetItem("COFB"), 1) },{ new DiscountItem(GetItem("BGLO"), 1) } })},
            };
            //TODO Sort based on best deal & add method to easily add generic discounts
            //_dicounts = _dicounts.OrderDescending(d => d.GetDiscount()).ToList();

        }

        public bool ItemExists(string sku)
        {
            return _items.ContainsKey(sku);
        }

        public float GetPrice(string sku)
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

        public float RemoveDiscount(List<Item> basketList)
        {
            float totalDiscount = 0;
            var basketDict = CreateDictFromBasket(basketList);

            foreach (var discount in _dicounts)
            {
                bool discountIsValid = true;
                Dictionary<string, int> tempBasketDict = new Dictionary<string, int>(basketDict);

                foreach (var discountItem in discount.DiscountItems)
                {
                    Item item = discountItem.Item;
                    if (!basketDict.ContainsKey(item.Sku))
                    {
                        discountIsValid = false;
                        break;
                    }

                    int requiredQuantity = discountItem.Quantity;
                    int quantityInBasket = tempBasketDict[item.Sku];
                    if (quantityInBasket < requiredQuantity)
                    {
                        discountIsValid = false;
                        break;
                    }
                    else
                    {
                        tempBasketDict[item.Sku] -= requiredQuantity;
                    }
                }

                if (discountIsValid)
                {
                    totalDiscount += discount.GetDiscount();
                    basketDict = new Dictionary<string, int>(tempBasketDict);
                }
            }
            return totalDiscount;
        }

        public float RemoveDiscount(ReceiptItem item)
        {
            float totalDiscount = 0;
            bool discountIsValid = true;



            Item item = discountItem.Item;
            if (!basketDict.ContainsKey(item.Sku))
            {
                discountIsValid = false;
                break;
            }

            int requiredQuantity = discountItem.Quantity;
            int quantityInBasket = tempBasketDict[item.Sku];
            if (quantityInBasket < requiredQuantity)
            {
                discountIsValid = false;
                break;
            }
            else
            {
                tempBasketDict[item.Sku] -= requiredQuantity;
            }


            if (discountIsValid)
            {
                totalDiscount += discount.GetDiscount();
                basketDict = new Dictionary<string, int>(tempBasketDict);
            }
            return totalDiscount;
        }

        private Dictionary<string, int> CreateDictFromBasket(List<Item> basketList)
        {
            Dictionary<string, int> basketDict = new Dictionary<string, int>();
            foreach (var item in basketList)
            {
                if (!basketDict.ContainsKey(item.Sku))
                {
                    basketDict.Add(item.Sku, 1);
                }
                else
                {
                    basketDict[item.Sku]++;
                }
            }
            return basketDict;
        }
    }
}