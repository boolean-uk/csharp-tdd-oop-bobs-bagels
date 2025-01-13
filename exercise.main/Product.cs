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

                //float? defprice = basket.getDefaultPrice(SKU);
                ////if (defprice == null)
                //Debug.Assert(defprice != null, "expected SKU to exist in basket...");

                var defprice = _inventory.getPrice(SKU);

                //totalCost_withoutDiscount +=  discountReq.Value * d * (defprice ?? 1.0f);
                totalCost_withoutDiscount +=  discountReq.Value * d * defprice;

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
        //protected ProductType productType;
        //public BaseProduct(string SKU,string name, float defaultPrice, ProductType productType, List<BaseProduct>? subProducts = null)
        public BaseProduct(string SKU,string name, float defaultPrice, List<BaseProduct>? subProducts = null)
        {            
            this.sku = SKU;
            this.name = name;
            this.productPrice = defaultPrice;
            this.subProducts = subProducts ?? new List<BaseProduct>();
            //this.productType = productType;
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

    public class Product: BaseProduct
    {
        public Product(string SKU, string name, float defaultPrice,List<BaseProduct>? subProducts = null)
            : base(SKU, name, defaultPrice, subProducts)
        {
        }
    }




}
