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
|          |										 |							  |
|__________|_________________________________________|____________________________|                                                                       
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
|Manager   |                                         |                            |
|          |                                         | 							  |
|          |                                         |                            |
|          |ChangeCapacity(int newCapacity)          |NewCapacity is non-negative |true   
|          |                                         |                            |   
|          |                                         |NewCapacity is negative     |false   
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
|__________|_________________________________________|____________________________|______________________________________                                                        
                                                                                                                   