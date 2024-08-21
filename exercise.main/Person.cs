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

        public Person(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
            _age = random.Next(12, 74);
        }


    }
}
