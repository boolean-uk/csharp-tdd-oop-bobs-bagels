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
                new Item("BGLO", 0.49M, "Bagel", "Onion"),
                new Item("BGLP", 0.39M, "Bagel", "Plain"),
                new Item("BGLE", 0.49M, "Bagel", "Everything"),
                new Item("COFB", 0.49M, "Bagel", "Sesame"),
                new Item("COFW", 0.99M, "Coffee", "Black"),
                new Item("COFC", 1.19M, "Coffee", "White"),
                new Item("COFL", 1.29M, "Coffee", "Capuccino"),
                new Item("BGLS", 1.29M, "Coffee", "Latte"),
                new Item("FILB", 0.12M, "Filling", "Bacon"),
                new Item("FILE", 0.12M, "Filling", "Egg"),
                new Item("FILC", 0.12M, "Filling", "Cheese"),
                new Item("FILX", 0.12M, "Filling", "Cream Cheese"),
                new Item("FILS", 0.12M, "Filling", "Smoked Salmon"),
                new Item("FILH", 0.12M, "Filling", "Ham")
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
        public void AddBagel(string sku)
        {
            if (_member || _customer || _manager)
            {
                addBagel(sku);
            }
        }

        private void addBagel(string sku)
        {
            foreach (Item item in Products)
            {
                if (item.SKU == sku)
                {
                    if (Basket.Count < _basketMax)
                    {
                        if (Basket.Contains(item))
                        {
                            Console.WriteLine($"{item.Name} is already in basket.");
                        }
                        else
                        {
                            Basket.Add(item);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Your basket is full.");
                    }
                }
                else
                {
                    Console.WriteLine("This product does not exist.");
                }
            }
        }
        #endregion

        #region RemoveBagel
        public void RemoveBagel(string sku)
        {
            if (_member || _customer || _manager)
            {
                removeBagel(sku);
            }
        }
        private void removeBagel(string sku)
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

        #region AddFilling
        public void AddFilling(string sku)
        {
            if (_member || _customer || _manager)
            {
                addFilling(sku);
            }
        }

        private void addFilling(string sku)
        {
            foreach (Item item in Products)
            {
                if (item.SKU == sku)
                {
                    if (Basket.Count < _basketMax)
                    {
                        if (Basket.Contains(item))
                        {
                            Console.WriteLine($"{item.Name} is already in basket.");
                        }
                        else
                        {
                            Basket.Add(item);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Your basket is full.");
                    }
                }
                else
                {
                    Console.WriteLine("This product does not exist.");
                }
            }
        }
        #endregion

        public List<Item> Products { get { return _products; } set { _products = value; } }

        public List<Item> Basket { get { return _basket; } set { _basket = value; } }
    }
}
