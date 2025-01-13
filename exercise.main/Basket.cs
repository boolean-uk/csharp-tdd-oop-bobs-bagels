using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private List<BaseProduct> products = new List<BaseProduct>();

        public Basket() {}

        
        public void addProduct(BaseProduct product)
        {
            this.products.Add(product);
        }
        public int countProductTypes(string SKU)
        {
            return products.Where(x=>x.SKU == SKU).Count();

        }
        public List<BaseProduct> getProducts()
        {
            // Return a deep copy of the list... 
            var cpyList = new List<BaseProduct>();
            foreach (BaseProduct product in this.products)
            {
                cpyList.Add(product);
            }
            return cpyList;
        }
        public Dictionary<string, int> getAmountPerSku()
        {
            var productList = getProducts();
            Dictionary<string, int> tempSku = new Dictionary<string, int>();
            foreach (var product in productList)
            {
                if (!tempSku.ContainsKey(product.SKU))
                {
                    tempSku[product.SKU] = 0;
                }
                tempSku[product.SKU]++;
            }
            return tempSku;
        }
        public float? getDefaultPrice(string SKU)
        {
            
            foreach (BaseProduct product in this.products)
            {
                if(product.SKU == SKU)
                {
                    return product.ProductPrice;
                }
            }
            return null;
            
        }

    }
}
