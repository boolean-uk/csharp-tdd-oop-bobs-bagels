using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Manager
    {
        private int id;
        private string name;
        public Manager(string name)
        {
            this.id = GetHashCode();
            this.name = name;
                       
        }
        public void SetMaxSize(int max, Customer c) => c.Basket.SetBasketMaxSize(max);
    }
    
}
