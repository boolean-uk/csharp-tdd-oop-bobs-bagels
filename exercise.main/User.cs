using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class User
    {
        public Basket UserBasket = new Basket();
        public bool AddToBasket(string sku)
        {
            return UserBasket.Add(sku);

        }

        public void RemoveFromBasket(string sku)
        {
            UserBasket.Remove(sku);
        }
    }
}
