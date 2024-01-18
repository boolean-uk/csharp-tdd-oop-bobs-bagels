using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Inventory
    {
        private Dictionary<string,Item> _shopInventory { get; }

        public Inventory() 
        {
            _shopInventory = new Dictionary<string,Item>();
            
        }

        public Dictionary<string, Item> ShopInventory { get { return _shopInventory; } }

        public void CreateNewItem(string name, string itemID, string variant, float cost)
        {
            Item item;

            switch (itemID.First())
            {
                case 'B':
                    item = new Bagle(name, itemID, variant, cost);
                    break;
                case 'C':
                    item = new Coffee(name, itemID, variant, cost);
                    break;
                case 'F':
                    item = new Filling(name, itemID, variant, cost);
                    break;
                default:
                    item = new Item(name, itemID, variant, cost);
                    break;
            }
            

            ShopInventory.Add(itemID, item);


        }

        public Item GetItem(string itemID)
        {
            
            return ShopInventory[itemID];
 
        }

        public bool ContainsItem(string itemID)
        {
            throw new NotImplementedException();
            //if (ShopInventory.ContainsKey(itemID)) return true;

            //return false;
        }
    }
}
