class Item
    PROPERTIES
        private string sku
        private double price
        private string name
        private string variant

class Basket
    PROPERTIES
        private List<Item> items
        private int capacity
        private Inventory inventory
    METHODS
        public bool Add(string sku) - returns true if item exists in inventory and adds item to basket
                                    - returns false if item does not exist in inventory
        public bool Remove(string sku) - returns true if item exists in basket and removes item from basket
                                       - returns false if item does not exists in basket
        public void ChangeCapacity(int) - changes the capacity of the basket
                                   - returns false if capacity gets < 0
        public double GetTotalCost - returns the total amount of all the items in the basket

class Inventory
    PROPERTIES
        Dictionary<string, Item> items 
    METHODS
        public double getPrice(string sku) - returns price of single item in inventory
        public Item getItem(string sku) - returns Item object by SKU
        public bool inStock(string sku) - returns true if item exists in stock
                                        - returns false if item does not exist in stock