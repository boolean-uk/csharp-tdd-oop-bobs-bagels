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
        private string _name;
        private string _itemID;
        private string _variant;
        private float _cost;


        public Item(string name,string itemID, string variant, float cost) 
        { 
            _name = name;
            _itemID = itemID;
            _variant = variant;
            _cost = cost;

        }

        public string Name { get { return _name; } }
        public string ItemID { get { return _itemID; } }
        public string Variant { get { return _variant; } }
        public float Cost { get { return _cost; } }

       
    }
}
