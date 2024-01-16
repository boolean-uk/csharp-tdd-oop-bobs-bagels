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
        private double _totalPrice;

        public Basket()
        {
            _bagels = new List<Bagel>();
            _capacity = 10;
            _totalPrice = 0;
        }

        public List<Bagel> Bagels { get =>  _bagels; }
        public int Capacity { get => _capacity; set => _capacity = value; }
        public double Total { get => _totalPrice; set => _totalPrice = value; }

        public void AddBagel(Bagel bagel)
        {
            if (Bagels.Count == Capacity)
            {
                throw new Exception("Basket is full");
            }

            Bagels.Add(bagel);
            Total += bagel.Price;
        }

        public void RemoveBagel(Bagel bagel)
        {
            if (Bagels.Contains(bagel))
            {
                Bagels.Remove(bagel);
            }
            else
            {
                throw new Exception("Bagel does not exist in basket");
            }
        }
    }
}