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


        //Constructors based on the input object.
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

        // If input object is not of type coffe, filling or bagel
        public Product(object product) {
            throw new ArgumentException($"Unsupported product");
        }

       

        public double getPrice()
        {
            return _price;
        }
        public string name { get { return _name; } }
        public string variant { get { return _variant; } }


    }
}
