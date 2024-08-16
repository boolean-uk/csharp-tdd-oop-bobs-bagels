using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {

        private List<Item> _items;
        private int _capacity;
        public Basket(int capacity)
        {
            this._items = new List<Item>();
            this._capacity = capacity;   
        }

        public bool AddItem(Item i)
        {
            if (this._items.Count() < this._capacity) 
            {
                this._items.Add(i);
                return true;
            }
            return false;
        }

        public bool RemoveItem(Item i)
        {
            if(this._items.Contains(i))
            {
                this._items.Remove(i);
                return true;
            }
            return false;
        }

        public bool ExtendBasket(int capacity)
        {
            if (capacity < 1 || capacity < _items.Count() || capacity == this._capacity)
            {
                return false;
            }
            else
            {
                this._capacity = capacity;
                return true;
            }
        }

        public double CheckBasketCost()
        {
            return this._items.Select((i) => i.Price).Sum();
        }
        
        public List<Item> Items { get => this._items; set => this._items = value; }
        public int Capacity { get => this._capacity; set => this._capacity = value; }
        
    }
}
