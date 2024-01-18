using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class UserBasketEntry
    {
        private BaseItem _baseItem;
        private int _count;
        private List<AddOn> _addOns;


        public UserBasketEntry(BaseItem baseItem, int count)
        {
            _baseItem = baseItem;
            _count = count;
            _addOns = new List<AddOn>();
        }

        public void IncludeAddOn(AddOn addOn)
        {
            if(!AddOns.Contains(addOn)) AddOns.Add(addOn);
        }

        public void ExcludeAddOn(AddOn addOn)
        {
            if (AddOns.Contains(addOn)) AddOns.Remove(addOn);
        }

        public decimal Footprint()
        {
            return Count * (BaseItem.BasketFootprint + AddOns.Sum(addOn => addOn.BasketFootprint));
        }

        public decimal Cost()
        {
            return Count * (BaseItem.Price + AddOns.Sum(addOn => addOn.Price));
        }

        public BaseItem BaseItem { get => _baseItem; }
        public int Count { get => _count; }
        public List<AddOn> AddOns { get => _addOns; }
    }
}
