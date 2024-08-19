using exercise.main.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        #region Properties
        private List<Item> _itemsInBasket = new List<Item>();
        private int _capacity = 5;
        public List<Item> ItemsInBasket { get => _itemsInBasket; }
        public int Capacity { get => _capacity; set => _capacity = value;  }
        #endregion

        public bool Add(Item item)
        {
            if (_capacity <= 0)
            {
                return false;
            }
            else
            {
                _itemsInBasket.Add(item);
                _capacity--;
                return true;
            }
        }

        public bool Remove(Item item)
        {
            if (_itemsInBasket.Contains(item))
            {
                _itemsInBasket.Remove(item);
                _capacity++;
                return true;
            } else
            {
                return false;
            }
            
        }

        public bool AddFillingToBagel(Bagel bagel, Filling filling)
        {
            foreach (var item in _itemsInBasket)
            {
                if (item.Sku == bagel.Sku)
                {
                    bagel.Fillings.Add(filling);
                    return true;
                }
            }

            return false;
        }
    }
}
