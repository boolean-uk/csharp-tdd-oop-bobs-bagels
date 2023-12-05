## Domain Model

## Core Requirements

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
So that I can maintain my sanity
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

Req. | Classes	  | Methods / Properties				   | Scenario											| Outputs	      |
-----|------------|----------------------------------------|----------------------------------------------------|-----------------|
1	 |Inventory.cs|Object `Item`: SKU/Price/Name/Variant   |The items that can be ordered						| Item			  |
1	 |Basket.cs	  |List<Item> Basket					   |Store items											| List			  |
1,3,8|Core.cs	  |`AddItem(string SKU)`				   |Add item to basket OR return "basket full"			| List			  |
2,5  |Core.cs	  |`RemoveItem(string SKU)`				   |Remove item from basket OR return "doesn't exist"	| List			  |
3	 |Core.cs	  |`MaxCapacity(int maximum)`			   |Set a max to the basket								|				  |
4    |Core.cs	  |`EditMaximum(identity, int)`			   |Manager (only) can change the maximum				| Int ?			  |
5	 |			  |Covered in `RemoveItem`				   |Notify when trying to remove item that doesnt exist | String		  |
6	 |			  |`SumCost()`		list.sum			   |Get the total cost of items in basket				| Int			  |
7,9	 |			  |`SeeMenu()` = display menu in console   |Show menu on console								| String		  |
8	 |			  |Covered in `AddItem()`				   |Add fillings										| ?				  |
9	 |			  |Covered in `SeeMenu()`				   |See price of fillings								| String		  |
10	 |			  |`CheckInventory()` Run before AddItem() |Only things in inventory can be added				| Bool ?		  |
App  |BagelApp.cs |`MainMenu()`