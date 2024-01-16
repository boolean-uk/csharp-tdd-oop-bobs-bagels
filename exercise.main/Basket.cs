using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main
{
    public class Basket
    {
        private List<Bagel> _bagels;
        private List<Coffee> _coffee;
        private int _capacity;
        private int _nrItems;

        public Basket()
        {
            _bagels = new List<Bagel>();
            _coffee = new List<Coffee>();
            _capacity = 10;
            _nrItems = 0;
        }

        public List<Bagel> Bagels { get =>  _bagels; }
        public List<Coffee> Coffees { get => _coffee; }
        public int Capacity { get => _capacity; set => _capacity = value; }
        public int NrItems { get => _nrItems; set => _nrItems = value; }

        public void Add(Bagel bagel)
        {
            if (Bagels.Count + Coffees.Count == Capacity)
            {
                throw new Exception("Basket is full");
            }

            Bagels.Add(bagel);
            NrItems++;
        }

        public void Remove(Bagel bagel)
        {
            if (Bagels.Contains(bagel))
            {
                Bagels.Remove(bagel);
                NrItems--;
            }
            else
            {
                throw new Exception("Bagel does not exist in basket");
            }
        }

        public void Add(Coffee coffee)
        {
            if (Coffees.Count + Bagels.Count == Capacity)
            {
                throw new Exception("Basket is full");
            }
            
            Coffees.Add(coffee);
            NrItems++;
        }

        public void Remove(Coffee coffee)
        {
            if(Coffees.Contains(coffee))
            {
                Coffees.Remove(coffee);
                NrItems--;
            }
            else
            {
                throw new Exception("Coffee does not exist in basket");
            }
        }

        public double GetTotal()
        {
            double sum = Coffees.Sum(coffee => coffee.Price);
            sum += Bagels.Sum(bagel => bagel.Price);
            return sum;
        }
    }
}