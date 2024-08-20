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
| InventoryItem | double Price { get; set; }			|																		| property to set Price						|
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| InventoryItem | string Name { get; set; }				|																		| property to set Name						|
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| InventoryItem | string Variant { get; set; }			|																		| property to set Variant					|
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| InventoryItem	|										| InventoryItem(string sku, double price, string name, string variant)	| constructor 								| InventoryItem
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

| BobsInventory | List<InventoryItem> BobsInventory		| 																		| list of available inventory items			| 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| BobsInventory | 										| BobsInventory()														| constructor								| BobsInventory
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| BobsInventory | double GetCostofItem { get; set; }	| 																		| property to get cost of item				| double
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| BobsInventory | string ItemVariant { get; set; }		| 																		| property to set variant of item			| string
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

| Basket		| List<InventoryItem> Basket			| 																		| list of inventory items in basket			| 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| Basket		|										| AddItem(string variant)												| if basket is not full add bagel			| true
| Basket		|										|																		| if basket is full							| false
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| Basket		| 										| RemoveItem(string variant)											| if bagel is not in basket					| false
| Basket		|										|																		| if bagel is in basket						| true
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| Basket		|										| ChangeCapacity(int capacity, bool IsManager)							| if IsManager is true set new capacity		| true
| Basket		|										|																		| if IsManager is false	don't change		| false
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| Basket		| int BasketCapacity { get; set; }		|																		| property to set maximum capacity 			| int
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| Basket		| bool IsInInventory { get; set; }		|																		| property to check if item is in inventory	| bool
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| Basket		| bool IsManager { get; set; }			| 																		| property to check for manager				| bool
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| Basket		| bool IsInBasket { get; set; }			| 																		| property to check if item is in basket	| bool
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| Basket		| double TotalCost { get; set; }		| 																		| property to get cost of basket			| double
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

