using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
            _productList = new List<Product>();
            _capacity = 5;
        }
        

        private int _capacity;
        private List<Product> _productList;

        public bool AddProduct(Product product)
        {
            
             if (_productList.Count >= _capacity)
               {
                   return false;

               }else {
                   _productList.Add(product);
                   return true;
               }
       
        }

        public bool RemoveProduct(Product product)
        {
           bool productIsInBasket = _productList.Contains(product);
            if (productIsInBasket) { 
            _productList.Remove(product);
                return true;
            }

            return false;
        }


        public double GetTotal()
        {
            double sum=0;
            _productList.ForEach(product => { sum += product.Price; });
            sum= Math.Round(sum, 2);

            return sum;
        }


        public List<string> GetList()
        {
            throw new NotImplementedException();
        }

        public int changeCapacity(Person person, int newCapacity)
        {
            if (person.AdminLevel=="admin")
            {
                _capacity = newCapacity;
            }
            return _capacity;
        }

        public int Capacity { get => _capacity; }
        public List<Product> ProductList { get => _productList; }



    }
}
