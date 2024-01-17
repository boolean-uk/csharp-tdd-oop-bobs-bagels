using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main
{
    public class Basket
    {
        private List<string> _bagels;
        private int _capacity;

        public Basket(int capacity)
        {
            _bagels = new List<string>();
            _capacity = capacity;
        }

        public int Capacity
        { 
            get { return _capacity; }
            set { _capacity = value; }
        }

        public List<string> Bagels
        {
            get { return _bagels; }
        }

        public void AddBagel(string bagel) 
        {
        if (_bagels.Count < _capacity)
            {
                _bagels.Add(bagel);
                Console.WriteLine($"Added '{bagel}' to the basket");
            }
            else
            {
                throw new InvalidOperationException("Basket is full");
            }
        }

        public void RemoveBagel(string bagel)
        {
            if( _bagels.Remove(bagel) )
            {
                Console.WriteLine("Removed '{bagel}' from basket");
            }
            else
            {
                throw new InvalidOperationException("Bagel is not in the basket");
            }
        }
    }
}