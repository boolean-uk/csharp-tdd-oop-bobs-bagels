using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Customer
    {
        Basket basket = new Basket();
        Inventory inventory = new Inventory();
        int funds = 0;
        public Customer(int funds)
        {
            this.funds = funds;
        }

        public void ViewMenu()
        {
            
        }
    }
}
