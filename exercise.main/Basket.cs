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
                Type t = i.GetType();
                Item newItem = (Item)Activator.CreateInstance(t, i.Sku, i.Price, i.Name, i.Variant);
                this._items.Add(newItem);
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

        public double CheckBasketCostDiscounted()
        {
            double price = 0.0;

            List<Item> bagels = this._items.Where(i => i.GetType() == typeof(Bagel)).ToList();
            List<Item> coffee = this._items.Where(i => i.GetType() == typeof(Coffee)).ToList();
            List<Filling> fillings = new List<Filling>();
            foreach (Bagel bagel in bagels)
            {
                foreach (Filling f in bagel.Fillings)
                {
                    fillings.Add(f);
                }
            }

            if (bagels.Count() == 1 && coffee.Count() == 1 && fillings.Count() == 0)
            {
                return 1.25;
            }

            int bagelsLeft = bagels.Count();
            int coffeeleft = coffee.Count();

            price += (bagelsLeft / 12) * 3.99;

            bagelsLeft = bagelsLeft % 12;

            price += (bagelsLeft / 6) * 2.49;

            bagelsLeft = bagelsLeft % 6;
             price += bagelsLeft * 0.49;

            price += fillings.Select(f => f.CheckItemCost()).Sum();
            price += coffee.Select(c => c.CheckItemCost()).Sum();
            return Math.Round(price, 2);
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
