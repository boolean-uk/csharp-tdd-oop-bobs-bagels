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
                    receipt += bagels.ElementAt(i).Key.GetBagelType() + "\t" + bagels.ElementAt(i).Value + "\t£" + bagels.ElementAt(i).Key.GetBagelCost() * bagels.ElementAt(i).Value;
                else
                    receipt += bagels.ElementAt(i).Key.GetBagelType() + "\t" + bagels.ElementAt(i).Value + "\t£" + bagels.ElementAt(i).Key.GetBagelCost() * bagels.ElementAt(i).Value +
                    "\n" + bagels.ElementAt(i).Key.GetFillingName() + "\t\t£" + bagels.ElementAt(i).Key.GetFillingCost();
            }

            receipt += "\n\n----------------------\nTotal\t\t\t£" + deal.DiscountPrice(basket) + "\n\n\tThank you\n\tfor your order!";

            Console.WriteLine(receipt);
            return true;
        }

        public bool DiscountedReceipt(Basket basket)
        {
            Deal deal = new Deal();
            Dictionary<Bagel, float> bagels = new Dictionary<Bagel, float>();
            Dictionary<Bagel, float> discBagels;
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

            discBagels = deal.SavedMoney(bagels);
            bool discounted = false;

            for (int i = 0; i < bagels.Count(); i++)
            {
                if (i > 0)
                    receipt += "\n";

                
                for (int j = 0; j < discBagels.Count(); j++)
                {
                    if (bagels.ElementAt(i).Key.GetBagelType() == discBagels.ElementAt(j).Key.GetBagelType() &&
                        bagels.ElementAt(i).Key.GetFillingName() == discBagels.ElementAt(j).Key.GetFillingName())
                    {
                        discounted = true;
                        if (bagels.ElementAt(i).Key.GetFillingName() == "")
                            receipt += bagels.ElementAt(i).Key.GetBagelType() + "\t" + bagels.ElementAt(i).Value + "\t£" + deal.DiscountedPrice(bagels.ElementAt(i).Key.GetBagelType());
                        else
                            receipt += bagels.ElementAt(i).Key.GetBagelType() + "\t" + bagels.ElementAt(i).Value + "\t£" + deal.DiscountedPrice(bagels.ElementAt(i).Key.GetBagelType()) +
                        "\n" + bagels.ElementAt(i).Key.GetFillingName() + "\t\t£" + bagels.ElementAt(i).Key.GetFillingCost();
                        receipt += "\n\t\t\t(-£" + discBagels.ElementAt(j).Value + ")";
                    }
                }

                if (!discounted)
                {
                    if (bagels.ElementAt(i).Key.GetFillingName() == "")
                        receipt += bagels.ElementAt(i).Key.GetBagelType() + "\t" + bagels.ElementAt(i).Value + "\t£" + bagels.ElementAt(i).Key.GetBagelCost() * bagels.ElementAt(i).Value;
                    else
                        receipt += bagels.ElementAt(i).Key.GetBagelType() + "\t" + bagels.ElementAt(i).Value + "\t£" + bagels.ElementAt(i).Key.GetBagelCost() * bagels.ElementAt(i).Value +
                        "\n" + bagels.ElementAt(i).Key.GetFillingName() + "\t\t£" + bagels.ElementAt(i).Key.GetFillingCost();
                }

                discounted = false;
            }

            receipt += "\n\n----------------------\nTotal\t\t\t£" + deal.DiscountPrice(basket) + "\n\n\tThank you\n\tfor your order!";

            Console.WriteLine(receipt);
            return true;
        }
    }
}