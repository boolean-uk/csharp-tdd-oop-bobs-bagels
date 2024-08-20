using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {

        // properties
        public BobsInventory Inventory { get; set; } = new BobsInventory();
        public List<Item> BasketItems { get; set; } = new List<Item>();
        public int MaxCapacity { get; set; } = 5;
        public bool IsManager { get; set; } = false;
       
            
        // methods
        public bool AddItem(Item item)
        {
            foreach (var i in Inventory.Inventory)
            {
                if (i.SKU == item.SKU && BasketItems.Count < MaxCapacity)
                {
                    BasketItems.Add(item);
                    return true;
                }
            }
            return false;
        }

        public void RemoveItem(Item item)
        {
            if (BasketItems.Count > 0 && BasketItems.Contains(item))
            {
                BasketItems.Remove(item);
            }
            return;
        }


        public bool RemoveNonExistingItem(Item item)
        {
            if (!BasketItems.Contains(item))
            {
                Console.WriteLine("This item doesnt exist in your basket");
                return true;
            }
            else
            {
                BasketItems.Remove(item);
                return false;
            }
        }

        public double GetTotalCost()
        {
            return BasketItems.Sum(x => x.Cost);
        }

        public bool ChangeCapacity(int newCapacity, bool IsManager)
        {
            if (IsManager && newCapacity != MaxCapacity)
            {
                MaxCapacity = newCapacity;
                return true;
            }
            return false;
        }
    }
}
