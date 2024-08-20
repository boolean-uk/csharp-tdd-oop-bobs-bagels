using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {

        public Basket()
        {
            discounts.Add("BGLP", 0.0);
            discounts.Add("BGLE", 0.0);// BaGeL Taste
            discounts.Add("BGLS", 0.0);// BaGeL Taste
            discounts.Add("BGLO", 0.0);// BaGeL Taste
            discounts.Add("COFB", 0.0);
            discounts.Add("COFW", 0.0);
            discounts.Add("COFC", 0.0); 
            discounts.Add("COFL", 0.0);
        }
        public struct BasketItem
        {
            public string coffeeOrBagel = string.Empty;
            public string filling = string.Empty;

            public BasketItem(string coffeeOrBagel)
            {
                this.coffeeOrBagel = coffeeOrBagel;
            }
            public BasketItem(string coffeeOrBagel, string filling)
            {
                this.coffeeOrBagel = coffeeOrBagel;
                this.filling = filling;
            }
        }

        private double totalDiscount = 0.0;
        public Dictionary<string, double> discounts = new Dictionary<string, double>();
   
        Inventory inventory = new Inventory();
        public List<BasketItem> basket = new List<BasketItem>();
        public void Add(BasketItem item)
        {
            basket.Add(item);
        }

        public int GetSize()
        {
            return basket.Count;
        }

        public bool OrderInBasket(string name, string variant)
        {
            
            foreach (var order in basket)
            {
                if(name == inventory.GetNameAndVariant(order.coffeeOrBagel).name &&
                   variant == inventory.GetNameAndVariant(order.coffeeOrBagel).variant)
                {
                    return true; 
                }
                
            }
            return false;
        }

        public double ShowCost()
        {
            totalDiscount = 0.0;
            double retCost = 0.0;
            int bagleAmountTaste = 0;
            int bagleAmountPlain = 0;

            //these are for coffee discounts later
            int cof1 = 0;
            int cof2 = 0;
            int cof3 = 0;
            int cof4 = 0;
            foreach(var item in discounts)
            {
                discounts[item.Key] = 0.0; //just a reset
            }

            foreach (var item in basket)
            {
                if(item.coffeeOrBagel == "BGLP") //plain bagle
                {
                    bagleAmountPlain++;
                }
                else if (item.coffeeOrBagel.Substring(0, 3) == "BGL") // flavorful bagel
                {
                    bagleAmountTaste++;
                }
                if (item.coffeeOrBagel == "COFB")
                {
                    cof1++; //cheapest
                }
                else if (item.coffeeOrBagel == "COFW")
                {
                    cof2++; // middle
                }
                else if (item.coffeeOrBagel == "COFC" )
                {
                    cof3++;//expensive cof
                }
                else if (item.coffeeOrBagel == "COFL")
                {
                    cof4++;//expensive cof
                }
                retCost += inventory.GetPrice(item.coffeeOrBagel);
                retCost += inventory.GetPrice(item.filling);
            }
            //time to figure out bagel discount for flavorful
            int spare12Taste = bagleAmountTaste % 12;
            int discount12 = bagleAmountTaste / 12; // int should just remove the decimals
            int spare6Taste = spare12Taste % 6;
            int discount6 = spare12Taste / 6;// int should just remove the decimals

            discounts["BGLT"] = (double)discount12 * 1.89 + (double)discount6 * 0.45;
            totalDiscount += (double)discount12 * 1.89 + (double)discount6 * 0.45;
            retCost -= (double)discount12 * 1.89;
            retCost -= (double)discount6 * 0.45;

            //time to figure out bagel discount for plain
            int sparePlain = bagleAmountPlain % 12;
            discount12 = bagleAmountPlain / 12; // int should just remove the decimals
            discounts["BGLP"] = (double)discount12 * 0.69;

            totalDiscount += (double)discount12 * 0.69;
            retCost -= (double)discount12 * 0.69;
            //retCost -= (double)discount6 * 0.45;
            // I will not implement a discount on 6 plain bagles as 
            // buying them induvidually costs 2.34 and the "discount" is 2.49
            // I will not be scamming my customers ;)

            //for coffe we will use the plain bagels first so the
            //customer gets the cheaper bagel discounted. This is how
            // most businisses do it
            
            for(int i = 0; i < cof1; i++) //black
            {
                if (sparePlain > 0)
                {
                    sparePlain--;
                    retCost -= 0.13;
                    totalDiscount += 0.13;
                    discounts["COFB"] += 0.13;
                }
                else if (spare6Taste > 0)
                {
                    spare6Taste--;
                    retCost -= 0.23;
                    totalDiscount += 0.23;
                    discounts["COFB"] += 0.23;
                }
            }
            for (int i = 0; i < cof2; i++)//white/
            {
                if (sparePlain > 0)
                {
                    sparePlain--;
                    retCost -= 0.33;
                    totalDiscount += 0.33;
                    discounts["COFW"] += 0.33;
                }
                else if (spare6Taste > 0)
                {
                    spare6Taste--;
                    retCost -= 0.43;
                    totalDiscount += 0.43;
                    discounts["COFW"] += 0.43;
                }
            }
            for (int i = 0; i < cof3; i++)//   capuccino
            {
                if (sparePlain > 0)
                {
                    sparePlain--;
                    retCost -= 0.43;
                    totalDiscount += 0.43;
                    discounts["COFC"] += 0.43;
                }
                else if (spare6Taste > 0)
                {
                    spare6Taste--;
                    retCost -= 0.53;
                    totalDiscount += 0.53;
                    discounts["COFC"] += 0.53;
                }
            }
            for (int i = 0; i < cof4; i++)//   latte
            {
                if (sparePlain > 0)
                {
                    sparePlain--;
                    retCost -= 0.43;
                    totalDiscount += 0.43;
                    discounts["COFL"] += 0.43;
                }
                else if (spare6Taste > 0)
                {
                    spare6Taste--;
                    retCost -= 0.53;
                    totalDiscount += 0.53;
                    discounts["COFL"] += 0.53;
                }
            }
            discounts["BGLO"] = discounts["BGLT"];
            discounts["BGLE"] = discounts["BGLT"];
            discounts["BGLS"] = discounts["BGLT"];
            discounts["BGLT"] = 0.0;

            foreach (var item in discounts)
            {
                discounts[item.Key] = Math.Round(item.Value, 2);
            }

            return Math.Round(retCost, 2);
        }

        public double GetDiscount()
        {
            return Math.Round(this.totalDiscount, 2);
        }
        public bool RemoveFromBasket(string name, string variant)
        {
            string code = inventory.GetCode(name, variant);
            if(name == "Coffee" || name == "Bagel")
            {
                for(int i = 0; i < basket.Count; i++)
                {
                    if (basket[i].coffeeOrBagel == code)
                    {
                        basket.RemoveAt(i);
                        return true;
                    }
                }
            }
            if (name == "Filling")
            {
                for (int i = 0; i < basket.Count; i++)
                {
                    if (basket[i].filling == code)
                    {
                        BasketItem replaceItem = basket[i];
                        replaceItem.filling = string.Empty;
                        return true;
                    }
                }
            }
            return false;
        }

        public void ClearBasket()
        {
            basket.Clear();
        }

        
    }
}
