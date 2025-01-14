using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Extension;


namespace exercise.main.Core
{
    public class Basket : IBasket
    {
        private List<Inventory> _basketList = new List<Inventory>();

        private int basketSize = 5; //Instantiating basket size

        //Dependency Injection
        public Basket(List<Inventory> basketList)
        {
            {
                _basketList = basketList;
            }
        }

        //User Story 1
        public bool AddBagelVariantToBasket(Bagel bagel)
        {
            if (_basketList.Count >= basketSize)
            {
                return false; // Basket is full
            }

            _basketList.Add(bagel);
            return true;
        }

        //User Story 2
        public bool RemoveBagelVariantFromBasket(Bagel bagel)
        {
            if (_basketList.Contains(bagel))
            {
                _basketList.Remove(bagel);
                return true;
            }
            return false;
        }

        //User Story 3
        public string BagelBasketIsFull()
        {
            if (_basketList.Count >= basketSize)
            {
                return "Basket is full!";
            }
            else
            {
                return "Basket is not full!";
            }
        }

        //User Story 4
        public string ChangeBasketCapacity(int newCapacity)
        {
            if (newCapacity > basketSize)
            {
                basketSize = newCapacity;
                return "Basket capacity is changed.";
            }
            else
            {
                return "Basket capacity is not changed.";
            }
        }

        //User Story 5
        public string CanRemoveItemInBasket(Inventory item)
        {
            if (_basketList.Contains(item))
            {
                return "Item is in basket and can be removed.";
            }
            else
            {
                return "Item is not in basket and cannot be removed.";
            }
        }

        //User Story 6
        public double TotalCostOfItems()
        {
            return _basketList.Sum(item => item.Price);
        }

        //User Story 7
        public double ReturnCostOfBagel(Bagel bagel)
        {
            foreach (Inventory item in _basketList)
            {
                if (item.Name == "Bagel" && item.Variant == bagel.Variant)
                {
                    return item.Price;
                }
            }
            return 0.0;
        }

        //User Story 8
        public string ChooseBagelFilling(Filling filling)
        {
            foreach (Inventory item in _basketList)
            {
                if (item.Sku == filling.Sku)
                {
                    return item.Variant;
                }
            }
            return "Filling type does not exist.";
        }

        //User Story 9
        public double CostOfEachFilling(Filling filling)
        {
            foreach (Inventory item in _basketList)
            {
                if (item.Sku == filling.Sku)
                {
                    return item.Price;
                }
            }
            return 0.0;
        }

        //User Story 10
        public bool MustBeInInventory(string sku)
        {
            foreach (Inventory item in _basketList)
            {
                if (item.Sku == sku)
                {
                    return true;
                }
            }
            return false;
        }

        //Helper getter methods for tests
        public List<Inventory> GetBasketList()
        {
            return _basketList;
        }
        public int GetBasketSize()
        {
            return basketSize;
        }

        // Extension 1: Discount
        public double CalculateTotalCostWithDiscounts()
        {
            double total = 0.0;

            // Simple discount logic for bagels
            int bgloCount = _basketList.Count(item => item.Sku == "BGLO");
            total += (bgloCount / 6) * 2.49 + (bgloCount % 6) * 0.49;

            int bglpCount = _basketList.Count(item => item.Sku == "BGLP");
            total += (bglpCount / 12) * 3.99 + (bglpCount % 12) * 0.39;

            int bgleCount = _basketList.Count(item => item.Sku == "BGLE");
            total += (bgleCount / 6) * 2.49 + (bgleCount % 6) * 0.49;

            // Coffee & Bagel Offer
            int coffeeCount = _basketList.Count(item => item.Sku == "COFB");
            int bagelCount = _basketList.Count(item => item.Name == "Bagel");
            int pairs = Math.Min(coffeeCount, bagelCount);
            total += pairs * 1.25;

            // Add remaining coffees
            total += (coffeeCount - pairs) * 0.99;

            return total;
        }

        //Extension 2: Receipt
        public Receipt GenerateReceipt()
        {
            var receipt = new Receipt();

            foreach (var group in _basketList.GroupBy(item => item.Sku))
            {
                var item = group.First();
                int quantity = group.Count();
                double totalCost = item.Price * quantity;

                receipt.AddItem($"{item.Name} {item.Variant}", quantity, totalCost);
            }

            receipt.CalculateTotal();
            return receipt;
        }


        // Extension 3: Discount Receipt
        public Receipt GenerateReceiptWithDiscounts()
        {
            var receipt = new Receipt();

            // Bagel Discounts
            foreach (var group in _basketList.GroupBy(item => item.Sku))
            {
                var item = group.First();
                int quantity = group.Count();
                double totalCost;
                double savings = 0.0;

                if (item.Sku == "BGLO" && quantity >= 6)
                {
                    totalCost = (quantity / 6) * 2.49 + (quantity % 6) * 0.49;
                    savings = (quantity * 0.49) - totalCost;
                }
                else if (item.Sku == "BGLP" && quantity >= 12)
                {
                    totalCost = (quantity / 12) * 3.99 + (quantity % 12) * 0.39;
                    savings = (quantity * 0.39) - totalCost;
                }
                else if (item.Sku == "BGLE" && quantity >= 6)
                {
                    totalCost = (quantity / 6) * 2.49 + (quantity % 6) * 0.49;
                    savings = (quantity * 0.49) - totalCost;
                }
                else
                {
                    totalCost = item.Price * quantity;
                }

                receipt.AddItem($"{item.Name} {item.Variant}", quantity, totalCost, savings);
            }

            receipt.CalculateTotal();
            return receipt;
        }



    }

}
