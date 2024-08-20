using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Persons
{
    public class Person
    {
        #region Properties
        private bool _isManager;
        private string _name;
        
        public bool IsManager;
        public string Name { get => _name; set => _name = value; }
        #endregion

        public Person(string name, bool isManager) 
        {
            _name = name;
            _isManager = isManager;
        }
    }
}
