using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace exercise.main

{
    public class Basket
    {
        public List<Item> Item { get; set; } = new List<Item> { };

        public int max_capasity { get; set; } 

        public void addItem(Item item)
        {
            if (Item.Count() <= max_capasity)
            {
                Item.Add(item);
            }

        }
        public void removeItem(Item item)
        {
            if (Item.Count() > max_capasity)
            {
                Item.Remove(item);
            }

        }
        public bool isFull()
        {
          if (Item.Count() <= max_capasity)
            {
                return true;
            }
             return false;
        }

        public bool changecapacity(int newcapasity)
        {
            
            if (newcapasity > 0)
            {
                max_capasity = newcapasity;
                return true;
            }
            return false;

        }

        
    }

}
