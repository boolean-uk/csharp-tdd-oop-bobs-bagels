using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {

        public int MaxCapacity { get; set; } = 5;
        public List<Product> Product { get; set; } = new List<Product>();
        public int totalCost { get; set; }

        public bool Remove(Product removableItem)
        {
            if (Product.Contains(removableItem))
            {
                Product.Remove(removableItem);
                return true;
            }

            return false;
        }
    }
}
