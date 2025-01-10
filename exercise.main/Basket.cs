using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Items;

namespace exercise.main
{
    public class Basket
    {
        public static int Capacity { get; set; } = 25;
        private List<Item> _items = [];
        public List<Item> Items { get { return _items; } }

        public bool Add(Item item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Item item) 
        { 
            throw new NotImplementedException(); 
        }

        public Receipt TotalCost { get { return new Receipt(_items); } }


    }
}
