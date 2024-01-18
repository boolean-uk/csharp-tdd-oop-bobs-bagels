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
        private readonly IInventory inventory;
        private readonly List<Item> basket;
        private float totalCost;
        private int capacity = 5;

         public Basket(IInventory inventory)
        {
            this.inventory = inventory ?? throw new ArgumentNullException(nameof(inventory));
            basket = new List<Item>();
        }

        public bool AddItem(string sku)
        {
            if (basket.Count < capacity && inventory.GetItemDetails(sku) is Item item)
            {
                basket.Add(item);
                return true;
            }
            return false;
        }
        
       public bool RemoveItem(string sku)
    {
        Item item = inventory.GetItemDetails(sku);
        return item != null && basket.Remove(item);
    }

    public float CalculateTotalCost()
    {
        totalCost = basket.Sum(item => item.Price);
        return totalCost;
    }

    public bool SetCapacity(int newCapacity)
    {
        if (newCapacity > 0)
        {
            capacity = newCapacity;
            return true;
        }
        return false;
    }

    public float GetPrice(string sku)
    {
        return inventory.GetItemDetails(sku)?.Price ?? 0;
    }
    }
}


