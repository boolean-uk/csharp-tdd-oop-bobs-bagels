using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        public int capacity;
        public List<IItem> inventoryList;
        public List<IItem> basketList;

        #region Basket
        public Basket()
        {
            capacity = 3;
            inventoryList = new List<IItem>();
            basketList = new List<IItem>();

            inventoryList.Add(new Bagel("BGLO", 0.49d, "Bagel", "Onion"));
            inventoryList.Add(new Bagel("BGLP", 0.39d, "Bagel", "Plain"));
            inventoryList.Add(new Bagel("BGLE", 0.49d, "Bagel", "Everything"));
            inventoryList.Add(new Bagel("BGLS", 0.49d, "Bagel", "Sesame"));
            inventoryList.Add(new Coffee("COFB", 0.99d, "Coffee", "Black"));
            inventoryList.Add(new Coffee("COFW", 1.19d, "Coffee", "White"));
            inventoryList.Add(new Coffee("COFC", 1.29d, "Coffee", "Cappuccino"));
            inventoryList.Add(new Coffee("COFL", 1.29d, "Coffee", "Latte"));
            inventoryList.Add(new Filling("FILB", 0.12d, "Filling", "Bacon"));
            inventoryList.Add(new Filling("FILE", 0.12d, "Filling", "Egg"));
            inventoryList.Add(new Filling("FILC", 0.12d, "Filling", "Cheese"));
            inventoryList.Add(new Filling("FILX", 0.12d, "Filling", "Cream Cheese"));
            inventoryList.Add(new Filling("FILS", 0.12d, "Filling", "Smoked Salmon"));
            inventoryList.Add(new Filling("FILH", 0.12d, "Filling", "Ham"));

        }
        #endregion

        #region Add Item
        public bool AddItem(string itemSKU) {

            for (int i = 0; i < inventoryList.Count; i++)
            {
                // Checks if the added item is viable in inventory
                if (basketList.Count < capacity)
                {
                    if (inventoryList[i].Sku == itemSKU)
                    {
                        basketList.Add(inventoryList[i]);
                        return true;
                    }

                } else return false;
            }
            return false;
        }
        #endregion

        #region Remove Item
        public bool RemoveItem(string itemSKU) {

            var item = basketList.Find(item => item.Sku == itemSKU);

            if (item != null)
            {
                basketList.Remove(item);
                Console.WriteLine($"{itemSKU} has been removed");
                return true;
            }
            Console.WriteLine($"{itemSKU} does not exist in basket");
            return false;
        }
        #endregion

        #region Calculate Cost
        public double totalCost()
        {
            return basketList.Sum(item => item.Price);
        }
        #endregion

        #region Change Capacity
        public int changeCapacity(int capacity) {
            // The idea is to copy the old basket into a new basket and overwrite
            List<IItem> list = new List<IItem>();
            this.capacity = capacity;

            if (basketList.Count != 0)
            {
                for (int i = 0; i < capacity; i++)
                {
                    list.Add(basketList[i]);
                }

                // Does not remove the filling to associated bagel
                foreach (var basketItem in basketList)
                {
                    if (basketItem.Sku.StartsWith("FIL"))
                    {
                        list.Add(basketItem);
                    }
                }
            }
            basketList = list;
            return basketList.Count;

        }
        #endregion

        #region Check Price

        public double checkPrice(string itemSKU)
        {
            foreach (var inventoryItem in inventoryList)
            {
                if (itemSKU == inventoryItem.Sku)
                {
                    return inventoryItem.Price;
                }
            }
            return 0;
        }
        #endregion

        #region Add Filling to bagel
        public bool AddFilling(int bagelIndex, string fillingSKU)
        {

            if (bagelIndex < 0 || bagelIndex >= basketList.Count)
            {
                return false;
            }

            var bagel = basketList[bagelIndex];
            if (!bagel.Sku.StartsWith("BGL"))
            {
                return false;
            }

            var filling = inventoryList.Find(x => x.Sku == fillingSKU);
            if (filling == null)
            {
                return false;
            }

            basketList.Insert(bagelIndex + 1, filling);
            return true;
        }
        #endregion

        #region Extension 1 - Discount
        public double Discount()
        {
            double price = 0;
            List<string> discount = new List<string>();

            // Adding inventory items
            inventoryList.Add(new Bagel("DIS6", 2.49, "Discount", "6 bagels"));
            inventoryList.Add(new Bagel("DIS12", 3.99, "Discount", "12 bagels"));
            inventoryList.Add(new Bagel("DISCB", 1.25, "Discount", "Coffee + Bagel"));

            // Sorting basketList (assuming basketList has items to be sorted)
            basketList.Sort((bagel1, bagel2) => bagel1.Sku.CompareTo(bagel2.Sku));

            int counterBGL = 0;
            int counterCOF = 0;

            // Counting Bagels (BGL) and Coffee (COF)
            foreach (var item in basketList)
            {
                if (item.Sku.StartsWith("BGL"))
                {
                    counterBGL++;
                }
                else if (item.Sku.StartsWith("COF"))
                {
                    counterCOF++;
                }
                else if (item.Sku.StartsWith("FIL"))
                {
                    discount.Add(item.Sku);
                }
            }

            // Generating how many "coupons"
            int discount12 = counterBGL / 12; // 20/12 = 1
            int remainingAfter12 = counterBGL % 12; // 20%12 = 8
            int discount6 = remainingAfter12 / 6; // 8/6 = 1
            int remainingAfter6 = remainingAfter12 % 6; // 8%6 = 2

            // Generating bagel discounts
            for (int i = 0; i < discount12; i++)
            {
                discount.Add("DIS12");
            }

            for (int i = 0; i < discount6; i++)
            {
                discount.Add("DIS6");
            }

            // Generating discounts with coffee + bagel
            if (counterCOF >= remainingAfter6)
            {
                int discountCB = counterCOF * remainingAfter6 / counterCOF;
                for (int i = 0; i < discountCB; i++)
                {
                    discount.Add("DISCB");
                }

                int remainder = counterCOF - remainingAfter6;
                int counter = 0;
                for (int i = 0; i < remainder; i++)
                {
                    for (int j = 0; j < basketList.Count; j++)
                    {
                        if (basketList[j].Sku.StartsWith("COF") && counter < remainder)
                        {
                            counter++;
                            discount.Add(basketList[j].Sku);
                        }
                    }
                }
            }

            if (remainingAfter6 > counterCOF)
            {
                int discountCB = remainingAfter6 * counterCOF / remainingAfter6;
                for (int i = 0; i < discountCB; i++)
                {
                    discount.Add("DISCB");
                }

                int remainder = remainingAfter6 - counterCOF;
                int counter = 0;
                for (int i = 0; i < remainder; i++)
                {
                    for (int j = 0; j < basketList.Count; j++)
                    {
                        if (basketList[j].Sku.StartsWith("BGL") && counter < remainder)
                        {
                            counter++;
                            discount.Add(basketList[j].Sku);
                        }
                    }
                }
            }

            // Calculate total price with discount
            foreach (var discountSku in discount)
            {
                foreach (var bagel in inventoryList)
                {
                    if (discountSku.Equals(bagel.Sku))
                    {
                        price += bagel.Price;
                    }
                }
            }

            return Math.Round(price, 2);
        }
        #endregion

        #region Extension 2 - Receipt


        public string PrintReceipt()
        {
            List<string> receipt = new List<string>();
            StringBuilder builder = new StringBuilder();

            string sku = basketList[0].Sku;
            double totalPrice = 0;

            builder.AppendLine("~~~ Bob's Bagel ~~~")
                    .AppendFormat("{0,-20}{1,20}{2,20}\n", "ITEM", "QTY.", "TOTAL")
                    .AppendLine("---------------------------------------------------------------------");

            foreach (var inventoryItem in inventoryList)
            {
                foreach (var basketItem in basketList)
                {
                    if (inventoryItem.Sku == basketItem.Sku)
                    {
                        sku = basketItem.Sku;
                    }

                    if (!receipt.Contains(sku))
                    {
                        receipt.Add(sku);

                        // Calculate the price for the item
                        int quantity = basketList.Count(p => p.Sku == sku);
                        double price = inventoryItem.Price * quantity;
                        totalPrice += price;
                        string formattedPrice = string.Format("{0:F2}£", price);

                        builder.AppendFormat("{0,-15}{1,-20}{2,-20}{3}\n", inventoryItem.Variant, inventoryItem.Name, quantity, formattedPrice);
                    }
                }
            }

            builder.AppendLine("---------------------------------------------------------------------")
                    .AppendFormat("{0,62}", totalCost() + "£");

            return builder.ToString();

        }
    }

        #endregion
}
