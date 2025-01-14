using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Store
    {
        public int _basketCapacity { get; set; }
        public List<Customer> _customerList { get; set; }
        public List<Item> _itemsInStock { get; set; }

        public Store(int basketCapacity, List<Item> stock)
        {
            _basketCapacity = basketCapacity;
            _customerList = new List<Customer>();
            _itemsInStock = stock;
        } 

        public void SetCapacity(int newCapacity)
        {
            _basketCapacity = newCapacity;
            foreach(Customer customer in _customerList)
            {
                while(customer._basket._items.Count > _basketCapacity)
                {
                    customer._basket._items.RemoveAt(customer._basket._items.Count - 1);
                }
            }
        }
    }
}
