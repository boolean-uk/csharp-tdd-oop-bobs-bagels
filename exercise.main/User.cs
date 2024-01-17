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
            throw new NotImplementedException();
        }

        public void AddItem()
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(int index)
        {
            throw new NotImplementedException();
        }

        public void AddAddOn()
        {
            throw new NotImplementedException();
        }

        public void RemoveAddOn()
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

        public string UserID { get => _userID;}
        public List<BasketEntry> Basket { get => _basket;}
    }
}
