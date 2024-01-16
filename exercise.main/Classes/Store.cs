using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Classes
{
    public class Store
    {
        public List<Basket> baskets { get; set; } = new List<Basket>();
        public Store() 
        { 
            Stock stock = new Stock();

        }

        public string Price(Name name)
        {
            throw new NotImplementedException();
        }
    }
}
