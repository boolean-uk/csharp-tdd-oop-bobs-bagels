using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        List<Product> _products;
        List<Product> Products { get { return _products; } set { _products = value; } }

        private static int _basketCapacity = 12;
        public static int BasketCapacity { get { return _basketCapacity; } set { _basketCapacity = value; } }

        public Basket()
        {
            Products = new List<Product>();
        }
        public bool AddProduct(Product product)
        {
            if (Products.Count < BasketCapacity)
            {
                Products.Add(product);
                return Products.Contains(product);
            }
            else
            {
                return false;
            }

        }

        public bool RemoveProduct(Product product)
        {
            return Products.Remove(product);
        }

        public bool IsProductInBasket(Product product)
        {
            return Products.Contains(product);
        }

        public int TotalCapacity()
        {
            return BasketCapacity;
        }

        public int CheckCurrentCapacity()
        {
            return TotalCapacity() - Products.Count();
        }

        public double CheckTotalCost()
        {
            return CashRegister.CalculateReceipt(Products);
        }

    }
}
