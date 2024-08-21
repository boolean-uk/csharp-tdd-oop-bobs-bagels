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

            _persons.Add(new Manager("John the First Bob's Bagels Manager", true));
            _persons.Add(new Customer("John the First Bob's Bagels Customer", false));
        }

        public List<Manager> GetShopManagers()
        {
            List<Manager> managers = new List<Manager>();

            foreach (var person in _persons.Where(person => person.GetType() == typeof(Manager)))
            {
                managers.Add((Manager)person);
            }

            return managers;
        }
        
        public List<Customer> GetShopCustomers()
        {
            List<Customer> customers = new List<Customer>();

            foreach (var person in _persons.Where(person => person.GetType() == typeof(Customer)))
            {
                customers.Add((Customer)person);
            }

            return customers;
        }

        public void AddShopManager(string name)
        {
            _persons.Add(new Manager(name, true));
        }

        public void AddShopCustomer(string name)
        {
            _persons.Add(new Customer(name, false));
        }

        public bool ChangeBasketCapacity(Manager manager, int capacity)
        {
            // TODO: CHECK IF CUSTOMER ALREADY SUCCEEDS GIVEN CAPACITY
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

        public void GetReceipt(Customer customer, string shopName)
        {
            Receipt receipt = customer.Checkout(shopName);
        }

        /*
        // PSEUDO CODE
            Shop-class: GetReceipt(Customer customer, string shopName)
                |--> customer.Checkout(string shopName);
            
            Customer-class: Checkout(string shopName);
                |--> _basket.Checkout(string shopName);
            
            Basket-class: Checkout(string shopName);
                |--> Receipt receipt = new Receipt(_itemsInBasket);
                |--> return receipt? Most of the job can be done in Receipt class since we have access to basket? If Shop-class has the receipt it has access to its methods so we can do everything from Shop-class

            Extra todo:
                * Make quantity property inside Item-class
                    |--> If you add an item quantity of that item++
                    |--> When you remove an item, check if the basket contains this item and take quantity--
                    
                * Make Receipt-class that takes a List<Item> in constructor
                    |--> Receipt-class has printReceipt()-method? 
            
            Tests:
                * Receipt-class: Check if the values inside matches with the values given? For example: when you add 6 bagels the receipt should have 6 bagels
        */
    }
}
