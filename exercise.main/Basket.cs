using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using tdd_bobs_bagels.CSharp.Main;

namespace tdd_bobs_bagels.CSharp.Main
{
    public class Basket
    {
        private Inventory inventory = new Inventory();
        private List<Item> _basket = new List<Item>();
        private Item item;
        private float totalCost;
        private int capacity = 5;

        public bool AddItem(string sku)
        {
            if(_basket.Count < capacity)
            {
                if(inventory.ItemDetails(sku) == null)
                {
                    return false;
                }
                item = inventory.ItemDetails(sku);
                _basket.Add(item);
                return true;
            }
            return false;
        }
        public bool RemoveItem(string sku)
        {
            if(_basket.Count > 0)
            {
                if(inventory.ItemDetails(sku) == null)
                {
                    return false;
                }
                item = inventory.ItemDetails(sku);
                _basket.Remove(item);
                return true;
            }
            return false;
        }
        public float CalculateTotalCost()
        {
            totalCost = 0;
            foreach(Item item in _basket)
            {
                totalCost += item.Price;
            }
            return totalCost;
        }
        public bool SetCapacity(int capacity)
        {
            if(capacity > 0)
            {
                this.capacity = capacity;
                return true;
            }
            return false;
        }
        public float GetPrice(string sku)
        {
            if(inventory.ItemDetails(sku) == null)
            {
                return 0;
            }
            item = inventory.ItemDetails(sku);
            return item.Price;
        }
    }
}


