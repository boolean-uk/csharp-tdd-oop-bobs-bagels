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

--


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


---- Extension 2 ----
As a customer,
So i can see that the total is correct,
I'd like to receive a receipt that shows the entire basket after checkout




| Classes       | Methods			     	  |  Scenario								 | Outputs      |
| ------------- | -------------	     		  |  ------------							 | -----------  |
| `Basket`		| AddItem(string sku)	      |  Adds item to basket by sku				 | true			|
|				|							  |  Item is not in inventory		         | false		|
|				|							  |  Basket is full					         | false		|

| `Basket`      | RemoveItem(Item item)       |  Removes item from basket			     | true         |
|               |				    		  |  Given item does not exist in basket     | false        |

| `Basket`      | ChangeCapacity(int capacity)|  Changes baskets capacity to 'capacity'	 | true         |
|               |                             |  'capacity' is lower than item count     | false        |
|               |                             |  'capacity' is same as current capacity  | false        |
|               |                             |  'capacity' is a negative number or 0    | false        |

| `Basket`      | CheckBasketCost()		      |  Checks total cost of items in basket	 | int          |
|               |                             |                                          |	            |
| `Item`        | CheckItemCost()		      |  Checks cost of item 			    	 | int          
|               |                             |                                          |	            |
| `Bagel`       | AddFilling()				  |  Adds filling to bagel			    	 | true         |
|               |           				  |  Filling is not in inventory	    	 | false         |
|               |                             |                                          |	            |
| `Bagel`       | RemoveFilling(string sku)	  |  Removes filling by filling sku		   	 | true         |
|               |                             |                                          |	            |


