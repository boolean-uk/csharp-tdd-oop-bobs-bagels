1. and 3.
As a member of the public,
So I can order a bagel before work,
I'd like to add a specific type of bagel to my basket.


As a member of the public,
So that I can not overfill my small bagel basket
I'd like to know when my basket is full when I try adding an item beyond my basket capacity.



| Classes         | Methods                                          | Scenario                                                         | Outputs                             |
|-----------------|--------------------------------------------------|------------------------------------------------------------------|-------------------------------------|
| `Basket`        | `Add(string bagelName)`                          | if capacity is not overfilled                                    | put bagelName in a capacity list    |
|                 |                                                  |                                                                  |                                     |


2.
As a member of the public,
So I can change my order,
I'd like to remove a bagel from my basket.


| Classes         | Methods                                          | Scenario                                                         | Outputs                             |
|-----------------|--------------------------------------------------|------------------------------------------------------------------|-------------------------------------|
| `Basket`        | `Remove(string bagelName)`                       | if bagelName is in Basket                                        | remove Bagel from the list          |
|                 |                                                  | if bagelName is not in Basket                                    | dont remove to the list             |
|                 |                                                  |                                                                  |                                     |
|                 |                                                  |                                                                  |                                     |


4.
As a Bob's Bagels manager,
So that I can expand my business,
I’d like to change the capacity of baskets.


| Classes         | Methods                                          | Scenario                                                         | Outputs                             |
|-----------------|--------------------------------------------------|------------------------------------------------------------------|-------------------------------------|
| `Basket`        | `ExpandBasket(int expandWith)`                   |                                                                  | change basket capasity              |
|                 |                                                  |                                                                  |                                     |
|                 |                                                  |                                                                  |                                     |

5.
As a member of the public
So that I can maintain my sanity
I'd like to know if I try to remove an item that doesn't exist in my basket.

| Classes         | Methods                                          | Scenario                                                         | Outputs                                                                             |
|-----------------|--------------------------------------------------|------------------------------------------------------------------|-------------------------------------------------------------------------------------|
| `Basket`        | `Remove(string bagelName)`                       | Item is not present in basket                                    | prints `the item you are trying to remove is not present in the basket`             |
|                 |                                                  |                                                                  |                                                                                     |
|                 |                                                  |                                                                  |                                                                                     |


6.
As a customer,
So I know how much money I need,
I'd like to know the total cost of items in my basket.

| Classes         | Methods                                          | Scenario                                                         | Outputs                                                                             |
|-----------------|--------------------------------------------------|------------------------------------------------------------------|-------------------------------------------------------------------------------------|
| `Basket`      | `TotalCost(Basket basket )`                          | Basket is not empty                                              | gets the total of the items in the basket                                          |
|                 |                                                  |                                                                  |                                                                                     |
|                 |                                                  |                                                                  |                                                                                     |
| `Basket`      | `TotalCost(Basket basket )`                          | Basket is empty                                                  | gets the 0 dollars out                                                              |
|                 |                                                  |                                                                  |                                                                                     |
|                 |                                                  |                                                                  |                                                                                     |

7.
As a customer,
So I know what the damage will be,
I'd like to know the cost of a bagel before I add it to my basket.

| Classes         | Methods                                          | Scenario                                                         | Outputs                                                                             |
|-----------------|--------------------------------------------------|------------------------------------------------------------------|-------------------------------------------------------------------------------------|
|`Inventory`      | `GetPrice(Bagel bagel)`                        | Buy a bagel                                                      |gets out a price                                                                     |
|                 |                                                  |                                                                  |                                                                                     |
|                 |                                                  |                                                                  |                                                                                     |

8.
As a customer,
So I can shake things up a bit,
I'd like to be able to choose fillings for my bagel.

| Classes         | Methods                                          | Scenario                                                         | Outputs                                                                             |
|-----------------|--------------------------------------------------|------------------------------------------------------------------|-------------------------------------------------------------------------------------|
|`Bagel`      | `ChooseFilling(Filling filling)`                        | Buy a bagel with a specific filling                                                      |adjust price                                                                     |
|                 |                                                  |                                                                  |                                                                                     |
|                 |                                                  |                                                                  |                                                                                     |



9.

As a customer,
So I don't over-spend,
I'd like to know the cost of each filling before I add it to my bagel order.

| Classes         | Methods                                          | Scenario                                                         | Outputs                                                                             |
|-----------------|--------------------------------------------------|------------------------------------------------------------------|-------------------------------------------------------------------------------------|
|`Inventory`      | `GetPrice(Filling filling)`                             | Buy a bagel                                                      |gets out a price                                                                     |
|                 |                                                  |                                                                  |                                                                                     |
|                 |                                                  |                                                                  |                                                                                     |

10.
As the manager,
So we don't get any weird requests,
I want customers to only be able to order things that we stock in our inventory.

| Classes         | Methods                                          | Scenario                                                         | Outputs                                                                             |
|-----------------|--------------------------------------------------|------------------------------------------------------------------|-------------------------------------------------------------------------------------|
|`Basket`         | `buy(Bagel bagel)`                               | Basket in the menu                                               |return true, assign bagel to Customer Basket                                         |
|                 |                                                  |                                                                  |                                                                                     |
|`Basket`         | `buy(Bagel bagel)`                               | Basket is not in the menu                                        |  returnfalse, assign bagel to Customer Basket                                       |




| Classes         | Methods                                          | Scenario                                                         | Outputs                                                                             |
|-----------------|--------------------------------------------------|------------------------------------------------------------------|-------------------------------------------------------------------------------------|
|`Bagel`          |                                                  | initiate bagel object with a specific filling                    |object assigned with a specific filling                                     |
