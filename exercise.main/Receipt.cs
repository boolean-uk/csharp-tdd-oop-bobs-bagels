using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Receipt
    {
        private Dictionary<Item, int> _items;
        private List<Discount> _discounts;

        public int ID { get; set; }

        public Receipt(Basket basket)
        {
            _items = basket.Items;
            _discounts = new List<Discount>()
            {
                new Discount("BGLO", 6, 2.49f),
                new Discount("BGLP", 12, 3.99f),
                new Discount("BGLE", 6, 2.49f),
                new Discount("COFB", 1, 1.25f)
            };
        }

        public string PrintReceipt()
        {
            Dictionary<Item, (int, float)> discountedItems = CalculateDiscounts(new Dictionary<Item, int>(_items)); 

            float total = 0;
            float itemTotal = 0;
            StringBuilder message = new StringBuilder();

            if (_items.Count() == 0)
            {
                message.Append("No items in basket!");
                Console.Write(message.ToString());
                return message.ToString();
            }

            message.Append("       ~~~ Bob's Bagels ~~~\n\n");
            message.Append($"       {DateTime.Now}\n\n");
            message.Append("---------------------------------\n\n");

            foreach (Item item in _items.Keys)
            {
                if (_items[item] > 0)
                {
                    message.Append($"{item.Variant} {item.Name}".PadRight(23));
                    message.Append($"{_items[item]}".PadRight(5));
                    itemTotal = item.Price * _items[item];
                    message.Append($"£{itemTotal}\n");
                    total += itemTotal;
                }
            }

            foreach (Item discountedItem in discountedItems.Keys) 
            {
                if (discountedItems[discountedItem].Item1 > 0)
                {
                    message.Append($"{discountedItem.Variant} {discountedItem.Name}".PadRight(23));
                    message.Append($"{discountedItems[discountedItem].Item1}".PadRight(5));
                    itemTotal = discountedItems[discountedItem].Item2;
                    message.Append($"£{itemTotal}\n");
                    total += itemTotal;
                }
            }
            message.Append("\n---------------------------------\n");
            message.Append($"Total\t\t".PadRight(18));
            message.Append($"£{total}\n\n");
            message.Append("\t    Thank you\n\t  for you order!\n");

            Console.Write(message.ToString());

            return message.ToString();
        }

        public Dictionary<Item, (int, float)> CalculateDiscounts(Dictionary<Item, int> items)
        {
            Dictionary <Item, (int, float)> discountedItems = new Dictionary<Item, (int, float)>();
            foreach (Discount discount in _discounts)
            {
                if (items.Keys.Where(x => x.SKU == discount.DiscountItemSKU).ToList().Count() > 0)
                {
                    Item foundItem = items.Keys.Where(x => x.SKU == discount.DiscountItemSKU).ToList()[0];

                    if (foundItem.SKU == "COFB")
                    {
                        if (items.Keys.Where(x => x.Name == "Bagel").ToList().Count() > 0)
                        {
                            Item foundBagel = items.Keys.Where(x => x.Name == "Bagel").ToList()[0];

                            while (items[foundItem] >= (discount.ItemsHit + discount.NumberOfRequiredItems) && items[foundBagel] >= (discount.ItemsHit + discount.NumberOfRequiredItems))
                            {
                                discount.NumberOfDiscountsHit++;
                                discount.ItemsHit += discount.NumberOfRequiredItems;
                                items[foundItem] -= discount.NumberOfRequiredItems;
                                items[foundBagel] -= discount.NumberOfRequiredItems;
                            }

                            if (discount.NumberOfDiscountsHit > 0)
                            {
                                if (discountedItems.ContainsKey(foundItem))
                                {
                                    discountedItems[foundItem] = (discount.ItemsHit, discount.DiscountPrice * discount.NumberOfDiscountsHit);
                                }
                                else
                                {
                                    discountedItems.Add(foundItem, (discount.ItemsHit, discount.DiscountPrice * discount.NumberOfDiscountsHit));
                                }
                            }
                        }
                    }
                    else
                    {
                        while (items[foundItem] >= (discount.ItemsHit + discount.NumberOfRequiredItems))
                        {
                            discount.NumberOfDiscountsHit++;
                            discount.ItemsHit += discount.NumberOfRequiredItems;
                            items[foundItem] -= discount.NumberOfRequiredItems;
                        }

                        if (discount.NumberOfDiscountsHit > 0)
                        {
                            if (discountedItems.ContainsKey(foundItem))
                            {
                                discountedItems[foundItem] = (discount.ItemsHit, discount.DiscountPrice * discount.NumberOfDiscountsHit);
                            }
                            else
                            {
                                discountedItems.Add(foundItem, (discount.ItemsHit, discount.DiscountPrice * discount.NumberOfDiscountsHit));
                            }
                        }
                    }
                }
            }
            return discountedItems;
        }

        public Dictionary<Item, int> Items { get { return _items; } }
        public List<Discount> Discounts { get { return _discounts; } }
    }
}
