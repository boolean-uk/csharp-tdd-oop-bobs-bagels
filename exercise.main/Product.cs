using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{

    public class Product
    {
        protected string name;
        private string sku;
        protected float productPrice;
        protected List<Product> subProducts;
        public Product(string SKU,string name, float defaultPrice, List<Product>? subProducts = null)
        {            
            this.sku = SKU;
            this.name = name;
            this.productPrice = defaultPrice;
            this.subProducts = subProducts ?? new List<Product>();
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

}
