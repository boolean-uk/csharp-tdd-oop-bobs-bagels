
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



| Classes         | Methods                                     | Scenario							 |			  Outputs								|
|-----------------|---------------------------------------------|------------------------------------|--------------------------------------------------|
| `Basket		` | `AddItem(Item item)						`	| Add item to basket, if not full	 |(bool) True if added, otherwise false				|
|                 |                                             |									 |													|
|-----------------|---------------------------------------------|------------------------------------|--------------------------------------------------|
| `Basket		` | `RemoveItem(Item item)					`	| Remove item from basket, if exists |(bool) True if removed, otherwise false			|
|                 |                                             |									 |													|
|-----------------|---------------------------------------------|------------------------------------|--------------------------------------------------|
| `Basket		` | `ChangeCapacity()						`	| If manager, change capacity		 |(bool) Returns true if changed, false if not		|
|                 |                                             |									 |													|
|-----------------|---------------------------------------------|------------------------------------|--------------------------------------------------|
| `Basket		` | `GetPrice()								`	| returns price of basket			 |(void) Cost of basket								|
|                 |                                             |									 |													|
|-----------------|---------------------------------------------|------------------------------------|--------------------------------------------------|
| `Basket		` | `AddFilling(Item item)					`	| Print cost, Add filling to bagel	 |(void) Prints a statement that it was added		|
|                 |                                             |									 |													|
|-----------------|---------------------------------------------|------------------------------------|--------------------------------------------------|
| `Basket		` | `RemoveFilling(Item item)				`	| Removes filling from bagel		 |(void) Prints a statement that it was removed		|
|                 |                                             |									 |													|
|-----------------|---------------------------------------------|------------------------------------|--------------------------------------------------|
| `Inventory	` | `GetInventory()							`	| Method for checking avaliable stock|(List<Item>) returns list with stock of items	    |
|                 |                                             |									 |													|
|-----------------|---------------------------------------------|------------------------------------|--------------------------------------------------|

Extension: 


| Classes         | Methods                                     | Scenario							 |			  Outputs								|
|-----------------|---------------------------------------------|------------------------------------|--------------------------------------------------|
| `Receipt		` | `GetReceipt(Basket basket)				`	| Prints a receipt of items			 |(void)											|
|                 |                                             |									 |													|
|-----------------|---------------------------------------------|------------------------------------|--------------------------------------------------|
| `Basket		` | `GetPrice()								`	| returns price of basket			 |(void) Cost of basket, with discount				|
|                 |                                             |									 |													|
|-----------------|---------------------------------------------|------------------------------------|--------------------------------------------------|
