User Stories

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



Domain Model

| Classes         | Methods																					| Scenario									| Outputs     |
|-----------------|-----------------------------------------------------------------------------------------|-------------------------------------------|-------------|
| `Item`	      |	Public Item(string id, double price, string name, string variant)                      	| Can either be a bagel, coffee or fillings | Item        |
| 	         	  |	                                                                                    	|                                           |             |
|-----------------|-----------------------------------------------------------------------------------------|-------------------------------------------|-------------|
| `Inventory`	  |	Public List<Item> Inventory                                                         	| List over all of the available items      | List        |
| 	         	  |	                                                                                    	| Can only order from the inventory         |             |
|-----------------|-----------------------------------------------------------------------------------------|-------------------------------------------|-------------|
| `Person`	      |	Public Person(string name, Role role)                                               	| Person can be a Manager or a Customer     | Person      |
| 	         	  |	Public Enum Role {CUSTOMER, MANAGER}                                                	|                                           |             |
| 	         	  |	                                                                                    	|                                           |             |
|-----------------|-----------------------------------------------------------------------------------------|-------------------------------------------|-------------|
| `Basket`		  | addItem(Item bagel, Item filling?, Item coffee?)                                        | User ordered bagel based on the type		| bool        |
|                 |																							| Item not in inventory				    	| bool        |
| 	         	  |	                                                                                    	| User adds filling and/or coffe to bagel   | bool        |
| 	         	  |	                                                                                    	|                                           |             |
| 	         	  |	                                                                                    	|                                           |             |
|                 |																							|											|             |
|				  |																							|                                           |             |
|                 | removeBagels(Item item) 																| User removed item from basket		    	| string      |
|                 |																							| The item didnt exist						| string   	  |
|				  |																							|                                           |             |
|                 | public int basketMaxSize																| Property to holding/setting the basket    | int         |
|                 | Modify addItem to check if full		    												|											| bool  	  |
|                 |																							|                                           |             |
|                 | changeCapasity(int capacity, Role role)                         						| Manager wants to change the basket size   | void (none) |
|				  |																							|                                           |             |
| 	         	  |	checkPrice(string type)                                                             	| Customers wants to see prices             | List        |
| 	         	  |	                                                                                    	|                                           |             |
| 	         	  |	                                                                                    	|                                           |             |
| 	         	  |	                                                                                    	|                                           |             |
| 	         	  |	                                                                                    	|                                           |             |
						