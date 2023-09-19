namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class Basket
    {
        private List<OrderItem> _items;
        private Inventory _inventory;
        private List<Discount> _discounts;
        private int _capacity = 100; // default capacity to be 100

        public Basket(Inventory inventory, List<Discount> discounts)
        {
            _items = new List<OrderItem>();
            _inventory = inventory;
            _discounts = discounts;
        }

        public bool AddItem(IProduct product, int quantity = 1)
        {
            if (!_inventory.DoesTheItemExist(product.SKU) || IsBasketFull())
                return false;

            var existingOrderItem = _items.FirstOrDefault(item => item.Product.SKU == product.SKU);
            if (existingOrderItem != null)
            {
                existingOrderItem.AdjustQuantity(quantity);
            }
            else
            {
                var orderItem = new OrderItem(product, quantity);
                ApplyDiscounts(orderItem); 
                _items.Add(orderItem);
            }
            return true;
        }

        private void ApplyDiscounts(OrderItem orderItem)
        {
            var applicableDiscounts = _discounts
                .Where(discount => discount.IsDiscounted(orderItem.Product))
                .ToList();

            decimal totalDiscount = 0M;

            foreach (var discount in applicableDiscounts)
            {
                var newPrice = discount.CalculateDiscount(orderItem.Product, orderItem.Quantity, orderItem.OriginalPrice);
                totalDiscount += orderItem.OriginalPrice - newPrice;
            }

            decimal discountedPrice = orderItem.OriginalPrice - totalDiscount;
            orderItem.AdjustDiscountedPrice(discountedPrice);
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
