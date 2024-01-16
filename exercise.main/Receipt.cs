using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Receipt
    {
        public Receipt()
        {

        }

        public bool PrintReceipt(Basket basket)
        {
            Deal deal = new Deal();
            Dictionary<Bagel, float> bagels = new Dictionary<Bagel, float>();
            bool found = false;
            string receipt = "~~~~ Bob's Bagels ~~~~\n\n2024-01-16 14:50:34\n\n----------------------\n\n";

            for (int i = 0; i < basket.GetBagels().Count(); i++)
            {
                for (int j = 0; j < bagels.Count(); j++)
                {
                    if (bagels.ElementAt(j).Key.GetBagelType() == basket.GetBagels()[i].GetBagelType() &&
                        bagels.ElementAt(j).Key.GetFillingName() == basket.GetBagels()[i].GetFillingName())
                    {
                        bagels[bagels.ElementAt(j).Key]++;
                        found = true;
                    }
                }

                if (!found)
                    bagels.Add(basket.GetBagels()[i], 1);
                found = false;
            }

            for (int i = 0; i < bagels.Count(); i++)
            {
                if (i > 0)
                    receipt += "\n";

                if (bagels.ElementAt(i).Key.GetFillingName() == "")
                    receipt += bagels.ElementAt(i).Key.GetBagelType() + "\t" + bagels.ElementAt(i).Value + "\t£" + bagels.ElementAt(i).Key.GetBagelCost();
                else
                    receipt += bagels.ElementAt(i).Key.GetBagelType() + "\t" + bagels.ElementAt(i).Value + "\t£" + bagels.ElementAt(i).Key.GetBagelCost() +
                    "\n" + bagels.ElementAt(i).Key.GetFillingName() + "\t\t£" + bagels.ElementAt(i).Key.GetFillingCost();
            }

            receipt += "\n\n----------------------\nTotal\t\t\t£" + deal.DiscountPrice(basket) + "\n\n\tThank you\n\tfor your order!";

            Console.WriteLine(receipt);
            return true;
        }
    }
}