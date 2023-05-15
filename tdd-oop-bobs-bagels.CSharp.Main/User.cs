using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class User
    {
        public UserRole Role { get; set; }
        public Basket Basket { get; private set; }

        public User(UserRole Role, Inventory inventory)
        {
            this.Role = Role;
            this.Basket = new Basket(inventory);
            
        }

    }

    public enum UserRole
    {
        MemberOfPublic,
        Customer,
        Manager
    }
}
