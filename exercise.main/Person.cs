using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{

    public enum Role { MANAGER, CUSTOMER }
    public class Person
    {
        public string name {  get; set; }
        public Role role { get; set; }

        public Person() { }
        public Person(string name, Role role)
        {
            this.name = name;
            this.role = role;
        }
        
    }
}
