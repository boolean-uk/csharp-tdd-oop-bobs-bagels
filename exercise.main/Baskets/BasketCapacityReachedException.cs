using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Baskets
{
    public class BasketCapacityReachedException : Exception
    {
        public BasketCapacityReachedException()
        {
            
        }
        public BasketCapacityReachedException(string message) : base(message)
        {
            
        }
    }
}
