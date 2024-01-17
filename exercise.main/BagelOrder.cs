using System;
using System.Collections.Generic;
using System.Linq;

namespace exercise.main
{
    public class BagelOrder
    {
        private List<string> _bagels;
        private List<string> _fillings;
        private BagelInventory _bagelInventory;

        public BagelOrder(BagelInventory bagelInventory)
        {
            _bagels = new List<string>();
            _fillings = new List<string>();
            _bagelInventory = bagelInventory;
        }

        public List<string> Bagels => _bagels;
        public List<string> Fillings => _fillings;

        public void AddBagel(string bagelType)
        {
            _bagels.Add(bagelType);
            Console.WriteLine($"Added '{bagelType}' to the order");
        }

        public void AddFilling(string fillingType)
        {
            _fillings.Add(fillingType);
            Console.WriteLine($"Added '{fillingType}' to the order");
        }

        public void PrintOrderDetails()
        {
            Console.WriteLine("Bagels in the order:");
            foreach (var bagel in _bagels)
            {
                Console.WriteLine($"- {bagel}");
            }

            Console.WriteLine("\nFillings in the order:");
            foreach (var filling in _fillings)
            {
                Console.WriteLine($"- {filling}");
            }
        }

        public double GetTotalCost()
        {
            double bagelCost = _bagels.Sum(bagelType => _bagelInventory.GetCost(bagelType));
            double fillingCost = _fillings.Sum(fillingType => _bagelInventory.GetCost(fillingType));

            double totalCost = bagelCost + fillingCost;
            Console.WriteLine($"Total cost of order: {totalCost}");
            return totalCost;
        }
    }
}
