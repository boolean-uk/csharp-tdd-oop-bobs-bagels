## Extension 1: Discounts

In a normal supermarket, things are identified using Stock Keeping Units, or SKUs.

In Bob's Bagels, we'll use the first 3 letters of a bagel with an extra letter for the variant. For example: an 'everything bagel' has a SKU of `BGLE`.

Our goods are priced individually. In addition, some items are multi-priced: buy n of them, and they'll cost you y pounds.

#### Bob's Bagels Inventory

| SKU  | Name   | Variant    | Price | Special offers          |
|------|--------|------------|-------|-------------------------|
| BGLO | Bagel  | Onion      | .49   | 6 for 2.49              |
| BGLP | Bagel  | Plain      | .39   | 12 for 3.99             |
| BGLE | Bagel  | Everything | .49   | 6 for 2.49              |
| COFB | Coffee | Black      | .99   | Coffee & Bagel for 1.25 |

Every Bagel is available for the `6 for 2.49` and `12 for 3.99` offer, but fillings still cost the extra amount per bagel.

#### Example orders
```
2x BGLO  = 0.98
12x BGLP = 3.99
6x BGLE  = 2.49
3x COF   = 2.97
           ----
          10.43
```

```
16x BGLP = 5.55
           ----
           5.55
```

## Task

Update and extend your program to handle these orders at Bob's Bagels.

Start with extracting useful stories and a functional domain model that represents these requirements.

11.
As the Bob's Bagels manager
So that I get more customers
I'd like to have special offers

12.
As the customer
So that I save money
I'd like to see the special offer for an item

```C# 

class Item
	PROPERTIES
	private string sku
	private float price
	private string itemName
	private string variant
	private List<Item> fillings

	public Item (string sku, float price, string itemName, string variant) // used to insitalize items into invetory
	public Item (Item item) // Used to create copies of items

	METHODS
	public Item AddFilling(Item filling)
		return an item with the added filling
	
	public float totalPrice()
		return total price of item + fillings
	


class Inventory
	PROPERTIES:
	private Dictionary<string, Item> items //<sku, Item>

	private Dictionary<string, offer> offers //<sku, offers>
		

	METHODS:
	public bool ItemExists(string sku)
		return true if item exists
		return false if not

	//EXTENDED
	public float GetPrice(string sku)
		return price


	public Item GetItem(string sku)
		return the item if it exists
		If it dosen't return null


class Basket
	PROPERTIES:
	private float _maxCapacity = 4
	public readonly List<Item> _basketList
	private Inventory _inventory
	

	METHODS:
	public bool AddBagle(string sku)
		// return true if it's a bagle and is added to basket
		// return false if item dosent exist in inventory or basket is full

	public bool RemoveBagle(int index)
		// Return true and remove an the item at the specified index
		// Return false if the index dosen't exists

	public bool AddFilling(int index, string fillingSKU)
		// Add filling to the specified index of bagel in the basket

	public float TotalCost()
		// calculate total cost of all items in basket

	public bool ChangeCapacity(float newCapacity)
		// return true if capacity is increased
		// return false if newCapacity < 1 or newCapacity < nr of basketLists items
```