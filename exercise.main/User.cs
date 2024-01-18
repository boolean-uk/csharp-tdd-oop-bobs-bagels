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
            throw new NotImplementedException();
        }

        public void RemoveItem(int basketIndex)
        {
            throw new NotImplementedException();
        }

        public void IncludeAddOn(int basketIndex, AddOn addOn)
        {
            throw new NotImplementedException();
        }

        public void ExcludeAddOn(int basketIndex, AddOn addOn)
        {
            throw new NotImplementedException();
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
