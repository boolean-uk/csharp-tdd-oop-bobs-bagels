using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private int _capacity;
        private List<string> _contents = new List<string>();
        public Basket(int capacity, List<string> contents)
        {
            _capacity = capacity;
            _contents = contents;
        }
        public bool addItem()
        {
            return false;
        }
        public bool removeItem()
        {
            return false;
        }
        private int changeCapacity()
        {
            return 0;
        }
    }
}