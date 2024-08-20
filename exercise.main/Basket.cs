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

        private string _variant;

        private StringBuilder _receipt = new StringBuilder();


        private StringBuilder AddToReceipt() 
        {
            _receipt.AppendLine("~~~ Bob's Bagels ~~~");
            _receipt.AppendLine();
            _receipt.AppendLine(DateTime.Now.ToString());
            _receipt.AppendLine();
            _receipt.AppendLine("---------------------");
            _receipt.AppendLine();



            foreach (var item in _Basket) 
            {
                _receipt.AppendLine($"{item.Variant} {item.Name}");
            }
            
            return _receipt;
            
        }
        

        public bool AddItem(string variant)
        {
            _variant = variant;

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
            _variant = variant;

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

        public bool IsInBasket { get { return _Basket.Any(item => item.Variant == _variant); } }

        public bool IsInInventory { get { return BobsInventory._Bobsinventory.Any(item => item.Variant == _variant); } }

        public double TotalCost { get { return _Basket.Sum(item => item.Price); } }

        public string PrintReceipt { get { return AddToReceipt().ToString(); } }
    }
}
