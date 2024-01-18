using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class User
    {
        private string _userID;
        private List<UserBasketEntry> _basket;

        public User(string userID)
        {
            _userID = userID;
            _basket = new List<UserBasketEntry>();
        }

        public void AddToBasket(BaseItem item, int count = 1)
        {
            if (HasSpaceForItem(item, count)) Basket.Add(new UserBasketEntry(item, count));
            else throw new InvalidOperationException("There is not enough space in your basket.");
        }

        public void RemoveFromBasket(int basketIndex)
        {
            if (IsValidBasketIndex(basketIndex)) Basket.RemoveAt(basketIndex);
            else throw new InvalidOperationException("There is no menu item at the specified location.");
        }

        public void IncludeAddOn(int basketIndex, AddOn addOn)
        {
            if (HasSpaceForItem(addOn))
            {
                if (IsValidBasketIndex(basketIndex)) Basket[basketIndex].IncludeAddOn(addOn);
                else throw new InvalidOperationException("There is no menu item at the specified location.");
            }
            else throw new InvalidOperationException("There is not enough space in your basket.");
        }

        public void ExcludeAddOn(int basketIndex, AddOn addOn)
        {
            if (IsValidBasketIndex(basketIndex)) Basket[basketIndex].ExcludeAddOn(addOn);
            else throw new InvalidOperationException("There is no menu item at the specified location.");
        }

        public decimal Cost()
        {
            return Basket.Sum(basketEntry => basketEntry.Cost());
        }

        public bool HasSpaceForItem(IMenuItem item, int count = 1)
        {
            return StoreVariables.GetMaximumBasketCapacity() >= BasketSpaceOccupation() + item.BasketFootprint * count;
        }

        public decimal BasketSpaceOccupation()
        {
            return Basket.Sum(basketEntry => basketEntry.Footprint());
        }

        private bool IsValidBasketIndex(int basketIndex)
        {
            return basketIndex >= 0 && basketIndex < _basket.Count;
        }

        public string UserID { get => _userID;}
        public List<UserBasketEntry> Basket { get => _basket;}
    }
}
