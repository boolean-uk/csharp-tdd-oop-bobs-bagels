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

        public bool AddItem(string sku)
        {   
            Item i = Inventory.InventoryItems.Find(i => i.Sku == sku);

            if (this._items.Count() < this._capacity && i != null)
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

        public List<Item> FindItem(string sku)
        {
            
            List<Item> found = this._items.Where(i => i.Sku == sku).ToList();
            return found;
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
            return this._items.Select((i) => i.CheckItemCost()).Sum();
        }

        public override string ToString()
        {
            string output = "";
            foreach(Item i in this._items)
            {
            }
            for (int i = 0; i < this._items.Count(); i++)
            {
                output += $"{i} {this._items[i].ToString()}";
            }
            return output;
        }

        public List<Item> Items { get => this._items; set => this._items = value; }
        public int Capacity { get => this._capacity; set => this._capacity = value; }
        
    }
}
