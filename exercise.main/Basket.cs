using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        Product product;
        public ProductList _productList;
        public List<Product> _basket;
        public List<Product> _discountBasket;
        public Discounts discounts;
        int _capacity = 30;
        int _count = 0;
        public Basket()
        {
            _basket = new List<Product>();
            _productList = new ProductList();
            _discountBasket = new List<Product>();
            discounts = new Discounts(_basket);

        }


        public void AddItem(string name, string variant)
        {
            if (CheckCapacity(_count))
            {
                if (_productList.products.Contains(findProduct(name, variant, _productList.products)))
                {

                    _basket.Add(findProduct(name, variant, _productList.products));
                    _count++;
                }
                else { Console.WriteLine("We do not carry that product."); }
            }
            else { Console.WriteLine("Your basket is full."); }
        }

        public void RemoveItem(string item, string variant)
        {
            if (checkForItem(item, variant))
            {
                _basket.Remove(findProduct(item, variant, _basket));
            }
        }


        //Finds the product in a list by name and variant
        //fix null errors
        private Product findProduct(string item, string variant, List<Product> list)
        {

            Product returnProduct = list.Find(x => x.Name == item && x.Variant == variant);


            return returnProduct;
        }

       
        public Product findProductBySKU(string sku)
        {

            Product returnProduct = _basket.Find(x => x.SKU == sku);


            return returnProduct;
        }
        public void AddFilling(string variant)
        {

            AddItem("Filling", variant);
        }

        public bool CheckCapacity(int count)
        {
            return count < _capacity;
        }

        public void changeCapacity(int n)
        {
            _capacity = n;
        }

        public bool checkForItem(string item, string variant)
        {
            bool itemFound = false;

            if (findProduct(item, variant, _basket) != null)
            {
                itemFound = true;
            }
            return itemFound;
        }

        public double CalculateSum()
        {
            double sum = 0;

            foreach (Product product in _basket)
            {
                sum += product.Price;
            }

            return sum;
        }

        public double findPrice(string item, string variant)
        {
            return findProduct(item, variant, _productList.products).Price;
        }

        public double FindPriceBySKU(string sku)
        {
            return findProductBySKU(sku).Price;
        }


    }
}
