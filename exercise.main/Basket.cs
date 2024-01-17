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
            _productList = new Dictionary<int, Product>();
            _capacity = 5;
        }
        

        private int _capacity;
        private Dictionary<int,Product> _productList;

        public bool AddProduct(Product product)
        {
            
             if (_productList.Keys.Count >= _capacity)
               {
                   return false;

               }else {
                   _productList.Add(_productList.Count,product);
                   return true;
               }
       
        }

        public bool RemoveProduct(int BasketID)
        {
           bool productIsInBasket = _productList.ContainsKey(BasketID);
            if (productIsInBasket) { 
            _productList.Remove(BasketID);
                return true;
            }

            return false;
        }


        public double GetTotal()
        {
            double sum=0;
            double sumFillings = 0;
            foreach (Product product in _productList.Values) { 
                sum += product.Price;
                sumFillings += product.Fillings.Count * 0.12;
            }
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
        public Dictionary<int,Product> ProductList { get => _productList; }



    }
}
