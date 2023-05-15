using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class Basket
    {
        private Inventory inventory;
        public List<string> Items { get; set; } = new List<string>();
        public int ItemsMax { get; set; } = 5;
        public bool FullBasket
        {
            get
            {
                return this.ItemsMax >= this.Items.Count ? true : false;
            }
        }
        public Basket(Inventory inventory)
        {
            this.inventory = inventory;
        }
        public void AddItem(string SKU)
        {
            var item = inventory.getBySKU(SKU);
            if (item == null || !item.CanOrder)
            {
                return;
            }

            this.Items.Add(SKU);
            
        }

        public void ChangeBasketCapacity(int newCapacity)
        {
            this.ItemsMax = newCapacity;
        }

        public bool RemoveFromBasket(string SKU)
        {
            return this.Items.Remove(SKU);
        }

        public float totalCost()
        {
            var totalCost = 0f;
            foreach (var sku in this.Items)
            {
                var item = inventory.getBySKU(sku);
                totalCost += item.Price;
               
            }
            return totalCost;
        }

    }


}
