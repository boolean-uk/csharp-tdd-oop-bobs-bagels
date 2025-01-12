using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main
{
    public class Person
    {
        private int _id;
        private bool _isManager;
        private Basket? _basket;

        public Person(int id, bool isManager)
        {
            _id = id;
            _isManager = isManager;
        }
    }
}