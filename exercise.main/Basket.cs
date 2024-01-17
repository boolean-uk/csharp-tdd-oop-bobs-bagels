using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        public Basket()
        {
            ProductList = new List<Product>();
            _capacity = 5;
        }
        

        private int _capacity;
        public List<Product> ProductList;

        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void RemoveProduct(Product product)
        {
            throw new NotImplementedException();
        }


        public void GetTotal(Product product)
        {
            throw new NotImplementedException();
        }




        public List<string> GetList()
        {
            throw new NotImplementedException();
        }


        public int Capacity { get => _capacity; set => _capacity = value; }




    }
}
