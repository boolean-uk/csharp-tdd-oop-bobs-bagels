using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace exercise.main
{
    public class Bagle : Item
    {

        private List<Item> _bagleFillings = new List<Item>();
        public Bagle(string name, string itemID, string variant, float cost) 
            : base(name, itemID, variant, cost)
        {


        }

        public List<Item> BagleFillings { get { return _bagleFillings; } }

        public override float GetItemCost() 
        {
            float totalCost = this.Cost;
            if(_bagleFillings.Count > 0)
            {

                foreach (Item item in _bagleFillings)
                {
                    totalCost += item.Cost;
                }

                return totalCost;
            }

            return totalCost;
        }

        public void AddFillingToBagle(string ItemID, Inventory inventory)
        {
            Filling filling = (Filling)inventory.GetItem(ItemID);

            _bagleFillings.Add(filling);
        }
    }
}
