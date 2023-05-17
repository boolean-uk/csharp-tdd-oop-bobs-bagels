using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace csharp_tdd_oop_bobs_bagels.Source
{
    public class Main
    {
        private bool _member;
        private bool _customer;
        private bool _manager;
        
        private List<IItem> _products = new List<IItem>();
        private List<IItem> _basket = new List<IItem>();

        private int _basketMax = 3;
        private decimal _total = 0m;
        private decimal _cost = 0m;

        public void SeedData()
        {
            _products = new List<IItem>
            {
                new Bagel("BGLO", 0.49M, "Bagel", "Onion", 20),
                new Bagel("BGLP", 0.39M, "Bagel", "Plain", 20),
                new Bagel("BGLE", 0.49M, "Bagel", "Everything", 20),
                new Bagel("BGLS", 0.49M, "Bagel", "Sesame", 20),
                new Coffee("COFB", 0.99M, "Coffee", "Black", 2),
                new Coffee("COFW", 1.19M, "Coffee", "White", 2),
                new Coffee("COFC", 1.29M, "Coffee", "Capuccino", 2),
                new Coffee("COFL", 1.29M, "Coffee", "Latte", 2),
                new Filling("FILB", 0.12M, "Filling", "Bacon", 2),
                new Filling("FILE", 0.12M, "Filling", "Egg", 2),
                new Filling("FILC", 0.12M, "Filling", "Cheese", 2),
                new Filling("FILX", 0.12M, "Filling", "Cream Cheese", 2),
                new Filling("FILS", 0.12M, "Filling", "Smoked Salmon", 2),
                new Filling("FILH", 0.12M, "Filling", "Ham", 2)
            };
        }

        #region SelectRole
        public string SelectRole(string role)
        {
            selectRole(role);
            return role;
        }

        private bool selectRole(string role)
        {
            if (role == "member")
            {
                _member = true;
                return _member;
            } 
            else if (role == "customer")
            {
                _customer = true;
                return _customer;
            } 
            else if (role == "manager")
            {
                _manager = true;
                return _manager;
            }
            return false;
        }
        #endregion

        #region AddBagel
        public void AddItem(string sku)
        {
            if (_member || _customer || _manager)
            {
                addItem(sku);
            }
        }

        private void addItem(string sku)
        {
            foreach (IItem item in Products)
            {
                if (item.SKU == sku)
                {
                    if (item.Stock > 0)
                    {
                        if (Basket.Count < _basketMax)
                        {
                            Basket.Add(item);
                            item.Stock -= 1;
                        }
                        else
                        {
                            Console.WriteLine("Your basket is full.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Item is out of stock");
                    }
                }
                else
                {
                    Console.WriteLine("This item does not exist.");
                }
            }
        }
        #endregion

        #region RemoveItem
        public void RemoveItem(string sku)
        {
            if (_member || _customer || _manager)
            {
                removeItem(sku);
            }
        }
        private void removeItem(string sku)
        {
            foreach (IItem item in Products)
            {
                if (item.SKU == sku)
                {
                    Basket.Remove(item);
                }
                else
                {
                    Console.WriteLine($"{item} is not in basket.");
                }
            }
        }
        #endregion

        #region ChangeBasketMax
        public void ChangeBasketMax(int max)
        {
            if (_manager)
            {
                changeBasketMax(max);
            }
        }

        private void changeBasketMax(int max)
        {
            _basketMax = max;
        }
        #endregion

        #region TotalCostBasket
        // var total needed for test
        public decimal total;
        public void TotalCostBasket()
        {
            if (_customer || _manager)
            {
                total = totalCostBasket();
            }
        }

        private decimal totalCostBasket()
        {
            // check if there are 6 or 12 bagels in basket
            List<Bagel> dealBagels = Basket.OfType<Bagel>().ToList();
            bool sixBagels = dealBagels.Count() == 6;
            bool twelveBagels = dealBagels.Count() == 12;

            var result = Basket.Except(dealBagels);

            // add deal price to totalcost
            if (sixBagels)
            {
                _total += 2.49M;
            }
            else if (twelveBagels)
            {
                _total += 3.99M;
            }

            // check for other items
            foreach (IItem item in result)
            {
                _total += item.Price;
            }
            return _total;
        }
        #endregion

        #region ItemCost
        // var cost needed for test
        public decimal cost;
        public void ItemCost(string item)
        {
            if (_customer)
            {
                cost = itemCost(item);
            }
        }

        private decimal itemCost(string sku)
        {
            foreach (IItem item in Products)
            {
                if (item.SKU == sku)
                {
                    _cost = item.Price;
                }
            }
            return _cost;
        }
        #endregion

        public List<IItem> Products { get { return _products; } set { _products = value; } }
        public List<IItem> Basket { get { return _basket; } set { _basket = value; } }
    }
}
