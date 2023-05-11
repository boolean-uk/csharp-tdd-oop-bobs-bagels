1.
As a member of the public, So I can order a bagel before work, 
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


| Classes			|Methods						|Scenario							|Output
--------------------|-------------------------------|---------------------------------------|------------
Basket				| AddBagel						| if item is not already in list		| basketlist + item
					|								| if item is already in list			| add quantity to item				
--------------------|-------------------------------|---------------------------------------|------------
Basket				| RemoveBagel					| if item is in list					| removes item
					|								| if item is not in list				| gives message "item does not exist"
--------------------|-------------------------------|---------------------------------------|------------
Basket				| AddBagel						| if basketlist < BasketListMax			| execute add method
					|								| if basketlist = BasketListMax			| gives message "Basket is full"
--------------------|-------------------------------|---------------------------------------|------------
Basket				| ChangeBasketMax				| if current basketlist.count < value	| BasketListmax = value
					|								| if current basketlist.count > value	| gives message "cannot change basket lower than current items"
--------------------|-------------------------------|---------------------------------------|------------
Basket				| TotalPrice					| if Basket is not empty				| calculate price of all items times quantity and show them in console
--------------------|-------------------------------|---------------------------------------|------------
BagelsInventory		| BagelPriceList				| opening app							| shows a list of bagels with their prices
--------------------|-------------------------------|---------------------------------------|------------
Basket				| AddFilling					| if there is a bagel && filling exist  | adds filling to bagel
FillingInventory	| FillingPriceList				| opening app							| shows a list of Fillings with their prices
--------------------|-------------------------------|---------------------------------------|------------


--------------------|-------------------------------|---------------------------------------|------------
					|								|									|