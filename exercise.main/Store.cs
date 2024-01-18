using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Store
    {
        private List<User> _users;
        private List<BaseItem> _baseItems;
        private List<AddOn> _addOns;

        private string _activeUser;
        private decimal _maximumBasketCapacity;
        private List<string> _managers;

        public Store()
        {
            _users = new List<User>();
            _baseItems = new List<BaseItem>();
            _addOns = new List<AddOn>();
            _managers = new List<string>();
            _maximumBasketCapacity = 5m;
            _activeUser = "";
        }

        public void Login(string userID)
        {
            if (IsAUser(userID)) _activeUser = userID;
            else throw new InvalidOperationException("Username does not exist.");
        }

        public void AddUser(string userID)
        {
            if (Users.Count == 0)
            {
                Managers.Add(userID);
                _activeUser = userID;
            }
            if (!HasAdminPriveleges()) throw new UnauthorizedAccessException("You are unauthorized to perform this operation.");
            User user = new User(userID);
            Users.Add(user);
        }

        public void AddBaseItem(string id, string name, decimal price, decimal basketFootprint = 1m)
        {
            if (!HasAdminPriveleges()) throw new UnauthorizedAccessException("You are unauthorized to perform this operation.");
            BaseItems.Add(new BaseItem(id, name, price, basketFootprint));
        }

        public void AddAddOn(string id, string name, decimal price, decimal basketFootprint = 0m)
        {
            if (!HasAdminPriveleges()) throw new UnauthorizedAccessException("You are unauthorized to perform this operation.");
            AddOns.Add(new AddOn(id, name, price, basketFootprint));
        }
        public List<User> Users { get => _users; }
        public List<BaseItem> BaseItems { get => _baseItems; }
        public List<AddOn> AddOns { get => _addOns; }
        public string ActiveUser { get => _activeUser; }
        public decimal MaximumBasketCapacity { get => _maximumBasketCapacity; }
        public List<string> Managers { get => _managers; }

        private bool IsAUser(string userID)
        {
            foreach (var user in Users)
            {
                if (user.UserID == userID) return true;
            }
            return false;
        }
        
        private bool HasAdminPriveleges()
        {
            return Managers.Contains(ActiveUser);
        }
    }
}
