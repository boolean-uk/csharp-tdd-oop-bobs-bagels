using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{

    public static class StoreVariables
    {
        private static decimal MaximumBasketCapacity { get; set;  } = 5m;
        
        public static decimal GetMaximumBasketCapacity() { return MaximumBasketCapacity; }
        public static void SetMaximumBasketCapacity(decimal maximumBasketCapacity, bool isAdmin)
        {
            if (isAdmin) MaximumBasketCapacity = maximumBasketCapacity;
            else throw new UnauthorizedAccessException("You are unauthorized to perform this operation.");
        }
    }
    public class Store
    {
        private List<User> _users;
        private List<BaseItem> _baseItems;
        private List<AddOn> _addOns;

        private string _activeUserID;
        private List<string> _managers;

        public Store()
        {
            _users = new List<User>();
            _baseItems = new List<BaseItem>();
            _addOns = new List<AddOn>();
            _managers = new List<string>();
            _activeUserID = "";
        }

        public void Login(string userID)
        {
            if (IsAUser(userID)) _activeUserID = userID;
            else throw new InvalidOperationException("Username does not exist.");
        }

        public void CreateNewUser(string userID)
        {
            if (Users.Count == 0)
            {
                Managers.Add(userID);
                _activeUserID = userID;
            }
            if (!HasAdminPriveleges()) throw new UnauthorizedAccessException("You are unauthorized to perform this operation.");
            User user = new User(userID);
            Users.Add(user);
        }

        public void CreateNewBaseItem(string id, string name, decimal price, decimal basketFootprint = 1m)
        {
            if (!HasAdminPriveleges()) throw new UnauthorizedAccessException("You are unauthorized to perform this operation.");
            if (IsAnItemID(id)) throw new InvalidOperationException($"Item with ID={id} already exists!");
            BaseItems.Add(new BaseItem(id, name, price, basketFootprint));
        }

        public void CreateNewAddOn(string id, string name, decimal price, decimal basketFootprint = 0m)
        {
            if (!HasAdminPriveleges()) throw new UnauthorizedAccessException("You are unauthorized to perform this operation.");
            if (IsAnItemID(id)) throw new InvalidOperationException($"Item with ID={id} already exists!");
            AddOns.Add(new AddOn(id, name, price, basketFootprint));
        }

        public User GetActiveUser()
        {
            return Users[Users.FindIndex(user => user.UserID == ActiveUserID)];
        }

        public void AddToBasket(string itemID, int count = 1)
        {
            BaseItem? item = GetBaseItemByID(itemID);
            if (item != null)
            {
                GetActiveUser().AddToBasket(item, count);
            }
        }

        public void RemoveFromBasket(int basketIndex = -1)
        {
            if (basketIndex < 0) basketIndex = GetActiveUser().Basket.Count - 1;
            GetActiveUser().RemoveFromBasket(basketIndex);
        }

        public void IncludeAddOn(string itemID, int basketIndex = -1)
        {
            AddOn? addOn = GetAddOnByID(itemID);
            if (addOn != null)
            {
                if (basketIndex < 0) basketIndex = GetActiveUser().Basket.Count - 1;
                GetActiveUser().IncludeAddOn(basketIndex, addOn);
            }
        }

        public void ExcludeAddOn(string itemID, int basketIndex = -1)
        {
            AddOn? addOn = GetAddOnByID(itemID);
            if (addOn != null)
            {
                if (basketIndex < 0) basketIndex = GetActiveUser().Basket.Count - 1;
                GetActiveUser().ExcludeAddOn(basketIndex, addOn);
            }
        }

        public decimal BasketTotalCost()
        {
            throw new NotImplementedException();
        }

        public void SetMaximumBasketCapacity(decimal maximumBasketCapacity)
        {
            bool isAdmin = HasAdminPriveleges();
            StoreVariables.SetMaximumBasketCapacity(maximumBasketCapacity, isAdmin);
        }

        public BaseItem GetBaseItemByID(string itemID)
        {
            if (IsAnItemID(itemID)) return BaseItems[BaseItems.FindIndex(item => item.ItemID == itemID)];
            else throw new KeyNotFoundException($"No MenuItem with ID={itemID}.)");
        }

        public AddOn GetAddOnByID(string itemID)
        {
            if (IsAnItemID(itemID)) return AddOns[AddOns.FindIndex(item => item.ItemID == itemID)];
            else throw new KeyNotFoundException($"No MenuItem with ID={itemID}.)");
        }


        public List<User> Users { get => _users; }
        public List<BaseItem> BaseItems { get => _baseItems; }
        public List<AddOn> AddOns { get => _addOns; }
        public string ActiveUserID { get => _activeUserID; }
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
            return Managers.Contains(ActiveUserID);
        }

        private bool IsAnItemID(string itemID)
        {
            bool isABaseItemID = BaseItems.Any(item => item.ItemID == itemID);
            bool isAnAddOnID = AddOns.Any(item => item.ItemID == itemID);
            return isABaseItemID || isAnAddOnID;
        }

    }
}
