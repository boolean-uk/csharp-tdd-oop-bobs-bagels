using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Classes
{
    public class Basket
    {
        public List<Item> Items { get; set; } = new();
        public int Capacity { get; set; }

        public Basket(int capacity) 
        { 
            Capacity = capacity;
            //Items.Add(new Item("", 0, 0, ""));
        }

        public string Add(Item item) //code is "decoded" in store class
        {
            throw new NotImplementedException();
        }

        public string Remove(string sku) 
        { 
            throw new NotImplementedException(); 
        }

        public double Cost()
        {
            throw new NotImplementedException();
        }

    }
}
