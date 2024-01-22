Extension user stories

As a Bob's Bagels manager,
So I can attract more customers with offers,
I'd like to have bundle discounts available on my shop.

As a member of the public,
So that I can keep track of my spending,
I'd like to receive a receipt of my purchases.

As a Bob's Bagels manager,
So that I can encourage customers to visit more often,
I want to emphasize how much a customer has saved in the receit when they buy bundles.


Class
: `Basket()`

Properties
: `private List<Item> _basket`
: `private List<float> totalCost`
: `private int _capacity = 5`
: `private Inventory inventory`
: `private enum Bundles { b6, b12, bac }`


Methods
: `public void priceRemover(float price, int iter)`
    * helper for bundle discount calculations to the totalCost list
    * 
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

: `public void BundleOrder(string descr, List<Item> items)`
    * corrects the bundle price according to type instruction (b6, b12, bac)
  
: `public float GetItemPrice(Item item)`
    * returns the Item price from _basket list
  
: `float void addFilling(string ID, Filling filling)`
    * adds filling to Contents list if filling exists
    * adds filling cost to Price

: `public void PrintReceit(Receit receit)`
    * calls the receit class to print the receit

_____________

Interface IItem

Properties
: `public abstract string ID { get; }`
: `public abstract string SKU { get; }`
: `public abstract string Name { get; }`
: `public abstract string Variant { get; }`
: `public abstract float Price { get; }`

_____________

Abstract Class
 `Item : IItem`

Properties
: `protected string ID`
: `protected SKU`
: `protectd Name`
: `protected Price`
: `protected Variant`
: `public bool inBundle`
: `public List<string> inBundleWith`


Methods
:  `public Item(String SKU ... )`
    * defines item

:  `public bool isInBundle()`
    * returns inBundle

:  `public virtual List<string> ListBundleIds()`
    * returns inBundleWith list

:  `public virtual void putToBundle(List<string> ids)`
    * inBundleWith = ids, set inBundle = true

:  ` public virtual void RemoveFromBundle()`
    * clear inBundleWith, set inBundle = false 

_____________

Class
 `Bagel : Item`

Properties
: `List Contents<Item>`

Methods
:  `public Item(String SKU ... List Contents<Item>)`
    * defines item

:  `public AddFillingToBagel(Item item)`
    * adds filling to contents list
  
: `float List<Item> ListFillings()`
    * returns Contents list

_____________

Class
 `Coffee : Item`

Methods
:  `public Item(String SKU ... )`
    * defines item
  
_____________

Class
 `Filling : Item`

Methods
:  `public Item(String SKU ... )`
    * defines item

:  `public override void putToBundle(List<string> skus )`
    * overrides this function to do nothing

:  `public override void RemoveFromBundle( )`
    * overrides this function to do nothing

:  `public override List<string> ListBundleIds()`
    * overrides this function to do nothing

_____________

Class
 `Inventory `

Properties
: `private Dictionary <string, Item> _all`

Methods
: `public List<Item> listContents()`
    * returns all Items list

: `public Dictionary<string , Item> getInventory()`
    * returns _all dictionary


_____________


Class
 `Receit`

Properties
: `private Dictionary bundle { ["6"] = 2.49F, ["12"] = 3.99F, ["2"] = 1.25F }`
: `string date`
: `string time`

Methods
: `public void PrintReceit(float totalprice, List<Item> _basket)`
    * prints the receit info
