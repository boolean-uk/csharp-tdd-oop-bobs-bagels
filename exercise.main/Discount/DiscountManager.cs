using System.Linq;

namespace exercise.main.Discount
{
    public class DiscountManager
    {

        List<DiscountBase> discountTypes = new List<DiscountBase>();
        //public void addDiscountType<T>(params object[] args) where T : Discount
        private Inventory _inventory;
        public DiscountManager(Inventory inventory)
        {
            _inventory = inventory;
        }
        public void addDiscountType(DiscountBase discount)
        {
            // TODO: Check for and remove identicals...
            discountTypes.Add(discount);
        }

        private List<DiscountedProductCount> pickBestDeals(List<DiscountedProductCount> possibleDiscounts, Basket basket)
        {
            // Looks for conflicting deals, removes them and favors best value deals

            List<Tuple<int, int, string>> conflictingIndexes = new List<Tuple<int, int, string>>();
            Dictionary<int, List<int>> handleDuplications = new();
            List<DiscountedProductCount> possibleCombinations = new List<DiscountedProductCount>();

            // Count/collect possible conflicting deals
            for (int i = 0; i < possibleDiscounts.Count; i++)
            {
                bool noConflict = true;
                //for (int j = i + 1; j < possibleDiscounts.Count; j++)
                for (int j = 0; j < possibleDiscounts.Count; j++)
                {
                    if (j == i)
                        continue; 
                    foreach (var key in possibleDiscounts[j].SKU_amount.Keys)
                    {

                        if (possibleDiscounts[i].SKU_amount.ContainsKey(key))
                        {
                            if (!handleDuplications.ContainsKey(i))
                                handleDuplications[i] = new();
                            if (!handleDuplications.ContainsKey(j))
                                handleDuplications[j] = new();

                            //if (!handleDuplications[i].Contains(j))
                            if (!handleDuplications[j].Contains(i))
                            {
                                conflictingIndexes.Add(new(i, j, key));
                                handleDuplications[i].Add(j);
                            }
                            noConflict = false;
                        }
                    }
                }
                if (noConflict)
                {
                    possibleCombinations.Add(possibleDiscounts[i]);
                }
            }

            var bestDeals = new List<DiscountedProductCount>(possibleCombinations);
            float total = basket.getUndiscountedTotal();
            foreach (var c in conflictingIndexes)
            {
                int index_i = c.Item1;
                int index_j = c.Item2;
                string SKU = c.Item3;

                if (total + possibleDiscounts[index_i].possibleSavings > total + possibleDiscounts[index_j].possibleSavings)
                {
                    bestDeals.Add(possibleDiscounts[index_i]);
                }
                else
                {
                    bestDeals.Add(possibleDiscounts[index_j]);

                }

            }

            return bestDeals;
        }

        //public Order calculateDiscount(Basket basket)
        private List<DiscountedProductCount> getPossibleDiscounts(Basket basket)
        {
            List<DiscountedProductCount> possibleDiscounts = new List<DiscountedProductCount>();
            foreach (DiscountBase discount in discountTypes)
            {
                if (discount.checkCondition(basket))
                {
                    possibleDiscounts.Add(discount.getDiscountedPrice(basket));
                }
            }
            return possibleDiscounts;
        }
        public Dictionary<string, OrderData> calculateDiscount(Basket basket)
        {
            var possibleDiscounts = getPossibleDiscounts(basket);
            var bestDealsDiscounts = pickBestDeals(possibleDiscounts, basket);

            List<OrderData> orderData = new List<OrderData>();

            var productList = basket.getProducts();

            // Remove Discounted products from the product list...
            foreach (var discount in bestDealsDiscounts)
            {

                foreach (var di in discount.SKU_amount)
                {
                    var sku = di.Key;
                    int amount = di.Value;

                    int counted = 0;
                    List<Product> temp = new List<Product>();

                    foreach (var product in productList)
                    {
                        if (sku != product.SKU || counted >= amount)
                        {
                            temp.Add(product);
                        }
                        else
                        {
                            counted++;
                        }
                    }

                    productList = temp;


                }
            }

            //Dictionary<string, Tuple<int, float>> nameAmountPrice = new Dictionary<string, Tuple<int, float>>();
            Dictionary<string, OrderData> nameAmountPrice = new Dictionary<string, OrderData>();

            foreach (var product in bestDealsDiscounts)
            {
                //string nameStr = "deal: " + string.Join(" + ", product.SKU_amount.Keys);
                string nameStr = "deal: " + string.Join(" + ", product.SKU_amount.Keys.Select(x => _inventory.getName(x)));

                nameAmountPrice[nameStr] = new OrderData
                {
                    name = nameStr,
                    amount = product.discountMultiple,
                    individual_price = 0.0f, // TODO: fix ...
                    discounted_price = product.finalPrice,
                    total_price = product.finalPrice,
                    saving = product.possibleSavings,
                    UsedDiscount = product.discount

                };
            }

            Dictionary<string, int> amontPerSku = new Dictionary<string, int>();
            foreach (var product in productList)
            {
                if (!amontPerSku.ContainsKey(product.SKU))
                {
                    amontPerSku[product.SKU] = 0;
                }
                amontPerSku[product.SKU]++;
            }

            //var amontPerSku = basket.getAmountPerSku();
            foreach (var product in amontPerSku)
            {

                //float? defPrice = basket.getDefaultPrice(product.Key);
                //float? defPrice = this._inventory.getPrice(product.Key);
                //if (defPrice == null)
                //Debug.Assert(false, "defPrice cant be zero...");

                float defPrice = _inventory.getPrice(product.Key);

                //nameAmountPrice[product.Key] = new (product.Value, defPrice.Value);
                nameAmountPrice[product.Key] = new OrderData
                {
                    name = product.Key,
                    amount = product.Value,
                    //individual_price = defPrice.Value,
                    individual_price = defPrice,
                    discounted_price = 0.0f, // TODO: fix
                    //total_price = defPrice.Value * product.Value,
                    total_price = defPrice * product.Value,
                    saving = 0.0f,
                };
            }

            return nameAmountPrice;
        }

        public string stringify()
        {

            return string.Join("\n", discountTypes.ToList().Select(x => x.stringify()).ToList());
        }
    }




}
