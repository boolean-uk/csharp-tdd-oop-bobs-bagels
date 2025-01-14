using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class ShoppingSystem
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

        // New list of Discounts
        public List<Discount> Discounts {get; set;}
        public Dictionary<string, int> GetInventory { get {return new Dictionary<string, int>(_inventory);}}
        public int CartSize { get { return _cartSize;} }

        public ShoppingSystem(){
            // Fill the inventory with 10 of each available item
            _availableItems.Keys.ToList().ForEach(sku => _inventory[sku] = 10);
            _cartSize = 8;
            Discounts = new List<Discount>();
        }

        
        public ActionMessage<bool> AddItemToCart(string SKU, Guid id)
        {
            
            //Item does not exist
            if (!_availableItems.Keys.Contains(SKU)){
                return new ActionMessage<bool>(false, "Item does not exist!");
            }

            //Add a cart for the customer if they do not have a cart yet
            if (!Carts.Keys.ToList().Contains(id))
            {
                Carts[id] = new List<Item>();
            }
            // Cannot add items to a full cart
            else if (Carts[id].Count > _cartSize)
            {
                return new ActionMessage<bool>(false, "Cart is full!");
            }
            // Add item to Cart if item exist in inventory
            if (_inventory[SKU] > 0)
            {
                ValueTuple<double, string, string> itemInfo = _availableItems[SKU];
            Item itemToAdd = new Item(SKU, itemInfo.Item1, itemInfo.Item2, itemInfo.Item3);

            Carts[id].Add(itemToAdd);
            _inventory[SKU] -= 1;
            
            return new ActionMessage<bool>(true, "Successfully added item!");
            }

            return new ActionMessage<bool>(false, "Out of stock!");

            
        }

        public ActionMessage<bool> RemoveItemFromCart(string SKU, Guid id)
        {
            // No cart associated with that ID
            if (!Carts.Keys.Contains(id)){
                return new ActionMessage<bool>(false, "Item does not exist!");
            }

            Item? itemToRemove = Carts[id].FirstOrDefault(item => item.SKU == SKU);

            // Item does not exist in cart
            if (!Carts[id].Remove(itemToRemove)){
                return new ActionMessage<bool>(false, "Item is not in Cart!");
            }
            _inventory[SKU] += 1;
            return new ActionMessage<bool>(true, "Successfully removed item from Cart!");
        }

        public void ChangeCapacityOfCart(int newSize)
        {
            _cartSize = newSize;
        }
        // Calculates the cost of the cart given itemprice 
        public ActionMessage<double> CalculateCartCost(Guid id)
        {
            //Return 0 if the id does not have a corresponding cart
            if (!Carts.Keys.ToList().Contains(id))
            {
                return new ActionMessage<double>(0, "No cart associated with id!");
            }

            double sum = 0; // Sum of the cart
            List<Item> CartCopy = new List<Item>(Carts[id]); //Copy of the items in the cart

            //Initiate recipt
            string Recipt = String.Format("{0, -20}\n", "~~ Bob's Bagels ~~");
            Recipt += String.Format("{0, -20}\n", DateTime.Now.ToString());
            Recipt += "-------------------" + "\n\n";

            double moneySavedOnDiscount = 0;

            Discount nextDiscount = new Discount(new Dictionary<string, int>{ {"Initial discount item", 1}}, 10, 10); //Initialize a "dummy" discount to make sure the code goes in the while loop

            int count = 0;
            //Find all Discounts in available for the Cart in question
            while (nextDiscount.SKUCount.Count > 0 || count <= CartSize) //Worstcase: A single item discount needs "CartSize" iterations to find all Discounts. Want to make sure that the loop does not iterate for infinity no matter what.
            {
                nextDiscount = FindDiscount(CartCopy);

                //Add Discount price to sum and remove discount items from the CartCopy
                if (nextDiscount.SKUCount.Count > 0) 
                {
                    sum += nextDiscount.Price;
                    
                    //Remove discounted items from CartCopy
                    foreach (string sku in nextDiscount.ToList()) 
                    {
                        Item? itemToRemove = CartCopy.FirstOrDefault(x => x.SKU == sku);
                        
                        if (itemToRemove.Equals(null))
                        {
                            return new ActionMessage<double>(0, "Unkown error"); //There is an error somewhere if this gets executed
                        }

                        CartCopy.Remove(itemToRemove);
                       
                        }

                    
                    
                    //Add discount to receipt
                    Recipt += "-----DISCOUNT-----" + "\n";
                    string DiscountString = "";
                    foreach (string SKU in nextDiscount.ToList())
                        {
                            DiscountString += GetFullItemName(SKU) + "\n";
                        }
                    
                    Recipt += String.Format("{0, -10} {1, 16}\n", DiscountString, Math.Round(nextDiscount.Price, 3).ToString() + "£");
                    double moneySaved = Math.Round(nextDiscount.Price - nextDiscount.originalPrice, 3);
                   
                    Recipt += String.Format("{0, 20}\n","(" + moneySaved.ToString() + "£)");
                    //Recipt += "-----------------" + "\n";
                    

                    moneySavedOnDiscount += moneySaved;
                }
                count += 1;
            }
            
            // Add sum of all items that are not discounted
            foreach (Item i in CartCopy)
            {
                sum += GetCost(i.SKU);
                Recipt += String.Format("{0, -10} {1, 6}\n\n", GetFullItemName(i.SKU), GetCost(i.SKU).ToString() + "£");
            }

            Recipt += "-------------------" + "\n";
            Recipt += String.Format("{0, 17}\n", "You saved:" + moneySavedOnDiscount + "£!");
            Recipt += String.Format("{0, 15}\n", "Welcome back");
            


            return new ActionMessage<double>(sum, Recipt);
        }



        public double GetCost(string SKU)
        {
            if (_availableItems.Keys.ToList().Contains(SKU))
            {
                return _availableItems[SKU].Item1;
            }
            return 0;
        }

        public void NewDiscount(Dictionary<string, int> SKUs,  double newPrice)
        {
            double originalPrice = 0;
            double currentPrice = 0;
            //Add the cost of each item to the originalPrice variable
            foreach (string sku in SKUs.Keys)
            {
                currentPrice = GetCost(sku);
                if (currentPrice == 0){return;} //Does not add discount if not all items are recognized
                originalPrice += currentPrice*SKUs[sku];

            }

            Discounts.Add(new Discount(SKUs, newPrice, originalPrice));
        }

        // Finds the best Discount in the given list of items
        public Discount FindDiscount(List<Item> items)
        {
            //Ensure that the best discounts are located first in the list
            Discounts.OrderByDescending(x => x.originalPrice - x.Price);
            // Convert items to a dictionary of <SKU, count>
            Dictionary<string, int> itemCount = items.GroupBy(x => x.SKU).ToDictionary(elem => elem.Key, elem => elem.Count());

            // Find the first Discount match in items
            bool isDiscount = false;
            foreach (Discount disc in Discounts)
            {
                foreach (string sku in disc.SKUCount.Keys)
                {
                    if (!itemCount.Keys.Contains(sku))
                    {
                        // The cart does not meet all criteria for the discount 
                        isDiscount = false;
                        break;
                    }
                    if (!(itemCount[sku] >= disc.SKUCount[sku]))
                    {
                        // The cart does not meet all criteria for the discount 
                        isDiscount = false;
                        break;
                    }

                    isDiscount = true;

                }
                if (isDiscount) //Discount found!
                    {
                        return disc;
                    }

            }
            return new Discount(); //Discount not found!
        }

    public string GetFullItemName(string SKU)
    {
        if (_availableItems.Keys.Contains(SKU)){
            return _availableItems[SKU].Item2 + " - " + _availableItems[SKU].Item3;
        }
        return "";
        
    }
 
    }
}
