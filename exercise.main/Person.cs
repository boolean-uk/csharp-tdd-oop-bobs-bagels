using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Person
    {
        public int _capacity = 10;
        private List<Item>_basket = new List<Item>();
        private List<Item>_bagels = new List<Item>();
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
       
                _basket.Add(item);
            

            if (item.GetType() == typeof(Bagel))
            {
                _bagels.Add(item);
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

                if (bagelflavors.Contains(item.name))
                {
                    bagel = true;
                }
            }
            return coffee && bagel;
        }



       
        public double GetTotalCost()
        {

            double total = 0;
            double discount = DeductDiscount();

            foreach (Item item in _basket)
            {
                total += item.prices[item.name];
                
            }

            foreach (Item bagel in _bagels)
            {
                foreach(Filling fill in bagel.bagelfillings)
                {
                    total += fill.prices[fill.actualname];
                }
            }

            

            return total - discount;
        }


        public double DeductDiscount()
        {
            bool bagel = false;           
            bool coffee = false;
            Dictionary<string, int> counts = new Dictionary<string, int>();
            foreach (Item item in _basket)
            {
                if (counts.ContainsKey(item.name))
                {
                    counts[item.name]++;
                }
                else
                {
                    counts.Add(item.name, 1);
                }
                
            }

            foreach(Item item in _basket)
            {
                if (item.name == "COFB")
                {
                    coffee = true;
                }
                else if (item.GetType() == typeof(Bagel)){
                   
                       bagel = true;
                    }
                }
            


            

            if (bagel && coffee)
            {
                return (0.49 + 0.99) - 1.25;
            }

            else
            {
                foreach(string key in counts.Keys)
                {
                    if (key.StartsWith('B')){
                        if (counts[key] >= 12)
                        {
                            return (0.49 * 12) - 3.99;
                    }
                        else if(counts[key] >= 6)
                        {
                            return (0.49 * 6) - 2.49;
                        }
                    
                        
                    }
                    
                }
            }
            return 0.0;

        }
    


        public double GetItemCost(Item item)
        {
            double tot = 0;
            if(item.GetType() == typeof(Bagel)){
                foreach(Filling fill in item.bagelfillings) {
                    tot += fill.prices[fill.actualname];

                }
            }


            return item.prices[item.name] + tot;
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
