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
                { "COFB", new Filling("COFB", 0.99f, "Coffee", "Black") },
                { "COFW", new Filling("COFW", 1.19f, "Coffee", "White") },
                { "COFC", new Filling("COFC", 1.29f, "Coffee", "Cappuccino") },
                { "COFL", new Filling("COFL", 1.29f, "Coffee", "Latte") },
                { "FILB", new Filling("FILB", 0.12f, "Filling", "Bacon") },
                { "FILE", new Filling("FILE", 0.12f, "Filling", "Egg") },
                { "FILC", new Filling("FILC", 0.12f, "Filling", "Cheese") },
                { "FILX", new Filling("FILX", 0.12f, "Filling", "Cream Cheese") },
                { "FILS", new Filling("FILS", 0.12f, "Filling", "Smoked Salmon") },
                { "FILH", new Filling("FILH", 0.12f, "Filling", "Ham") }
            };



            //Discount(sku, discount, List<DiscountItem>{Item, quantity})

            this._dicounts = new List<Discount> {
                {new Discount(GetItem("BGLO"), 2.49f, 0.45f, new List<DiscountItem> { { new DiscountItem(_items["BGLO"], 6) } })},
                {new Discount(GetItem("BGLP"), 2.49f, 0.69f, new List<DiscountItem> { { new DiscountItem(_items["BGLP"], 12) } })},
                {new Discount(GetItem("BGLE"), 2.49f, 0.45f, new List<DiscountItem> { { new DiscountItem(_items["BGLE"], 6) } })},
                {new Discount(GetItem("COFB"), 1.25f, 0.45f, new List<DiscountItem> { { new DiscountItem(_items["BGLO"], 1) },{ new DiscountItem(_items["BGLO"], 1) } })},

            };

            //Sort based on best deal
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

        public Item GetItem(string sku)
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

            //Copy basket into a temp basket to keep track of discounted items
            List<Item> discountedBasket = new List<Item>(basketList);

            //Look through each available discount
            foreach (var discount in _dicounts)
            {
                bool isDealValid = true;

                //Temp discount basket to keep track of remove items
                List<Item> tempDiscountBasket = new List<Item>(discountedBasket);

                //If there is an item in the basket that has a deal
                if (tempDiscountBasket.Contains(discount.ItemOnDeal))
                {
                    //Look through the discount for the neccessary requirements
                    foreach (var discountItem in discount.DiscountItems)
                    {
                        int requiredQuantity = discountItem.Quantity;
                        int quantityInBasket = 0;

                        //TODO Change to check SKU instead, not using bagels with fillings now
                        Item itemDeal = discountItem.Item;

                        //Remove items if they match the discount
                        for (int i = 0; i < tempDiscountBasket.Count();)
                        {
                            if (tempDiscountBasket[i].Sku.Equals(itemDeal.Sku))
                            {
                                tempDiscountBasket.RemoveAt(i);
                                quantityInBasket++;
                            }
                            else
                            {
                                i++;
                            }
                            if (quantityInBasket >= requiredQuantity) break;
                        }

                        bool pause = true;

                        //Discount was not fulfilled
                        if (quantityInBasket < requiredQuantity)
                        {
                            isDealValid = false;
                            break;
                        }
                        // The discount is valid
                        if (isDealValid)
                        {
                            //Store the list with removed items
                            discountedBasket = new List<Item>(tempDiscountBasket);
                            totalDiscount += discount.GetDiscount();
                        }
                    }

                }
            }

            //Return
            if (totalDiscount > 0)
            {
                return totalDiscount;
            }
            else
            {
                return 0;
            }
        }
    }
}
