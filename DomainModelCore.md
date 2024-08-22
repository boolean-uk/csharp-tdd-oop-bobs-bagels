 ## USER-STORIES
1.
As a member of the public,
So I can order a bagel before work,
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
I�d like to change the capacity of baskets. 

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


-----------------------------------------------------
## EXTENSIONS

1.
As a customer,
So I can choose special offers,
I want customers to be able to see special offers and get discount on the receipt

2.
As a customer,
So I can see what i bought,
I want customers to get a receipt of what items they bought

3.
As a customer,
So i can see the correct price,
I want customers to see the discount if there is one on the items they bought

4. Textmessage
Part 1:
- Users should receive a text message with their order summary, 
  and delivery time when they complete their order.



| Classes         | Methods                                            | Scenario											| Outputs    |
|-----------------|----------------------------------------------------|----------------------------------------------------|------------|
| `Item`          | `Public Item(string id, double price, `            | Item can be either Bagel, Coffe or Filling	        | Double     |
|                 | `string name, string variant)`                     |								                    |            |
|                 |                                                    |								                    |            |
| `Person`        | `Public Person(string name, Role role)`            | Person can be a Manager or Customer                | Person     |
|                 | `Public Enum Role {CUSTOMER, MANAGER}`             |								                    |            |
|                 |                                                    |								                    |            |
| `Inventory`     | `Public List<Item> Inventory`                      | List of all of the Items in Bobs inventory         | List<Item> |
|                 |                                                    |								                    |            |
|                 |                                                    |								                    |            |
| `Basket`        | `Inventory inventory`                              | Property for Bobs inventory					    | List<Item> |
|                 | `List<Item> basket = new List<Item>()`			   | Basket-list for all the Items                      | List<Item> | 
|                 |                                                    |								                    |            |
|       		  | `AddItem(Item item)`                               | User order bagel/filling/coffee to basket-list     | bool       |
|                 |                                                    | If Bagel/Coffe/filling not in inventory (message)	| bool       |
|                 |                                                    | If basket is full (message)	                    | bool       |
|                 |                                                    |								                    |            |
|                 | `RemoveBagelOrItem(Item item)`					   | User can remove bagel from basket					| bool       |
|                 |													   | No bagel found to remove (message)					| bool       |
|                 |                                                    |								                    |            |
|                 | `public int MaxBasketSize { get; set; } = int`     | Property for holding and setting full basket value | int        |
|                 |                                                    |								                    |            |
|                 |                                                    |								                    |            |
|                 |                                                    |								                    |            |
|                 | `ChangeBasketCapacity(int capacity, Role role)`    | If Role is Manager the basket capacity can 	    | int        |
|                 |                                                    | be changed								            |            |
|                 |                                                    |								                    |            |
|                 | `TotalCost()`                                      | Sum of all the items in the basket	                | Double     |
|                 |                                                    |								                    |            |
|                 | `GetPriceOfItem(Item item)`                        | User can see the price of a specific item          | Double     |
|                 |                                                    |								                    |            |
|-----------------|----------------------------------------------------|----------------------------------------------------|------------|
|                 |                                                    |								                    |            |
| `Basket`        | `Discount()`                                       | If special offer decided by count of items it      | double     |
|                 |                                                    | gives a discount				                    |            |
|                 |                                                    |								                    |            |
|                 | `Receipt()`                                        | Displays all the items a customer has bought       | void       |
|                 |                                                    |								                    |            |
|                 | `ReceiptWithDiscount()`                            | Displays the items bought with discount	        | void       |
|                 |                                                    | (if discount)							            |            |
|                 |                                                    |								                    |            |
|                 |                                                    |								                    |            |
|                 |                                                    |								                    |            |
|-----------------|----------------------------------------------------|----------------------------------------------------|------------|


