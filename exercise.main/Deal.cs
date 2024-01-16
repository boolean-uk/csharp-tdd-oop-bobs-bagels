using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Deal
    {
        public struct Discounts
        {
            public string SKU;
            public int nrItems;
            public float price;
        }

        List<Discounts> discounts;

        public Deal()
        {
            discounts = new List<Discounts>();
            
            Discounts deal1 = new Discounts();
            deal1.SKU = "BGLO";
            deal1.nrItems = 6;
            deal1.price = 2.49f;


            Discounts deal2 = new Discounts();
            deal2.SKU = "BGLP";
            deal2.nrItems = 12;
            deal2.price = 3.99f;

            Discounts deal3 = new Discounts();
            deal3.SKU = "BGLE";
            deal3.nrItems = 6;
            deal3.price = 2.49f;

            //Discounts deal4 = new Discounts();
            //deal4.SKU = "COFB";
            //deal4.nrItems = 1;
            //deal4.price = 1.25f;

            discounts.Add(deal1);
            discounts.Add(deal2);
            discounts.Add(deal3);
            //discounts.Add(deal4);
        }

        public bool CheckDeal(string SKU)
        {
            for (int i = 0; i < discounts.Count(); i++)
            {
                if (discounts[i].SKU == SKU)
                    return true;
            }

            return false;
        }

        public float DiscountPrice(Basket basket)
        {
            List<Bagel> bagels = basket.GetBagels();
            float totalPrice = 0.0f;

            float[] currentNr = new float[discounts.Count];
            currentNr[0] = 0;
            currentNr[1] = 0;
            currentNr[2] = 0;

            for (int i = 0; i < bagels.Count(); i++)
            {
                for (int j = 0; j < discounts.Count(); j++)
                {
                    if (bagels[i].GetBagelType() == discounts[j].SKU)
                    { 
                        currentNr[j]++;
                    }
                }
                    totalPrice += bagels[i].GetBagelCost();
                    totalPrice += bagels[i].GetFillingCost();
            }

            for (int i = 0; i < discounts.Count(); i++)
            {
                if (discounts[i].nrItems == currentNr[i])
                {
                    totalPrice -= (bagels[i].CostOfBagel(discounts[i].SKU) * discounts[i].nrItems);
                    totalPrice += discounts[i].price;
                }
            }

            return totalPrice;
        }

        public Dictionary<Bagel, float> SavedMoney(Dictionary<Bagel, float> nrBagels)
        {
            Dictionary<Bagel, float> discBagels = new Dictionary<Bagel, float>();

            for (int i = 0; i < nrBagels.Count(); i++)
            {
                for (int j = 0; j < discounts.Count(); j++)
                {
                    if (nrBagels.ElementAt(i).Key.GetBagelType() == discounts[j].SKU && nrBagels.ElementAt(i).Value == discounts[j].nrItems)
                        discBagels.Add(nrBagels.ElementAt(i).Key, discounts[j].price - nrBagels.ElementAt(i).Key.GetBagelCost());
                }
            }

            return discBagels;
        }

        public float DiscountedPrice(string SKU)
        {
            float cost = 1;

            for (int i = 0; i < discounts.Count(); i++)
            {
                if (discounts[i].SKU == SKU)
                    cost = discounts[i].price;
            }

            return cost;
        }
    }
}
