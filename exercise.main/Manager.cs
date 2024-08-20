using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Manager : Person
    {
        private int _currentBasketCapacityInStore;
        private Product _bagel;
        private Product _coffee;
        private Product _filling;
        private List<Product> _products = new List<Product>(); //menu item
        private List<Tuple<string, string, float, int>> _discountList = new List<Tuple<string, string, float, int>>(); 


        public Manager(string firstName, string lastName)
            :base(firstName, lastName)
        { 
            _currentBasketCapacityInStore = 3;
            _bagel = new Bagel(getBagelMenu());
            _coffee = new Coffee(getCoffeeMenu());
            _filling = new Filling(getFillingMenu());
            _products.Add(_bagel);
            _products.Add(_coffee);
            _products.Add(_filling);
            addDiscount(); 
        }

        public void changeBasketCapacity(int newBasketCapacity)
        {
            _currentBasketCapacityInStore = newBasketCapacity;
        }

        public int getCurrentBasketSize() { return _currentBasketCapacityInStore;}

        public Product getProductReference(string SKU)
        {
            Product product = null;
            if (SKU.Contains("BGL"))
            {
                return product = new Bagel(_bagel.getVariants().FirstOrDefault(item => item.Item1 == SKU));
            }
            else if (SKU.Contains("COF"))
            {
                return product = new Bagel(_coffee.getVariants().FirstOrDefault(item => item.Item1 == SKU));
            }
            else if (SKU.Contains("FIL"))
            {
                return product = new Bagel(_filling.getVariants().FirstOrDefault(item => item.Item1 == SKU));
            }
            return null;
        }


        public bool getProduct(string SKU, Customer customer) {
            //Tuple<string, string, string, float> bagel = _bagel.getVariants().FirstOrDefault(item => item.Item1 == SKU);
            
            Product product = null;
            if (SKU.Contains("BGL"))
            {
                product = new Bagel(_bagel.getVariants().FirstOrDefault(item => item.Item1 == SKU));
                bool productAdded = customer.recieveProductInBasket(product);
                if (!productAdded) { basketOverflowWarning(); }
                return productAdded;
            } else if (SKU.Contains("COF")) 
            {
                product = new Coffee(_coffee.getVariants().FirstOrDefault(item => item.Item1 == SKU));
                bool productAdded = customer.recieveProductInBasket(product);
                if (!productAdded) { basketOverflowWarning(); }
                return productAdded;
            }
            else if (SKU.Contains("FIL"))
            {
                product = new Filling(_filling.getVariants().FirstOrDefault(item => item.Item1 == SKU));
                bool productAdded = customer.recieveProductInBasket(product);
                if (!productAdded) { basketOverflowWarning(); }
                return productAdded;
            }
            return false;
        }

        private Tuple<string, string, string, float>[] getBagelMenu()
        {
            Tuple<string, string, string, float>[] variants =
{
            Tuple.Create("BGLO", "Bagel", "Onion", 0.49f),
            Tuple.Create("BGLP", "Bagel", "Plain", 0.39f),
            Tuple.Create("BGLE", "Bagel", "Everything", 0.49f),
            Tuple.Create("BGLS", "Bagel", "Sesame", 0.49f),
        };
            return variants;
        }

        private Tuple<string, string, string, float>[] getFillingMenu()
        {
            Tuple<string, string, string, float>[] variants =
{
            Tuple.Create("FILB", "Filling", "Bacon", 0.12f),
            Tuple.Create("FILE", "Filling", "Egg", 0.12f),
            Tuple.Create("FILC", "Filling", "Cheese", 0.12f),
            Tuple.Create("FILX", "Filling", "Cream Cheese", 0.12f),
            Tuple.Create("FILS", "Filling", "Smoked Salmon", 0.12f),
            Tuple.Create("FILH", "Filling", "Ham", 0.12f),
        };
            return variants;
        }

        private Tuple<string, string, string, float>[] getCoffeeMenu()
        {
            Tuple<string, string, string, float>[] variants =
{
            Tuple.Create("COFB", "Coffee", "Black", 0.99f),
            Tuple.Create("COFW", "Coffee", "White", 1.19f),
            Tuple.Create("COFC", "Coffee", "Capuccino", 1.29f),
            Tuple.Create("COFL", "Coffee", "Latte", 1.29f),
        };
            return variants;
        }

        private void addDiscount()
        {
            //List<Tuple<string, string, float, int>> variants =
            //Tuple("BGLO", "", 2.49f, 6),
            //Tuple.Create("BGLP", "", 3.99f, 12),
            //Tuple.Create("BGLE", "", 2.49f, 6),
            //Tuple.Create("COFB", "BGL", 1.25f, 1),

            _discountList.Add(new Tuple<string, string, float, int>("BGLP", "", 2.49f, 6));
            _discountList.Add(new Tuple<string, string, float, int>("BGLP", "", 3.99f, 12));

            _discountList.Add(new Tuple<string, string, float, int>("BGLE", "", 2.49f, 6));
            _discountList.Add(new Tuple<string, string, float, int>("BGLE", "", 3.99f, 12));
            
            _discountList.Add(new Tuple<string, string, float, int>("BGLO", "", 2.49f, 6));
            _discountList.Add(new Tuple<string, string, float, int>("BGLO", "", 3.99f, 12));
            
            _discountList.Add(new Tuple<string, string, float, int>("BGLS", "", 2.49f, 6));
            _discountList.Add(new Tuple<string, string, float, int>("BGLS", "", 3.99f, 12));
            
            _discountList.Add(new Tuple<string, string, float, int>("COFB", "BGLP", 1.25f, 1));
            _discountList.Add(new Tuple<string, string, float, int>("COFB", "BGLE", 1.25f, 1));
            _discountList.Add(new Tuple<string, string, float, int>("COFB", "BGLO", 1.25f, 1));
            _discountList.Add(new Tuple<string, string, float, int>("COFB", "BGLS", 1.25f, 1));

        }

        public void basketOverflowWarning() { Console.WriteLine("I am sorry but you basket is full. I cannot add anymore to it!"); }

        public List<Product> getMenu() // either print here or return list with products
        {
            return _products;
        }

        public List<Tuple<string, string, float, int, bool>> checkout(Basket basket) //might work
        {


            //due to it being BGL in discount and not four letters
            var productsThatMatch = (from discount in _discountList
                                     where basket.getProductsInBasket().Any(product => (product.SKU.Contains(discount.Item1)) &&
                                        (discount.Item4 <= basket.getProductsInBasket().FindAll(item => item.SKU.Contains(discount.Item1)).Count) ||
                                     (product.SKU.Contains(discount.Item1) && discount.Item2 == basket.getProductsInBasket().Find(item => item.SKU.Contains(discount.Item2)).SKU))
                                     select discount).ToList();


            int amountOfBagelsToRemove = 0;
            int amountOfCoffeeToRemove = 0;

            //implement check so that duplicate matches for same bagel type is not possible

            int productNumCheck = 0;
            string oldSKU = "";

            foreach (var product in productsThatMatch.OrderByDescending(item => item.Item4))
            {
                if (basket.getProductsInBasket().FindAll(item => item.SKU.Contains(product.Item1)).Count > productNumCheck)
                {
                    productNumCheck += product.Item4;
                    oldSKU = product.Item1;
                }
                else if (basket.getProductsInBasket().FindAll(item => item.SKU.Contains(product.Item1)).Count <= productNumCheck && oldSKU == product.Item1)
                {
                    productsThatMatch.Remove(product);
                }
            }

            //productsThatMatch.ForEach(product =>
            //{
            //    if (basket.getProductsInBasket().FindAll(item => item.SKU.Contains(product.Item1)).Count < productNumCheck + product.Item4)
            //    {
            //        productNumCheck += product.Item4;
            //    } else if (basket.getProductsInBasket().FindAll(item => item.SKU.Contains(product.Item1)).Count > productNumCheck + product.Item4)
            //    {
            //        productsThatMatch.Remove(product);
            //    }
            //});

            //should work
            foreach (var product in productsThatMatch.OrderByDescending(item => item.Item4))
            {
                if (basket.getProductsInBasket().FindAll(item => item.SKU.Contains("BGL")).Count - amountOfBagelsToRemove >= product.Item4)
                {
                    amountOfBagelsToRemove += product.Item4;
                } else
                {
                    continue; //think this should be continue and nod break, otherwise use break...
                }
            }

            foreach (var product in productsThatMatch.OrderByDescending(item => item.Item4))
            {
                if (basket.getProductsInBasket().FindAll(item => item.SKU.Contains("COF")).Count - amountOfCoffeeToRemove >= product.Item4)
                {
                    amountOfCoffeeToRemove += product.Item4;
                }
                else
                {
                    continue;
                }
            }

            List<Product> copyList = basket.getProductsInBasket();

            for (int i = 0; i < amountOfBagelsToRemove; i++)
            {
                copyList.Remove(copyList.Find(item => item.SKU.Contains("BGL")));
            }

            for (int i = 0; i < amountOfCoffeeToRemove; i++)
            {
                copyList.Remove(copyList.Find(item => item.SKU.Contains("COF")));
            }

            //for (int i = 0; i < amountOfBagelsToRemove; i++)
            //{
            //    copyList.Remove(copyList.Find(item => item.SKU.Contains("FIL")));
            //}

            int stuffLeftInBasket = copyList.Count();

            float totalCost = 0;

            productsThatMatch.ForEach(product => totalCost += product.Item3);
            copyList.ForEach(product => totalCost += product.price);

            //we iterate through the copylist and increment int
            //we then check the sku of those in copylist and concat that number and price to the ones in products that match and then make new list and return

            List < Tuple<string, string, float, int, bool> > checkoutList = checkoutListMerge(productsThatMatch, copyList);


            return checkoutList;
        }

        //does not merge filling for some reason
        private List<Tuple<string, string, float, int, bool>> checkoutListMerge(List<Tuple<string, string, float, int>> productsThatMatch, List<Product> copyList)
        {
            List<Tuple<string, string, float, int, bool>> checkoutList = new List<Tuple<string, string, float, int, bool>>();

            int numOfBagelType = 0;
            int numOfCoffeeType = 0;
            int numOfFillingType = 0;

            foreach (var bagel in _bagel.getVariants())
            {
                numOfBagelType = copyList.FindAll(item => item.SKU == bagel.Item1).Count();
                if (numOfBagelType != 0)
                {
                    checkoutList.Add(new Tuple<string, string, float, int, bool>(bagel.Item1, bagel.Item2, bagel.Item4, numOfBagelType, false));

                }
            }
            foreach (var bagel in _coffee.getVariants())
            {
                numOfCoffeeType = copyList.FindAll(item => item.SKU == bagel.Item1).Count();
                if (numOfCoffeeType != 0)
                {
                    checkoutList.Add(new Tuple<string, string, float, int, bool>(bagel.Item1, bagel.Item2, bagel.Item4, numOfCoffeeType, false));

                }
            }
            foreach (var bagel in _filling.getVariants())
            {
                numOfFillingType = copyList.FindAll(item => item.SKU == bagel.Item1).Count();
                if (numOfFillingType != 0)
                {
                    checkoutList.Add(new Tuple<string, string, float, int, bool>(bagel.Item1, bagel.Item2, bagel.Item4, numOfFillingType, false));

                }
            }
            foreach (var discount in productsThatMatch)
            {
                checkoutList.Add(new Tuple<string, string, float, int, bool>(discount.Item1, discount.Item2, discount.Item3, discount.Item4, true));
            }
            //foreach (var product in copyList)
            //{
            //    checkoutList.Add(new Tuple<string, string, float, int, bool>(product.SKU, product.name, product.price, 1, false));
            //}
            //checkoutList.ForEach(item => Console.WriteLine(item));

            return checkoutList;
        }
    }
}
