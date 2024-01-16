using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Class_Items
{
    public class Bagle : Product
    {
        private string _name;
        public string Name { get { return _name; } }
        public Bagle(string name)
        {
            _name = name;
        }
    }
}
