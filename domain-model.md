1.
As a member of the public,
So I can order a bagel before work,
I'd like to add a specific type of bagel to my basket.

| Classes         | Methods                                     | Scenario                  | Outputs                               |
|-----------------|---------------------------------------------|---------------------------|---------------------------------------|
| `Basket`	        | `addItem(Item item)`                      | any			            | void			            |

2.
As a member of the public,
So I can change my order,
I'd like to remove a bagel from my basket.

| Classes         | Methods                                     | Scenario                  | Outputs                               |
|-----------------|---------------------------------------------|---------------------------|---------------------------------------|
| `Basket`	        | `removeItem(Item item)`                | bagel exist			    | true			            |
|                 |                                             | no such bagel			    | false			            |

3.
As a member of the public,
So that I can not overfill my small bagel basket
I'd like to know when my basket is full when I try adding an item beyond my basket capacity.

| Classes         | Methods                                     | Scenario                  | Outputs                               |
|-----------------|---------------------------------------------|---------------------------|---------------------------------------|
| `Basket`	      | `isFull()`                                  | basket full			    | true			            |
|                 |                                             | basket not full		    | false			            |

4.
As a Bob's Bagels manager,
So that I can expand my business,
I’d like to change the capacity of baskets.

| Classes         | Methods                                     | Scenario                  | Outputs                               |
|-----------------|---------------------------------------------|---------------------------|---------------------------------------|
| `Basket`	        | `changeBasketCapacity(int newCapacity)`   | any			            | void			                        |

5.
As a member of the public
So that I can maintain my sanity
I'd like to know if I try to remove an item that doesn't exist in my basket.

| Classes         | Methods                                     | Scenario                  | Outputs                               |
|-----------------|---------------------------------------------|---------------------------|---------------------------------------|
| `Basket`	      | `doesItemExist(Item item)`                  | item removed              | true                                  |
|                 |                                             | no such item			    | false, print "No such item"		    |

6.
As a customer,
So I know how much money I need,
I'd like to know the total cost of items in my basket.

| Classes         | Methods                                     | Scenario                  | Outputs                                     |
|-----------------|---------------------------------------------|---------------------------|---------------------------------------------|
| `Basket`	      | `getBasketCost()`                           | has content               | total price of content in basket as double  |
|                 |                                             | empty basket			    | 0                         		          |

7.
As a customer,
So I know what the damage will be,
I'd like to know the cost of a bagel before I add it to my basket.

| Classes         | Methods                                     | Scenario                  | Outputs                               |
|-----------------|---------------------------------------------|---------------------------|---------------------------------------|
| `Bagel`	      | `getPrice()`                                | any                       | price of bagel as double              |

8.
As a customer,
So I can shake things up a bit,
I'd like to be able to choose fillings for my bagel.

| Classes         | Methods                                     | Scenario                  | Outputs                               |
|-----------------|---------------------------------------------|---------------------------|---------------------------------------|
| `Bagel`         | `addFilling(Filling filling)`               | any                       | void                                  |


9.
As a customer,
So I don't over-spend,
I'd like to know the cost of each filling before I add it to my bagel order.

| Classes         | Methods                                     | Scenario                  | Outputs                               |
|-----------------|---------------------------------------------|---------------------------|---------------------------------------|
| `Filling`       | `getPrice()`                                | any                       | price of filling                      |

10.
As the manager,
So we don't get any weird requests,
I want customers to only be able to order things that we stock in our inventory.

| Classes         | Methods                                     | Scenario                  | Outputs                               |
|-----------------|---------------------------------------------|---------------------------|---------------------------------------|
| `Inventory`     | `getItemsInInventory()`                     | any                       | List<Item> inventoryItems             |