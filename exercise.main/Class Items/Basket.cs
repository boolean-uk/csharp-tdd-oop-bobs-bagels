using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Class_Items
{
    public class Basket
    {
        private List<Bagle> _bagles;
        private int _capacity = 4;
        public Basket()
        {
            _bagles = new List<Bagle>();
        }

        public bool Add(Bagle bagle)
        {
            if (_bagles.Count < _capacity)
            {
                _bagles.Add(bagle);
                return true;
            }
            Console.WriteLine("Your basket is full!");
            return false;
        }

        public int Remove(string type)
        {
            if (_bagles.Exists(x => x.Name == type))
            {
                _bagles.RemoveAt(_bagles.IndexOf(_bagles.Find(x => x.Name == type)));
            }
            return _bagles.Count;
        }

        public int ChangeCapacity(int amount)
        {
            _capacity = amount;
            return _capacity;
        }
    }
}
