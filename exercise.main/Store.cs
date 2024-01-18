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
        private int _maximumBasketCapacity;
        private List<String> _managers;

        public Store()
        {
            throw new NotImplementedException();
        }

        public void Login(string userID)
        {
            throw new NotImplementedException();
        }

        public void AddUser(string userID)
        {
            throw new NotImplementedException();
        }

        public void AddBaseItem(string id, string name, decimal price, decimal basketFootprint = 1m)
        {
            throw new NotImplementedException();
        }

        public void AddAddOn(string id, string name, decimal price, decimal basketFootprint = 0m)
        {
            throw new NotImplementedException();
        }
        public List<User> Users { get => _users; }
        public List<BaseItem> BaseItems { get => _baseItems; }
        public List<AddOn> AddOns { get => _addOns; }
        public string ActiveUser { get => _activeUser; }
        public int MaximumBasketCapacity { get => _maximumBasketCapacity; }
        public List<string> Managers { get => _managers; }
    }
}
