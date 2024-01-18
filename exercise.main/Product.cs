using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Product
    {

        public string _sku;
        public double _price;
        public string _name;
        public string _variant;
        public int count;
        public List<Product> _products;
       


        public Product(string SKU, double Price, string Name, string Variant) 
        {
            _products = new List<Product>();
            
            _sku = SKU;
            _price = Price;
            _name = Name;
            _variant = Variant;
            
        }

        public Product(string SKU, double Price, string Name, string Variant, int Count)
        {
            _products = new List<Product>();

            _sku = SKU;
            _price = Price;
            _name = Name;
            _variant = Variant;
            count = Count;

        }


        public double SpecialOfferCost()
        {
            double cost = 0;

            if(_sku == "BGLO")
            {
                cost += CalculateBagelSpecialOffer(6, 2.49);
            }
            else if (_sku == "BGLP")
            {
                cost += CalculateBagelSpecialOffer(12, 3.99);
            }
            else if (_sku == "BGLE")
            {
                cost += CalculateBagelSpecialOffer(6, 2.49);
            }
            else if (_sku == "BGLS")
            {
                cost += CalculateBagelSpecialOffer(6, 2.49);
            }
            else if(_name == "Baggel" && _name == "Coffee")
            {
                CalculateCoffeeAndBagelDiscount();
            }
            else
            {
                cost += _price * count;
            }

            return cost;
        }

        private double CalculateBagelSpecialOffer(int offerCount, double offerPrice)
        {
            double discount = 0;

            while (count >= offerCount)
            {
                discount += offerPrice;
                count -= offerCount;
            }

            return discount + (_price * count);
        }

        private double CalculateCoffeeAndBagelDiscount()
        {
            
            int coffeeCount = 0;
            int bagelCount = 0;

            foreach (Product product in _products)
            {
                if (product._name == "Coffee")
                {
                    coffeeCount += product.count;
                }
                else if (product._name == "Bagel")
                {
                    bagelCount += product.count;
                }
            }

            
            int comboCount = Math.Min(coffeeCount, bagelCount);
            

            return comboCount * 1.25;
        }
    }

}
