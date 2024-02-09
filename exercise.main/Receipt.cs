namespace exercise.main
{
    public class Receipt
    {
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
            decimal totalBasketCost = 0;

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
                var basket = _basket.GetBasket();
                var discountedBasket = _basket.GetDiscountedBasket();

                foreach (BasketItem item in discountedBasket.Values)
                {
                    totalBasketCost += item.TotalCost;

                    receipt.Add($"{item.Item.Variant} {item.Item.ItemName} {basket[item.Item.Sku].Quantity} £{item.TotalCost}");

                    foreach (var filling in item.Fillings)
                    {
                        receipt.Add($"{filling.Variant} (£{filling.Price})");
                    }

                    /*
                    if (basket[item.Item.Sku].TotalCost != item.TotalCost)
                    {
                        receipt.Add($"(-£{basket[item.Item.Sku].TotalCost - item.TotalCost})");
                    }
                    */
                }
            }

            void AddFooter()
            {
                receipt.Add("----------------------------");
                receipt.Add($"Total £{totalBasketCost}");
                receipt.Add("");
                receipt.Add("Thank you for your order!");
            }
        }
    }
}
