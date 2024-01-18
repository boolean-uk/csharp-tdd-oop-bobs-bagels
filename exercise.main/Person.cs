using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public  class Person
    {
        public string Name { get; }

        private bool _admin; 

        public Basket basket;
        public Person(string name, bool admin = false)
        {
            Name = name;
            _admin = admin;
            basket = new Basket(this);

        }

        public Basket GetBasket() 
        {
            return basket;
        }

        public bool IsAdmin() 
        { 
            return _admin; 
        }

    }
}
