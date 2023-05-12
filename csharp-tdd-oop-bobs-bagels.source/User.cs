using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_tdd_oop_bobs_bagels.source
{
    public class User
    {
        private string name;
        private string role;
        private List<Product> products;

        public User()
        {

        }

        public User(string name, string role)
        {
            this.name = name;
            this.role = role;
            products = new List<Product>();
        }

        public string Name { get => name; set => name = value; }
        public string Role { get => role; set => role = value; }
        public List<Product> Products { get => products; set => products = value; }
    }
}
