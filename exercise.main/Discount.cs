using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Discount
    {
        private string _name;
        private float _discount;
        private List<Item> _itemsNeeded;

        public Discount(string name, float discount, List<Item> itemsNeeded)
        {
            _name = name;
            _discount = discount;
            _itemsNeeded = itemsNeeded;
        }

        public string name { get { return _name; } }
        public float discount { get { return _discount; } }
        public List<Item> itemsNeeded { get { return _itemsNeeded; } }
    }
}
