using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class ProductList
    {
        public List<Product> _products = new List<Product> { new Bagel(0.49, "Onion"),
            new Bagel(0.39, "Plain"), new Bagel(0.49, "Everything"),
            new Bagel(0.49, "Sesame"), new Coffe(0.99, "Black"),
            new Coffe(1.19, "White"), new Coffe(1.29, "Capuccino"),
            new Coffe(1.29, "Latte"), new Filling(0.12, "Bacon"),
            new Filling(0.12, "Cream Cheese"), new Filling(0.12, "Smoked Salmon"),
            new Filling(0.12, "Ham") };


        public void GetFillings()
        {
            List<Product> result = new List<Product>();

            for (int i = 0; i < _products.Count; i++)
            {
                if (_products[i].GetType() == typeof(Filling))
                {
                    result.Add(_products[i]);
                }
            }
            return;
        }

        public void GetBagels()
        {
            //List<Product> result = new List<Product>();
            Console.WriteLine($"Price   Name    Variant");

            for (int i = 0; i < _products.Count; i++)
            {
                if (_products[i].GetType() == typeof(Bagel))
                {
                    //result.Add(_products[i]);
                    Console.WriteLine($"{_products[i]._price}   {_products[i]._name}    {_products[i]._variant}");
                }
            }
            return;
        }

        public double GetPriceBagle(string variant)
        {
            for (int i = 0; i < _products.Count; i++)
            {
                if (_products[i]._variant == variant)
                {
                    return _products[i]._price;
                }

            }
            return 0;
        }
    }
}
