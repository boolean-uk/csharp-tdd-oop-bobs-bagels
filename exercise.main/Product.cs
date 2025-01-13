using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public struct OrderData
    {
        public string name;
        public int amount;
        public float individual_price; 
        public float discounted_price; 
        public float total_price; 
        public float saving; 
    }
    public class Order
    {
        public Dictionary<string, OrderData> orderDatas;
        public Order(Basket basket)
        {

        }
    }
    public class DiscountManager 
    {
        
        List<Discount> discountTypes = new List<Discount>();
        //public void addDiscountType<T>(params object[] args) where T : Discount
        private Inventory _inventory; 
        public DiscountManager(Inventory inventory)
        {
            this._inventory = inventory;
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
            List<DiscountedProductCount> possibleCombinations= new List<DiscountedProductCount>();

            // Count/collect possible conflicting deals
            for (int i = 0; i < possibleDiscounts.Count; i++)
            {
                bool noConflict = true;
                for (int j = i+1; j < possibleDiscounts.Count; j++)
                {
                    foreach (var key in possibleDiscounts[j].SKU_amount.Keys)
                    {

                        if(possibleDiscounts[i].SKU_amount.ContainsKey(key))
                        {
                            conflictingIndexes.Add(new (i, j, key));
                            noConflict = false;
                        }
                    }
                }
                if (noConflict)
                {
                    possibleCombinations.Add(possibleDiscounts[i]);
                }
            }

            foreach(var c in conflictingIndexes)
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
                 
                foreach ( var di in discount.SKU_amount)
                {
                    var sku = di.Key; 
                    int amount = di.Value;

                    int counted = 0;
                    List<BaseProduct> temp = new List<BaseProduct>();
                    
                    foreach ( var product in productList)
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
                string nameStr = "deal: " + string.Join(" + ", product.SKU_amount.Keys.Select(x => this._inventory.getName(x)));
                
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

                float defPrice = this._inventory.getPrice(product.Key);

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
    public abstract class Discount
    {
        public Discount(float discountedPrice, Inventory inventory) 
        {
            this.discountPrice = discountedPrice;
            this._inventory = inventory;
        }
        //private Func<int, int> discountConditionFunc;
        //private Action discountConditionFunc;

        //public void defineCondition(Func<int,int> func )
        private float discountPrice;
        protected Inventory _inventory;

        public float DiscountPrice { get => discountPrice; }

        public abstract bool checkCondition(Basket basket);
        public abstract DiscountedProductCount getDiscountedPrice(Basket basket);
    }

    public class Discount_XforY : Discount
    {
        Dictionary<string, int> nrOfRequiredProducts = new Dictionary<string, int>();
        
        public Discount_XforY(Dictionary<string, int> nrOfRequiredProductsSKU, float discountedPrice, Inventory inventory)
            : base(discountedPrice, inventory)
        {
            this.nrOfRequiredProducts = nrOfRequiredProductsSKU;

        }
        public override bool checkCondition(Basket basket)
        {
            foreach (var discountReq in  this.nrOfRequiredProducts)
            {
                if (basket.countProductTypes(discountReq.Key) < discountReq.Value)
                    return false;
            }
            return true;
        }

        public override DiscountedProductCount getDiscountedPrice(Basket basket)
        {
            Dictionary<string, int> discountedProductSKU = new Dictionary<string, int>();
            float totalCost_withoutDiscount = 0.0f;
            float totalCost_withDiscount = 0.0f;
            float discountedSavings = 0.0f;

            foreach (var discountReq in this.nrOfRequiredProducts)
            {
                string SKU = discountReq.Key;
                int requiredProduct = discountReq.Value;
                int d = (int)MathF.Floor(basket.countProductTypes(SKU) / discountReq.Value);

                float? defprice = basket.getDefaultPrice(SKU);
                //if (defprice == null)
                Debug.Assert(defprice != null, "expected SKU to exist in basket...");

                totalCost_withoutDiscount +=  discountReq.Value * d * (defprice ?? 1.0f);

                discountedProductSKU[SKU] = d;
            }

            // The max possible discount is limited by the smalletst multiplier
            float maxDiscountMultiplier = discountedProductSKU.ToList().Min(x => x.Value);

            totalCost_withDiscount = this.DiscountPrice * maxDiscountMultiplier;

            discountedSavings = this.DiscountPrice - totalCost_withoutDiscount;

            Dictionary<string, int> nrOfDiscounted = new Dictionary<string, int>();
            foreach(var discountReq in this.nrOfRequiredProducts)
            {
                string SKU = discountReq.Key;
                int requiredProduct = discountReq.Value;
                nrOfDiscounted[SKU] = (int)maxDiscountMultiplier * requiredProduct;
            }

            DiscountedProductCount dp = new DiscountedProductCount 
            {
                //SKU_amount = discountedProductSKU,
                SKU_amount = nrOfDiscounted,
                //discountMultiple = maxDiscountMultiplier ,
                discountMultiple = (int)maxDiscountMultiplier ,
                possibleSavings = discountedSavings,
                finalPrice = totalCost_withDiscount
            };

            return dp;
        }
    }

    public class DiscountedProductCount
    {
        public Dictionary<string,int> SKU_amount = new Dictionary<string, int>();
        public int discountMultiple = 0;
        public float possibleSavings = 0.0f; 
        public float finalPrice = 0.0f; 
    }


    public abstract class BaseProduct
    {
        protected string name;
        private string sku;
        protected float productPrice;
        protected List<BaseProduct> subProducts;
        protected ProductType productType;
        public BaseProduct(string SKU,string name, float defaultPrice, ProductType productType, List<BaseProduct>? subProducts = null)
        {            
            this.sku = SKU;
            this.name = name;
            this.productPrice = defaultPrice;
            this.subProducts = subProducts ?? new List<BaseProduct>();
            this.productType = productType;
        }
        public float CombinedPrice
        {
            get { return this.productPrice + subProducts.Sum(x => x.CombinedPrice); }
        }
        public float ProductPrice
        {
            get { return this.productPrice; }
        }
        public string ProductName
        {
            get { return this.name; }
        }

        public string SKU { get => sku;}
    }

    public class Product<T>: BaseProduct where T : ProductType, new()
    {
        public Product(string SKU, string name, float defaultPrice,List<BaseProduct>? subProducts = null)
            : base(SKU, name, defaultPrice, new T(),subProducts)
        {
        }
    }


    public interface ProductType
    {
        public float calcPrice();
        public string TypeName()
        {
            return GetType().Name;
        }
    }
    public class Filling : ProductType
    {
        public float calcPrice()
        {
            throw new NotImplementedException();
        }
    }
    public class Coffee : ProductType
    {
        public float calcPrice()
        {
            throw new NotImplementedException();
        }
    }
    public class Bagel : ProductType
    {
        public Bagel() { }
        public float calcPrice()
        {
            throw new NotImplementedException();
        }
    }

}
