using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class CheckOut
    {
        private int _nrCoffeeBagel = 0;
        private float _originalCoffeeBagelCost = 0;
        private Dictionary<string, float> _itemCost = new Dictionary<string, float>();

        //calculates the total cost, and also readies information for the receipts
        internal float CalculateCost(Dictionary<ShopItem, int> itemAmounts)
        {
            _nrCoffeeBagel = 0;
            _originalCoffeeBagelCost = 0;
            _itemCost.Clear();


            float totalCost = 0;
            int nrSingleBagels = 0;
            int nrCoffees = 0;
            float blackCoffeePrice = 0;
            Dictionary<ShopItem, int> leftOvers = new Dictionary<ShopItem, int>();

            //first all bagel deals are calculated, black coffees are counted
            //and all other item costs are added normally
            foreach (var itemAmount in itemAmounts)
            {
                if (itemAmount.Key.SKU.Substring(0, 3).Equals("bgl"))
                {
                    int nrTwelves = itemAmount.Value / 12;
                    int rest = itemAmount.Value % 12;
                    int nrSixes = rest / 6;
                    rest = itemAmount.Value % 6;

                    nrSingleBagels += rest;
                    leftOvers.Add(itemAmount.Key, rest);

                    float cost = nrTwelves * 3.99f + nrSixes * 2.49f;
                    totalCost += cost;
                    _itemCost[itemAmount.Key.SKU] = cost;
                    
                }
                else if (itemAmount.Key.SKU.Equals("cofb"))
                {
                    blackCoffeePrice = itemAmount.Key.Price;
                    nrCoffees += itemAmount.Value;
                }
                else
                {
                    float cost = itemAmount.Key.Price * itemAmount.Value;
                    totalCost += cost;
                    _itemCost[itemAmount.Key.SKU] = cost;
                }
            }

            //the are more bagels left than black coffees
            //some of the bagels will be part of a coffee bagel deal
            //while some should just be priced normally
            if (nrSingleBagels > nrCoffees)
            {
                _nrCoffeeBagel = nrCoffees;
                int rest = nrSingleBagels - nrCoffees;
           
                foreach (var bagelAmount in leftOvers)
                {
                    //all the bagels that are left are part of the coffe-bagel deal
                    if (rest == 0)
                    {
                        float cost = bagelAmount.Key.Price * bagelAmount.Value;
                        _originalCoffeeBagelCost += cost;
                    }
                    //some of the bagels are part of the deal, some are not discounted
                    else if (bagelAmount.Value > rest)
                    {
                        _originalCoffeeBagelCost += bagelAmount.Key.Price * (bagelAmount.Value - rest);
                        _itemCost[bagelAmount.Key.SKU] += bagelAmount.Key.Price * rest;

                        totalCost += bagelAmount.Key.Price * rest;

                        rest = 0;
                    }
                    //all the bagels are not discounted
                    else
                    {
                        float cost = bagelAmount.Key.Price * bagelAmount.Value;
                        _itemCost[bagelAmount.Key.SKU] += cost;
                        totalCost += cost;
                        rest -= bagelAmount.Value;
                    }
                }
            }
           //all bagels that are left are part of the coffe-bagel deal
           //but some black coffes might not be discounted
            else
            {
                _nrCoffeeBagel = nrSingleBagels;
                int rest = nrCoffees - nrSingleBagels;

                _itemCost["cofb"] = blackCoffeePrice * rest;
                totalCost += blackCoffeePrice * rest;

                foreach (var bagelAmount in leftOvers)
                {
                    float cost = bagelAmount.Key.Price * bagelAmount.Value;
                    _originalCoffeeBagelCost += cost;
                }
            }
            totalCost += _nrCoffeeBagel * 1.25f;
            _originalCoffeeBagelCost += blackCoffeePrice * _nrCoffeeBagel;

            return (float)Math.Round(totalCost, 2);
        }

        public void Receipt(Dictionary<ShopItem, int> itemAmounts)
        {
            float totalCost = this.CalculateCost(itemAmounts);

            var culture = CultureInfo.GetCultureInfo("en-GB");
            string receipt = $"{"~~~ Bob's Bagels ~~~~",28} \n";
            receipt += $"\n {DateTime.Now.ToString("dddd MMM yy, HH:mm", culture), 27} \n";
            receipt += new String('-', 40) + "\n";
            foreach (KeyValuePair<ShopItem, int> itemAmount in itemAmounts)
            {
                if (_itemCost.ContainsKey(itemAmount.Key.SKU) && _itemCost[itemAmount.Key.SKU] > 0)
                {
                    string type = itemAmount.Key.SKU.Substring(0, 3);
                    switch (type)
                    {
                        case "cof":
                            type = $"{itemAmount.Key.Description} Coffee";
                            break;

                        case "bgl":
                            type = $"{itemAmount.Key.Description} Bagel";
                            break;

                        case "fil":
                            type = $"{itemAmount.Key.Description} Filling";
                            break;
                    }
                    receipt += $"{type,-22}  {itemAmount.Value, -7}   {"£" + _itemCost[itemAmount.Key.SKU]} \n";
                    if (itemAmount.Value * itemAmount.Key.Price > _itemCost[itemAmount.Key.SKU])
                    {
                        receipt += $"{"",-32}(-£{(float)Math.Round(itemAmount.Value * itemAmount.Key.Price - _itemCost[itemAmount.Key.SKU], 2)})\n";
                    }
                }  
            }
            if(_nrCoffeeBagel > 0)
            {
                receipt += $"{"Coffee and bagel",-23} {_nrCoffeeBagel,-9} {"£" + _nrCoffeeBagel * 1.25f}\n";
                receipt += $"{"",32}(-£{(float)Math.Round(_originalCoffeeBagelCost - (_nrCoffeeBagel * 1.25f), 2)})\n";
            }
            
            receipt += new String('-', 40) + "\n";
            receipt += $"{"Total:",-33} {"£"+totalCost}\n";
            receipt += $"{"Thank you for",23}   \n {"shopping at Bob's Bagels babyy",32}";

            Console.WriteLine(receipt);
        }
    }
}
