using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace exercise.main
{
    public class Basket
    {
        List<string> inventory = new List<string>()
        {
            "BGLO",
            "BGLP" ,
            "BGLE",
            "BGLS" ,
            "COFB" ,
            "COFW" ,
            "COFC" ,
            "COFL" ,
            "FILB" ,
            "FILE" ,
            "FILC" ,
            "FILX"  ,
            "FILS" ,
            "FILH",
        };
        int _maxCapasity;
        List<Product> _basket;
        Person person;
        //float totalCost = 0;
        public Basket(int maxCapasity, Person person)
        {
            _maxCapasity = maxCapasity;
            this.person = person;
            _basket = new List<Product>();

        }





        public void AddToBasket(Product product)
        {

            if (_basket.Count < _maxCapasity && inventory.Contains(product.Sku))
            {

                if (person is Customer && product.Name == "bagel")
                {
                    Bagel bagel = (Bagel)product;
                    if (bagel.Filling is not null)
                    {
                        Console.WriteLine("the price of this filling is: " + bagel.Filling.Price);
                        _basket.Add(bagel.Filling);
                    }
                    Console.WriteLine("price of this bagel is: " + product.Price.ToString());



                }
                _basket.Add(product);

            }
            else
            {
                Console.WriteLine("unable to add product");


            }



        }
        public void ExpandBaskets(int newMaxCapasity)
        {
            if (person is Manager)
            {
                _maxCapasity = newMaxCapasity;

            }
            else
            {
                Console.WriteLine("you dont have access to this");

            }
        }

        public int FindBasketSize()
        {
            return _basket.Count;
        }
        public string RemoveFromBasket(Product product)
        {
            string message = "you can not remove from an empty list";
            if (_basket.Count != 0)
            {
                _basket.Remove(product);
                message = "product is succesfully removed from basket";
                return message;

            }
            return message;


        }


        public decimal TotalCost()
        {
            decimal total = 0;
          

            if (person is Customer)
            {
                total = _basket.Sum(b => b.Price);
                return total;
            }
            Console.WriteLine("you dont have access to this");
            return total;
        }
        
        //have not finished

       /* public void PrintReceipt()
        {
            Console.WriteLine(" ~~~ Bob's Bagels ~~~ ");
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            Console.WriteLine("----------------------------");
            int PbagelCount = _basket.Where(b => b.Name == "plain").Count();
            if (PbagelCount != 0)
            {

                Console.WriteLine("Plain Bagel      " + PbagelCount);



                // _basket.ForEach(b => { Console.WriteLine(b.Name, b.Price); });

            }
        }*/
    }


        
    
}
