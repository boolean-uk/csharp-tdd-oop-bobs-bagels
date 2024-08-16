 this is my domain






|Classes   |Methods                                  |Scenarios                   |output
|__________|_________________________________________|____________________________|______________________________
|Customer  |Customer(int funds, int id)              |Create a new customer with  |--------
|          |                                         |funds to spend and a        |
|          |                                         |customer ID.                |
|          |                                         |                            |
|          |ViewMenu()                               |Present a menu with         |--------- 
|          |                                         |bagels and                  | 
|          |                                         |fillings.                   |    
|          |                                         |                            |
|          |                                         |                            |
|          |AddToBasket(string bagel, int funds,     |Manager accepts order       |true            
|          |int id)                                  |                            |
|          |AddToBasket(string bagel, int funds,     |                            |
|          |int id, string filling)                  |                            |
|          |                                         |                            |
|          |                                         |                            |
|          |                                         |Manager declines order.     |false
|          |                                         |                            |
|          |                                         |                            |         
|          |                                         |                            |                              
|          |                                         |                            |
|          |RemoveBagel(string)                      |Removes bagel if it exists  |true
|          |                                         |and manager updates capcaity|
|          |                                         |                            |
|          |                                         |Bagel does not exist        |false
|          |                                         |                            |
|          |ShowCost()                               |Calls basket to output cost |string
|          |										 |of items in basket		  |
|          |										 |							  |
|          |										 |							  |
|__________|_________________________________________|____________________________|                                                                       
|Manager   |                                         |                            |
|          |                                         | 							  |
|          |ConfirmOrder(string bagel, int funds, int|Funds are sufficient for 	  |true
|          |id)                                      |order, items is on the menu |
|          |ConfirmOrder(string bagel, int funds, int|and basket capacity not full|
|          |id, string filling)                    	 |                            |
|          |                                         |                            |
|          | 										 |Funds are insufficient for  |false
|          | 										 |order or item is not on menu|
|          | 										 |or capacity is full         |
|          |                                         |                            |
|          |ChangeCapacity(int newCapacity)          |NewCapacity is non-negative |true     
|          |                                         |and no customer basket is   |
|          |                                         |is affected.                |                
|          | 										 |                            |
|          |                                         |NewCapacity is non-negative |true   
|          |                                         |and at least one customer   |   
|          |                                         |basket is now overfull and  |   
|          |                                         |therefore emptied.          |   
|          |                                         |                            |   
|          |                                         |NewCapacity is negative     |false   
|__________|_________________________________________|____________________________|                                                                       
|Basket    |                                         |                            |          
|          | ShowCost()                              |Shows sum of bagels in order|string                                                                             
|          |                                         |                            |         
|          | Add(string bagel, int funds,            |order added to basket       |------                                                            
|          |                                         |                            |                                          
|          | Add(string bagel, int funds,   		 |order added to basket       |------
|          | string filling)                         |							  |
|          |										 |                            |
|          |Remove(string bagel)                     |Item exists in basket       |true
|          |                                         |							  |
|          |                                         |Item does not exists in 	  |false
|          |                                         |basket.					  |
|          |										 |                            |
|          |Remove(string bagel,                     |Item exists in basket       |true
|          |string filling)                          |							  |
|          |                                         |Item does not exists in 	  |false
|          |										 |basket.					  |
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
|__________|_________________________________________|____________________________|______________________________________                                                        
                                                                                                                   