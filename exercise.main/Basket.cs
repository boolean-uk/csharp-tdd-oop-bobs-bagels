using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_bobs_bagels.CSharp.Main
{

    public class Basket
    {
        private List<string> _items = new List<string>();
        private int _capacity = 5;
        private int _amount = 0;

        public Basket()
        {

        }

        public List<string> Items { get => _items; set => _items = value; }
        public int Capacity { get => _capacity; set => _capacity = value; }

        public void add(string bagelName)

        {
            if (_amount <= Capacity)
            {
                _items.Add(bagelName);
                _amount++;
            }
            else
            {
                Console.WriteLine("Sorry, your basket does not have enough space");
            }
        }

        public void changeCap(int v)
        {
            _capacity = v;
        }

        public bool remove(string bagelName)
        {
            if (_items.Contains(bagelName))
            {
                _items.Remove(bagelName);
                return true;
            }
            return false;
        }


    }

}
