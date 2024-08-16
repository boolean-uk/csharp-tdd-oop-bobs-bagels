using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class BasketItem : IInventory
    {
        public bool InStock()
        {
            return false;
        }
    }
}
