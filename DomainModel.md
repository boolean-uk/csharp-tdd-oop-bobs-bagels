## User Stories

```
1.
As a member of the public,
So I can order a bagel before work,
I'd like to add a specific type of bagel to my basket.
```

```
2.
As a member of the public,
So I can change my order,
I'd like to remove a bagel from my basket.
```

```
3.
As a member of the public,
So that I can not overfill my small bagel basket
I'd like to know when my basket is full when I try adding an item beyond my basket capacity.
```

```
4.
As a Bob's Bagels manager,
So that I can expand my business,
I’d like to change the capacity of baskets.
```

```
5.
As a member of the public
So that I can mafloatain my sanity
I'd like to know if I try to remove an item that doesn't exist in my basket.
```

```
6.
As a customer,
So I know how much money I need,
I'd like to know the total cost of items in my basket.
```

```
7.
As a customer,
So I know what the damage will be,
I'd like to know the cost of a bagel before I add it to my basket.
```

```
8.
As a customer,
So I can shake things up a bit,
I'd like to be able to choose fillings for my bagel.
```

```
9.
As a customer,
So I don't over-spend,
I'd like to know the cost of each filling before I add it to my bagel order.
```

```
10.
As the manager,
So we don't get any weird requests,
I want customers to only be able to order things that we stock in our inventory.
```


## Domain Model
```C# 

class Item
	PROPERTIES
	private string sku {get: set}
	private float price {get: set}
	private string itemName {get: set}
	private string variant {get: set}
	private List<Item> fillings

	METHODS
	public bool AddFilling(string sku)
		return true if item is a bagle and add filling
		return false if item is not a bagle
	
	public float totalPrice()
		return total price of item + fillings
	


class Inventory
	PROPERTIES:
	private Dictionary<string, Item> items //<sku, Item>
		

	METHODS:
	public void AddItem(SKU, item)
		Add the item to the invetory
	public bool ItemExists(string sku)
		return true if item exists
		return false if not
	public float GetPrice(string sku)
		return price
	public Item getItem(sting sku)
		check if item exits and return item if it does
		return null if it dosen't exist

class Basket
	PROPERTIES:
	public readonly List<Item> _basketList
	private float _maxCapacity = 4
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

## Bob's Inventory

| SKU  | Price | Name    | Variant       |
|------|-------|---------|---------------|
| BGLO | 0.49  | Bagel   | Onion         |
| BGLP | 0.39  | Bagel   | Plain         |
| BGLE | 0.49  | Bagel   | Everything    |
| BGLS | 0.49  | Bagel   | Sesame        |
| COFB | 0.99  | Coffee  | Black         |
| COFW | 1.19  | Coffee  | White         |
| COFC | 1.29  | Coffee  | Capuccino     |
| COFL | 1.29  | Coffee  | Latte         |
| FILB | 0.12  | Filling | Bacon         |
| FILE | 0.12  | Filling | Egg           |
| FILC | 0.12  | Filling | Cheese        |
| FILX | 0.12  | Filling | Cream Cheese  |
| FILS | 0.12  | Filling | Smoked Salmon |
| FILH | 0.12  | Filling | Ham           |