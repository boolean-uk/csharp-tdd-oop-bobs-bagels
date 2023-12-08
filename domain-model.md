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
1	 |Item.cs	  |Object `Item`: ID/SKU/Price/Name/Variant|Item with properties								| Item			  |
1	 |Inventory.cs|List<Item> Stock						   |The items that can be ordered						| List			  |
1	 |Basket.cs	  |List<Item> orderBasket				   |Store items	that customer adds to basket			| List			  |
1,3,8|Basket.cs	  |`AddItem(string itemID)`				   |Add item to basket OR return "basket full"			| List, message   |
2,5  |Basket.cs	  |`RemoveItem(string itemID)`			   |Remove item from basket OR return "not in basket"	| List, message	  |
3	 |Basket.cs	  |`MaxCapacity(int maximum)`			   |Set a max to the basket								|				  |
4    |Basket.cs	  |`EditMaximum(identity, int)`	 		   |Manager (only) can change the maximum				| Int			  |
6	 |Basket.cs	  |`SumBasket()`						   |Get the total cost of items in basket				| Int			  |
6	 |Basket.cs   |`ViewBasket()`						   |Show basket, incl nr of items and cost				| String		  |
7,9	 |BagelApp.cs |`SeeMenu()` = display menu in console   |Show menu on console, incl prices					| String		  |
10	 |BagelApp.cs |Switch only allows IDs of existing items|Only things in inventory can be added				| ?				  |
App  |BagelApp.cs |`Welcome()`							   |First entry to order system
App  |BagelApp.cs |`SeeMenu()`							   |Customer goes here to view menu and place order
App  |BagelApp.cs |`DisplayMenu()`						   |Get the menu on screen
App  |BagelApp.cs |`Stop()`								   |Quit running the app




