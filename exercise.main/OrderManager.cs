using System;

namespace exercise.main
{
    public class OrderManager
    {
        public void ChangeBasketCapacity(Basket basket, int newCapacity)
        {
            basket.Capacity = newCapacity;
            Console.WriteLine($"Basket capacity has been updated to: {newCapacity}");
        }

        public double GetTotalCost(Basket basket, BagelInventory bagelInventory)
        {
            double totalCost = basket.Bagels.Sum(bagelType => bagelInventory.GetCost(bagelType));
            Console.WriteLine($"Total cost of basket: {totalCost}");
            return totalCost;
        }

        public bool IsItemInInventory(string item, BagelInventory bagelInventory)
        {
            bool isItemInInventory = bagelInventory.GetCost(item) > 0;
            Console.WriteLine($"{item} in inventory: {isItemInInventory}");
            return isItemInInventory;
        }

        public double GetBagelCost(string bagelType, BagelInventory bagelInventory)
        {
            double bagelCost = bagelInventory.GetCost(bagelType);
            Console.WriteLine($"Cost of {bagelType} : {bagelCost}");
            return bagelCost;
        }
    }
}
