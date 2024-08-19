using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace exercise.main

{
    public class Basket
    {
        public List<Item> Item { get; set; } = new List<Item> { };

        public int _max_capasity { get; set; } = 5;

        public void addItem(Item item)
        {
            if (Item.Count() < _max_capasity)
            {
                Item.Add(item);
            }

        }

        public void removeItem(Item item)
        {
            if (Item.Count() > _max_capasity)
            {
                Item.Remove(item);
            }

        }


    }

}
