using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Baskets
{
    public class ItemNotInBasketException : Exception
    {
        public ItemNotInBasketException()
        {
            
        }

        public ItemNotInBasketException(string message) : base(message) 
        {
            
        }
    }
}
