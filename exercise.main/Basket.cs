using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        Inventory inventory = new Inventory();
        private int MAX_BASKET_SIZE { get; set; } = 5;

        public List<Item> basketItems = new List<Item>();

        public bool addItem(Item? plainBagel)
        {
            throw new NotImplementedException();
        }
    }
}
