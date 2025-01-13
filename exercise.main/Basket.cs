using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace exercise.main
{
    public class Basket
    {
        private List<Inventory> _basketList = new List<Inventory>();
        private List<Inventory> _inventoryList = new List<Inventory>();
        private List<Bagel> _bagelList = new List<Bagel>();

        private int basketSize = 5; //Instantiating basket size

        //Dependency Injection
        public Basket(List<Inventory> basketList, List<Bagel> bagelList, List<Inventory> inventoryList)
        {
            {
                _basketList = basketList;

                _bagelList = bagelList;

                _inventoryList = inventoryList;
            }
        }

        //User Story 1
        public bool AddBagelVariantToBasket(Bagel bagelVariant)
        {
            if (!_bagelList.Contains(bagelVariant))
            {
                _bagelList.Add(bagelVariant);
                return true;
            }
            else
            {
                return false;
            }
        }

        //User Story 2
        public bool RemoveBagelVariantFromBasket(Bagel bagelVariant)
        {
            if (_bagelList.Contains(bagelVariant))
            {
                _bagelList.Remove(bagelVariant);
                return true;
            }
            else
            {
                return false;
            }
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
            double totalCost = 0.0;
            foreach (Inventory item in _basketList)
            {
                totalCost += item.Price;
            }
            return totalCost;
        }

        //User Story 7
        public double ReturnCostOfBagel(Bagel bagelVariant)
        {
            foreach (Inventory item in _inventoryList)
            {
                if (item.Name == "Bagel" && item.Variant == bagelVariant.Variant)
                {
                    return item.Price;
                }
            }
            return 0.0;
        }

        //User Story 8
        public string ChooseBagelFilling(Filling bagelFilling)
        {
            foreach (Inventory item in _inventoryList)
            {
                if (item.Sku == bagelFilling.Sku)
                {
                    return item.Variant;
                }
            }
            return "Filling type does not exist.";
        }

        //User Story 9
        public double CostOfEachFilling(Filling bagelFilling)
        {
            foreach (Inventory item in _inventoryList)
            {
                if (item.Sku == bagelFilling.Sku)
                {
                    return item.Price;
                }
            }
            return 0.0;
        }

        //User Story 10
        public bool MustBeInInventory(string sku)
        {
            foreach (Inventory item in _inventoryList)
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
    }

}
