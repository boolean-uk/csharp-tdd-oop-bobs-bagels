using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        // Define field
        private int _capacity = 3; //Default = 3
        private double _total = 0;

        // Define properties
        public List<Product> _basket = new List<Product>();
        Dictionary<Product, List<Product>> _sandWiches = new Dictionary<Product, List<Product>>();

        //Adding product to the basket
        public bool Add(Product product)
        {
            if (_basket.Count < _capacity)
            {
                _basket.Add(product);
                return true;
            }
            return false;
        }

        //Remove the product from the basket
        public bool Remove(Product product)
        {
            if (_basket.Contains(product))
            {
                _basket.Remove(product);
                return true;
            }
            return false;

        }

        //Get price of each product
        public int getPrice(Product product)
        {
            throw new NotImplementedException();
        }

        //Get price of the basket
        public double getTotalPrice()
        {
            _total = _basket.Sum(product => product.getPrice());
            double discount = checkDisCount();
            //Check if the discount scenario occurs:
            if (discount > 0)
            {
                _total -= discount;
            }

            return _total;
        }

        //Setting new Capacity
        public bool setNewCapacity(int newCapacity)
        {
            _capacity = newCapacity;
            return true;
        }

        //Get the basket as a collection.
        public List<Product> getBasket()
        {
            return _basket;
        }

        // A method if the user wants to make a sandwich (bagel + filling)
        public void MakeSandwich(Product product1, Product product5)
        {
            if (_basket.Contains(product1) && product1.name == "Bagel")
            {
                if (_sandWiches.ContainsKey(product1))
                {
                    if (Add(product5))
                    {
                        _sandWiches[product1].Add(product5);
                    }
                    else
                    {
                        throw new Exception("Check the basket capacity");
                    }
                }
                else
                {
                    _sandWiches.Add(product1, new List<Product>() { product5 });
                }

            }
            else
            {
                throw new Exception("Need to by a bagel and add it to your basket first");
            }
        }

        // Method returning the sandwich
        public Dictionary<Product, List<Product>> getSandwich()
        {
            return _sandWiches;
        }

        public int capacity { get { return _capacity; } }

        //Method for calculating the discount:
        public double checkDisCount()
        {
            double discount = 0;
            int productCount = _basket.Count(product => product.name == "Bagel");

            
            while (productCount > 0)
            {

                // Get a list of the bagels sorted by lowest price
                if (productCount >= 12)
                {
                    var sortBasket = _basket.Where(product => product.name == "Bagel")
                            .OrderBy(product => product.getPrice())
                            .Take(12);

                    productCount -= 12;
                    double first12Items = sortBasket.Sum(product => product.getPrice());

                    //Check if the sum of the first 12 cheapest is acutally higher than discount price:
                    if (3.99 - first12Items < 0)
                    {
                        discount += (0.49 * 12) - 3.99;
                    }
                    else
                    {
                        discount += 0;
                    }

                }

                else if (productCount >= 6)
                {
                   
                        // Get a list of the bagels sorted by lowest price
                        var sortBasket = _basket.Where(product => product.name == "Bagel")
                            .OrderBy(product => product.getPrice())
                            .Take(6);
                   
                    productCount -= 6;
                     double first6Items = sortBasket.Sum(product => product.getPrice());
                   
                    //Check if the sum of the first 12 cheapest is acutally higher than discount price:
                    if (2.49 - first6Items < 0)
                    {

                        discount += (0.49 * 6) - 2.49;
                    }
                    else
                    {
                        discount += 0;
                    }

                }
                else
                {
                    productCount = -1;
                     discount += 0;
                }
            }

            return discount;
        }

    }


}
