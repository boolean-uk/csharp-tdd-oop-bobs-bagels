using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using exercise.main.Products;

namespace exercise.main
{
    public class Basket
    {
        private int _capacity = 30;
        private List<InventoryProduct> _listOfProducts;
        Inventory inventory;
        public Discount discount;
        public Basket()
        {
            discount = new Discount();
            _listOfProducts = new List<InventoryProduct>();
            inventory = new Inventory();

        }

        public bool AddProduct(InventoryProduct product)
        {
            if (_listOfProducts.Count < _capacity)
            {
                if (inventory.checkInventory(product))
                {
                    product.ID = inventory.ID;
                    inventory.ID = product.ID + 1;
                    _listOfProducts.Add(product);
                    return true;
                }
                return false;
            }

            return false;

        }
        public bool RemoveProduct(InventoryProduct product)
        {
            if (_listOfProducts.Contains(product)) { _listOfProducts.Remove(product); return true; }
            else { return false; }

        }
        public double GetTotal()
        {
            double sum = 0;
            foreach (InventoryProduct product in _listOfProducts)
            {
                sum += product.Price;
            }
            return Math.Round(sum, 2);
        }

        public int changeCapacity(Person person, int newCapacity)
        {

            if (person.AdminLevel == "admin")
            {
                _capacity = newCapacity;
            }
            return _capacity;

        }


        public void PrintReciept()
        {
            List<InventoryProduct> sortedBagels = new List<InventoryProduct>();
            List<InventoryProduct> sortedCoffees = new List<InventoryProduct>();
            Dictionary<string, double> receipt = new Dictionary<string, double>();
            Dictionary<string, double> discounts = new Dictionary<string, double>();

            foreach (InventoryProduct item in _listOfProducts)
            {
                if (item.Name == "Bagel")
                {
                    sortedBagels.Add(item);

                }
                else if (item.Name == "Coffee")
                {
                    sortedCoffees.Add(item);
                }

            }

            sortedBagels.OrderBy(x => x.Sku);
            sortedCoffees.OrderBy(x => x.Sku);

            List<InventoryProduct> CopyOfsortedBagels = sortedBagels;
            List<InventoryProduct> CopyOfsortedCoffees = sortedCoffees;


            Dictionary<string, double> addedDiscounts = discount.checkDiscounts(CopyOfsortedBagels, CopyOfsortedCoffees);

            List<InventoryProduct> tempbagels = new List<InventoryProduct>();
            List<InventoryProduct> tempcoffee = new List<InventoryProduct>();
            List<InventoryProduct> tempFilling = new List<InventoryProduct>();

            for (int i = 0; i < sortedBagels.Count; i++)
            {

                tempbagels = sortedBagels.Where(bagel => bagel.Sku.Equals(sortedBagels[i].Sku)).ToList();

                receipt.Add($"{tempbagels.Count}x\tBagel {sortedBagels[i].Variant}", Math.Round(sortedBagels[i].Price * tempbagels.Count, 2));
                foreach (Bagel bagel in tempbagels)
                {
                    if (bagel.Fillings.Count > 0)
                    {
                        foreach (Filling filling in bagel.ListOfFillings)
                        {
                            receipt.Add($"1x\tFilling {filling.Variant}", 0.12d);
                        }
                    }
                }
                i = i + tempbagels.Count;
            }
            for (int i = 0; i < sortedCoffees.Count; i++)
            {
                tempcoffee = sortedCoffees.Where(coffee => coffee.Sku.Equals(sortedCoffees[i].Sku)).ToList();
                receipt.Add($"{tempcoffee.Count}x\tCoffee {sortedCoffees[i].Variant}", Math.Round(sortedCoffees[i].Price * tempcoffee.Count, 2));
                i = i + tempcoffee.Count;
            }
            foreach (string discount in addedDiscounts.Keys)
            {
                receipt.Add(discount, addedDiscounts[discount]);
            }
            double sum = 0;
            foreach (string key in receipt.Keys)
            {
                Console.WriteLine("{0,-30}  {1,-6}", key, receipt[key]);
                sum += receipt[key];
            }
            Console.WriteLine("{0,-30}  {1,-6}", "\nTotal", Math.Round(sum, 2));

        }

        public List<InventoryProduct> ListOfProducts { get { return _listOfProducts; } }
        public Inventory Inventory { get { return inventory; } }
        public int Capacity { get { return _capacity; } }
    }
}
