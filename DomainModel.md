
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
| `Basket		` | `ChangeCapacity(Person person, int cap)	`	| If manager, change capacity		 |(bool) Returns true if changed, false if not		|
|                 |                                             |									 |													|
|-----------------|---------------------------------------------|------------------------------------|--------------------------------------------------|
| `Basket		` | `GetPrice()								`	| returns price of basket			 |(double) Cost of basket							|
|                 |                                             |									 |													|
|-----------------|---------------------------------------------|------------------------------------|--------------------------------------------------|
| `Basket		` | `GetDiscountPrice()						`	| returns price of discount			 |(double) Cost of discount							|
|                 |                                             |									 |													|
|-----------------|---------------------------------------------|------------------------------------|--------------------------------------------------|
| `Bagel		` | `AddFilling(string namefilling)			`	| add filling to bagel				 |(string) returns string indicating if it was added|
|                 |                                             |									 |													|
|-----------------|---------------------------------------------|------------------------------------|--------------------------------------------------|
| `Bagel		` | `RemoveFilling(string nameFilling)		`	| Removes filling from bagel		 |(bool) True if removed, otherwise false			|
|                 |                                             |									 |													|
|-----------------|---------------------------------------------|------------------------------------|--------------------------------------------------|
| `Bagel		` | `GetPrice()								`	| Gets price with fillings			 |(double) returns price of bagel					|
|                 |                                             |									 |													|
|-----------------|---------------------------------------------|------------------------------------|--------------------------------------------------|
| `Receipt		` | `GetReceipt(Basket basket)				`	| Gets receipt of basket			 |(string) returns receipt							|
|                 |                                             |									 |													|
|-----------------|---------------------------------------------|------------------------------------|--------------------------------------------------|
| `Receipt		` | `PrintReceipt()							`	| Prints receipt					 |(void) prints receipt								|
|                 |                                             |									 |													|
|-----------------|---------------------------------------------|------------------------------------|--------------------------------------------------|
| `SMSService	` | `SendSMS(string message)				`	| Sends receipt of order			 |(void) Sends receipt by SMS						|
|                 |                                             |									 |													|
|-----------------|---------------------------------------------|------------------------------------|--------------------------------------------------|
| `Inventory	` | `GetInventory()							`	| Method for checking avaliable stock|(List<Item>) returns list with stock of items	    |
|                 |                                             |									 |													|
|-----------------|---------------------------------------------|------------------------------------|--------------------------------------------------|
