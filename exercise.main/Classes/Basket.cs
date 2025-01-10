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

        private bool CheckIfProductExistsInBasket(Product item)
        {
            return GetItemFromBasket(item) == null ? false : true;

        }

        private BasketItem GetItemFromBasket(Product item)
        {
            return _items.Find(x => x.Product.GetSKU().Equals(item.GetSKU()));
        }
    }
}
