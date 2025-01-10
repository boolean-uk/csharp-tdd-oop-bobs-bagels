using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Items
{
    public class Item
    {
        private string _id;
        private string _name;
        private string _variant;
        protected float _cost;
        public string Id { get { return _id; } }
        public string Name { get { return _name; } }
        public string Variant { get { return _variant; } }
        public float Price { get { return _cost; } }

        public Item(string id, string name, string variant, float cost)
        {
            _id = id;
            _name = name;
            _variant = variant;
            _cost = cost;
        }

        override
        public string ToString()
        {
            return $"{Name} - {Variant} - {Price}£";
        }
    }
}
