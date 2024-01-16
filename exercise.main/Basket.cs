using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main
{
    public class Basket
    {
        private List<Bagel> _bagels;
        private int _capacity;
        private int _totalPrice;

        public Basket()
        {
            _bagels = new List<Bagel>();
            _capacity = 10;
            _totalPrice = 0;
        }

        public List<Bagel> Bagels { get =>  _bagels; }
        public int Capacity { get => _capacity; set => _capacity = value; }
        public int Total { get => _totalPrice; }

        public void AddBagel(string Bagel)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveBagel()
        {
            throw new System.NotImplementedException();
        }
    }
}