using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private List<Item> _items;
        private int _capacity;
        private Inventory _inventory;

        public int Capacity => _capacity; 

        public Basket()
        {
            _items = new List<Item>();
            _capacity = 6;
            _inventory = new Inventory();
        }

        public bool Add(string sku)
        {
            if (_capacity == _items.Count)
            {
                Console.WriteLine("Your basket is full, could not add all the items!");
                return false;
            } else if  (_inventory.InStock(sku) && _capacity > _items.Count)
            {
                _items.Add(_inventory.Stock[sku]);
                return true;
            }
            return false;
        }

        public bool Remove(string sku)
        {
                if (_inventory.InStock(sku))
                {
                    _items.Remove(_inventory.Stock[sku]);
                    return true;
                }
   
            return false;
        }

        public void ChangeCapacity(int capacity)
        {
            _capacity = capacity;
        }

        public Dictionary<ItemDto, int> GetItemAmounts()
        {
            Dictionary<ItemDto, int> itemAmounts = new Dictionary<ItemDto, int>();

            if (_items.Any())
            {
                foreach (Item item in _items)
                {
                    ItemDto itemDto = item.ToDto();

                    // Check if SKU already exists in the dictionary
                    if (itemAmounts.ContainsKey(itemDto))
                    {
                        // Increment the quantity for the existing SKU
                        itemAmounts[itemDto]++;
                    }
                    else
                    {
           
                        itemAmounts.Add(itemDto, 1);
                    }
                }

                return itemAmounts;
            }

            throw new InvalidOperationException($"Your basket is empty");
        }

        public double GetTotalCost()
        {
            double totalCost = 0;
            Dictionary<ItemDto, int> itemAmounts = GetItemAmounts();

            foreach (KeyValuePair<ItemDto, int> item in itemAmounts)
            {
                int quantity = item.Value;
                if (item.Key.Sku.StartsWith("BGL", StringComparison.OrdinalIgnoreCase))
                {
                    if (quantity >= 12) {
                        int discountQuantity12 = quantity / 12;
                        totalCost += 3.99 * discountQuantity12;  // Discount for multiples of 12

                        quantity %= 12;
                    }
                    if (quantity >= 6) {
                        int discountQuantity6 = quantity / 6;
                        totalCost += 2.49 * discountQuantity6;  // Discount for multiples of 6
                        quantity %= 6;
                    }
                }

                totalCost += item.Key.Price * quantity; // Remaining quantity at regular price 
            }

            return Math.Round(totalCost, 2);
        }





    }

}
