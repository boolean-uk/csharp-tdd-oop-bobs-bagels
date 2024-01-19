.
As a member of the public,
So I can order a bagel before work,
I'd like to add a specific type of bagel to my basket.
verbs/actions: add bagel type, order(I deem this out of scope of exercise)
method: bool addBagel(Item itemType, int amount)

2.
As a member of the public,
So I can change my order,
I'd like to remove a bagel from my basket.
verbs/actions: remove a bagel
method: bool removeBagel(Item itemType, int amount)

3.
As a member of the public,
So that I can not overfill my small bagel basket
I'd like to know when my basket is full when I try adding an item beyond my basket capacity.
verbs/actions: know when basket is full
method: int checkCurrentCapacity();

4.
As a Bob's Bagels manager,
So that I can expand my business,
I�d like to change the capacity of baskets.
verbs/actions: change basket size
method: bool changeBasketSize(int newSize)

5.
As a member of the public
So that I can maintain my sanity
I'd like to know if I try to remove an item that doesn't exist in my basket.
verbs/actions: know if bagel exists
method: bool isItemInBasket();

6.
As a customer,
So I know how much money I need,
I'd like to know the total cost of items in my basket.
verbs/actions: know total cost
method: double checkTotalCost() //Collection.Sum

7.
As a customer,
So I know what the damage will be,
I'd like to know the cost of a bagel before I add it to my basket.
verbs/actions: know cost of bagel
method: double checkPriceOfBagel(string bagelType)

8.
As a customer,
So I can shake things up a bit,
I'd like to be able to choose fillings for my bagel.
verbs/actions: choose fillings
method: bool chooseFilling(string filling)

9.
As a customer,
So I don't over-spend,
I'd like to know the cost of each filling before I add it to my bagel order.
verbs/actions:  know filling cost
method: double checkPriceOfFilling(string filling)

10.
As the manager,
So we don't get any weird requests,
I want customers to only be able to order things that we stock in our inventory.
verbs/actions: know what's in inventory
method: bool isItInInventory(string item)

---------------------------------------------------------------------------------------------------------------------
`Extension user stories`
---------------------------------------------------------------------------------------------------------------------
11. 
As a customer,
So I am encouraged to buy more,
I'd like to get discounts on bagels.

12. 
As a customer,
So I can get a quick breakfast and get my dose of caffeine,
I'd like to get discounts when I buy a combo of bagel and coffee.

13.
As a customer,
So I can keep track of my spendings and personal finance,
I'd like to get a receipt printed out.

14.
As a customer,
So I can see how much money I've saved,
I'd like the receipt to also state how much money I've saved if I bought a discount.


| Classes             | Members                             | Methods                                                | Scenario                                           | Outputs   |
|---------------------|-------------------------------------|--------------------------------------------------------|----------------------------------------------------|-----------|
| `Basket`	          | List<Product> products              | bool AddProduct(string productName, int amount)        | If Product was added						          | true      |
|        	          |                                     |                                          			     | If Product was NOT added						      | false     |
| 	                  |                                     | bool RemoveProduct(string productName, int amount)	 | If Product was removed						      | true      |
|        	          |                                     |                                          			     | If Product was NOT removed						  | false     |
|        	          |                                     | bool IsProductInBasket()                   			 | If Product is in basket						      | true      |
|        	          |                                     |                                          			     | If Product is NOT in basket						  | false     |
|        	          |                                     | int TotalCapacity()                                    | 						                              | int       |
|        	          |                                     | int CheckCurrentCapacity()                             | 						                              | int       |
|                     |                                     | double CheckTotalCost()		                         | 						                              | double    |
| `Product`           |                                     | double CheckPriceOfProduct()                           | 						                              | double    |
| `Bagel (subclass)`  | Product filling                     | bool ChooseFilling(string filling)                     | Filling was was used as filling					  | true      |
|        	          |                                     |                                                        | Filling was was NOT used as filling		     	  | false     |
|       	          |                                     | double CheckPriceOfProduct()                           | Overload to calculate with filling                 | double    |
|       	          |                                     |                                                        | Overload to calculate with NO filling              | double    |
| `Coffee (subclass)` |                                     |                                                        |                              					  |           |
| `Filling (subclass)`|                                     |                                                        |                              					  |           |
| `Store`          	  | List<Tuple> skuList                 | bool IsProductInInventory(Product productName)         | If Product is in inventory                         | true      |
|        	          | List<Tuple> discountCombos          |                                                        | If Product is NOT in inventory 		              | false     |
|                     |                                     | bool ChangeBasketSize(int newSize)			         | If basketSize was changed (isManager)			  | true      |
|        	          |                                     |                                          			     | If basketSize was NOT changed (!isManager)	      | false     |
| `Person`            |  Basket personalBasket              |                                   			         | 			                                          |           |
|                     |                                     | can call on the store methods			                 | 			                                          |           |
| `CashRegister`      |                                     | double CheckTotalCost()		                         | 						                              | double    |
