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

Basket class and BasketTest class

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



| Classes     | Methods											  | Scenario                     | Outputs			 |
|-------------|---------------------------------------------------|------------------------------|-------------------|
| `Basket`    | `Add(List<String> basket, String bagel)`		  | The basket is not full       | add bagel type    |
|`_capacity=5`|												      | The basket is full           | dont add bagel    |
|			  | `Remove(List<String> basket, String bagel)`	      | If bagel is in basket        | remove            |
|		      |													  | If bagel is not in basket    | does not exist    |
|`_isManager` | `UpdateCapacity(List<String> basket, int newcap)` | If isManager change capacity | new capacity 	 |

Added the new user stories and the inventory, I will add some objects of bagels to implement the SKU, Price Name and Variant.
I will add the option Filling that (if chosen) will add to the base price before adding it to the basket.
I will change all bagels from strings to objects everywhere.

|			  |	`Sum(List<Object> basket)`						  | The total cost of the basket	   | sum				 |
|			  | `Add(List<Object> basket, bagel)`				  | Show cost and confirm before adding| cost and confirm	 |
|		      |	`AddFillings(List<Object> basket, bagel, filling)`| Add fillings to a bagel		       | check price and add |



SKU	    Price	 Name		Variant
BGLO	0.49	 Bagel		Onion
BGLP	0.39	 Bagel		Plain
BGLE	0.49	 Bagel		Everything
BGLS	0.49	 Bagel		Sesame
COFB	0.99	 Coffee		Black
COFW	1.19	 Coffee		White
COFC	1.29	 Coffee		Capuccino
COFL	1.29	 Coffee		Latte
FILB	0.12	 Filling	Bacon
FILE	0.12	 Filling	Egg
FILC	0.12	 Filling	Cheese
FILX	0.12	 Filling	Cream Cheese
FILS	0.12	 Filling	Smoked Salmon
FILH	0.12	 Filling	Ham