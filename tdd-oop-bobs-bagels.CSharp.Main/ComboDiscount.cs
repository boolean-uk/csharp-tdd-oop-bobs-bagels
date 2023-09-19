namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class ComboDiscount : Discount
    {
        private const decimal ComboPrice = 1.25M;
        private Inventory _inventory;

        public ComboDiscount(Inventory inventory)
        {
            _inventory = inventory;
        }

        public override bool IsDiscounted(IProduct product)
        {
            return product is Coffee || product is Bagel;
        }

        public override decimal CalculateDiscount(IProduct product, int quantity, decimal originalPrice)
        {
            if (!IsDiscounted(product))
            {
                return 0M;
            }

            var coffeeSKUs = _inventory.GetProductsOfType<Coffee>().Select(c => c.SKU).ToList();
            var bagelSKUs = _inventory.GetProductsOfType<Bagel>().Select(b => b.SKU).ToList();

            bool hasCoffee = coffeeSKUs.Any(sku => sku.StartsWith("COF"));
            bool hasBagel = bagelSKUs.Any(sku => sku.StartsWith("BGL"));

            if (hasCoffee && hasBagel)
            {
                decimal coffeePrice = coffeeSKUs.Select(sku => _inventory.GetPriceOfItem(sku)).FirstOrDefault();
                decimal bagelPrice = bagelSKUs.Select(sku => _inventory.GetPriceOfItem(sku)).FirstOrDefault();

                decimal originalComboPrice = (coffeePrice + bagelPrice) * quantity;
                decimal comboDiscountAmount = originalComboPrice - (ComboPrice * quantity); /

                return comboDiscountAmount;
            }

            return 0M;
        }
    }
}
