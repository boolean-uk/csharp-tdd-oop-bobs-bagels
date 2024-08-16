using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Customer : Manager
    {
        public Basket basket = new Basket();
        public float wallet { get; set; }
        public Customer(float allowance)
        {
            this.wallet = allowance;
        }
    }
}
