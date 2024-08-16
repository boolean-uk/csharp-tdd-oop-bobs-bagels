using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class User
    {
        private bool _isManager = false;
        public User(bool isManager = false)
        {
            _isManager = isManager;
        }
        public bool IsManager { get { return _isManager; } }
    }
}
