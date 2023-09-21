namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class Basket
    {
        private List<OrderItem> _items;
        private Inventory _inventory;
        private List<Discount> _discounts;
        private int _capacity = 30; // default capacity to be 100
        private bool comboApplied = false;

        public Basket(Inventory inventory, List<Discount> discounts)
        {
            _items = new List<OrderItem>();
            _inventory = inventory;
            _discounts = discounts;
        }

        public bool AddItem(IProduct product, int quantity = 1)
        {
            if (!_inventory.DoesTheItemExist(product.SKU))
                return false;

            if (IsBasketFull())
                return false;
            Console.WriteLine($"Added {quantity} of {product.Name} to the basket. Current total: £{GetTotalCost():0.00}");

            var existingOrderItem = _items.FirstOrDefault(item => item.Product.SKU == product.SKU);
            if (existingOrderItem != null)
            {
                existingOrderItem.AdjustQuantity(quantity);
            }
            else
            {
                var orderItem = new OrderItem(product, quantity);
                _items.Add(orderItem);
            }

            // Reset the comboApplied flag before applying discounts
            comboApplied = false;

            // Apply discounts only once after all items have been added
            ApplyDiscounts();

            return true;
        }


        private void ApplyDiscounts()
        {
            // Apply the combo discount first
            ApplyComboDiscount();

            foreach (var orderItem in _items)
            {
                decimal totalDiscount = 0M;

                var applicableDiscounts = _discounts
                    .Where(discount => discount.IsDiscounted(orderItem.Product) && !(discount is ComboDiscount)) // Exclude ComboDiscount
                    .ToList();

                foreach (var discount in applicableDiscounts)
                {
                    totalDiscount += discount.CalculateDiscount(orderItem.Product, orderItem.Quantity, orderItem.OriginalPrice, _items);
                }

                // Only adjust the discounted price if a new discount is applied
                if (totalDiscount > 0)
                {
                    decimal discountedPricePerUnit = orderItem.OriginalPrice - (totalDiscount / orderItem.Quantity);
                    orderItem.AdjustDiscountedPrice(discountedPricePerUnit);
                    Console.WriteLine($"Discount applied to {orderItem.Product.Name}. Original Price: {orderItem.OriginalPrice}, Discounted Price: {orderItem.DiscountedPrice}");
                }
            }
        }
        private void ApplyComboDiscount()
        {
            var coffeeItem = _items.FirstOrDefault(item => item.Product is Coffee);
            var bagelItem = _items.FirstOrDefault(item => item.Product is Bagel);

            if (coffeeItem != null && bagelItem != null)
            {
                var comboDiscount = _discounts.OfType<ComboDiscount>().FirstOrDefault();
                if (comboDiscount != null)
                {
                    decimal totalBeforeDiscount = coffeeItem.OriginalPrice + bagelItem.OriginalPrice;
                    decimal totalDiscount = totalBeforeDiscount - ComboDiscount.comboPrice;

                    decimal coffeeDiscount = totalDiscount / 2;
                    decimal bagelDiscount = totalDiscount / 2;

                    coffeeItem.AdjustDiscountedPrice(coffeeItem.OriginalPrice - coffeeDiscount);
                    bagelItem.AdjustDiscountedPrice(bagelItem.OriginalPrice - bagelDiscount);
                }
            }
        }
        public bool RemoveItem(IProduct product, int quantity = 1)
        {
            var existingOrderItem = _items.FirstOrDefault(item => item.Product.SKU == product.SKU);
            if (existingOrderItem == null)
                return false;

            existingOrderItem.AdjustQuantity(-quantity);
            if (existingOrderItem.Quantity <= 0)
            {
                _items.Remove(existingOrderItem);
            }
            return true;
        }

        public bool IsBasketFull() => _items.Count >= _capacity;

        public void SetCapacity(int capacity) => _capacity = capacity;

        public int GetCapacity() => _capacity;

        public bool ContainsItem(string sku) => _items.Any(item => item.Product.SKU == sku);

        public decimal GetTotalCost() => _items.Sum(item => item.TotalPrice());

        public decimal GetTotalSavings() => _items.Sum(item => item.GetSavings());

        public decimal GetItemSavings(string sku)
        {
            var orderItem = _items.FirstOrDefault(item => item.Product.SKU == sku);
            return orderItem?.GetSavings() ?? 0M;
        }

        public Receipt GenerateReceipt()
        {
            var receipt = new Receipt();
            foreach (var orderItem in _items)
            {
                receipt.AddOrderItem(orderItem);
            }
            return receipt;
        }
        public void Clear()
        {
            _items.Clear();
        }
    }
}
