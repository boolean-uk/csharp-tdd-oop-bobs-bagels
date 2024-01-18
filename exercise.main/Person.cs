using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Person
    {
        private Basket _basket;
        public Basket Basket { get { return _basket; } set { _basket = value; } }

        private bool _isManager;
        public bool IsManager { get { return _isManager; } set { _isManager = value; } }

        public Person(Basket basket = null, bool isManager = false)
        {
            Basket = basket;
            IsManager = isManager;
        }

        public bool IsProductInInventory(string sKU)
        {
            return Store.IsProductInInventory(sKU);
        }

        public bool ChangeBasketSize(bool isManager, int newCapacity)
        {
            return Store.ChangeBasketSize(isManager, newCapacity);
        }
    }
}
