using exercise.main.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Discount
    {
        private double totalDiscount = 0;
        public int twelveBagelsForThreeNintyNine = 0;
        public int sixBagelsForTwoFourtyNine = 0;
        public int CoffeAndBagelForOneTwentyNine = 0;
        Dictionary<string,double> discounts = new Dictionary<string,double>();
        public Discount() { }

        public Dictionary<string, double> checkDiscounts(List<InventoryProduct> bagelList, List<InventoryProduct> coffeeList)
        {
            List<InventoryProduct> bagels = bagelList.ToList();
            List<InventoryProduct> coffees = coffeeList.ToList();
            string lineSeparator = "------------------------------------\n";
            Dictionary<string, double> addedDiscounts = new Dictionary<string, double>();

            int twelveBagelsForThreeNintyNine = 0;
            int sixBagelsForTwoFourtyNine = 0;
            int CoffeAndBagelForOneTwentyNine = 0;


            if (bagels.Count >= 12)
            {
                double productSum = 0;
                double twelves = bagels.Count / 12;
                twelveBagelsForThreeNintyNine = (int)Math.Floor(twelves);

                for (int i = 0; i < twelveBagelsForThreeNintyNine * 12; i++)
                {
                    productSum += bagels[0].Price;
                    bagels.Remove(bagels[0]);
                }
                addedDiscounts.Add($"{lineSeparator}{twelveBagelsForThreeNintyNine}x\tDiscount Twelve Bagels", Math.Round(-(productSum - 3.99d * twelveBagelsForThreeNintyNine), 2));

            }
            if (bagels.Count >= 6)
            {
                double productSum = 0;
                double sixs = bagels.Count / 6;
                sixBagelsForTwoFourtyNine = (int)Math.Floor(sixs);
                for (int i = 0; i < sixBagelsForTwoFourtyNine * 6; i++)
                {
                    productSum += bagels[0].Price;
                    bagels.Remove(bagels[0]);
                }
                string newLine = "";
                if (addedDiscounts.Keys.Count == 0)
                {
                    newLine = lineSeparator;
                }
                addedDiscounts.Add($"{newLine}{sixBagelsForTwoFourtyNine}x\tDiscount Six Bagels", Math.Round(-(productSum - 2.49d * sixBagelsForTwoFourtyNine), 2));
            }
            if (bagels.Count > 0 && coffees.Count > 0)
            {
                if (bagels.Count < coffees.Count)
                {

                    CoffeAndBagelForOneTwentyNine = bagels.Count;

                }
                else { CoffeAndBagelForOneTwentyNine = coffees.Count; }
                double productSum = 0;
                for (int i = 0; i < CoffeAndBagelForOneTwentyNine; i++)
                {
                    productSum += bagels[0].Price;
                    bagels.Remove(bagels[0]);
                }
                string newLine = "";
                if (addedDiscounts.Keys.Count == 0)
                {
                    newLine = lineSeparator;
                }
                addedDiscounts.Add($"{newLine}{CoffeAndBagelForOneTwentyNine}x\tDiscount Coffee & Bagel", Math.Round(-(productSum - 0.3d * CoffeAndBagelForOneTwentyNine), 2));
            }


            return addedDiscounts;
        }






        public double discount { get; set; }

        public double sum {  get { return totalDiscount; } }
    }
}
