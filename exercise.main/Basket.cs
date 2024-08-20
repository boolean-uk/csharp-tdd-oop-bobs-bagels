using csharp_tdd_bobs_bagels.tests;
using exercise.main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_bobs_bagels.CSharp.Main
{

    public class Basket
    {
        private List<Bagel> _bagels = new List<Bagel>();
        private List<Coffee> _coffee = new List<Coffee>();
        private int _capacity = 10;
        private int _amount = 0;
        private float _totalPrice = 0;
        
        public Basket()
        {

        }

        public bool Add(Bagel bagelName)
        {
            if ((_amount < Capacity))
            {
                _bagels.Add(bagelName);
                _amount++;
                _totalPrice += bagelName.Price;

                return true;
            }
            return false;
        }
        public bool Add(Coffee coffeeName)
        {
            if ((_amount < Capacity))
            {
                _coffee.Add(coffeeName);
                _amount++;
                _totalPrice += coffeeName.Price;

                return true;
            }
            return false;
        }
        public void Discount()
        {
            int discount6Bagels = _bagels.Count() /  6;

            if (discount6Bagels > 0)
            {
                _totalPrice -= 0.45f * discount6Bagels;

                int bagelCount = _bagels.Count - (discount6Bagels * 6);

                if (bagelCount > 0 && _coffee.Count > 0)
                {
                    int coffeeCount = _coffee.Count(); 
                    while (coffeeCount > 0 && bagelCount > 0)
                    {
                        _totalPrice -= 0.23f;
                        coffeeCount -= 1;
                        bagelCount -= 1;
                    }
                }
            }
            
        }

        public bool Remove(Bagel bagelName)
        {
            if (_bagels.Contains(bagelName))
            {
                _bagels.Remove(bagelName);
                _amount--;
                return true;
            }
            return false;
        }

        public void ChangeCapacity(int v)
        {
            _capacity = v;
        }

        public float Total()
        {
            return _totalPrice;
        }

        public List<Bagel> AmountOfBagels { get => _bagels; set => _bagels = value; }
        public int Capacity { get => _capacity; set => _capacity = value; }
    }

}


