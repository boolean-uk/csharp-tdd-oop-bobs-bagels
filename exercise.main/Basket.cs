using exercise.main.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        List<Product> _basket = new List<Product>();
        int _maxBasketSize = 5;

        public bool AddItemToBasket(Product item) 
        {
            throw new NotImplementedException();
        }

        public bool AddItemToBasket(string[] SKUs)
        {
            throw new NotImplementedException();
        }

        public int SetBasketSize(int newSize) 
        {
            throw new NotImplementedException();
        }

        public float GetBasketPrice() 
        { 
            throw new NotImplementedException();
        }

        public bool RemoveProductFromBasket(Product item) 
        {
            throw new NotImplementedException();
        }

        public bool RemoveProductFromBasket(string[] SKUs)
        {
            throw new NotImplementedException();
        }


        public bool IsFull() 
        {
            throw new NotImplementedException();
        }
    }
}
