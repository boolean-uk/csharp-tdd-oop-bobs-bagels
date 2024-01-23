1.
As a member of the public,
So I can order a bagel before work,
I'd like to add a specific type of bagel to my basket.

2.
As a member of the public,
So I can change my order,
I'd like to remove a bagel from my basket.

3.
As a member of the public,
So that I can not overfill my small bagel basket
I'd like to know when my basket is full when I try adding an item beyond my basket capacity.

4.
As a Bob's Bagels manager,
So that I can expand my business,
I’d like to change the capacity of baskets.

5.
As a member of the public
So that I can maintain my sanity
I'd like to know if I try to remove an item that doesn't exist in my basket.

6.
As a customer,
So I know how much money I need,
I'd like to know the total cost of items in my basket.

7.
As a customer,
So I know what the damage will be,
I'd like to know the cost of a bagel before I add it to my basket.

8.
As a customer,
So I can shake things up a bit,
I'd like to be able to choose fillings for my bagel.

9.
As a customer,
So I don't over-spend,
I'd like to know the cost of each filling before I add it to my bagel order.

10.
As the manager,
So we don't get any weird requests,
I want customers to only be able to order things that we stock in our inventory.

Class:
	Item

Properties:
	public string: Name
	public string: Variant
	public string: SKU
	public float: Price 

Class:
	Basket

Properties:
	private list<Item>: itemsInBasket
	private int: Capacity (5 by default)

Methods:

	void AddItemToBasket(Item, item, Inventory, inventory)
	(adds item to basket if it exists in inventory, and if max capacity is'nt reached, 
	returns errorMessage otherwise)

	void RemoveItemFromBasket (String, SKU)
		(Removes Item from the basket if it exists in the basket, 
		otherwise return error message)

	void AdjustBasketCapacity(Int, Capacity)
		(Adjusts the capacity of the basket to the value provided)

	float GetTotalPrice()
		(returns the total price of all items in the basket)
Class:
	Inventory

Properties:
	public List<Item> AvailableItems

Methods:

	bool IsItemInStock(String, SKU)
		(returns true if item is in the inventory, false otherwise)

	void AddItemToInventory(Item, item)
		(adds Item to Inventory)

	float GetItemPrice(String, SKU)
		(returns the price of an item, based on SKU provided

REFACTOR
/*
Things updated in this domainModel:
1. Updated the accessability to properties to classes:
	- Item
	- Basket
	- Inventory
2. With a {get; private set;} property, I realized you dont need get methods
3. Created interface for all items so they have a tempelate
4. Made inventory a property of Basket, so that the customer dont have to pass 
	instance of basket everytime they add item

Interface
	Iitem:

Properties:
	private string: Name
	private string: SKU
	private readonly float: Price

Class:
	Bagel : Iitem

Properties:
	private string: Name {get;private set;}
	private string: SKU {get;private set;}
	private readonly float: Price {get;private set;}
	private string: Variant {get;private set;}

Methods:
	Bagel()
		Variant = "Bagel"

Class:
	Coffee : Iitem

Properties:
	private string: Variant

Methods:
	Coffee()
		Variant = "Coffee"
Class:
	Filling : Iitem

Properties:
	private string: Variant


Methods:
	Filling()
		Variant = "Filling"

Class:
	Basket

Properties:
	private list<Item>: itemsInBasket
	private int: Capacity (5 by default)
	public Inventory: inventory

Methods:

	void AddItemToBasket(string SKU)
	(adds item to basket if it exists in inventory, and if max capacity is'nt reached, 
	returns errorMessage otherwise)

	void RemoveItemFromBasket (String SKU)
		(Removes Item from the basket if it exists in the basket, 
		otherwise return error message)

	void AdjustBasketCapacity(Int basketCapacity)
		(Adjusts the capacity of the basket to the value provided)

	float GetTotalPrice()
		(returns the total price of all items in the basket)

Class:
	Inventory

Properties:
	private List<Item> AvailableItems

Methods:

	bool IsItemInStock(String, SKU)
		(returns true if item is in the inventory, false otherwise)

	void AddItemToInventory(Item, item)
		(adds Item to Inventory)

	float GetItemPrice(String, SKU)
		(returns the price of an item, based on SKU provided