using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private int _id;
        private int _capacity;
        public int Id { get { return _id; } set { _id = value; } }
        public int Capacity { get { return _capacity; }set { _capacity = value; } }

        private List<Item> _items;

        public List<Item> Items
        {
            get { return _items; }
  
        }

      
        public Basket(int capacity) { 
            this._items = new List<Item>();
            this._capacity = capacity;
        }

        public bool AddItem(Item item)
        {

            if (_items.Count >= _capacity){
                return false;
            }
            _items.Add(item);
            return true;
        }

        public bool RemoveItem(Item item)
        {

            if (_items.Contains(item))
            {
                _items.Remove(item);
                return true;
            }
            return false;
        }

        public double GetPrice()
        {
            double price = 0;
            
            foreach(var product in _items)
            {
                price += product.Price;

            }
            price = Math.Round(price, 2);

            
            return price;
        }

        public double GetDiscountPrice()
        {
            
            List<Item> bagels = this._items.Where(x => x.GetType() == typeof(Bagel)).ToList();
            List<Item> coffee = this._items.Where(x => x.GetType() == typeof(Coffee)).ToList();
            List<Item> filling = this._items.Where(x => x.GetType() == typeof(Filling)).ToList();
            List<Filling> bagelFilling = new List<Filling>();


            foreach (var item in bagels)
            {
                Bagel bagel = (Bagel)item;
               
                bagelFilling.AddRange(bagel.GetFillings());    
            }
            //Getting discount on bagels
            double price = 0;
            int bagelsLeft = bagels.Count;

            price += (bagelsLeft / 12) * 3.99;
            bagelsLeft = bagels.Count % 12;
            price += (bagelsLeft / 6) * 2.49;
            bagelsLeft = bagelsLeft % 6;
            
            price += bagelsLeft * 0.49;

            //Adding fillings to price

            foreach (var item in bagelFilling)
            {
                price += item.Price;
            }

            //Adding price of coffee items
            foreach (var item in coffee)
            {
                price += item.Price;
            }

            //Adding price of fillings
            foreach (var item in filling)
            {
                price += item.Price;
            }
            return Math.Round(price, 2);

        }

        public bool ChangeCapacity(Person person, int newCapacity)
        {
            if (person.Manager == true)
            {
                _capacity = newCapacity;
                return true;
            }
            return false;
        }

       
    }
}
