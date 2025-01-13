using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Shop
    {
        //Size of each Cart
        private int _cartSize {get; set;}
        
        //Arguments for each available item
        private Dictionary<string, ValueTuple<Double, string, string>> _availableItems = new Dictionary<string, ValueTuple<double, string, string>>
        {
            {"BGLO", new ValueTuple<Double, string, string>(0.49, "Bagel", "Onion" ) },
            {"BGLP", new ValueTuple<Double, string, string>(0.39, "Bagel", "Plain" ) },
            {"BGLE", new ValueTuple<Double, string, string>(0.49, "Bagel", "Everything") },
            {"BGLS", new ValueTuple<Double, string, string>(0.49, "Bagel", "Sesame") },
            {"COFB", new ValueTuple<Double, string, string>(0.99, "Coffee", "Black") },
            {"COFW", new ValueTuple<Double, string, string>(1.19, "Coffee", "White") },
            {"COFC", new ValueTuple<Double, string, string>(1.29, "Coffee", "Capuccino") },
            {"COFL", new ValueTuple<Double, string, string>(1.29, "Coffee", "Latte") },
            {"FILB", new ValueTuple<Double, string, string>(0.12, "Filling", "Bacon") },
            {"FILE", new ValueTuple<Double, string, string>(0.12, "Filling", "Egg") },
            {"FILC", new ValueTuple<Double, string, string>(0.12, "Filling", "Cheese") },
            {"FILX", new ValueTuple<Double, string, string>(0.12, "Filling", "Cream Cheese") },
            {"FILS", new ValueTuple<Double, string, string>(0.12, "Filling", "Smoked Salmon") },
            {"FILH", new ValueTuple<Double, string, string>(0.12, "Filling", "Ham") }
        };
        // A Count of each item in inventory
        private Dictionary<string, int> _inventory = new Dictionary<string, int>();

        // A collection of carts, which are bound to each customer
        public Dictionary<Guid, List<Item>> Carts = new Dictionary<Guid, List<Item>>();
        public Dictionary<string, int> GetInventory { get {return new Dictionary<string, int>(_inventory);}}
        public int CartSize { get { return _cartSize;} }

        public Shop(){
            // Fill the inventory with 10 of each available item
            _availableItems.Keys.ToList().ForEach(sku => _inventory[sku] = 10);
            _cartSize = 8;
        }

        
        public ActionMessage AddItemToCart(string SKU, Guid id)
        {
            

            //Item does not exist
            if (!_availableItems.Keys.Contains(SKU)){
                return new ActionMessage(false, "Item does not exist!");
            }

            //Add a cart for the customer if they do not have a cart yet
            if (!Carts.Keys.ToList().Contains(id))
            {
                Carts[id] = new List<Item>();
            }
            // Cannot add items to a full cart
            else if (Carts[id].Count > _cartSize)
            {
                return new ActionMessage(false, "Cart is full!");
            }
            // Add item to Cart if item exist in inventory
            if (_inventory[SKU] > 0)
            {
                ValueTuple<double, string, string> itemInfo = _availableItems[SKU];
            Item itemToAdd = new Item(SKU, itemInfo.Item1, itemInfo.Item2, itemInfo.Item3);

            Carts[id].Add(itemToAdd);
            _inventory[SKU] -= 1;
            
            return new ActionMessage(true, "Successfully added item!");
            }

            return new ActionMessage(false, "Out of stock!");

            
        }

        public ActionMessage RemoveItemFromCart(string SKU, Guid id)
        {
            // No cart associated with that ID
            if (!Carts.Keys.Contains(id)){
                return new ActionMessage(false, "Item does not exist!");
            }

            Item? itemToRemove = Carts[id].FirstOrDefault(item => item.SKU == SKU);

           
            if (!Carts[id].Remove(itemToRemove)){
                return new ActionMessage(false, "Item is not in Cart!");
            }
            _inventory[SKU] += 1;
            return new ActionMessage(true, "Successfully added item to Cart!");
        }

        public void ChangeCapacityOfCart(int newSize)
        {
            _cartSize = newSize;
        }

        public double GetCost(Guid id)
        {
            if (!Carts.Keys.ToList().Contains(id))
            {
                return 0;
            }

            return Carts[id].Sum(x => x.Price);
        }

    }
}
