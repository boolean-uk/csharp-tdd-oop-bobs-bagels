using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket1
    {
        private IInventory _inventory;
        private int _capacity;
        private List<IProduct> _products = new List<IProduct>();

        public Basket1(IInventory inventory, int capacity) {
            _inventory = inventory;
            _capacity = capacity;
        }
    }
}