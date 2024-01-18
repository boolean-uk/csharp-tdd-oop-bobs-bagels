using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class User
    {
        private string _userID;
        private List<BasketEntry> _basket;

        public User(string userID)
        {
            _userID = userID;
            _basket = new List<BasketEntry>();
        }

        public void AddToBasket(BaseItem item, int count = 1)
        {
            Basket.Add(new BasketEntry(item, count));
        }

        public void RemoveFromBasket(int basketIndex)
        {
            if (IsValidBasketIndex(basketIndex)) Basket.RemoveAt(basketIndex);
            else throw new InvalidOperationException("There is no menu item at the specified location.");
        }

        public void IncludeAddOn(int basketIndex, AddOn addOn)
        {
            if (IsValidBasketIndex(basketIndex)) Basket[basketIndex].IncludeAddOn(addOn);
            else throw new InvalidOperationException("There is no menu item at the specified location.");
        }

        public void ExcludeAddOn(int basketIndex, AddOn addOn)
        {
            if (IsValidBasketIndex(basketIndex)) Basket[basketIndex].ExcludeAddOn(addOn);
            else throw new InvalidOperationException("There is no menu item at the specified location.");
        }

        public decimal BasketTotalCost()
        {
            throw new NotImplementedException();
        }

        public decimal BasketOccupation()
        {
            throw new NotImplementedException();
        }

        private bool IsValidBasketIndex(int basketIndex)
        {
            return basketIndex >= 0 && basketIndex < _basket.Count;
        }

        public string UserID { get => _userID;}
        public List<BasketEntry> Basket { get => _basket;}
    }
}
