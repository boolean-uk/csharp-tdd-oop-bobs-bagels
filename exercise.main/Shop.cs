using exercise.main.Items;
using exercise.main.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Shop
    {
        #region Properties
        private ShopInventory _shopInventory;
        private List<Manager> _managers = new List<Manager>();
        private List<Customer> _customers = new List<Customer>();
        private List<Person> _persons = new List<Person>();
        private string _shopName;

        public ShopInventory ShopInventory { get => _shopInventory; }
        public List<Manager> Managers { get => _managers; }
        public List<Customer> Customers { get => _customers; }
        public List<Person> Persons { get => _persons; }
        public string ShopName;
        #endregion

        public Shop(string shopName, ShopInventory shopInventory)
        {
            _shopName = shopName;
            _shopInventory = shopInventory;

            _persons.Add(new Manager("manager1", true));
            _persons.Add(new Customer("customer1", false));
        }

        public bool ChangeBasketCapacity(Manager manager, int capacity)
        {
            // TODO: CHECK IF CUSTOMER ALREADY SUCCEEDS CHOSE CAPACITY
            foreach (var person in _persons)
            {
                if (person.GetType() == typeof(Customer))
                {
                    Customers.Add((Customer)person);
                }
            }

            foreach (var customer in _customers)
            {
                customer.ChangeBasketCapacity(manager, capacity);
            }

            return true;
        }
    }
}
