```C#
class Item {
    // Members
        public string Sku { get; set; }
        public float Price { get; set; }
        public string Name { get; set; }
        public string Varient { get; set; }
        public List<string> Fillings { get; set; } 

    // Methods
        public Item(string Sku, float Price, string Name, string Variant, List<string> addedFillings = { "" }) {
            // "setters"
        }
}

class BobsInventory {
    // Members 
        public List<Item> _inventory = new list<Item> {
            // bobs inventory
        };
    // Methods 
        public bool IsItemInStock(string sku); // return true if given bagel is in stock, else retuyrn false
        public float GetFillingCost(string sku); // returns the price of given filling  
        public float GetBagelCost(string sku) // return the price of given bagel
}

class Basket {
    // Members
        private BobsInventory _inventory;
        private int _capacity { get; set; }
        private List<Bagel> _bagels = new List<Bagel>();
    
    //Methods
        public float TotalCostOfBasket(); // returns total cost of _bagels content
        public int ChangeBasketCapacity(int newCapacity); // changes the max capacity of basket
        public bool AddToBasket(string sku); // return true if successfully added, false if something happened 
        public bool RemoveFromBasket(string sku); // return true if successfully removed, false if something happened
    
    // Helper methods
        private ifFull(); // return true if basket is full, false if not
        private ContainsInBasket(string sku); // return true if _bagels contains given bagel, else return false
}
```