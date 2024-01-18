using exercise.main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
   
    public class Basket
    {
        private List<Item> _items;
        private int _basketSize;

        public Basket() {
            _items = new List<Item>();
            _basketSize = 40;
        }

        public Basket(int basketSize)
        {
            _basketSize = basketSize;
            _items = new List<Item>();
        }

        public string PutInBasket(Item item)
        {
            if (!DefaultInventory.Inventory.Contains(item))
            {
                return $"{item.Variant} is not in inventory";
            }
            else if (items.Count >= _basketSize)
            {
                return "Basket is full";
            } 
            else
            {
                _items.Add(item);
                return $"{item.Variant} is added to basket";
            }
        }

        public string RemoveFromBasket(Item item)
        {
            if (_items.Contains(item))
            {
                _items.Remove(item);
                return $"{item.Variant} is removed from basket";
            } else
            {
                return "There is no such item in basket";
            }

        }

        public void ChangeBasketCapacity(int NewBasketSize)
        {
            _basketSize = NewBasketSize;
        }

        public double SumTotal()
        {
            return _items.Sum(item => item.Price);
        }

        public List<Item> AddDiscountIfThereIs()
        {

            int plainCount = _items.Where(i => i.Sku == "BGLP").Count();
            int onionCount = _items.Where(i => i.Sku == "BGLO").Count();
            int everythingCount = _items.Where(i => i.Sku == "BGLE").Count();

            if (plainCount >= 12)
            {
                int removalCount = (plainCount / 12) * 12;
                int numberOfOffer = plainCount / 12;
                for (int i = 0; i < removalCount; i++) {
                    _items.Remove(_items.FirstOrDefault(item => item.Sku == "BGLP"));
                }
                for (int i = 0; i < numberOfOffer; i++)
                {
                    _items.Add(DefaultInventory.FindItemInSpecialOffersBySKU("SOBP"));
                }
            }
            if (onionCount >= 6) 
            {
                int removalCount = (onionCount / 6) * 6;
                int numberOfOffer = onionCount / 6;
                for (int i = 0; i < removalCount; i++)
                {
                    _items.Remove(_items.FirstOrDefault(item => item.Sku == "BGLO"));
                }
                for (int i = 0; i < numberOfOffer; i++)
                {
                    _items.Add(DefaultInventory.FindItemInSpecialOffersBySKU("SOBO"));
                }
            }
            if (everythingCount >= 6)
            {
                int removalCount = (everythingCount / 6) * 6;
                int numberOfOffer = everythingCount / 6;
                for (int i = 0; i < removalCount; i++)
                {
                    _items.Remove(_items.FirstOrDefault(item => item.Sku == "BGLE"));
                }
                for (int i = 0; i < numberOfOffer; i++)
                {
                    _items.Add(DefaultInventory.FindItemInSpecialOffersBySKU("SOBE"));
                }
            }

            List<Item> bagelItems = _items.Where(item => item.Name == Name.Bagel).ToList();
            if (bagelItems.Count > 0)
            {
                Item bagelItem = bagelItems.OrderByDescending(item => item.Price).First();
                Item coffeeItem = _items.FirstOrDefault(item => item.Variant == "Black");

                if (bagelItem != null && coffeeItem != null)
                {
                    _items.Remove(bagelItem);
                    _items.Remove(coffeeItem);
                    _items.Add(DefaultInventory.FindItemInSpecialOffersBySKU("SOCB"));
                }

            }

            return _items;
        }



        public void printReciept()
        {
            DateTime now = DateTime.Now;
            Console.WriteLine($"Bobs bagel {now}");
            foreach (Item item in _items)
            {
                Console.WriteLine($"{item.Variant} {item.Price}");
            }
            Console.WriteLine($"\nTotal {SumTotal()}");
        }

        public List<Item> items { get => _items; }
    }
}
