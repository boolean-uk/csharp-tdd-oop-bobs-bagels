using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Class_Items
{
    public class Bagle : Product
    {
        private List<Filling> _fillings;

        override public double Price 
        { 
            get 
            {
                double total = _price;
                foreach (var filling in _fillings)
                {
                    total += filling.Price;
                }
                return total; 
            } 
        }

        public Bagle(string sku, double price, ProdType type, string varaiant) : base(sku, price, type, varaiant)
        {
            _fillings = new List<Filling>();
        }

        public override void AddFilling(Filling fill)
        {
            _fillings.Add(fill);
        }
    }
}
