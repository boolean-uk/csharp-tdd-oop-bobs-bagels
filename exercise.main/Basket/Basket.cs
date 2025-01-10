using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Products;

namespace exercise.main.Basket
{
    internal class Basket : IBasket
    {
        public int Capacity { get; }

        public void AddItem(Product p)
        {
            throw new NotImplementedException();
        }

        public bool Contains(Product p)
        {
            throw new NotImplementedException();
        }

        public double GetTotalCost()
        {
            throw new NotImplementedException();
        }

        public bool IsFull()
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(Product o)
        {
            throw new NotImplementedException();
        }

        public void SetCapacity(int newCapacity)
        {
            throw new NotImplementedException();
        }
    }
}
