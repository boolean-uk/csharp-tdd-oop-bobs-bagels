using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Inventory
    {
        private  Dictionary<string, object> availableItems;

        public Inventory()
        {
            availableItems = new Dictionary<string, object>();
            InitializeInventory();
        }

        private void InitializeInventory()
        {
            AddItem(new Bagel("BGLO", 0.49m, "Bagel", "Onion"));
            
        }

        public void AddItem(object item)
        {
            // Assuming SKU is a unique identifier for items
            var skuProperty = item.GetType().GetProperty("SKU");
            if (skuProperty != null)
            {
                var sku = (string)skuProperty.GetValue(item);
                availableItems[sku] = item;
            }
            else
            {
                throw new InvalidOperationException("Item must have a SKU property.");
            }
        }

        public void RemoveItem(string sku)
        {
            if (availableItems.ContainsKey(sku))
            {
                availableItems.Remove(sku);
            }
            else
            {
                throw new ArgumentException("Item not found in inventory");
            }
        }

        public object GetItemDetails(string sku)
        {
            if (availableItems.ContainsKey(sku))
            {
                return availableItems[sku];
            }
            else
            {
                throw new ArgumentException("Item not found in inventory");
            }
        }
    }
}
