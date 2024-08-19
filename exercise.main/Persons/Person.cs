using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Persons
{
    public class Person
    {
        private Basket _basket;
        private bool _isManager;
        public Basket Basket { get => _basket; }
        public bool IsManager;

        public Person() 
        { 
            _basket = new Basket(); 
        }
    }
}
