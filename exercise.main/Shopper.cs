using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BobsBagels.main
{
    public class Shopper : User
    {
        private Basket _basket = new();

        public float Total() { throw new NotImplementedException(); }
        public float GetItemPrice(Item item) { throw new NotImplementedException(); }
        public float GetFillingPrice(Item item) { throw new NotImplementedException(); }
        public Basket Basket { get { return _basket; } }

    }
}
