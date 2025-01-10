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

        public bool Add(Product item, int amount) 
        {
            // Check if the capacity is full
            if (_items.Count >= _capacity) 
            {
                return false;
            }

            BasketItem alreadyExists = _items.Find(x => x.Product.Equals(item));

            // If the product already exists in the basket
            if (CheckIfProductExistsInBasket(item))
            {
                BasketItem foundItem = GetItemFromBasket(item);
                foundItem.Amount += amount;
            }
            else 
            {
                BasketItem newItem = new BasketItem(item, amount);
                _items.Add(newItem);
            }

            return true;

        }
        public void Remove(Product item) 
        {
            if (CheckIfProductExistsInBasket(item))
            {
                _items.Remove(GetItemFromBasket(item));
            }
            
        }

        public void Remove(string sku) 
        { 
            _items.Remove(GetItemBySKU(sku));
        }

        public int Capacity
        {
            get => _capacity;
            set { _capacity = value; }
        }

        public double GetTotal()
        {
            double total = 0;
            foreach (var item in _items) 
            {
                total += item.Product.GetPrice();
            }
            return total;
        }

        public List<BasketItem> GetItems()
        {
            return _items;
        }

        public List<BasketItem> SubmitOrder()
        {
            return _items;
        }

        public BasketItem GetItemBySKU(string sku)
        {
            return _items.Find(x => x.Product.GetSKU().Equals(sku));
        }

        private void CheckDiscounts()
        {
            throw new NotImplementedException();
        }

        private bool CheckCapacity()
        {
            throw new NotImplementedException();
        }

        public bool CheckIfProductExistsInBasket(Product item)
        {
            return GetItemFromBasket(item) == null ? false : true;

        }

        private BasketItem GetItemFromBasket(Product item)
        {
            return _items.Find(x => x.Product.GetSKU().Equals(item.GetSKU()));
        }
    }
}
