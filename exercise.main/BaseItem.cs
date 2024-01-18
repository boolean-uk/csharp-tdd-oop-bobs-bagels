using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class BaseItem : IMenuItem
    {
        private string _itemID;
        private string _name;
        private decimal _price;
        private decimal _basketFootprint;
        private List<String> _defaultAddOns;
        private List<String> _availableAddOns;

        public BaseItem(string id, string name, decimal price, decimal basketFootprint)
        {
            throw new NotImplementedException();
        }

        public void AllowAddOns(params string[] itemIDs) { throw new NotImplementedException(); }
        public void DisallowAddOns(params string[] itemIDs) { throw new NotImplementedException(); }
        public string ItemID { get => _itemID; }
        public string Name { get => _name; }
        public decimal Price { get => _price; }
        public decimal BasketFootprint { get => _basketFootprint; }
        public List<string> DefaultAddOns { get => _defaultAddOns; }
        public List<string> AvailableAddOns { get => _availableAddOns; }
    }
}
