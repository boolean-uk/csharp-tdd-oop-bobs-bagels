using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private List<Product> _productList { get; set; } = new List<Product>();


        //adds item to list if there is room
        public bool Add(Product product)
        {
            //int count = _productList.Count;

            if(_productList.Count < MaxCapacity)
            {
                _productList.Add(product);
                return true;
            }

            //add max cap check
            return false;
        }

        //better add method for filling and stuff

        public decimal GetTotalCost()
        {
            decimal totalCost = 0M;

            foreach(Product Product in _productList)
            {
                totalCost += Product.Price;
            }

            return totalCost;      
        }

        public bool Remove(Product removableItem)
        {
            if (_productList.Contains(removableItem))
            {
                _productList.Remove(removableItem);
                return true;
            }

            return false;
        }

        public int MaxCapacity { get; set; } = 5;

        public List<Product> ProductList { get { return _productList; } }

        public int totalCost { get; set; }

    
    }
}
