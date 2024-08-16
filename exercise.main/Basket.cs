using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {

        public decimal GetTotalCost()
        {
            decimal totalCost = 0M;

            foreach(Product Product in ProductList)
            {
                totalCost += Product.Price;
            }

            return totalCost;
                
        }

        public bool Remove(Product removableItem)
        {
            if (ProductList.Contains(removableItem))
            {
                ProductList.Remove(removableItem);
                return true;
            }

            return false;
        }

        public int MaxCapacity { get; set; } = 5;
        public List<Product> ProductList { get; set; } = new List<Product>();
        public int totalCost { get; set; }
    }
}
