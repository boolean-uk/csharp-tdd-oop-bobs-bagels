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
            {
                Console.WriteLine($"Product {product.Name} with SKU {product.SKU} does not exist in the inventory.");

                return false;
            }


            if (IsBasketFull())
            {
                Console.WriteLine("Basket is full. Cannot add more items.");

                return false;

            }
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
            comboApplied = false;
            ApplyDiscounts();
            return true;
        }


        private void ApplyDiscounts()
        {
            ApplyComboDiscount();

            foreach (var orderItem in _items)
            {
                decimal totalDiscount = 0M;

                var applicableDiscounts = _discounts
                    .Where(discount => discount.IsDiscounted(orderItem.Product) && !(discount is ComboDiscount))
                    .ToList();

                foreach (var discount in applicableDiscounts)
                {
                    totalDiscount += discount.CalculateDiscount(orderItem.Product, orderItem.Quantity, orderItem.OriginalPrice, _items);
                }

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
                    decimal totalDiscount = coffeeItem.OriginalPrice + bagelItem.OriginalPrice - ComboDiscount.comboPrice;

                    decimal coffeeDiscount = coffeeItem.OriginalPrice - (totalDiscount / 2);
                    decimal bagelDiscount = bagelItem.OriginalPrice - (totalDiscount / 2);

                    coffeeItem.AdjustDiscountedPrice(coffeeDiscount);
                    bagelItem.AdjustDiscountedPrice(bagelDiscount);

                    Console.WriteLine($"Applied combo discount to Coffee. New Discounted Price for Bagel: {bagelItem.DiscountedPrice}");
                }
            }
        }
        private void ApplyBulkDiscount()
        {
            var bagelItems = _items.Where(item => item.Product is Bagel).ToList();
            var totalBagelQuantity = bagelItems.Sum(item => item.Quantity);

            if (totalBagelQuantity >= 6)
            {
                var bulkDiscount = _discounts.OfType<BulkDiscount>().FirstOrDefault();
                if (bulkDiscount != null)
                {
                    decimal totalDiscount = bulkDiscount.CalculateDiscount(null, totalBagelQuantity, 0M, _items);
                    decimal discountPerBagel = totalDiscount / totalBagelQuantity;

                    foreach (var bagelItem in bagelItems)
                    {
                        bagelItem.AdjustDiscountedPrice(bagelItem.OriginalPrice - discountPerBagel);
                        Console.WriteLine($"Applied bulk discount to {bagelItem.Product.Name}. New Discounted Price: {bagelItem.DiscountedPrice}");
                    }
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
