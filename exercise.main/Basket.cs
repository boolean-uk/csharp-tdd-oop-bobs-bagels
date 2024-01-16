using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace exercise.main
{
    public class Basket
    {
        public int _capacity = 1;
        public List<Product> _basketList = new List<Product>();
        public Menu _menu = new Menu();
        

        public Basket()
        {
            _basketList = new List<Product>(_capacity);
            
        }

        public List<Product> Products { get { return _basketList; } }
        public int Capacity { get { return _capacity; } }

        public bool addProductToBasket(Product prod)
        {
            if (_basketList.Count > _capacity)
            {
                Console.WriteLine("Basket is full");
                return false;
            }
            else
            {
                _basketList.Add(prod);
                return true;
            }

        }

        public void removeProduct(Product product)
        {
            if(!_basketList.Contains(product))
            {
                ProductNotInBasket(product);
            }
            else { _basketList.Remove(product);}
            
        }

        public void changeBasketCapacity(int size) 
        {
            _capacity = size;
        }

        public string ProductNotInBasket(Product prod)
        {
            return ($"{prod} is not in the basket");
        }

        public double totalCost()
        {
            double totalCost = 0;
            foreach(Product product in _basketList)
            {
                totalCost += product._price;
            }

            return totalCost;
        }

        public string printMenu()
        {
            return _menu.showMenu();
        }


    }
}
