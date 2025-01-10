using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        public List<Item> items = new List<Item>();
        public Basket()
        {

        }

        public void Add(Item item)
        {
            items.Add(item);
        }

    }
}
