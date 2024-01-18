| Classes   | Methods						       | Scenario												                                        | Outputs                         |
|-----------|--------------------------------------|------------------------------------------------------------------------------------------------|---------------------------------|
| `Basket`  | `AddItem(AddItem(Item item))`		   | Adds a specific type of items (bagel, coffee, filling)                                         | Item is added to the basket	  |
|           |                                      | to the basket                                                                                  |								  |
|-----------|--------------------------------------|------------------------------------------------------------------------------------------------|---------------------------------|
| `Basket ` | ` RemoveItem(Item item) `	           | change my order by removing a bagel from my basket                                             | Item is removed from the basket |
|-----------|--------------------------------------|------------------------------------------------------------------------------------------------|---------------------------------|
| `Basket`  | `IsFull()`                           |  I want to know when my basket is full				                                            |True or False                    |
|-----------|------------------------------------------------------|--------------------------------------------------------------------------------|---------------------------------|
| `Basket`	|  `ChangeCapacity(int newCapacity)`   | I'd like to change the capacity of baskets			                                            | Updated Basket capacity         |
|-----------|--------------------------------------|------------------------------------------------------------------------------------------------|---------------------------------|
| `Basket`  | `CalculateTotalCost()`               | Total cost considering individual prices and offers                                            | Total costs				      |
|-----------|--------------------------------------|------------------------------------------------------------------------------------------------|---------------------------------|
| `Bagel `  | ` CalculateCost(int quantity)  `     |Calculates the cost of purchasing a certain quantity                                            |	Cost                          |
|			|									   |of bagel and applies the offer if there are any.                                                |                                 |
|------------|--------------------------------------|-----------------------------------------------------------------------------------------------|---------------------------------|
| `Coffee`   |                                      |													                                            |			                      |										  |
|------------|--------------------------------------|-----------------------------------------------------------------------------------------------|---------------------------------|
| `Filling`	 |		   							    |Filling is a type of Item with a specific category and price.								    |			                      |
|------------|--------------------------------------|-----------------------------------------------------------------------------------------------|---------------------------------|
| `Item`     | `CalculateCost(int quantity)`	    |Calculates the total cost of purchasing a specified quantity of the item.                      |                                 |
|------------|--------------------------------------|-----------------------------------------------------------------------------------------------|---------------------------------|
|`Inventory` | `GetItemBySKU(string sku))`          |Get item details (name, variant, price, offers) based on its SKU                               |                                 |
|------------|--------------------------------------|-----------------------------------------------------------------------------------------------|---------------------------------|
|`Inventory` | `IsItemInInventory(string sku)`      |Determines whether an item with the specified SKU is present in the inventory                  | False or True				      |							     |													  |
|------------|--------------------------------------|-----------------------------------------------------------------------------------------------|---------------------------------|
|`BagelOffer`| `CalculateDiscount(int quantity)`	|Calculates the total discount for a specified quantity based on the offer conditions           |  The total discount amount      |									     |											          |
|------------|--------------------------------------|-----------------------------------------------------------------------------------------------|---------------------------------|
| `Receipt`  | Main(): Entry point of the application. Creates instances of Inventory and OrderManager. Creates a sample order with quantities. Calls DisplayOrderSummary method from OrderManager to display the order summary. 

  