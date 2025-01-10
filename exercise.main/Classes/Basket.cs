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

        public void Add(Product item, int amount) 
        {
            BasketItem alreadyExists = _items.Find(x => x.Product.Equals(item));

            // If the product already exists in the basket
            if (alreadyExists != null)
            {
                alreadyExists.Amount += amount;
            }
            else 
            {
                BasketItem newItem = new BasketItem(item, amount);
                _items.Add(newItem);
            }

            

        }
        public void Remove(Product item) { }

        public void SetCapacity(int size) { }

        public double GetTotal()
        {
            throw new NotImplementedException();
        }

        public List<BasketItem> GetItems()
        {
            return _items;
        }

        public List<BasketItem> SubmitOrder()
        {
            return _items;
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
