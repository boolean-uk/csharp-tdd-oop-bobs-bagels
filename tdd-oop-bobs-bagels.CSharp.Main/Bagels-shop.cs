namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class BagelsShop
    {
        private List<Items> items;
        private int _capacity;
        private Dictionary<Items, int> _basket;

        public BagelsShop()
        {
            _capacity = 5;
            _basket = new Dictionary<Items, int>();
            items = new List<Items>();

            items.Add(new Items("BGLO", 0.49m, "Bagel", "Onion"));
            items.Add(new Items("BGLP", 0.39m, "Bagel", "Plain"));
            items.Add(new Items("BGLE", 0.49m, "Bagel", "Everything"));
            items.Add(new Items("BGLS", 0.49m, "Bagel", "Sesame"));
            items.Add(new Items("COFB", 0.99m, "Coffee", "Black"));
            items.Add(new Items("COFW", 1.19m, "Coffee", "White"));
            items.Add(new Items("COFC", 1.29m, "Coffee", "Cappucino"));
            items.Add(new Items("COFL", 1.29m, "Coffee", "Latte"));
            items.Add(new Items("FILB", 0.12m, "Filling", "Bacon"));
            items.Add(new Items("FILE", 0.12m, "Filling", "Egg"));
            items.Add(new Items("FILC", 0.12m, "Filling", "Cheese"));
            items.Add(new Items("FILX", 0.12m, "Filling", "Cream Cheese"));
            items.Add(new Items("FILS", 0.12m, "Filling", "Smoked Salmon"));
            items.Add(new Items("FILH", 0.12m, "Filling", "Ham"));



        }
        public int ProductsInBasket {  get { return _basket.Count;  } }
        public int Capacity { get { return _capacity; } set { _capacity = value; } }
        public List<Items> Items { get { return items; } }

        public Dictionary<Items, int> Products { get { return _basket; } }

        private bool ItemExists(Items item)
        {
            foreach (var bagel in items)
            {
                if (bagel.Sku.ToUpper() == item.Sku.ToUpper())
                {

                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// returns true if the item can be added to the basket chekcing the capacity and the role if its shopper and if the items exists in the bagels shops
        /// </summary>
        /// <param name="item"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        public bool addBagel(Items item, Roles roles)
        {
            if (ItemExists(item) && _basket.Count < _capacity && roles == Roles.Shopper && (item.Name == "Bagel" || item.Name == "Coffee"))
            {
                _basket.Add(item, _basket.Count + 1);
                return true;
            }
            Console.WriteLine("Failed to add the item in the basket. Check the capacity of your basket");
            return false;
        }
        public bool RemoveBagel(Items item, Roles roles)
        {
            foreach (var product in _basket)
            {

                if (ItemExists(item) && _basket.Count > 0 && roles == Roles.Shopper && product.Key.Sku == item.Sku)
                {
                    _basket.Remove(product.Key);
                    // Console.WriteLine($"{product.Key.Sku} {product.Value}, {item.Sku}");
                    return true;
                }
            }
            Console.WriteLine("Failed to add the item in the basket. Check the capacity of the SKU code");
            return false;
        }
        /// <summary>
        /// changes the capacity of the basket only if the role is manager and the new capacity is not the same 
        /// as the previous one
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="newCapacity"></param>
        /// <returns></returns>
        public int ChangeCapacity(Roles role, int newCapacity)
        {
            if (this.Capacity != newCapacity)
            {
                this.Capacity = newCapacity;
                return this.Capacity; //capacity changed here
            }
            else
            {
                Console.WriteLine("The basket has already this capacity");
                return 0; //the default capacity
            }

        }
        /// <summary>
        /// adding a filling only if the basket isnt empty the role is shopper and the item name is filling
        /// </summary>
        /// <param name="item"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public bool AddFillings(Items item, Roles role)
        {
            // if the basket is empty then shopper cant add fillings


            if (ItemExists(item) && _basket.Count < this.Capacity && _basket.Count != 0 && role == Roles.Shopper && _basket.Keys.Any(item => item.Name == "Bagel") && item.Name.Equals("Filling"))
            {

                _basket.Add(item, _basket.Count + 1);
                return true;

            }

            return false;
        }
        // returns the price of the given item 
        public decimal IndividualCost(Items item, Roles role)
        {
            decimal cost= 0;
           
            if(ItemExists(item) && role == Roles.Shopper) { cost =  item.Price; }
            
            return cost;
        }

        public decimal TotalCost(Roles role)
        {
            decimal totalcost = 0;
            
            foreach(var item in _basket)
            {
                totalcost += item.Key.Price;

            }
            return totalcost;
        }
    }
}
