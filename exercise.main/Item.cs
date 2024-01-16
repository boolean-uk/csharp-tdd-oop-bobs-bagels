using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace exercise.main
{
    public class Item
    {
        public string Name { get;}
        public string itemID { get;}
        public string Variant { get; }
        public float Cost { get; }


        public Item(string name,string _itemID, string variant, float cost) 
        { 
            Name = name;
            itemID = _itemID;
            Variant = variant;
            Cost = cost;

        }


        List<Item> BagleFillings = new List<Item>();

       

        public float GetTotalItemCost() 
        { 
            throw(new NotImplementedException()); 
        }
    }
}
