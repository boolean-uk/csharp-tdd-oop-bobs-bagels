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

        public Basket()
        {

        }

        public void Add(Bagel bagelName)
        {
            if (_amount < _capacity)
            {
                _items.Add(bagelName);
                _amount++;
            }
        }

        public List<Bagel> Items { get => _items; set => _items = value; }
    }

}
