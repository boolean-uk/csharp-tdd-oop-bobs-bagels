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

        public float GetTotalItemCost() 
        {
            throw new NotImplementedException();
        }

        public void AddFillingToBagle(string ItemID, Inventory inventory)
        {

        }
    }
}
