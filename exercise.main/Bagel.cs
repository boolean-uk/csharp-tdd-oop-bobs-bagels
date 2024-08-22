using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main
{
    public class Bagel : Item
    {
        //private string v1;
        //private double v2;
        private List<Filling> _fillings;

        public List<Filling> Fillings { get { return _fillings; } }

        public Bagel(string sku, float price, string name) : base(sku, price, name)
        {
            _fillings = new List<Filling>();
        }

        public bool AddFilling(Filling filling)
        {
            if (Inventory.inventory.Where(x => x.GetType() == typeof(Filling)).Contains(filling)) 
            { 
                _fillings.Add(filling);
                return true;
            }
            return false;
        }

        public bool RemoveFilling(Filling filling)
        {
            if (_fillings.Contains(filling))
            {
                _fillings.Remove(filling);
                return true;
            }
            return false;
        }

        public override float GetItemCost()
        {
            return this.Price + _fillings.Sum(x => x.Price);
        }
    }
}