using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public abstract class Item
    {
        protected string _SKU;
        protected float _cost;
        protected string _name;
        private string _variant;

        protected List<Item> _fillings;

        public Item(string variant)
        {
            _variant = variant;
        }

        public string sKU { get { return _SKU; } }
        public float cost { get { return _cost; } }
        public string name { get { return _name; } }
        public string variant { get { return _variant; } }

        public abstract void AddFilling(Item filling);

        public abstract List<Item> GetFillings();
    }
}
