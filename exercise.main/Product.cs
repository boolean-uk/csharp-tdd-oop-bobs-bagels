using exercise.main.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Product
    {

        // Define fields:
        private string _name;
        private double _price;
        private string _variant;

        public Product(Bagel bagel)
        {
            _variant = bagel.variant;
            _price = bagel.price;
            _name = bagel.name;
        }

        public Product(Coffe coffe)
        {
            _variant = coffe.variant;
            _price = coffe.price;
            _name = coffe.name;
        }

        public Product(Filling filling)
        {
            _variant = filling.variant;
            _price = filling.price;
            _name = filling.name;
        }

        public double getPrice()
        {
            return _price;
        }


    }
}
