# Domain model for Bob's Bagels


### User stories:
>1.
>As a member of the public,
So I can order a bagel before work,
I'd like to add a specific type of bagel to my basket.

> 2.
>As a member of the public,
So I can change my order,
I'd like to remove a bagel from my basket.

> 3.
>As a member of the public,
So that I can not overfill my small bagel basket
I'd like to know when my basket is full when I try adding an item beyond my basket capacity.

>4.
>As a Bob's Bagels manager,
So that I can expand my business,
I’d like to change the capacity of baskets.

>5.
>As a member of the public
So that I can maintain my sanity
I'd like to know if I try to remove an item that doesn't exist in my basket.

> 6.
>As a customer,
So I know how much money I need,
I'd like to know the total cost of items in my basket.

>7.
>As a customer,
So I know what the damage will be,
I'd like to know the cost of a bagel before I add it to my basket.

>8.
>As a customer,
So I can shake things up a bit,
I'd like to be able to choose fillings for my bagel.

>9.
>As a customer,
So I don't over-spend,
I'd like to know the cost of each filling before I add it to my bagel order.

>10.
>As the manager,
So we don't get any weird requests,
I want customers to only be able to order things that we stock in our inventory.


 
 
| Classes   | Methods | Scenario | Outputs |
|-----------|---------|----------|---------|
|`Inventory` |BagelPrice(string variant)|Checks the price of a bagel|double| 
|          |FillingPrice(string variant)|Checks the price of a filling|double|   
|		   |ShowInventory()| Show a list of what the customers can order from the bagelshop|List<InventoryProducts,> | 
|`InventoryProducts`|        |         |           
|	`Basket`	   |IsFull()| If the basket is full | true|
|		   |        | If the basket is not full| false |
|		   |TotalCost()| Finds the total cost of items in the basket| double|
|  |AddToBasket(string name, string variant);|Adds a bagel to the customers basket| true if added, false if not |  
|				|RemoveBagel(Bagel bagel)|If the bagel is in the basket, the bagel gets removed|true if removed, false if not|
|			|ChooseFilling(string variant)|Choose filling for the bagel| void|
|		|ChangeBasketCapacity(int capacity)|Changes the capacity of baskets| void  |     




