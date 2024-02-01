﻿using System;
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
            if (_inventory.InStock(sku) && _items.Count < _capacity)
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

        public double GetTotalCost()
        {
            double totalCost = 0;
            foreach (Item item in _items)
            {
                totalCost += item.Price;
            }
            return totalCost;
        }
    }
}
