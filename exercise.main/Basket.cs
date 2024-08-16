using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private int _basketID;
        private int _basketCapacity = 3;
        private Dictionary<Item, int> _items = new Dictionary<Item, int>();

        public Basket(int basketID, int basketCapacity)
        {
            _basketID = basketID;
            _basketCapacity = basketCapacity;
        }

        public int BasketID { get { return _basketID; } }
        public int BasketCapacity { get { return _basketCapacity; } }
    }
}
