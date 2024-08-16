using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private int _basketCapacity;
        private Dictionary<Item, int> _items = new Dictionary<Item, int>();

        public Basket(int basketCapacity = 3)
        {
            _basketCapacity = basketCapacity;
        }

        public bool AddItem(Item item)
        {
            return false;
        }

        public int BasketCapacity { get { return _basketCapacity; } }
    }
}
