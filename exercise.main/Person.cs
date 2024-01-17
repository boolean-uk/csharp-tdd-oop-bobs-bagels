using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Person
    {
        private string _adminLevel;
        public Person(string adminLevel) { 
            _adminLevel = adminLevel;
        
        }

        public string AdminLevel { get { return _adminLevel; } }
    }
}
