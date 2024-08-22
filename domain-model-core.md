




  | Classes       | Members			    | Methods										 	   | Scenario					       	                   | Outputs 			    
  |---------------|---------------------|------------------------------------------------------|-------------------------------------------------------|-------------------------------------------|
  | `Basket`      | property MaxCapacity|												       | default 5  										   |				
  |			      | property BasketItems|												       | List to expose all items in Basket     	           | 	
  |			      | property IsManager  |												       | bool								    			   |
  |			      | property Inventory  |												       | 											           |
  |			      | property PrintReceipt | 											       | 											           | returns GetReceipt()
  |			      |					    | AddItem(item)			     						   | method add to Basket, if basket not full and item is  | bool true if added 
  |	 			  |					    |													   | - in inventory										   | 
  |				  |					    | RemoveItem(item)									   | method remove bagel from Basket, if already exists    | bool true if removed
  |			      |					    | RemoveNonExistingItem()							   | method check if nonexisting item will not be removed  | bool true if not removed
  |				  |					    | GetTotalCost()								       | sums the total cost of all items in Basket		       | return double cost														
  |	 			  |					    | ChangeCapacity(int newCapacity, bool IsManager)	   | update MaxCapacity member if IsManager				   | bool true if changed
  |	 			  |					    | GetDiscount()										   | 													   | double 	
  |	 			  |					    | GetReceipt()										   | creates the receipt								   | string receipt	
  -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
  |	`Inventory`   |	List<Item>          |													   | collection of all items						   	   | 
  -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
  |	`Item`        |	property SKU        |													   |													   |			
  |			      | property Name       |													   |													   |
  |				  | property Cost       |													   |													   |
  |				  | property Type       |										 			   |													   |
  |				  |				        | GetItemCost(item)						 			   | get cost if item									   | int 	
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
  |	`Bagel`       |					    | AddFilling(item)									   | add item filling to basket							   | void											           
  -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
  |	`Filling`     |				        |													   |											      	   |
  -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
  |	`Coffee`      |				        |													   |											      	   |
  -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|

