using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{

    public class Core
    {
        private List<string> _bagels;
        int _nrBagels;
        int _capacity;

        public Core()
        {
            _bagels = new List<string>();
            _nrBagels = 0;
            _capacity = 5;
        }

        public List<string> Bagels { get { return _bagels; } }

        public void Add(string bagel)
        {
            if (_nrBagels != _capacity)
            {
                Bagels.Add(bagel);
                _nrBagels++;
            }
            else
            {
                throw new Exception("Basket is full");
            }
        }

        public void Remove(string bagel)
        {
            if (!Bagels.Remove(bagel))
            {
                throw new Exception("Bagel is not in basket");
            }
        }

        public void IncreaseCapacity()
        {

            //BIG customer waves for breakfast :PPPP
            _capacity *= 3; //upping capacity 3 times.
            Console.WriteLine($"Increased capacity to: {_capacity}");
        }
    }
}