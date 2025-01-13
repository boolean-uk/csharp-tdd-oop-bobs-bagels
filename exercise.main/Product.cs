using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{


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
