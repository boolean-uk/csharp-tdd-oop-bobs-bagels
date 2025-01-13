using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private int _capacity = 10;
        public int Capacity
        {
            get { return _capacity; }
            set { _capacity = value; }
        }
        private List<Iproduct> _items = new List<Iproduct>();
       
        public List<Iproduct> Items
        {
            get { return _items; }
            set { _items = value; }
        }
        public void AddBagel(Iproduct item)
        { 
            if(!this.IsFull())
            {
                Items.Add(item);
            }
        }
        public void RemoveBagel(Iproduct item)
        {
            if (this.ItemNotPresent(item))
            {
                throw new ArgumentException("Parameter cannot be null", nameof(item)); //throws exception so the user can know item is not present
            }
            Items.Remove(item);
        }
        public bool IsFull() 
        {
            return Items.Count >= Capacity;
        }
        public bool ItemNotPresent(Iproduct item)
        {
            return !Items.Any(x => x == item);
        }
        public float GetTotalCost()
        { 
            float totalCost = 0F;
            Items.ForEach(x => totalCost += x.GetPrice());
            return totalCost;
        }
    }
}
