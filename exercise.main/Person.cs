using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Person
    {
        public int _capacity = 10;
        private List<Item> _basket = new List<Item>();
        public string role { get; set; }



        public int GetCapacity()
        {
            return _capacity;
        }


        public void GetItems()
        {
            List<Item> items = _basket;

            foreach (Item item in items)
            {

                Console.WriteLine(item.name);

            }
        }

        public void AddItem(Item item)
        {
            if (IsFull())
            {
                throw new Exception("The basket is full");
            }
            else if (!item.prices.ContainsKey(item.name))
            {
                throw new Exception("The item is not in inventory");
            }
            else
            {
                _basket.Add(item);
            }

        }

        public void RemoveItem(Item item)
        {
            if (_basket.Contains(item))
            {
                _basket.Remove(item);
            }

            else
            {
                throw new Exception("Not in basket");
            }
        }

        public bool IsFull()
        {
            return _basket.Count >= _capacity;
        }

        public void ChangeCapacity(int newcapacity)
        {
            if (role == "manager")
            {
                _capacity = newcapacity;
            }
            else
            {
                throw new Exception("You are not allowed to change the capacity, you are a customer");
            }
        }

        public bool ItemExists(Item item)
        {
            return _basket.Contains(item);
        }

        public bool coffeebageldiscount()
        {
            bool coffee = false;
            bool bagel = false;

            List<string> bagelflavors = new List<string> { "BGLO", "BGLP", "BGLE", "BGLS" };
            foreach (Item item in _basket)
            {
                if (item.name == "COFB")
                {
                    coffee = true;
                }

                else if (bagelflavors.Contains(item.name))
                {
                    bagel = true;
                }
            }
            return coffee && bagel;
        }


        public string GetCheapestBagel()
        {
            double mincost = 10000000;
            string name = "";

            foreach (Item item in _basket)
            {
                if (item.name.StartsWith("BGL"))
                {
                    if (item.prices[item.name] < mincost)
                    {
                        mincost = item.prices[item.name];
                        name = item.name;
                    }
                }
            }
            return name;
        }

        public double GetTotalCost()
        {
            double total = 0;
            
            if (coffeebageldiscount())
            {
                string bagelname = GetCheapestBagel();

                foreach (Item item in _basket) {
                    if (item.name == "COFB")
                    {
                        _basket.Remove(item);
                        break;
                    }
                }

                foreach (Item item in _basket)
                {
                    if (item.name == bagelname)
                    {
                        foreach (Filling fill in item.bagelfillings)
                        {
                            total += fill.prices[fill.actualname];
                            item.bagelfillings.Remove(fill);
                        }

                        _basket.Remove(item);
                        break;
                    }

                }
                total += 1.25;
            }


            foreach (Item item in _basket)
            {

                total += item.totalcost + item.prices[item.name];

            }


            return total;
        }
    


        public double GetItemCost(Item item)
        {
            return item.prices[item.name] + item.totalcost;
        }

        public int GetTotalItems()
        {
            return _basket.Count;
        }

        public void AddFill(Bagel bagel, Filling fill)
        {
            bagel.AddFilling(fill);
        }

        public double GetFillingCost(Filling fill)
        {
            return fill.prices[fill.actualname];
        }

        public int GetItemAmount(Item item)
        {
            return item.itemcount[item.name];

        }
    }
}
