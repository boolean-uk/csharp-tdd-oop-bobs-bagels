using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Objects
{
    public class BobsBagels
    {
        Inventory Inventory = new Inventory();
        private int _basketLimit = 4;

        public int Basketlimit { get { return _basketLimit; }set { _basketLimit = value; } }


        public BobsBagels() { }



       
    }
}
