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
        private List<Product> products = new List<Product>();
        private Inventory _inventory;


        private int _capacity; 
        private int Capacity { get => _capacity; }
        private int NrOfItems { get => products.Count; }
        private DiscountManager _DM;
        private DiscountManager DM { get => _DM; }
        private List<string> _warnings = new List<string>();
        public List<string>  Warnings { 
            get { 
                var temp = _warnings.ToList();
                _warnings.RemoveRange(0, _warnings.Count);
                return temp;
            }
        }
        public Basket(Inventory inventory, DiscountManager dm ,int capacity = 15) 
        {
            this._inventory = inventory;
            this._capacity = capacity;
            this._DM = dm;
        }

        public void setCapacity(int newCapacity)
        {
            this._capacity = newCapacity;
            if (this.Capacity < products.Count)
            {
                var tempProducts = products.ToList().GetRange(0,this.Capacity);
                products = tempProducts;
            }
        }

        
        public void addProduct(string productSku, int amount = 1)
        {
            if (amount < 1)
            {
                _warnings.Add("Amount to add must be positive");
                return;
            }

            int productStock = this._inventory.getStock(productSku);
            if (productStock < amount)
            {
                _warnings.Add($"Can't add {amount} {productSku}, as the there's {productStock} in stock ");
                return;
            }
            
            if (NrOfItems + amount > Capacity )
            {
                _warnings.Add($"Can't add {amount} {productSku}, will be more than Baskets Capacity of {Capacity} items");
                return;
            }


            for (int i = 0; i < amount; i++)
            {
                this.products.Add(_inventory.createProductType(productSku));
            }
            this._inventory.decreaseStock(productSku, amount);
        }
        public bool removeProduct(string productSku, int amount = 1)
        {
            if (amount < 1)
            {
                _warnings.Add($"Amount to remove must be positive");
                return false;

            }

            int amountProductInBasket = this.countProductTypes(productSku);
            int nrToRemove = Math.Min(amountProductInBasket, amount);
            var itemsToRemoveList = this.products.Where(x => x.SKU == productSku).ToList();
            if (itemsToRemoveList.Count == 0)
            {
                _warnings.Add($"Can't remove {productSku}, as its not in the basket");
                return false;
            }
            for (int i = 0; i < nrToRemove; i++)
            {
                this.products.Remove(itemsToRemoveList[i]);
            }
            
            this._inventory.IncreaseStock(productSku, nrToRemove);
            return true; 
        }
        public int countProductTypes(string SKU)
        {
            return products.Where(x=>x.SKU == SKU).Count();

        }
        public List<Product> getProducts()
        {
            // Return a deep copy of the list... 
            var cpyList = new List<Product>();
            foreach (Product product in this.products)
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

        public float getTotal()
        {
            var orderDataDict = DM.calculateDiscount(this);

            return orderDataDict.Values.Sum(x => x.total_price);

        }
        
        public float getUndiscountedTotal()
        {
            return this.products.Sum(x => x.ProductPrice);

        }

        public string stringify(DiscountManager dm)
        {
            var cacledBasket = dm.calculateDiscount(this);
            string ret = string.Format("{0,7}  {1,-25}{2,-10}{3,-10}\n", "Type", "Name", "Amount", "Cost");

            foreach (var x in cacledBasket.ToList())
            {
                if (x.Value.UsedDiscount == null)
                {
                    ret += "\n"+ string.Format("{0,7}  {1,-25}{2,-10}{3,-10}", _inventory.getProductType(x.Value.name) ,_inventory.getName(x.Value.name), x.Value.amount, x.Value.total_price);
                }
                else
                {
                    ret += "\n"+ string.Format("{0,7}  {1,-25}", "Deal", x.Value.UsedDiscount.stringify());
                    ret += "\n"+ string.Format("{0,7}  {1,-25}{2, -10}{3, -10}","", "", x.Value.amount, x.Value.total_price);
                }
            }

            ret += $"\n\n Total: {getTotal()}";

            return ret;
        }

    }
}
