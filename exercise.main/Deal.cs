using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Deal
    {
        private Inventory inventory = new Inventory();
        public Deal()
        {
        }

        public float DiscountedTotalPrice(Dictionary<Basket, int> basket)
        {
            Dictionary<Basket, int> tempBasket = basket;
            float totalPrice = 0.0f;
            int nrCoffees = 0;
            int nrBagels = 0;

            for (int i = 0; i < tempBasket.Count(); i++)
            {
                //If it is a bagel
                if (tempBasket.ElementAt(i).Key.GetSKU()[0] == 'B')
                {
                    if (tempBasket.ElementAt(i).Value < 6)
                    {
                        //Checks if the coffee can be paired with a bagel
                        if (nrCoffees > 0 && nrBagels > 0)
                        {
                            if (nrCoffees < nrBagels)
                            {
                                totalPrice += 1.25f * nrCoffees;
                                nrCoffees -= nrCoffees;
                                nrBagels -= nrCoffees;
                            }
                            else
                            {
                                totalPrice += 1.25f * nrBagels;
                                nrCoffees -= nrBagels;
                                nrBagels -= nrBagels;
                            }
                        }
                        else
                            totalPrice += inventory.CostOfBagel(tempBasket.ElementAt(i).Key.GetSKU());
                    }

                    //If there are exactly 6 same bagels
                    else if (tempBasket.ElementAt(i).Value == 6)
                        totalPrice += 2.49f;

                    //If there are exactly 12 same bagels
                    else if (tempBasket.ElementAt(i).Value == 12)
                        totalPrice += 3.99f;

                    //More than 12
                    else if (tempBasket.ElementAt(i).Value > 12)
                    {
                        i--;
                        totalPrice += 3.99f;
                        tempBasket[tempBasket.ElementAt(i).Key] -= 12;
                    }

                    //More than 6
                    else if (tempBasket.ElementAt(i).Value > 6)
                    {
                        i--;
                        totalPrice += 2.49f;
                        tempBasket[tempBasket.ElementAt(i).Key] -= 6;
                    }
                }

                //If it is a coffee
                else if (tempBasket.ElementAt(i).Key.GetSKU()[0] == 'C')
                {
                    nrCoffees += tempBasket.ElementAt(i).Value;

                    //Checks if the coffee can be paired with a bagel
                    if (nrCoffees > 0 && nrBagels > 0)
                    {
                        if (nrCoffees < nrBagels)
                        {
                            totalPrice += 1.25f * nrCoffees;
                            nrCoffees -= nrCoffees;
                            nrBagels -= nrCoffees;
                        }
                        else
                        {
                            totalPrice += 1.25f * nrBagels;
                            nrCoffees -= nrBagels;
                            nrBagels -= nrBagels;
                        }
                    }
                    else
                        totalPrice += inventory.CostOfBagel(tempBasket.ElementAt(i).Key.GetSKU());
                }
            }

            return totalPrice;
        }

        public bool CheckDiscount(Basket item, int amount)
        {
            if (amount < 6 || item.GetSKU()[0] != 'B')
                return false;

            return true;
        }

        public float GetDiscounts(Basket item, int amount)
        {
            float price = 0.0f;

            if (item.GetSKU()[0] == 'B')
            {
                if (amount == 6)
                    return 2.49f;
                else if (amount == 12)
                    return 3.99f;
                else if (amount > 12)
                {
                    price = 3.99f;
                    int tempAmount = amount;
                    tempAmount -= 12;

                    while (tempAmount > 12)
                    {
                        price += 3.99f;
                        tempAmount -= 12;
                    }

                    while (tempAmount > 6)
                    {
                        price += 2.49f;
                        tempAmount -= 6;
                    }

                    if (tempAmount > 0)
                        price += inventory.CostOfBagel(item.GetSKU()) * tempAmount;

                    return price;
                }
                else if (amount > 6)
                {
                    price = 2.49f;
                    int tempAmount = amount;
                    tempAmount -= 6;

                    while (tempAmount > 6)
                    {
                        price += 2.49f;
                        tempAmount -= 6;
                    }

                    if (tempAmount > 0)
                        price += inventory.CostOfBagel(item.GetSKU()) * tempAmount;

                    return price;
                }
                else if (amount < 6)
                    price = inventory.CostOfBagel(item.GetSKU()) * amount;
            }

            return price;
        }

        public Dictionary<Basket, int> GetDiscountList(Dictionary<Basket, int> basket)
        {
            Dictionary<Basket, int> discounts = new Dictionary<Basket, int>();

            for (int i = 0; i < basket.Count(); i++)
            {
                
            }

            return discounts;
        }
    }
}
