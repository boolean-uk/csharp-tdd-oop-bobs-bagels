using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Baskets;
using exercise.main.Inventories;
using exercise.main.Products;

namespace exercise.main.Users
{
    abstract class User
    {
        public enum Role
        {
            Customer,
            Manager
        }

        public Role UserRole;

        private Basket _basket;

        private readonly Inventory _inventory;

        protected User()
        {
            _basket = new Basket(25);
            _inventory = Inventory.Instance;
        }

        void SelectProductToBasket(Product p)
        {
            

            if (_inventory != null && _inventory.IsInStock(p))
            {
                try
                {
                    _basket.AddItem(p);
                }
                catch (BasketCapacityReachedException e)
                {
                    throw new CouldNotSelectProductExeption(e.Message);
                }
            }
        }

        void RemoveProductFromBasket(Product p) 
        { 

        }
    }
}
