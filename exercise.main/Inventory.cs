using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Inventory
    {
        private Dictionary<Item, string> ShopInventory { get; }


        public void CreateNewItem(string name, string itemID, string variant, float cost)
        {
            /*
            Item item = new Item(name,itemID,variant,cost);

            ShopInventory.Add(item,itemID);
            */
            throw new NotImplementedException();
        }

        public Item GetItem(string itemID) 
        { 
            throw(new NotImplementedException()); 
        }
    }
}
