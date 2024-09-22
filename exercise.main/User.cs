using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class User
    {
        private Role _role;
        public User(Role role)
        {
            _role = role;
        }
        public Role Role { get { return _role; } }
        public Basket AssignedBasket { get; set; }
    }
}
