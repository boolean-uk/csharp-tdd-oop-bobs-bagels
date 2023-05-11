using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class User
    {
        private string name;
        private string role;
        private List<Item> items;

        public string Name { get { return name; } set { name = value; } }
        public string Role { get { return role; } set { role = value; } }
        public List<Item> Items { get { return items; } set { items = value; } }

        public User(string Name, string Role) {
            this.Name = Name;
            this.Role = Role;
            Items = new List<Item>();
        }
    }
}
