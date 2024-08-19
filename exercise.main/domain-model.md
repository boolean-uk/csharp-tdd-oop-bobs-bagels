User Stories
1. As a member of the public, So I can order a bagel before work, I'd like to add a specific type of bagel to my basket.
2. As a member of the public, So I can change my order, I'd like to remove a bagel from my basket.
3. As a member of the public, So that I can not overfill my small bagel basket, I'd like to know when my  basket is full when I try adding an item beyond my basket capacity.
4. As a Bob's Bagel manager, So that I can expand my business, I'd like to change the capacity of baskets.
5. As a member of the public, So that I can maintain my sanity, I'd like to know if I try to remove an item that doesn't exist in my basket.
6. As a customer, So I know how much money I need, I'd like to know the total cost of items in my basket.
7. As a customer, So I know what the damage will be, I'd like to know the cost of a bagel before I add it to my basket.
8. As a customer, So I can shake things up a bit, I'd like to be able to choose fillings for my bagel.
9. As a customer, So I don't over-spend, I'd like to know the cost of each filling before I add it to my bagel order.
10. As a manager, So we don't get any weird requests, I want customer to only be able to order things that we stock in our inventory.

	
| Classes		| Members								| Methods																| Scenario									| Output
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| InventoryItem | string SKU { get; set; }				|																		| property to set SKU						|
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| InventoryItem | decimal Price { get; set; }			|																		| property to set Price						|
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| InventoryItem | string Name { get; set; }				|																		| property to set Name						|
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| InventoryItem | string Variant { get; set; }			|																		| property to set Variant					|
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| InventoryItem	|										| InventoryItem(string SKU, decimal Price, string Name, string Variant)	| constructor 								| InventoryItem
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

| BobsInventory | List<InventoryItem> BobsInventory		| 																		| list of available inventory items			| BobsInventory
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| BobsInventory | decimal CostofItem { get; set;}		| 																		| property to get cost of item				| CostofItem
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

| Basket		| List<InventoryItem> Basket			| AddItem(InventoryItem)												| if basket is not full add bagel			| True
| Basket		|										|																		| if basket is full							| False
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| Basket		| 										| RemoveItem(InventoryItem)												| if bagel is not in basket					| False
| Basket		|										|																		| if bagel is in basket						| True
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| Basket		| bool IsInInventory					|																		| property to check if item is in inventory	| True
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| Basket		| int BasketCapacity { get; set; }		|																		| property to set maximum number 			| int
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| Basket		| bool IsBasketFull { get; set; }		|																		| property to check if basket is full 		| bool
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| Basket		| bool IsManager { get; set; }			| 																		| property to check for manager				| bool
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| Basket		|										| ChangeCapacity(int capacity, bool IsManager)							| if IsManager is true set new capacity		| BasketCapacity
| Basket		|										|																		| if IsManager is false	don't change		| BasketCapacity
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| Basket		| decimal TotalCost{ get; set;}			| 																		| property to get cost of basket			| TotalCost
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| Basket		|										| TotalCostofBasket()													| adds up cost of items in basket			| TotalCost
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
