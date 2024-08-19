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

        public bool AddItemToBasket(Item item)
        {
            _itemsInBasket.Add(item);
            _capacity -= 1;
            return true;
        }
    }
}
