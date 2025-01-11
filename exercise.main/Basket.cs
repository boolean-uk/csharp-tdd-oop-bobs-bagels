using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace exercise.main
{
    public class Basket
    {
        private List<Inventory> basketList;
        private List<Inventory> inventoryList;
        private List<Bagel> bagelList;

        private int basketSize = 5;

        public Basket()
        {
            basketList = new List<Inventory>();
            bagelList = new List<Bagel>();
            inventoryList = new List<Inventory>
        {
            new Inventory("BGLO", 0.49, "Bagel", "Onion"),
            new Inventory("BGLP", 0.39, "Bagel", "Plain"),
            new Inventory("BGLE", 0.49, "Bagel", "Everything"),
            new Inventory("BGLS", 0.49, "Bagel", "Sesame"),
            new Inventory("COFB", 0.99, "Coffee", "Black"),
            new Inventory("COFW", 1.19, "Coffee", "White"),
            new Inventory("COFC", 1.29, "Coffee", "Cappuccino"),
            new Inventory("COFL", 1.29, "Coffee", "Latte"),
            new Inventory("FILB", 0.12, "Filling", "Bacon"),
            new Inventory("FILE", 0.12, "Filling", "Egg"),
            new Inventory("FILC", 0.12, "Filling", "Cheese"),
            new Inventory("FILX", 0.12, "Filling", "Cream Cheese"),
            new Inventory("FILS", 0.12, "Filling", "Smoked Salmon"),
            new Inventory("FILH", 0.12, "Filling", "Ham")
        };
        }

        public bool AddBagelVariantToBasket(Bagel bagelVariant)
        {
            if (!bagelList.Contains(bagelVariant))
            {
                bagelList.Add(bagelVariant);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveBagelVariantFromBasket(Bagel bagelVariant)
        {
            if (bagelList.Contains(bagelVariant))
            {
                bagelList.Remove(bagelVariant);
                return true;
            }
            else
            {
                return false;
            }
        }

        public string BagelBasketIsFull()
        {
            if (basketList.Count >= basketSize)
            {
                return "Basket is full!";
            }
            else
            {
                return "Basket is not full!";
            }
        }

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

        public string CanRemoveItemInBasket(Inventory item)
        {
            if (basketList.Contains(item))
            {
                return "Item is in basket and can be removed.";
            }
            else
            {
                return "Item is not in basket and cannot be removed.";
            }
        }

        public double TotalCostOfItems()
        {
            double totalCost = 0.0;
            foreach (Inventory item in basketList)
            {
                totalCost += item.Price;
            }
            return totalCost;
        }

        public double ReturnCostOfBagel(Bagel bagelVariant)
        {
            foreach (Inventory item in inventoryList)
            {
                if (item.Name == "Bagel" && item.Variant == bagelVariant.Variant)
                {
                    return item.Price;
                }
            }
            return 0.0;
        }

        public string ChooseBagelFilling(Filling bagelFilling)
        {
            foreach (Inventory item in inventoryList)
            {
                if (item.Sku == bagelFilling.Sku)
                {
                    return item.Variant;
                }
            }
            return "Filling type does not exist.";
        }

        public double CostOfEachFilling(Filling bagelFilling)
        {
            foreach (Inventory item in inventoryList)
            {
                if (item.Sku == bagelFilling.Sku)
                {
                    return item.Price;
                }
            }
            return 0.0;
        }

        public bool MustBeInInventory(string sku)
        {
            foreach (Inventory item in inventoryList)
            {
                if (item.Sku == sku)
                {
                    return true;
                }
            }
            return false;
        }

        public List<Inventory> GetBasketList()
        {
            return basketList;
        }

        public void SetBasketList(List<Inventory> basketList)
        {
            this.basketList = basketList;
        }

        public List<Inventory> GetInventoryList()
        {
            return inventoryList;
        }

        public void SetInventoryList(List<Inventory> inventoryList)
        {
            this.inventoryList = inventoryList;
        }

        public int GetBasketSize()
        {
            return basketSize;
        }

        public void SetBasketSize(int basketSize)
        {
            this.basketSize = basketSize;
        }
    }

    // Supporting Classes
    public class Inventory
    {
        public string Sku { get; }
        public double Price { get; }
        public string Name { get; }
        public string Variant { get; }

        public Inventory()
        {

        }

        public Inventory(string sku, double price, string name, string variant)
        {
            Sku = sku;
            Price = price;
            Name = name;
            Variant = variant;
        }
    }

    public class Bagel
    {
        public string Variant { get; }

        public Bagel()
        {

        }

        public Bagel(string variant)
        {
            Variant = variant;
        }
    }

    public class Filling
    {
        public string Sku { get; }

        public Filling()
        {

        }

        public Filling(string sku)
        {
            Sku = sku;
        }
    }

}
