using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Bagel : Product
    {
        private List<Filling> _fillings = [];

        public Bagel(string sku, float price, ProductType type, string variant) : base(sku, price, type, variant)
        {
        }

        public List<Filling> Fillings { get { return _fillings; } set { _fillings = value; } }
    }
}
