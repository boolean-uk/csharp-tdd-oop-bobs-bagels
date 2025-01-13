using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private List<Iproduct> _items = new List<Iproduct>();
        public List<Iproduct> Items
        {
            get { return _items; }
            set { _items = value; }
        }
        public void Add(Iproduct item)
        { 
            Items.Add(item);        
        }
            
    }
}
