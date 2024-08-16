using exercise.main.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Persons
{
    public class Customer
    {
        private Basket _basket;
        public Basket Basket { 
            get {  return this._basket; }
        }
        public Customer() 
        { 
            this._basket = new Basket(); 
        }
        public bool Add(Item item)
        {
            _basket.AddItemToBasket(item);
            return true;
        }
    }
}
