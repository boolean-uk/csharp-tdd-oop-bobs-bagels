Class
: `Basket()`

Properties
: `private List<Item> _basket`
: `private float totalCost = 0F`
: `private int _capacity = 5`
: `private Inventory inventory`

Methods
: `public bool AddItem(string SKU)`
    * adds a new product order to _bagelBasket. Must be a string included in the _types list. Adds the cost of the item to the totalCost;
    * Outputs an error message (Console.WriteLine) if _capacity is exceeded. True if success, false if error

: `public bool RemoveItem(string SKU)`
    * removes (the first found) item from _bagelBasket if the item exists. Removes the cost of the item from totalCost
    * Outputs an error message (Console.WriteLine) if the item is not in the basket. True if success, false if error

: `public void ChangeCapacity(int capacity)`
    * changes the value of the _capacity variable. The default of capacity is 5

: `public float TotalCost()`
    * returns the total costs of ordered items

: `public Item GetItem(string SKU)`
    * returns the Item from _basket list
  
: `public float GetItemPrice(string SKU)`
    * returns the Item price from _basket list

: `public string ListPrices(string type)`
    * returns a List of Items in the inventory with their prices. Type can be All, Bagel, Coffee or Filling



Class
 `Item()`

Properties
: `int ID`
: `string SKU`
: `string Name`
: `float Price`
: `string Variant`
: `List Contents<Item>`

Methods
:  `public Item(String SKU ... List Contents<Item>)`
    * defines item

: `float TotalPrice(string SKU)`
    * returns the price of the product

: `float void addFilling(string SKU)`
    * adds filling to Contents list if filling exists
    * adds filling cost to Price



Class
 `Inventory()`

Properties
: `private Dictionary <string, Item> bagels`
: `private Dictionary <string, Item> coffees`
: `private Dictionary <string, Item> fillings`

Methods
: `public List<Item> listBagels()`
    * returns bagels list

: `public List<Item> listCoffees()`
    * returns coffees list

: `public List<Item> listFillings()`
    * returns fillings list

: `public Item GetItem(string SKU)`
    * returns item by id

: `public float GetItemCost(string SKU)`
    * returns cost of a given item