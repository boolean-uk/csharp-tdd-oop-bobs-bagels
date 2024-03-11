#  original md tdd-bobs-bagels
### Class Basket
- string bagelType

PROPERTIES
- public List<string> ordersInBasket;
- int basketSize

METHODS

`I'd like to add a specific type of bagel to my basket.`
- public bool addBagel(string bagelType), adds bagel to List<string> ordersInBasket; when order does not excist in List

`I'd like to remove a bagel from my basket.`
- public bool changeOrder(), return true when bagel is removed from order, message of changed order, return false message with order not found

`I'd like to know when my basket is full when I try adding an item beyond my basket capacity.`
- public bool fullBasket(), return true when full, message when bakset is full 

`I'd like to know when my basket is full when I try adding an item beyond my basket capacity.`
- public void setBasketSize(int newSize), 

`I'd like to know if I try to remove an item that doesn't exist in my basket.`
- public bool removeOrder(), return false when item doesnt exist while trying to delete it. 
  return true if exists message with removed order.

# Refactored Domain Model TDD-OOP-Bobs-Bagels

### Class Basket
PROPERTIES
	private int basketCapacity;
	private List<Item> itemsInList;
	private Inventory inventory;

METHODS 
	public bool AddItem(string sku), adds bagel/item to List<string> ordersInBasket; => when order does not excist in List<Inventory>
	public bool RemoveItem(string sku), removes bagel/item from List<string> ordersInBasket; => when excist in List<Inventory>, message when return false
	public void SetBasketSize(int newSize), returns false when newSize is < 0
	public double GetTotalCosts, returns all costs of items in basket.

### Class Inventory
PROPERTIES
	Dictionary<string(sku), Item(List<Item>) items 

METHODS
	public Item getItemFromList(string SKU), returns item found by its sku
	public double getPrice(string SKU), returns price of each item found by its sku
	public bool checkItemInStock(string SKU), returns true if item exists && is in stock
												returns false if item is not in stock || doesnt exists.


### Item
	private string sku
	private double price
	private string name
	private stirng variant
