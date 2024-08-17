using csharp_tdd_bobs_bagels.tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_bobs_bagels.CSharp.Main
{

    public class Basket
    {
        private List<Bagel> _items = new List<Bagel>();
        private int _capacity = 5;
        private int _amount = 0;
        private Dictionary<string, float> _allowedFlavor = new Dictionary<string, float>()
        {
            {"onion",0.49f},
            {"plain",0.39f},
            {"everything",0.49f},
            {"sesame",0.49f}
        };


        public Basket()
        {

        }

        public bool Add(Bagel bagelName)
        {
            if ((_amount < Capacity) )
            {
                _items.Add(bagelName);
                _amount++;

                return true;
            }
            return false;
        }

        public bool Remove(Bagel bagelName)
        {
            if (_items.Contains(bagelName))
            {
                _items.Remove(bagelName);
                _amount--;
                return true;
            }
            return false;
        }

        public void ChangeCapacity(int v)
        {
            _capacity = v;
        }

        public List<Bagel> Items { get => _items; set => _items = value; }
        public int Capacity { get => _capacity; set => _capacity = value; }
    }

}
