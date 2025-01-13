namespace exercise.main.Discount
{
    public class DiscountManager
    {

        List<Discount> discountTypes = new List<Discount>();
        //public void addDiscountType<T>(params object[] args) where T : Discount
        private Inventory _inventory;
        public DiscountManager(Inventory inventory)
        {
            _inventory = inventory;
        }
        public void addDiscountType(Discount discount)
        {
            // TODO: Check for and remove identicals...
            discountTypes.Add(discount);
        }

        private List<DiscountedProductCount> pickBestDeals(List<DiscountedProductCount> possibleDiscounts, Basket basket)
        {
            // Looks for conflicting deals, removes them and favors best value deals

            List<Tuple<int, int, string>> conflictingIndexes = new List<Tuple<int, int, string>>();
            List<DiscountedProductCount> possibleCombinations = new List<DiscountedProductCount>();

            // Count/collect possible conflicting deals
            for (int i = 0; i < possibleDiscounts.Count; i++)
            {
                bool noConflict = true;
                for (int j = i + 1; j < possibleDiscounts.Count; j++)
                {
                    foreach (var key in possibleDiscounts[j].SKU_amount.Keys)
                    {

                        if (possibleDiscounts[i].SKU_amount.ContainsKey(key))
                        {
                            conflictingIndexes.Add(new(i, j, key));
                            noConflict = false;
                        }
                    }
                }
                if (noConflict)
                {
                    possibleCombinations.Add(possibleDiscounts[i]);
                }
            }

            foreach (var c in conflictingIndexes)
            {
                int index_i = c.Item1;
                int index_j = c.Item2;
                string SKU = c.Item3;
                //float? defprice = basket.getDefaultPrice(SKU);
                //if (defprice == null)
                //Debug.Assert(defprice != null, "expected SKU to exist in basket...");

                if (possibleDiscounts[index_i].possibleSavings > possibleDiscounts[index_j].possibleSavings)
                {
                    possibleCombinations.Add(possibleDiscounts[index_i]);
                }
                else
                {
                    possibleCombinations.Add(possibleDiscounts[index_j]);

                }


                //defprice.

            }

            return possibleCombinations;
        }

        //public Order calculateDiscount(Basket basket)
        public Dictionary<string, OrderData> calculateDiscount(Basket basket)
        {
            List<DiscountedProductCount> possibleDiscounts = new List<DiscountedProductCount>();
            foreach (Discount discount in discountTypes)
            {
                if (discount.checkCondition(basket))
                {
                    possibleDiscounts.Add(discount.getDiscountedPrice(basket));
                }
            }

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
                    List<BaseProduct> temp = new List<BaseProduct>();

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
    }




}
