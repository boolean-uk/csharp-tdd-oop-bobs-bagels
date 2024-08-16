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
        public int MAX_BASKET_SIZE { get; set; } = 3;
        public List<Item> yourBasket = new List<Item>();
    }
}
