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
            Dictionary<string, int> bagelCount = new Dictionary<string, int>();
            foreach(Bagel bagel in  Bagels)
            {
                if (!bagelCount.ContainsKey(bagel.SKU))
                {
                    bagelCount.Add(bagel.SKU, 1);
                }
                else
                {
                    bagelCount[bagel.SKU]++;
                }

            }

            double sum = 0;
            foreach ((string SKU, int count) in bagelCount)
            {
                if (count == 6) sum += 2.49;
                else if (count == 12) sum += 3.99;
                else sum += new Bagel(SKU).Price;
            }

            sum += Bagels.Sum(bagel => bagel.Filling is not null ? bagel.Filling.Price : 0);
            sum += Coffees.Sum(coffee => coffee.Price);

            return sum;
        }
    }
}