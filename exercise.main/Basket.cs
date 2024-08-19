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
        private int BasketCapacity { get; set; } = 5;
        private bool IsBasketFull { get { return _Basket.Count >= BasketCapacity ? true : false; } }
        

        public bool AddItem(string variant)
        {
            bool IsInInventory = BobsInventory._Bobsinventory.Any(x => x.Variant == variant);

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
            throw new NotImplementedException();
        }
    }
}
