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
        
        private List<Item> _products = new List<Item>();
        private List<Item> _basket = new List<Item>();

        private int _basketMax = 3;
        private decimal _total = 0m;
        private decimal _cost = 0m;

        public void SeedData()
        {
            _products = new List<Item>
            {
                new Item("BGLO", 0.49M, "Bagel", "Onion", 2),
                new Item("BGLP", 0.39M, "Bagel", "Plain", 2),
                new Item("BGLE", 0.49M, "Bagel", "Everything", 2),
                new Item("BGLS", 0.49M, "Bagel", "Sesame", 2),
                new Item("COFB", 0.99M, "Coffee", "Black", 2),
                new Item("COFW", 1.19M, "Coffee", "White", 2),
                new Item("COFC", 1.29M, "Coffee", "Capuccino", 2),
                new Item("COFL", 1.29M, "Coffee", "Latte", 2),
                new Item("FILB", 0.12M, "Filling", "Bacon", 2),
                new Item("FILE", 0.12M, "Filling", "Egg", 2),
                new Item("FILC", 0.12M, "Filling", "Cheese", 2),
                new Item("FILX", 0.12M, "Filling", "Cream Cheese", 2),
                new Item("FILS", 0.12M, "Filling", "Smoked Salmon", 2),
                new Item("FILH", 0.12M, "Filling", "Ham", 2)
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
            foreach (Item item in Products)
            {
                if (item.SKU == sku)
                {
                    if (item.Stock > 0)
                    {
                        if (Basket.Count <= _basketMax)
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

        #region RemoveBagel
        public void RemoveItem(string sku)
        {
            if (_member || _customer || _manager)
            {
                removeItem(sku);
            }
        }
        private void removeItem(string sku)
        {
            foreach (Item item in Products)
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
            if (_customer)
            {
                total = totalCostBasket();
            }
        }

        private decimal totalCostBasket()
        {
            foreach (Item item in Basket)
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
            foreach (Item item in Products)
            {
                if (item.SKU == sku)
                {
                    _cost = item.Price;
                }
            }
            return _cost;
        }
        #endregion

        public List<Item> Products { get { return _products; } set { _products = value; } }
        public List<Item> Basket { get { return _basket; } set { _basket = value; } }

    }
}
