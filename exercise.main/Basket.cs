using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private List<string> _items;
        private int _capacity;

        public Basket()
        {
            _items = new List<string>();
            _capacity = 10;
        }

        public string AddProduct(string cheeseBagel)
        {
            string encumbered;
            if (_items.Count == _capacity)
            {
                encumbered = "Nope. Overencumbered.";
            }
            else
            {
                _items.Add(cheeseBagel);
                encumbered = "Product added to basket";
            }

            return encumbered;

        }

        public void ChangeCapacity(int v)
        {
            _capacity = v;
        }

        public List<string> GetItems()
        {
            return _items;
        }

        public string RemoveProduct(string product)
        {
            string nonexistent;
            if (!_items.Contains(product))
            {
                nonexistent = "No such product to remove.";
            }
            else
            {
                _items.Remove(product);
                nonexistent = "Product removed from basket";
            }

            return nonexistent;
        }
    }
}

