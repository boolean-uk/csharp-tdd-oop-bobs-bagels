using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Classes
{
    public class Basket
    {
        private List<BasketItem> _items;
        private int _capacity;
        public Basket() 
        {
            _items = new List<BasketItem>();
            _capacity = 10;
        }

        public void Add(Product item) { }
        public void Remove(Product item) { }

        public void SetCapacity(int size) { }

        public double GetTotal()
        {
            throw new NotImplementedException();
        }

        public List<BasketItem> GetItems()
        {
            throw new NotImplementedException();
        }

        public List<BasketItem> SubmitOrder()
        {
            throw new NotImplementedException();
        }

        private void CheckDiscounts()
        {
            throw new NotImplementedException();
        }

        private bool CheckCapacity()
        {
            throw new NotImplementedException();
        }
    }
}
