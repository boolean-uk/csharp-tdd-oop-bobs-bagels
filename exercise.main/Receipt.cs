namespace exercise.main
{
    public class Receipt
    {
        //private Inventory _inventory;
        private Basket _basket;
        private DateTime _createdAt;

        public Receipt(Basket basket)
        {
            this._basket = basket;
            this._createdAt = DateTime.Now;
        }

        public List<string> PrintRecipt()
        {
            var receipt = new List<string>();
            float totalBasketCost = 0;

            AddHeader();
            AddItems();
            AddFooter();

            return receipt;


            void AddHeader()
            {
                receipt.Add("~~~ Bob's Bagels ~~~");
                receipt.Add($"{_createdAt}");
                receipt.Add("----------------------------");
            }

            void AddItems()
            {
                var items = GetReceiptItems(_basket);

                foreach (var item in items)
                {
                    totalBasketCost += item.GetTotalPrice();
                    receipt.Add($"{item.Variation} {item.Name} {item.Quantity} £{item.GetTotalPrice()}");
                }
            }

            void AddFooter()
            {
                receipt.Add("----------------------------");
                receipt.Add($"Total £{totalBasketCost}");
                receipt.Add("Thank you for your order!");
            }
        }

        private List<ReceiptItem> GetReceiptItems(Basket basket)
        {
            var basketDict = ConvertBasketToDict(basket);
            var receipt = CreateReceipt(basketDict);

            return receipt;

            List<ReceiptItem> CreateReceipt(Dictionary<string, ReceiptItem> basketDict)
            {
                List<ReceiptItem> receiptItems = new List<ReceiptItem>();
                foreach (var item in basketDict)
                {
                    var properties = item.Value;
                    receiptItems.Add(
                        new ReceiptItem(properties.Name, properties.Variation, properties.Price, properties.Quantity));
                }
                return receiptItems;
            }


            Dictionary<string, ReceiptItem> ConvertBasketToDict(Basket basket)
            {
                var basketDict = new Dictionary<string, ReceiptItem>();

                //Check products
                foreach (var item in basket._basketList)
                {
                    if (!basketDict.ContainsKey(item.Sku))
                    {
                        basketDict.Add(item.Sku, new ReceiptItem(item.ItemName, item.Variant, item.Price, 1));
                    }
                    else
                    {
                        var receiptItem = basketDict[item.Sku];
                        receiptItem.IncrementQuantity();
                        basketDict[item.Sku] = receiptItem;
                    }

                    AddFillingsToDictionary(item);
                }

                return basketDict;

                void AddFillingsToDictionary(Item item)
                {
                    if (item.GetType() != typeof(Bagel)) { return; }

                    Bagel bagelItem = (Bagel)item;

                    foreach (var filling in bagelItem._fillings)
                    {
                        if (!basketDict.ContainsKey(filling.Sku))
                        {
                            basketDict.Add(filling.Sku, new ReceiptItem(filling.ItemName, filling.Variant, filling.Price, 1));
                        }
                        else
                        {
                            var receiptItem = basketDict[item.Sku];
                            receiptItem.IncrementQuantity();
                            basketDict[item.Sku] = receiptItem;
                        }
                    }
                }
            }
        }
    }

    public struct ReceiptItem
    {
        public string Name { get; init; }
        public string Variation { get; init; }
        public float Price { get; }
        public int Quantity { get; set; }
        public ReceiptItem(string productName, string productVariation, float price, int quantity)
        {
            this.Name = productName;
            this.Variation = productVariation;
            this.Price = price;
            this.Quantity = quantity;

        }
        public void IncrementQuantity()
        {
            this.Quantity += 1;
        }

        public float GetTotalPrice()
        {
            return Price * Quantity;
        }
    }
}
