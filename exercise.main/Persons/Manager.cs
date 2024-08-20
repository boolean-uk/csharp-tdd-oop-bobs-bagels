using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Persons
{
    public class Manager : Person
    {
        private bool _isManager;
        public bool IsManager { get => _isManager; set => _isManager = value; }
        public Manager(string name, bool isManager) : base(name, isManager) 
        {
            IsManager = true;
        }
    }
}
