using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private List<Product> _items;
        private int _capacity;

        public Basket()
        {
            _items = new List<Product>();
            _capacity = 100;
        }

        public string AddProduct(string product)
        {

            if (_items.Count >= _capacity)
            {
                return "Nope. Overencumbered.";
            }
            else if (!Inventory.variantToSku.ContainsKey(product))
            {
                return "Warning: The product is not available.";
            }
            else
            {
                _items.Add(Inventory.skuToProductFactory[Inventory.variantToSku[product]]());
                return "Product added to basket";
            }

        }

        public double CalculateDiscount()
        {
            List<Product> bagels = _items.Where(item => item.Name == "Bagel").ToList();
            List<Product> coffees = _items.Where(item => item.Name == "Coffee").ToList();

            bagels = bagels.OrderByDescending(item => item.BasePrice).ToList();
            coffees = coffees.OrderByDescending(item => item.BasePrice).ToList();

            // calculate the BAGEL dicounts

            //calculate bagel discounted prices for 12 for 3.99
            int numberOfDozens = bagels.Count / 12;
            double discountedBagelPrice = numberOfDozens * 3.99d;

            //add the discounted price for the remainding bagels for 6 for 2.49
            int numberOfHalfDozens = (bagels.Count - (numberOfDozens*12))/6;
            discountedBagelPrice += numberOfHalfDozens * 2.49d;

            //calculate the difference between the original prices and the discounted prices
            int discountedBagels = (numberOfDozens * 12) + (numberOfHalfDozens * 6);
            double originalBagelPrice = bagels.Take(discountedBagels).Sum(product => product.BasePrice);
            double bagelDiscount = originalBagelPrice - discountedBagelPrice;

            // calculate COFFEE-BAGEL discounts for the remainding bagels that are paired with coffees

            //find the number of coffee/bagel pairs for remainding bagels not already discounted
            int coffeeNumber = coffees.Count;
            int unDiscountedBagelsNumber = bagels.Count - (discountedBagels);
            int coffeBagelCombos = Math.Min(unDiscountedBagelsNumber, coffeeNumber); 

            // calculate the original price for the coffee and bagels before coffe-bagel discount 
            double originalCoffeePrice = coffees.Take(coffeBagelCombos).Sum(product => product.BasePrice);
            double originalLeftOverBagelPrice = bagels.Take(coffeBagelCombos).Sum(product => product.BasePrice);
            double originalCoffeBagelPrice = originalCoffeePrice + originalLeftOverBagelPrice;
            // calculate the new discounted price 
            double discountedCoffeeBagelPrice = coffeBagelCombos * 1.25d;

            //calculate the difference between the original prices and the discounted prices
            double coffeBagelDiscount = originalCoffeBagelPrice - discountedCoffeeBagelPrice;
            

            return bagelDiscount + coffeBagelDiscount;
        }

        public void ChangeCapacity(int v)
        {
            _capacity = v;
        }

        public List<Product> GetItems()
        {
            return _items;
        }

        public string RemoveProduct(string variant)
        {
            // Find the product with the matching variant
            var productToRemove = _items.FirstOrDefault(p => p.Variant == variant);

            if (productToRemove == null)
            {
                return "No such product to remove.";
            }
            else
            {
                _items.Remove(productToRemove);
                return "Product removed from basket";
            }
        }

        public double TotalPrice()
        {
            return _items.Sum(product => product.Price)-CalculateDiscount();
        }

        
    }

}

