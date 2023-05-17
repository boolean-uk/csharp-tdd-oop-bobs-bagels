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
        private List<IItem> _otherItems = new List<IItem>();

        private int _basketMax = 3;
        private decimal _total = 0m;
        private decimal _cost = 0m;
        private bool _sixBagels = false;
        private bool _twelveBagels = false;

        public void SeedData()
        {
            _products = new List<IItem>
            {
                new Bagel("BGLO", 0.49M, "Bagel", "Onion", 20, 1, 0),
                new Bagel("BGLP", 0.39M, "Bagel", "Plain", 20, 1, 0),
                new Bagel("BGLE", 0.49M, "Bagel", "Everything", 20, 1, 0),
                new Bagel("BGLS", 0.49M, "Bagel", "Sesame", 20, 1, 0),
                new Coffee("COFB", 0.99M, "Coffee", "Black", 2, 1, 0),
                new Coffee("COFW", 1.19M, "Coffee", "White", 2, 1, 0),
                new Coffee("COFC", 1.29M, "Coffee", "Capuccino", 2, 1, 0),
                new Coffee("COFL", 1.29M, "Coffee", "Latte", 2, 1, 0),
                new Filling("FILB", 0.12M, "Filling", "Bacon", 2, 1, 0),
                new Filling("FILE", 0.12M, "Filling", "Egg", 2, 1, 0),
                new Filling("FILC", 0.12M, "Filling", "Cheese", 2, 1, 0),
                new Filling("FILX", 0.12M, "Filling", "Cream Cheese", 2, 1, 0),
                new Filling("FILS", 0.12M, "Filling", "Smoked Salmon", 2, 1, 0),
                new Filling("FILH", 0.12M, "Filling", "Ham", 2, 1, 0)
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
                            if (Basket.Contains(item))
                            {
                                item.Amount += 1;
                                item.Stock -= 1;
                            } 
                            else
                            {
                                Basket.Add(item);
                                item.Stock -= 1;
                            }
                        }
                    }
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
            // could be simplified even more by adding all item.Cost together
            // current method doesnt recognize 6 + 1 of the same bagel
            // check if there are 6 or 12 bagels in basket
            foreach (IItem item in Basket)
            {
                if (item is Bagel)
                {
                    if (item.Amount == 6)
                    {
                        _sixBagels = true;
                    }
                    else if (item.Amount == 12)
                    {
                        _twelveBagels = true;
                    }
                    else
                    {
                        otherItems.Add(item);
                    }
                }
                else
                {
                    otherItems.Add(item);
                }
            }

            // add deal price to totalcost
            if (_sixBagels)
            {
                _total += 2.49M;
            }
            else if (_twelveBagels)
            {
                _total += 3.99M;
            }

            // check for other items
            foreach (IItem item in otherItems)
            {
                _total += (item.Amount * item.Price);
            }
            return _total;
        }
        #endregion

        #region ItemCost
        public void ItemCost(string item)
        {
            if (_customer || _manager)
            {
                itemCost(item);
            }
        }

        private void itemCost(string sku)
        {
            bool sixBagels = false;
            bool twelveBagels = false;
            // check if there are 6 or 12 bagels in item
            foreach (IItem item in Basket)
            {
                if (item.SKU == sku)
                {
                    if (item is Bagel)
                    {
                        if (item.Amount == 6)
                        {
                            sixBagels = true;
                        }
                        else if (item.Amount == 12)
                        {
                            twelveBagels = true;
                        }
                    }
                }
            }

            // add deal price to cost
            foreach (IItem item in Basket)
            {
                if (item.SKU == sku)
                {
                    if (sixBagels)
                    {
                        item.Cost = 2.49M;
                    }
                    else if (twelveBagels)
                    {
                        item.Cost = 3.99M;
                    }
                    // if no deal price
                    else
                    {
                        item.Cost = (item.Amount * item.Price);
                    }
                }
            }
        }
        #endregion

        public List<IItem> Products { get { return _products; } set { _products = value; } }
        public List<IItem> Basket { get { return _basket; } set { _basket = value; } }
        public List<IItem> otherItems { get { return _otherItems; } set { _otherItems = value; } }
    }
}
