using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace exercise.main

{
    public class Basket
    {
        public List<Item> item {  get; set; }  = new List<Item> { };

        public int _max_capasity { get; set; } = 5;

        public void addItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
    
    

}
