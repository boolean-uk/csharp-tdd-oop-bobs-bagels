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
            _itemID = id;
            _name = name;
            _price = price;
            _basketFootprint = basketFootprint;
            _defaultAddOns = new List<String>();
            _availableAddOns = new List<String>();
        }

        public void AllowAddOns(params string[] itemIDs)
        {
            foreach (string itemID in itemIDs)
            {
                if (!AvailableAddOns.Contains(itemID)) AvailableAddOns.Add(itemID);
            }
        }
        public void DisallowAddOns(params string[] itemIDs)
        {
            RemoveDefaultAddons(itemIDs);
            for (int i = 0; i < AvailableAddOns.Count; i++)
            {
                if (itemIDs.Contains(AvailableAddOns[i])) AvailableAddOns.RemoveAt(i);
            }
        }

        public void SetDefaultAddons(params string[] itemIDs)
        {
            AllowAddOns(itemIDs);
            foreach (string itemID in itemIDs)
            {
                if (!DefaultAddOns.Contains(itemID)) DefaultAddOns.Add(itemID);
            }
        }

        public void RemoveDefaultAddons(params string[] itemIDs)
        {
            for (int i = 0; i < DefaultAddOns.Count; i++)
            {
                if (itemIDs.Contains(DefaultAddOns[i])) DefaultAddOns.RemoveAt(i);
            }
        }

        public bool IsAllowingAddOn(string itemID)
        {
            return AvailableAddOns.Contains(itemID);
        }

        public string ItemID { get => _itemID; }
        public string Name { get => _name; }
        public decimal Price { get => _price; }
        public decimal BasketFootprint { get => _basketFootprint; }
        public List<string> DefaultAddOns { get => _defaultAddOns; }
        public List<string> AvailableAddOns { get => _availableAddOns; }
    }
}
