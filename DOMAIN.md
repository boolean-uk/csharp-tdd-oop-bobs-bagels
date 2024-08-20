 this is my domain






|Classes   |Methods                                  |Scenarios                   |output
|__________|_________________________________________|____________________________|______________________________
|Customer  |Customer(int funds)                      |Create a new customer with  |--------
|          |                                         |funds to spend              |
|          |                                         |                            |
|          |                                         |                            |
|          |ViewMenu()                               |Present a menu with         |--------- 
|          |                                         |bagels and                  | 
|          |                                         |fillings.                   |    
|          |                                         |                            |
|          |EXTENTION 1: Showcost                    |Presents specials in menu   |
|          |                                         |                            |
|          |AddToBasket(string name, string variant  |Manager accepts order       |true            
|          | double remainingfunds)                  |                            |
|          |                                         |                            |
|          | AddToBasket(string name, string variant |                            |
|          |double remainingfunds,string filling)    |Manager declines order.     |false
|          |                                         |                            |
|          |                                         |                            |         
|          |                                         |                            |                              
|          |                                         |                            |
|          |RemoveItem(string name, string variant)  |Removes  item if it exists  |true
|          |                                         |and manager updates capcaity|
|          |                                         |                            |
|          |                                         | Itemn does not exist        |false
|          |                                         |                            |
|          |ShowCost()                               |Calls basket to output cost |double
|          |										 |of items in basket		  |
|          |										 |							  |
|          |EXTENSION 1: Showcost()                  |Discounts oppertunities     |double
|          |										 |discovered and applied      |
|          |										 |							  |
|          |EXTENSION 2: Purchase()            		 |Calls for a manager receipt.| true
|          |										 |Basket is not empty         |
|          |										 |	Then empties basket       |
|          |										 |							  |
|          |										 |Calls for a manager receipt.| false
|          |										 |Basket is empty             |
|          |										 |          				  |
|          |										 |							  |
|__________|_________________________________________|____________________________|                                                                       
|Manager   |                                         |                            |
|          |                                         |                            |
|          |ConfirmOrder(string namne, string variant|                            |
|          |, double remainingFunds, int basketSize) |                            |
|          |                                         |Funds are sufficient for 	  |true
|          |                                         |order, items is on the menu |
|          |                                         |and capcaity no full        |
|          |                                         |                            |
|          | 										 |Funds are insufficient for  |false
|          | 										 |order or item is not on menu|
|          | 										 |or capacity is full         |
|          |                                         | 							  |
|          |                                         |                            |
|          |ChangeCapacity(int newCapacity)          |NewCapacity is non-negative |true   
|          |                                         |                            |   
|          |                                         |NewCapacity is negative     |false   
|          |                                         | 							  |
|          |  EXTENSION 2                            | 							  |
|          | PrintReceipt(Basket basket)             |Calls Receipt.PrintReceipt  |-------
|          |                                         | 							  |
|          |                                         | 							  |
|__________|_________________________________________|____________________________|                                                                       
|Basket    |                                         |                            |          
|          | ShowCost()                              |Shows sum of bagels in order|double                                                                             
|          |                                         |                            |         
|          | Add(string name, string variant)        |order added to basket       |------                                                            
|          |                                         |                            |                                          
|          |                                         |							  |
|          |Remove(string name, string variant)      |Item exists in basket       |true
|          |                                         |							  |
|          |                                         |Item does not exists in 	  |false
|          |                                         |basket.					  |
|__________|_________________________________________|____________________________|                                                                       
|Inventory |  									     |							  |
|          |IsInInventory(string name, string variant)|Item exists in inventory    |true                                                                                                              
|          |                                         |                            |                                     
|          |                                         |Item does not exist in      |false                                                           
|          |                                         |inventory                   |                                              
|          |                                         |                            |                                     
|          |GetPrice(string name, string variant)    |Item exists in inventory    |double cost                                                                                      
|          |                                         |                            |                                                                      
|          |                                         |Item does not exist in      |-1                                                                 
|          |                                         |inventory                   |                                                                      
|__________|_________________________________________|____________________________|       
|Receipt   |EXTENSION2   							 |							  |
|          |										 |							  |
|          |PrintReceipt(Basket)   					 |Prints receipt of items in  | string
|          |										 |basket		         	  |
|          |										 |							  |
|          |										 |							  |
|          |										 |							  |
|          |										 |							  |
|          |										 |							  |
|          |										 |							  |
|          |										 |							  |
|          |										 |							  |
|__________|_________________________________________|____________________________|______________________________________                                                        
                                                                                                           
                                                                                                           


Extension 2
As a customer, I'd like to recieve a receipt, so that I know I was charged correctly.