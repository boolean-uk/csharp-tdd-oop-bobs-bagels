using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Person
    {
        Random random = new Random();
        private string _firstName;
        private string _lastName;
        private int _age;
        private Basket _basket;

        public Person(string firstName, string lastName) { 
            _firstName = firstName;
            _lastName = lastName;
            _age = random.Next(12, 74);
            _basket = null; //if you dont have a basket no bagels for you
        }

        public void grabBasket()
        {
            _basket = new Basket();
        }
    }
}
