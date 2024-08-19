using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Manager
    {
        private int capacity = 5;

        public bool ChangeCapcity(int newCapacity)
        {
            if(newCapacity < 0)
            {
                return false;
            }
            capacity = newCapacity; 
            return true;
            
        }

        public bool ConfirmOrder(string name, string variant, double funds, int basketSize)
        {
            throw new NotImplementedException();
        }
    }
}
