using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        List<Product> products;
        static int capacity;

        public bool add(string v)
        {
            Product value = BagelShop.Category[v];
            return true;
        }

        public bool remove(string v)
        {
            Product value = BagelShop.Category[v];
            return true;
        }
    }
}
