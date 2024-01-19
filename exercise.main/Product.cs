using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public abstract class Product
    {
        private string _sku = string.Empty;
        public string SKU { get { return _sku; } set { _sku = value; } }

        private double _price;
        public virtual double Price { get { return _price; } set { _price = value; } }

        private string _name = string.Empty;
        public string Name { get { return _name; } set { _name = value; } }

        private string _variant = string.Empty;
        public string Variant { get { return _variant; } set { _variant = value; } }

        protected Product(string sKU)
        {
            sKU = sKU.Trim().ToUpper();
            Tuple<string, double, string, string> skuInfo = Store.getSkuInfo(sKU);

            if (skuInfo != null)
            {
                InitializeProduct(sKU);
            }
            else
            {
                throw new ArgumentException("Invalid SKU");
            }
        }

        protected void InitializeProduct(string sKU)
        {
            Tuple<string, double, string, string> productInfo = Store.getSkuInfo(sKU);
            SKU = productInfo.Item1;
            Price = productInfo.Item2;
            Name = productInfo.Item3;
            Variant = productInfo.Item4;
        }

        public virtual double CheckPriceOfProduct()
        {
            return Price;
        }
    }
}
