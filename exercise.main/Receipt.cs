using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace exercise.main
{
    public class Receipt
    {
        private Deal deal = new Deal();
        private Inventory inventory = new Inventory();

        public Receipt()
        {

        }

        private string GetRealName(string itemName)
        {
            string name = "";

            switch (itemName)
            {
                case "BGLO":
                    name = "Onion Bagel";
                    break;

                case "BGLP":
                    name = "Plain Bagel";
                    break;

                case "BGLE":
                    name = "Everything Bagel";
                    break;

                case "BGLS":
                    name = "Sesame Bagel";
                    break;

                case "COFB":
                    name = "Black Coffee";
                    break;

                case "COFW":
                    name = "White Coffee";
                    break;

                case "COFC":
                    name = "Cappuccino Coffee";
                    break;

                case "COFL":
                    name = "Latte Coffee";
                    break;

                case "FILB":
                    name = "Bacon Filling";
                    break;


                case "FILE":
                    name = "Egg Filling";
                    break;

                case "FILC":
                    name = "Cheese Filling";
                    break;

                case "FILX":
                    name = "Cream Cheese Filling";
                    break;

                case "FILS":
                    name = "Smoked Salmon Filling";
                    break;

                case "FILH":
                    name = "Ham Filling";
                    break;
            }

            return name;
        }

        public string GetReceipt(Dictionary<Basket, int> basket)
        {
            string receipt = "~~~~ Bob's Bagels ~~~~\n\n2024-01-16 14:50:34\n\n----------------------\n\n";

            for (int i = 0; i < basket.Count(); i++)
            {
                if (i > 0)
                    receipt += "\n";

                receipt += GetRealName(basket.ElementAt(i).Key.GetSKU()) + "\t\t" + basket.ElementAt(i).Value + "\t£" + deal.GetDiscounts(basket.ElementAt(i).Key, basket.ElementAt(i).Value);

            }
            receipt += "\n\n----------------------\nTotal\t\t\t£" + deal.DiscountedTotalPrice(basket) + "\n\n\tThank you\n\tfor your order!";
            return receipt;
        }

        public string DiscountedReceipt(Dictionary<Basket, int> basket)
        {
            string receipt = "~~~~ Bob's Bagels ~~~~\n\n2024-01-16 14:50:34\n\n----------------------\n\n";

            for (int i = 0; i < basket.Count(); i++)
            {
                if (i > 0)
                    receipt += "\n";

                receipt += GetRealName(basket.ElementAt(i).Key.GetSKU()) + "\t\t" + basket.ElementAt(i).Value + "\t£" + deal.GetDiscounts(basket.ElementAt(i).Key, basket.ElementAt(i).Value);
                
                if (deal.CheckDiscount(basket.ElementAt(i).Key, basket.ElementAt(i).Value))
                    receipt += "\n\t\t\t\t\t(-£" + (deal.GetDiscounts(basket.ElementAt(i).Key, basket.ElementAt(i).Value) - inventory.CostOfBagel(basket.ElementAt(i).Key.GetSKU())) + ")";
            }

            receipt += "\n\n----------------------\nTotal\t\t\t£" + deal.DiscountedTotalPrice(basket) + "\n\n\tThank you\n\tfor your order!";
            return receipt;
        }
    }
}