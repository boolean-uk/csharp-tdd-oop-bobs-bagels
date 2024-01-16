using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Objects
{
    public class Manager
    {
        public bool AlterSize(Basket basket, int newSize)
        {
            return basket.BasketSize(newSize);
        }
    }
}
