using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Discount;

namespace exercise.main
{
    public class Basket
    {
        private List<BaseProduct> products = new List<BaseProduct>();
        private Inventory _inventory;

        public Basket(Inventory inventory) 
        {
            this._inventory = inventory;
        }

        
        //public void addProduct(BaseProduct product)
        public void addProduct(string productSku, int amount = 1)
        {
            if (amount < 1)
            {
                Debug.Assert(amount < 1, "Amount to add must be positive");
            }

            int productStock = this._inventory.getStock(productSku);
            if (productStock < amount)
            {
                Debug.Assert(productStock <= 0, $"There's not enough {productSku} in stock...");
            }
            for (int i = 0; i < amount; i++)
            {
                Product p = new Product(
                    productSku,
                    _inventory.getName(productSku),
                    _inventory.getPrice(productSku)
                    );

                this.products.Add(p);
            }
            this._inventory.decreaseStock(productSku, amount);
        }
        public void removeProduct(string productSku, int amount = 1)
        {
            if (amount < 1)
            {
                Debug.Assert(amount < 1, "Amount to remove must be positive");
            }

            int amountProductInBasket = this.countProductTypes(productSku);
            int nrToRemove = Math.Min(amountProductInBasket, amount);
            var itemsToRemoveList = this.products.Where(x => x.SKU == productSku).ToList();
            for (int i = 0; i < nrToRemove; i++)
            {
                this.products.Remove(itemsToRemoveList[i]);
            }
            this._inventory.IncreaseStock(productSku, nrToRemove);
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
        public bool isNotEmpty()
        {
            return this.products.Count > 0;
        }

        public string stringify(DiscountManager dm)
        {
            var cacledBasket = dm.calculateDiscount(this);
            string ret = string.Format("{0,0}{1,25}{2,25}\n", "Name", "Amount", "Cost");

            foreach (var x in cacledBasket.ToList())
            {
                if (x.Value.UsedDiscount == null)
                {
                    ret += "\n"+ string.Format("{0,0}{1,25}{2,25}", _inventory.getName(x.Value.name), x.Value.amount, x.Value.total_price);
                }
                else
                {
                    ret += "\n"+ string.Format("{0,0}{1,25}{2,25}", x.Value.UsedDiscount.stringify(), x.Value.amount, x.Value.total_price);
                }
            }

            ret += $"\n\n Total: {cacledBasket.Sum(x => x.Value.total_price)}";

            return ret;
        }

    }
}
