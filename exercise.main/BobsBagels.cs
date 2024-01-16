using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main
{
    public class BobsBagels
    {
        private Dictionary<string, int> _stock;
        private int _capacity;

        public BobsBagels()
        {
            _stock = new Dictionary<string, int>() 
            {
                {"Onion", 100}, {"Plain", 100}, {"Everything", 100}, {"Sesame", 100}
            };

            _capacity = 10;
        }

        public Dictionary<string, int> Stock { get => _stock; }
        public int Capacity { get => _capacity; set => _capacity = value; }
    }
}