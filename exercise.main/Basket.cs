using csharp_tdd_bobs_bagels.tests;
using exercise.main;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace tdd_bobs_bagels.CSharp.Main
{

    public class Basket
    {
        private Dictionary<string, List<string>> _checkout = new Dictionary<string, List<string>>();
        private List<Bagel> _bagels = new List<Bagel>();
        private List<Coffee> _coffee = new List<Coffee>();
        private int _capacity = 10;
        private int _amount = 0;
        private float _totalPrice = 0;

        public Basket()
        {

        }

        public bool Add(Bagel bagelName)
        {
            if ((_amount < Capacity))
            {
                _bagels.Add(bagelName);
                _amount++;
                _totalPrice += bagelName.Price;

                return true;
            }
            return false;
        }
        public bool Add(Coffee coffeeName)
        {
            if ((_amount < Capacity))
            {
                _coffee.Add(coffeeName);
                _amount++;
                _totalPrice += coffeeName.Price;

                return true;
            }
            return false;

        }
        public void Discount()
        {
            int discount6Bagels = _bagels.Count / 6;

            if (discount6Bagels > 0)
            {
                _totalPrice -= 0.45f * discount6Bagels;

                int bagelCount = _bagels.Count - (discount6Bagels * 6);

                if (bagelCount > 0 && _coffee.Count > 0)
                {
                    int coffeeCount = _coffee.Count;
                    while (coffeeCount > 0 && bagelCount > 0)
                    {
                        _totalPrice -= 0.23f;
                        coffeeCount -= 1;
                        bagelCount -= 1;
                    }
                }
            }
            else if (_bagels.Count > 0 && _coffee.Count > 0)
            {
                int bagelCount = _bagels.Count;
                int coffeeCount = _coffee.Count;
                while (coffeeCount > 0 && bagelCount > 0)
                {
                    _totalPrice -= 0.23f;
                    coffeeCount -= 1;
                    bagelCount -= 1;
                }

            }

        }

        public bool Remove(Bagel bagelName)
        {
            if (_bagels.Contains(bagelName))
            {
                _bagels.Remove(bagelName);
                _amount--;
                return true;
            }
            return false;
        }

        public void ChangeCapacity(int v)
        {
            _capacity = v;
        }

        public float Total()
        {
            return _totalPrice;
        }
        public Dictionary<string, int> CheckOut()
        {
            //returns a dictionary with SKU as key and amount of duplicates as value

            //List<string> bagelSkuList = _bagels.Select(b => b.SKU).ToList();
            Dictionary<string, int> counts = new Dictionary<string, int>();

            foreach (Bagel bagel in _bagels)
            {
                if (counts.ContainsKey(bagel.SKU))
                {
                    counts[bagel.SKU]++;
                }
                else
                {
                    counts[bagel.SKU] = 1;
                }
            }
            foreach (Coffee coffee in _coffee)
            {
                if (counts.ContainsKey(coffee.SKU))
                {
                    counts[coffee.SKU]++;
                }
                else
                {
                    counts[coffee.SKU] = 1;
                }
            }
            return counts;
        }

        public string PrintBetterReceipt()
        {
            StringBuilder receipt = new();
            DateTime now = DateTime.Now;
            Dictionary<string, int> counts = CheckOut();


            receipt.AppendLine("    ~~~ Bob's Bagels ~~~     \n");
            receipt.AppendLine("         " + now.ToString("dd/MM/yyyy"));
            receipt.AppendLine("----------------------------\n");
            return receipt.ToString();
        }


        public string PrintReceipt()
        {
            //prints the receipt (ISUE FOUND: cant sum up all the elements in one line)
            StringBuilder receipt = new();
            DateTime now = DateTime.Now;
            receipt.AppendLine("    ~~~ Bob's Bagels ~~~     \n");
            receipt.AppendLine("         " + now.ToString("dd/MM/yyyy"));
            receipt.AppendLine("----------------------------\n");
            if (_bagels.Count > 0)
            {
                foreach (Bagel bagel in _bagels)
                {
                    float bagelPrice = bagel.Price;
                    string bagelName = bagel.CurrentFlavor.Substring(0, 1).ToUpper() + bagel.CurrentFlavor.Substring(1);
                    float bagelTotal = 0;


                    if (bagel.Fillings.Count > 0)
                    {
                        foreach (Filling filling in bagel.Fillings)
                        {
                            bagelPrice -= filling.Price;
                        }
                    }
                    receipt.AppendLine(bagelName.PadRight(16) + bagelPrice.ToString().PadLeft(12));

                    if (bagel.Fillings.Count > 0)
                    {
                        foreach (Filling filling in bagel.Fillings)
                        {
                            float fillingPrice = filling.Price;
                            string fillingName = filling.FillingName.Substring(0, 1).ToUpper() + filling.FillingName.Substring(1);
                            receipt.AppendLine(fillingName.PadRight(16) + fillingPrice.ToString().PadLeft(12));
                        }
                    }
                }
                if (_coffee.Count > 0)
                {
                    foreach (Coffee coffee in _coffee)
                    {
                        float coffeePrice = coffee.Price;
                        string coffeeName = coffee.Type.Substring(0, 1).ToUpper() + coffee.Type.Substring(1);
                        receipt.AppendLine(coffeeName.PadRight(16) + coffeePrice.ToString().PadLeft(12));
                    }
                }
            }

            receipt.AppendLine("----------------------------\n");
            decimal totalNumber = (decimal)_totalPrice;
            string total = totalNumber.ToString();
            receipt.AppendLine("Total:".PadRight(15) + (total.PadLeft(12)) + "£");
            receipt.AppendLine("\n Thank you for your order!");

            return receipt.ToString();
        }
        
        public List<Bagel> AmountOfBagels { get => _bagels; set => _bagels = value; }
        public int Capacity { get => _capacity; set => _capacity = value; }
    }

}


