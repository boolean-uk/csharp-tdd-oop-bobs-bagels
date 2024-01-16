using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Classes
{
    public class Store
    {
        public int capacity { get; set; } = 16;
        public List<Basket> Baskets { get; set; } = new();
        public Store() 
        { 
            Stock stock = new();

        }

        public string Price(Name name)
        {
            throw new NotImplementedException();
        }

        public void SetCapacity(int capacity) 
        { 
            throw new NotImplementedException(); 
        }

        public void AddItem(Basket basket, string sku)
        {
            throw new NotImplementedException();
        }
    }
}
