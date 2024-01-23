using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Discounts
    {
        public List<Product> _basket;
        public Discounts(List<Product> basket)
        {
            _basket = basket;

        }

        public double CalculateDiscount()
        {
            //Variables to keep track of different bagels and total bagels
            double discountprice = 0;
            double coffeeDiscountE = 0.0;
            double coffeeDiscountP = 0.0;
            double coffeeDiscountS = 0.0;
            double coffeeDiscountO = 0.0;



            int bagelECount = 0;
            int bagelSCount = 0;
            int bagelPCount = 0;
            int bagelOCount = 0;
            int cofCCount = 0;
            int cofBCount = 0;
            int cofWCount = 0;
            int cofLCount = 0;
            int FilSCount = 0;
            int FilECount = 0;
            int FilCCount = 0;
            int FilXCount = 0;
            int FilHCount = 0;

            //Switch statement to find number of items in cart 
            foreach (Product product in _basket)
            {

                switch (product.SKU)
                {
                    case ("COFW"):
                        cofWCount++;
                        break;
                    case ("COFB"):
                        cofBCount++;
                        break;
                    case ("COFL"):
                        cofLCount++;
                        break;
                    case ("COFC"):
                        cofCCount++;
                        break;
                    case ("BGLO"):
                        bagelOCount++;
                        break;
                    case ("BGLE"):
                        bagelECount++;
                        break;
                    case ("BGLS"):
                        bagelSCount++;
                        break;
                    case ("BGLP"):
                        bagelPCount++;
                        break;
                    case ("FILS"):
                        FilSCount++;
                        break;
                    case ("FILE"):
                        FilECount++;
                        break;
                    case ("FILX"):
                        FilXCount++;
                        break;
                    case ("FILH"): 
                        FilHCount++;
                        break;
                    case ("FILC"):
                        FilCCount++;
                        break;
                }
            }

            int coffeeCount = cofWCount + cofBCount + cofLCount + cofCCount;

            //Runs method to check and porentialy do discount on the bagels depending on number
            //Moves discounted items to discount basket
            //Onion bagel
            double bgloDiscount = BagelDiscount("BGLO", bagelOCount, out int bgloCountAfter);

            bagelOCount = bgloCountAfter;


            //Everything bagel
            double bgleDiscount = BagelDiscount("BGLE", bagelECount, out int bgleCountAfter);

            bagelECount = bgleCountAfter;

           

            //Plain bagel
            double bglpDiscount = BagelDiscount("BGLP", bagelPCount, out int bglpCountAfter);

            bagelPCount = bglpCountAfter;


            //Sesame bagel
            double bglsDiscount = BagelDiscount("BGLS", bagelSCount, out int bglsCountAfter);

            bagelSCount = bglsCountAfter;
            while (coffeeCount > 0 && bgleCountAfter > 0)
            {
                if (cofBCount > 0 && bgleCountAfter > 0)
                {
                    coffeeDiscountO += CoffeeDiscount(bagelOCount, cofBCount, out int bagelCountAfter, out int coffeeCountAfter);
                    bagelOCount = bagelCountAfter;
                    cofBCount = coffeeCountAfter;

                    coffeeDiscountE += CoffeeDiscount(bagelECount, cofBCount, out bagelCountAfter, out coffeeCountAfter);
                    bagelECount = bagelCountAfter;
                    cofBCount = coffeeCountAfter;

                    coffeeDiscountS += CoffeeDiscount(bagelSCount, cofBCount, out bagelCountAfter, out coffeeCountAfter);
                    bagelSCount = bagelCountAfter;
                    cofBCount = coffeeCountAfter;

                    coffeeDiscountP += CoffeeDiscount(bagelPCount, cofBCount, out bagelCountAfter, out coffeeCountAfter);
                    bagelPCount = bagelCountAfter;
                    cofBCount = coffeeCountAfter;
                }
                if (cofWCount > 0 && bgleCountAfter > 0)
                {
                    coffeeDiscountO = CoffeeDiscount(bagelOCount, cofWCount, out int bagelCountAfter, out int coffeeCountAfter);
                    bagelOCount = bagelCountAfter;
                    cofWCount = coffeeCountAfter;

                    coffeeDiscountE = CoffeeDiscount(bagelECount, cofWCount, out bagelCountAfter, out coffeeCountAfter);
                    bagelECount = bagelCountAfter;
                    cofWCount = coffeeCountAfter;

                    coffeeDiscountS = CoffeeDiscount(bagelSCount, cofWCount, out bagelCountAfter, out coffeeCountAfter);
                    bagelSCount = bagelCountAfter;
                    cofWCount = coffeeCountAfter;

                    coffeeDiscountP = CoffeeDiscount(bagelPCount, cofWCount, out bagelCountAfter, out coffeeCountAfter);
                    bagelPCount = bagelCountAfter;
                    cofWCount = coffeeCountAfter;
                }
                if (cofCCount > 0 && bgleCountAfter > 0)
                {
                    coffeeDiscountO = CoffeeDiscount(bagelOCount, cofCCount, out int bagelCountAfter, out int coffeeCountAfter);
                    bagelOCount = bagelCountAfter;
                    cofCCount = coffeeCountAfter;

                    coffeeDiscountE = CoffeeDiscount(bagelECount, cofCCount, out bagelCountAfter, out coffeeCountAfter);
                    bagelECount = bagelCountAfter;
                    cofCCount = coffeeCountAfter;

                    coffeeDiscountS = CoffeeDiscount(bagelSCount, cofCCount, out bagelCountAfter, out coffeeCountAfter);
                    bagelSCount = bagelCountAfter;
                    cofCCount = coffeeCountAfter;

                    coffeeDiscountP = CoffeeDiscount(bagelPCount, cofCCount, out bagelCountAfter, out coffeeCountAfter);
                    bagelPCount = bagelCountAfter;
                    cofCCount = coffeeCountAfter;
                }
                if (cofLCount > 0 && bgleCountAfter > 0)
                {
                    coffeeDiscountO = CoffeeDiscount(bagelOCount, cofLCount, out int bagelCountAfter, out int coffeeCountAfter);
                    bagelOCount = bagelCountAfter;
                    cofLCount = coffeeCountAfter;

                    coffeeDiscountE = CoffeeDiscount(bagelECount, cofLCount, out bagelCountAfter, out coffeeCountAfter);
                    bagelECount = bagelCountAfter;
                    cofLCount = coffeeCountAfter;

                    coffeeDiscountS = CoffeeDiscount(bagelSCount, cofLCount, out bagelCountAfter, out coffeeCountAfter);
                    bagelSCount = bagelCountAfter;
                    cofLCount = coffeeCountAfter;

                    coffeeDiscountP = CoffeeDiscount(bagelPCount, cofLCount, out bagelCountAfter, out coffeeCountAfter);
                    bagelPCount = bagelCountAfter;
                    cofLCount = coffeeCountAfter;
                }

                coffeeCount--;
            }

            //Math for adding together total discount
            discountprice =  bgloDiscount + bgleDiscount + bglpDiscount + bglsDiscount +
                coffeeDiscountO + coffeeDiscountE + coffeeDiscountP + coffeeDiscountS +
                (0.49 * bagelOCount) + (0.49 * bagelECount) + (0.49 * bagelSCount) +
                (0.39 * bagelPCount) + (0.99 * cofBCount) + (1.19 * cofWCount)
                + (1.29 * cofCCount) + (1.29 * cofLCount);
            ;

            return discountprice;
        }


        //Calculate discounts on 12 or 6 of bagels
        public double BagelDiscount(string SKU, int bglCount, out int bagelCountAfter)
        {
            double discountPrice = 0.00;

            while (bglCount >= 6)
            {
                if (bglCount >= 12)
                {
                    discountPrice += (3.99);
                    bglCount -= 12;

                }

                if (bglCount >= 6 && bglCount < 12)
                {
                    discountPrice += (2.49);
                    bglCount -= 6;

                }
            }
            bagelCountAfter = bglCount;
            return discountPrice;
        }
        //Calculate coffee discounts
        public double CoffeeDiscount(int bagelCount, int coffeeCount, out int bagelCountAfter, out int coffeeCountAfter)
        {
            double discountPrice = 0.00;
            while (bagelCount > 0 && coffeeCount > 0)
            {
                discountPrice += 1.25;
                bagelCount--; coffeeCount--;
            }
            bagelCountAfter = bagelCount;
            coffeeCountAfter = coffeeCount;
            return discountPrice;
        }

    }





}
