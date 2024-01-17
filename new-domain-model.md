Class
: `Basket()`

Properties
: `private List<Item> _basket`
: `private List<float> totalCost`
: `private int _capacity = 5`
: `private IInventory inventory`
: `private enum Bundles { b6, b12, bac }`


Methods
: `public bool AddItem(Item item)`
    * adds a new product order to _bagelBasket. Must be a string included in the _types list. Adds the cost of the item to the totalCost;
    * Outputs an error message (Console.WriteLine) if _capacity is exceeded. True if success, false if error

: `public bool RemoveItem(Item item)`
    * removes (the first found) item from _bagelBasket if the item exists. Removes the cost of the item from totalCost
    * Outputs an error message (Console.WriteLine) if the item is not in the basket. True if success, false if error

: `public void ChangeCapacity(int capacity)`
    * changes the value of the _capacity variable. The default of capacity is 5

: `public float TotalCost()`
    * returns the total costs of ordered items

: `public Item GetItem(int ID)`
    * returns the Item from _basket list

: `public void BundleOrder(string type, string SKU, string SKU2)`
    * corrects the bundle price according to type instruction (b6, b12, bac)
  
: `public float GetItemPrice(Item item)`
    * returns the Item price from _basket list
  
: `float void addFilling(Item bagel, Item filling)`
    * adds filling to Contents list if filling exists
    * adds filling cost to Price



Abstract Class
 `Item()`

Properties
: `string ID`
: `string SKU`
: `string Name`
: `float Price`
: `string Variant`

Methods
:  `public Item(String SKU ... )`
    * defines item


Class
 `Bagel() : Item`

Properties
: `string SKU`
: `string Name`
: `float Price`
: `string Variant`
: `List Contents<Item>`

Methods
:  `public Item(String SKU ... List Contents<Item>)`
    * defines item
  
: `float List<Item> ListFillings()`
    * returns Contents list


Class
 `Coffee() : Item`

Properties
: `string SKU`
: `string Name`
: `float Price`
: `string Variant`

Methods
:  `public Item(String SKU ... )`
    * defines item
  

Class
 `Fillings() : Item`

Properties
: `string SKU`
: `string Name`
: `float Price`
: `string Variant`

Methods
:  `public Item(String SKU ... )`
    * defines item





Interface
  `Inventory()`

Methods:
 `getInventory();`
  * outputs the Item dictionary
 `listContents();`
 * outputs the Item list


Class
 `WholeInventory() : Inventory `

Properties
: `private Dictionary <string, Item> _all`

Methods
: `public List<Item> listContents()`
    * returns all Items list

: `public List<Item> getInventory()`
    * returns _all dictionary



Class
 `BagelInventory() : Inventory `

Properties
: `private Dictionary <string, Item> bagels`

Methods
: `public List<Item> listContents()`
    * returns bagels Item list

: `public List<Item> getInventory()`
    * returns bagels dictionary


Class
 `CoffeeInventory() : Inventory `

Properties
: `private Dictionary <string, Item> coffees`

Methods
: `public List<Item> listContents()`
    * returns coffee Item list

: `public List<Item> getInventory()`
    * returns coffees dictionary


Class
 `FillingsInventory() : Inventory `

Properties
: `private Dictionary <string, Item> fillings`

Methods
: `public List<Item> listContents()`
    * returns fillings Item list

: `public List<Item> getInventory()`
    * returns fillings dictionary