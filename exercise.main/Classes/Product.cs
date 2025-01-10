using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Classes
{
    public class Product
    {
        private double _price;
        private string _name;
        private string _sku;
        private string _variant;
        private double _discount;
        public Product(string sku, double price, string name, string variant) 
        {
            _sku = sku;
            _price = price;
            _name = name;
            _variant = variant;
            _discount = 0;
        }

        public double GetPrice()
        {
            throw new NotImplementedException();
        }

        public void SetPrice()
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            throw new NotImplementedException();
        }

        public void AddPromo(double amount, double price)
        {
            throw new NotImplementedException();
        }
    }
}
