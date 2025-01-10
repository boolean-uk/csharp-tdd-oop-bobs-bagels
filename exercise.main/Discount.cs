using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Discount
    {
        private string _SKU;
        private float _discount;
        private List<Item> _itemsNeeded;
        public Discount(string sKU, float discount, List<Item> itemsNeeded)
        {
            _SKU = sKU;
            _discount = discount;
            _itemsNeeded = itemsNeeded;
        }

        public string SKU { get { return _SKU; } }
        public float discount { get { return _discount; } }
        public List<Item> itemsneeded { get { return _itemsNeeded; } }
    }
}
