## Extension 2: Receipts

Receipts are important.

## Task

Update and extend your program to handle printing receipts. These receipts should print to the terminal.

Start with extracting useful stories and a functional domain model that represents these requirements.

Tip: Think about a Receipt as an object. What other objects are contained in a receipt?

## User Stories
```
As a customer
So that I can see what I payed for
Id like to get a receipt

As a owner
So that I can keep track of my sales
I'd likes to store orders made by customers
```


#### Example Receipt
```
    ~~~ Bob's Bagels ~~~

    2021-03-16 21:38:44

----------------------------

Onion Bagel        2   £0.98
Plain Bagel        12  £3.99
Everything Bagel   6   £2.49
Coffee             3   £2.97

----------------------------
Total                 £10.43

        Thank you
      for your order!
```

```
    ~~~ Bob's Bagels ~~~

    2021-03-16 21:40:12

----------------------------

Plain Bagel        16  £5.55

----------------------------
Total                  £5.55

        Thank you
      for your order!
```

```C# 

class Basket
	PROPERTIES:
	private float _maxCapacity = 4
	public readonly List<Item> _basketList
	private Inventory _inventory
	


	METHODS:
	public Basket(Inventory _inventory)

	public bool AddProduct(string sku)
		// return true if it's a bagle and is added to basket
		// return false if item dosent exist in inventory or basket is full

	public bool AddFilling(int index, string fillingSKU)
		// Add filling to the specified index of bagel in the basket

	public bool RemoveBagle(int index)
		// Return true and remove an the item at the specified index
		// Return false if the index dosen't exists


	public bool ChangeCapacity(float newCapacity)
		// return true if capacity is increased
		// return false if newCapacity < 1 or newCapacity < nr of basketLists items

	public Dictionary<string, BasketItem> GetBasket()

	public Dictionary<string, BasketItem> GetDiscountedBasket()


struct BasketItem
	PROPERTIES:
	+ Item Item
	+ List<Filling> Fillings
	+ int quantity
	+ decimal TotalCost

	METHODS:
	IncrementQuantity()

Class Discount
	PROPERTIES:
	+ Item ItemWithDeal
	- decimal _discount
	+ List<RequiredItemsForDiscount> RequiredItemsForDiscount { get; }

	METHODS:
	public Discount(Item item, decimal discount, List<RequiredItemsForDiscount> discountItems)
	public decimal GetDiscountedPrice()

public struct RequiredItemsForDiscount
	PROPERTIES
	+ Item Item { get; }
    + int Quantity { get; }

	METHODS:
    + RequiredItemsForDiscount(Item item, int quantity)

class Inventory
	PROPERTIES:
	- Dictionary<string, Item> items //<sku, Item>
	- List<Discount> _discounts
		

	METHODS:
	+ bool ItemExists(string sku)
		return true if item exists
		return false if not
	+ float GetPrice(string sku)
		return price
	+ Item GetItem(string sku)
		return the item if it exists
		If it dosen't return null
	+ Dictionary<string, BasketItem> GetDiscountedBasket(Dictionary<string, BasketItem> basket)
		Apply discounts on the inputed basket

class Item
PROPERTIES:
	private string sku
	private float price
	private string itemName
	private string variant

METHODS:
	public Item (string sku, float price, string itemName, string variant) // used to insitalize items into invetory
	public Item (Item item) // Used to create copies of items
	virtual GetPrice


class Bagle : Item
PROPERTIES:
	private List<Item> fillings

METHODS:
	public Item AddFilling(Item filling)
	public float GetPrice()
	return total price of item + fillings

class Coffee : Item
class Filling : Item


class Receipt
PROPERTIES:
        - Basket _basket;
        - DateTime _createdAt;
METHODS:
        + Receipt(Basket basket)
        + List<string> PrintRecipt()



	






```