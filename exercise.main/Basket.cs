using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        // fields
        private readonly StringBuilder _receipt = new StringBuilder();
        private readonly double _12BagelDiscount = 3.99;
        private readonly double _coffeeAndBagel = 1.25;
        private readonly double _6BagelDiscount = 2.49;
        private List<Item> _basketItems = new List<Item>();


        // properties
        public BobsInventory Inventory { get; set; } = new BobsInventory();
        public List<Item> BasketItems { get {  return _basketItems; } } 
        public int MaxCapacity { get; set; } = 5;
        public bool IsManager { get; set; } = false;
        public string PrintReceipt { get { return GetReceipt(); } }


        // methods
        public bool AddItem(Item item)
        {
            foreach (var i in Inventory.Inventory)
            {
                if (i.SKU == item.SKU && BasketItems.Count < MaxCapacity)
                {
                    BasketItems.Add(item);
                    return true;
                }

            }
            return false;
        }

        public void RemoveItem(Item item)
        {
            if (BasketItems.Count > 0 && BasketItems.Contains(item))
            {
                BasketItems.Remove(item);
            }
            return;
        }


        public bool RemoveNonExistingItem(Item item)
        {
            if (!BasketItems.Contains(item))
            {
                Console.WriteLine("This item doesnt exist in your basket");
                return true;
            }
            else
            {
                BasketItems.Remove(item);
                return false;
            }
        }


        public bool ChangeCapacity(int newCapacity, bool IsManager)
        {
            if (IsManager && newCapacity != MaxCapacity)
            {
                MaxCapacity = newCapacity;
                return true;
            }
            return false;
        }


        public string GetReceipt()
        {
            _receipt.AppendLine("~~~ Bob's Bagels ~~~");
            _receipt.AppendLine();
            _receipt.AppendLine(DateTime.Now.ToString());
            _receipt.AppendLine();
            _receipt.AppendLine("----------------------------");
            _receipt.AppendLine();

            foreach (var i in BasketItems)
            {
                _receipt.AppendLine($"{i.Type} {i.Name} - {i.Cost}");
            }

            _receipt.AppendLine();
            _receipt.AppendLine("----------------------------");
            _receipt.AppendLine($"Total £{GetDiscount()}");
            _receipt.AppendLine();
            _receipt.AppendLine("Thank you for your order!");

            return _receipt.ToString();
        }

        public double GetTotalCost() { return BasketItems.Sum(x => x.Cost); }


        public double GetDiscount()
        {
            int bagelCount = BasketItems.Where(item => item.SKU.StartsWith("BGL")).Count();
            int coffeeCount = BasketItems.Where(item => item.SKU.StartsWith("COF")).Count();

            if (bagelCount == 6) { return _6BagelDiscount; }
            else if (bagelCount == 12) { return _12BagelDiscount; }
            else if (bagelCount == coffeeCount) { return _coffeeAndBagel; }
            else { return GetTotalCost(); }
        }
    }
}


