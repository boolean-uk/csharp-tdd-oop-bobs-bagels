using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Classes
{
    public class Basket
    {
        public List<Item> items { get; set; } = new List<Item>();
        public int Capacity { get; } = 15;

        public Basket() { }

        public string Add(Item item)
        {
            throw new NotImplementedException();
        }

        public string Remove(string variant) 
        { 
            throw new NotImplementedException(); 
        }

        public void SetCapacity(int capacity)
        {
            throw new NotImplementedException();
        }

    }
}
