using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private List<InventoryItem> _Basket = new List<InventoryItem>();

        private BobsInventory BobsInventory = new BobsInventory();
        private int BasketCapacity { get; set; } = 3;
        
        

        public bool AddItem(string variant)
        {
            bool IsInInventory = BobsInventory._Bobsinventory.Any(item => item.Variant == variant);

            if (!IsInInventory) 
            {
                return false;
            }

            if (!IsBasketFull && IsInInventory)
            {
                _Basket.Add(BobsInventory._Bobsinventory.First(item => item.Variant == variant));

                return true;
            }
            return false;

            
        }

        public bool RemoveItem(string variant)
        {
            bool IsInBasket = _Basket.Any(item => item.Variant == variant);

            if (IsInBasket) 
            {
                _Basket.Remove(_Basket.First(item => item.Variant == variant));
                return true;
            }
            return false;
        }

        public bool ChangeCapacity(int capacity, bool isManager)
        {
            if (isManager) 
            { 
                BasketCapacity = capacity;
                return true;
            }
            return false;
        }

        public bool IsBasketFull { get { return _Basket.Count >= BasketCapacity ? true : false; } }


    }
}
