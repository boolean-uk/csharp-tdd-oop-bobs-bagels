using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Enums;
using exercise.main.Interfaces;

namespace exercise.main.Classes
{
    public class Product : IProduct
    {
        private double _price;
        private ProductType _type;
        private string _sku;
        private string _variant;
        private double _discount;
        public Product(string sku, double price, ProductType type, string variant)
        {
            _sku = sku;
            _price = price;
            _type = type;
            _variant = variant;
            _discount = 0;
        }

        public double GetPrice()
        {
            double cost = _price;
            if (_discount > 0) 
            {
                double percentDiscount = 1 - _discount;
                cost *= percentDiscount;
            }
            return cost;
        }

        public void SetPrice()
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            throw new NotImplementedException();
        }

        public string GetSKU()
        {
            return _sku;
        }

        public void AddDiscount(double amount)
        {
            _discount = amount;
        }
    }
}
