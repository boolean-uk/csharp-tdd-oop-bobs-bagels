using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Models
{
    public class Basket
    {

        public List<Product> Products { get; set; }
        public int Capacity { get; set; }
        public Basket(int capacity) {
            Capacity = capacity;
            Products = new List<Product>();
        }
        public bool Add(Product product)
        {
            if (Products.Count < Capacity)
            {
                Products.Add(product);
                return true;
            }
            return false;
        }

        public decimal GetTotalPrice()
        {
            return Products.Sum(p =>
            {
            decimal price = 0;
            if (p is Bagel bagel)
            {
                return bagel.GetTotalPrice();
                }
                else
                {
                    return p.Price;
                }
            });
        }

        public bool Remove(Bagel bagel)
        {
           if(Products.Contains(bagel))
            {
                Products.Remove(bagel);
                return true;
            }
            return false;
        }

        public void UpdateCapacity(int capacity, Role role)
        {
            if(role == Role.Manager)
            {
                Capacity = capacity;
            }
            else
            {
                throw new Exception("You are not authorized to update the capacity");
            }
        }
    }
}
