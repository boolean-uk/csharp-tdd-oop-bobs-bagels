using csharp_tdd_bobs_bagels.tests;
using exercise.main;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
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
        private float _toatalPriceAfterDiscount = 0;

        //discount count
        private int _discount6Bagels = 0;
        private int _discount12Bagels = 0;
        private int _coffeeBagelDiscount = 0;


        public Basket()
        {
            
        }

        public bool Add(Bagel bagelName)
            //Override for Bagel Add
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
            //Override for Coffee Add
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
            //this method calculates discount based on:
            //12 bagels of any type will always cost 3.99,
            //6 bagels of any type will always cost 2.49
        {
            int bagelAmount = _bagels.Count;
            int coffeeAmount = _coffee.Count;


            if (bagelAmount >= 12)
            {
                _discount12Bagels = bagelAmount/12;

                for (int i = 0; i < (_discount12Bagels * 12); i++)
                {
                    _bagels[i].Price = 3.99f / 12;
                }

                if (bagelAmount - (_discount12Bagels * 12) > 6)
                {
                    _discount6Bagels++;
                    for (int i = (_discount12Bagels * 12); i < (_discount12Bagels * 12) + 6; i++)
                    {
                        _bagels[i].Price = 2.48f / 6;
                    }
                    if (bagelAmount - (_discount12Bagels * 12) - 6 > 0 && coffeeAmount > 0)
                    {
                        //this can be grouped into a private method later if I have time
                        int coffeeLeft = coffeeAmount;
                        int bagelLeft = bagelAmount - (_discount12Bagels * 12) - 6;
                        int counterB = (_discount12Bagels * 12) + 6;
                        int counterC = 0;
                        while (coffeeLeft > 0 && bagelLeft > 0)
                        {
                            _bagels[counterB].Price = 0;
                            _coffee[counterC].Price = 1.25f;
                            _coffeeBagelDiscount++;
                            counterB++;
                            counterC++;
                            coffeeLeft--;
                            bagelLeft--;
                        }
                    }
                }
            }
            else if (bagelAmount >= 6)
            {
                _discount6Bagels++;

                for (int i = 0; i < 6;  i++)
                {
                    _bagels[i].Price = 2.49f / 6;
                }
                if (bagelAmount - 6 > 0 && coffeeAmount > 0)
                {
                    int coffeeLeft = coffeeAmount;
                    int bagelLeft = bagelAmount - 6;
                    int counterB = 6;
                    int counterC = 0;
                    while (coffeeLeft > 0 && bagelLeft > 0)
                    {
                        _bagels[counterB].Price = 0;
                        _coffee[counterC].Price = 1.25f;
                        _coffeeBagelDiscount++;
                        counterB++;
                        counterC++;
                        coffeeLeft--;
                        bagelLeft--;
                    }
                }

            }
            else
            {
                if (coffeeAmount > 0 && bagelAmount > 0)
                {
                    int coffeeLeft = coffeeAmount;
                    int bagelLeft = bagelAmount;
                    int counterB = 0;
                    int counterC = 0;
                    while (coffeeLeft > 0 && bagelLeft > 0)
                    {
                        _bagels[counterB].Price = 0;
                        _coffee[counterC].Price = 1.25f;
                        _coffeeBagelDiscount++;
                        counterB++;
                        counterC++;
                        coffeeLeft--;
                        bagelLeft--;
                    }

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
        public bool Remove(Coffee coffeeName)

        {
            if (_coffee.Contains(coffeeName))
            {
                _coffee.Remove(coffeeName);
                _amount--;
                return true;
            }
            return false;
        }



        public void ChangeCapacity(int v)
        {
            _capacity = v;
        }
        public float TotalAfterDiscount()
        {
            foreach (Bagel bagel in _bagels)
            {
                if (bagel.Fillings.Count > 0)
                {
                    foreach (Filling filling in bagel.Fillings)
                    {
                        _toatalPriceAfterDiscount += filling.Price;
                    }
                    _toatalPriceAfterDiscount += bagel.Price;
                }
                else
                {
                    _toatalPriceAfterDiscount += bagel.Price;
                }
            }
            foreach (Coffee coffee in _coffee)
            {
                _toatalPriceAfterDiscount += coffee.Price;
            }
                
            return _toatalPriceAfterDiscount;
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

       
        public string PrintReceipt()
        {
            StringBuilder receipt = new();
            DateTime now = DateTime.Now;
            Dictionary<string, int> counts = CheckOut();


            receipt.AppendLine("    ~~~ Bob's Bagels ~~~     \n");
            receipt.AppendLine("         " + now.ToString("dd/MM/yyyy"));
            receipt.AppendLine("----------------------------\n");

            foreach (KeyValuePair<string, int> entry in CheckOut())
            {
                foreach (KeyValuePair<string, float> dec in SkuHandler.SkuDecoder(entry.Key))
                {
                    float tempPrice = dec.Value * entry.Value;
                    string tempString = dec.Key.PadRight(18);
                    tempString += (entry.Value.ToString() + "  £" + tempPrice.ToString()).PadLeft(10);
                    receipt.AppendLine(tempString);
                }
            }
            receipt.AppendLine("----------------------------\n");
            decimal totalNumber = (decimal)_totalPrice;
            if (_discount12Bagels > 0 || _discount6Bagels > 0 || _coffeeBagelDiscount > 0)
            {
            }
            string total = totalNumber.ToString();
            receipt.AppendLine("Total:".PadRight(15) +  ("£" + total).PadLeft(13) );
            receipt.AppendLine("\n Thank you for your order!");

            return receipt.ToString();
        }


        public List<Bagel> AmountOfBagels { get => _bagels; set => _bagels = value; }
        public int Capacity { get => _capacity; set => _capacity = value; }
    }

}


