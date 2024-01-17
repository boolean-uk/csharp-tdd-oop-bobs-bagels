Domain Model:

## Basket Class:

Properties:

Items: List of items in the basket.
Capacity: Maximum capacity of the basket.
Methods:

AddItem(item): Adds an item to the basket.
RemoveItem(item): Removes an item from the basket.
IsFull(): Checks if the basket is full.


## Bagel Class:

Properties:
SKU: Unique identifier.
Price: Price of the bagel.
Name: Name of the bagel.
Variant: Bagel variant.
Coffee Class:

Properties:
SKU: Unique identifier.
Price: Price of the coffee.
Name: Name of the coffee.
Type: Coffee type.


## Filling Class:

Properties:
SKU: Unique identifier.
Price: Price of the filling.
Name: Name of the filling.


## Inventory Class:

Properties:

availableItems: Dictionary of available items in the inventory.
Methods:

AddItem(item): Adds an item to the inventory.
RemoveItem(item): Removes an item from the inventory.
GetItemDetails(item): Retrieves details of an item from the inventory.

# User Story 1
1.
As a member of the public,
So I can order a bagel before work,
I'd like to add a specific type of bagel to my basket.

+--------+------------------------------------------+---------+--+--+
| Class  | Properties                               | Methods |  |  |
+--------+------------------------------------------+---------+--+--+
| Basket | Items: List of items in the basket.      |         |  |  |
|        | Capacity: Maximum capacity of the basket |         |  |  |
+--------+------------------------------------------+---------+--+--+
| Bagel  | SKU : Unique identifier.                 |         |  |  |
|        | Price : Price of the bagel.              |         |  |  |
|        | Name : Name of the bagel.                |         |  |  |
|        | Variant : Bagel variant.                 |         |  |  |
+--------+------------------------------------------+---------+--+--+
|        |                                          |         |  |  |
+--------+------------------------------------------+---------+--+--+


# User Story 2

As a member of the public,
So I can change my order,
I'd like to remove a bagel from my basket.

+--------+------------------------------------------+-------------------+--+--+
| Class  | Properties                               | Methods           |  |  |
+--------+------------------------------------------+-------------------+--+--+
| Basket | Items: List of items in the basket.      | AddItem(item);    |  |  |
|        | Capacity: Maximum capacity of the basket | RemoveItem(item); |  |  |
|        |                                          | IsFull();         |  |  |
+--------+------------------------------------------+-------------------+--+--+
| Bagel  | SKU : Unique identifier.                 |                   |  |  |
|        | Price : Price of the bagel.              |                   |  |  |
|        | Name : Name of the bagel.                |                   |  |  |
|        | Variant : Bagel variant.                 |                   |  |  |
+--------+------------------------------------------+-------------------+--+--+
|        |                                          |                   |  |  |
+--------+------------------------------------------+-------------------+--+--+

# User Story 3
3.
As a member of the public,
So that I can not overfill my small bagel basket
I'd like to know when my basket is full when I try adding an item beyond my basket capacity.

+--------+------------------------------------------+-------------------+--+--+
| Class  | Properties                               | Methods           |  |  |
+--------+------------------------------------------+-------------------+--+--+
| Basket | Items: List of items in the basket.      | AddItem(item);    |  |  |
|        | Capacity: Maximum capacity of the basket | RemoveItem(item); |  |  |
|        |                                          | IsFull();         |  |  |
+--------+------------------------------------------+-------------------+--+--+
| Bagel  | SKU : Unique identifier.                 |                   |  |  |
|        | Price : Price of the bagel.              |                   |  |  |
|        | Name : Name of the bagel.                |                   |  |  |
|        | Variant : Bagel variant.                 |                   |  |  |
+--------+------------------------------------------+-------------------+--+--+
|        |                                          |                   |  |  |
+--------+------------------------------------------+-------------------+--+--+

# User Story 4
4.
As a Bob's Bagels manager,
So that I can expand my business,
I’d like to change the capacity of baskets.
+--------+------------------------------------------+-------------------------------+--+--+
| Class  | Properties                               | Methods                       |  |  |
+--------+------------------------------------------+-------------------------------+--+--+
| Basket | Items: List of items in the basket.      | AddItem(item);                |  |  |
|        | Capacity: Maximum capacity of the basket | RemoveItem(item);             |  |  |
|        |                                          | IsFull();                     |  |  |
|        |                                          | ChangeCapacity(newCapacity);) |  |  |
+--------+------------------------------------------+-------------------------------+--+--+
| Bagel  | SKU : Unique identifier.                 |                               |  |  |
|        | Price : Price of the bagel.              |                               |  |  |
|        | Name : Name of the bagel.                |                               |  |  |
|        | Variant : Bagel variant.                 |                               |  |  |
+--------+------------------------------------------+-------------------------------+--+--+
|        |                                          |                               |  |  |
+--------+------------------------------------------+-------------------------------+--+--+

# User Story 5
5.
As a member of the public
So that I can maintain my sanity
I'd like to know if I try to remove an item that doesn't exist in my basket.
+--------+------------------------------------------+-------------------------------+--+--+
| Class  | Properties                               | Methods                       |  |  |
+--------+------------------------------------------+-------------------------------+--+--+
| Basket | Items: List of items in the basket.      | AddItem(item);                |  |  |
|        | Capacity: Maximum capacity of the basket | RemoveItem(item);             |  |  |
|        |                                          | IsFull();                     |  |  |
|        |                                          | ChangeCapacity(newCapacity);) |  |  |
+--------+------------------------------------------+-------------------------------+--+--+
| Bagel  | SKU : Unique identifier.                 |                               |  |  |
|        | Price : Price of the bagel.              |                               |  |  |
|        | Name : Name of the bagel.                |                               |  |  |
|        | Variant : Bagel variant.                 |                               |  |  |
+--------+------------------------------------------+-------------------------------+--+--+
|        |                                          |                               |  |  |
+--------+------------------------------------------+-------------------------------+--+--+

# User Story 6
6.
As a customer,
So I know how much money I need,
I'd like to know the total cost of items in my basket.

+--------+------------------------------------------+-----------------------+--+--+
| Class  | Properties                               | Methods               |  |  |
+--------+------------------------------------------+-----------------------+--+--+
| Basket | Items: List of items in the basket.      | AddItem(item);        |  |  |
|        | Capacity: Maximum capacity of the basket | RemoveItem(item);     |  |  |
|        |                                          | IsFull();             |  |  |
|        |                                          | CalculateTotalCost(); |  |  |
+--------+------------------------------------------+-----------------------+--+--+
| Bagel  | SKU : Unique identifier.                 |                       |  |  |
|        | Price : Price of the bagel.              |                       |  |  |
|        | Name : Name of the bagel.                |                       |  |  |
|        | Variant : Bagel variant.                 |                       |  |  |
+--------+------------------------------------------+-----------------------+--+--+
|        |                                          |                       |  |  |
+--------+------------------------------------------+-----------------------+--+--+

# User Story 7
7.
As a customer,
So I know what the damage will be,
I'd like to know the cost of a bagel before I add it to my basket.
+--------+------------------------------------------+-----------------------+--+--+
| Class  | Properties                               | Methods               |  |  |
+--------+------------------------------------------+-----------------------+--+--+
| Basket | Items: List of items in the basket.      | AddItem(item);        |  |  |
|        | Capacity: Maximum capacity of the basket | RemoveItem(item);     |  |  |
|        |                                          | IsFull();             |  |  |
|        |                                          | CalculateTotalCost(); |  |  |
+--------+------------------------------------------+-----------------------+--+--+
| Bagel  | SKU : Unique identifier.                 |                       |  |  |
|        | Price : Price of the bagel.              |                       |  |  |
|        | Name : Name of the bagel.                |                       |  |  |
|        | Variant : Bagel variant.                 |                       |  |  |
+--------+------------------------------------------+-----------------------+--+--+
|        |                                          |                       |  |  |
+--------+------------------------------------------+-----------------------+--+--+

# User Story 8
8.
As a customer,
So I can shake things up a bit,
I'd like to be able to choose fillings for my bagel.
+---------+---------------------------------------------------+-----------------------+--+--+
| Class   | Properties                                        | Methods               |  |  |
+---------+---------------------------------------------------+-----------------------+--+--+
| Basket  | Items: List of items in the basket.               | AddItem(item);        |  |  |
|         | Capacity: Maximum capacity of the basket          | RemoveItem(item);     |  |  |
|         |                                                   | IsFull();             |  |  |
|         |                                                   | CalculateTotalCost(); |  |  |
+---------+---------------------------------------------------+-----------------------+--+--+
| Bagel   | SKU : Unique identifier.                          |                       |  |  |
|         | Price : Price of the bagel.                       |                       |  |  |
|         | Name : Name of the bagel.                         |                       |  |  |
|         | Variant : Bagel variant.                          |                       |  |  |
|         | Fillings : List of chosen fillings for the bagel. |                       |  |  |
+---------+---------------------------------------------------+-----------------------+--+--+
| Filling | SKU : Unique identifier                           |                       |  |  |
|         | Price : price of the filling                      |                       |  |  |
|         | Name : name of the filling                        |                       |  |  |
+---------+---------------------------------------------------+-----------------------+--+--+

# User Story 9
9.
As a customer,
So I don't over-spend,
I'd like to know the cost of each filling before I add it to my bagel order.
+---------+---------------------------------------------------+-----------------------+--+--+
| Class   | Properties                                        | Methods               |  |  |
+---------+---------------------------------------------------+-----------------------+--+--+
| Basket  | Items: List of items in the basket.               | AddItem(item);        |  |  |
|         | Capacity: Maximum capacity of the basket          | RemoveItem(item);     |  |  |
|         |                                                   | IsFull();             |  |  |
|         |                                                   | CalculateTotalCost(); |  |  |
+---------+---------------------------------------------------+-----------------------+--+--+
| Bagel   | SKU : Unique identifier.                          |                       |  |  |
|         | Price : Price of the bagel.                       |                       |  |  |
|         | Name : Name of the bagel.                         |                       |  |  |
|         | Variant : Bagel variant.                          |                       |  |  |
|         | Fillings : List of chosen fillings for the bagel. |                       |  |  |
+---------+---------------------------------------------------+-----------------------+--+--+
| Filling | SKU : Unique identifier                           |                       |  |  |
|         | Price : price of the filling                      |                       |  |  |
|         | Name : name of the filling                        |                       |  |  |
+---------+---------------------------------------------------+-----------------------+--+--+

# User Story 10
10.
As the manager,
So we don't get any weird requests,
I want customers to only be able to order things that we stock in our inventory.

+-----------+-----------------------------------------------------------------+------------------------------------------------------------------------+--+--+
| Class     | Properties                                                      | Methods                                                                |  |  |
+-----------+-----------------------------------------------------------------+------------------------------------------------------------------------+--+--+
| Basket    | Items: List of items in the basket.                             | AddItem(item);                                                         |  |  |
|           | Capacity: Maximum capacity of the basket                        | RemoveItem(item);                                                      |  |  |
|           |                                                                 | IsFull();                                                              |  |  |
|           |                                                                 | CalculateTotalCost();                                                  |  |  |
+-----------+-----------------------------------------------------------------+------------------------------------------------------------------------+--+--+
| Inventory | AvailableItem : Dictionary of available items in the inventory. | AddItem(item); Adds an item to the inventory.                          |  |  |
|           |                                                                 | RemoveItem(item): Removes an item from inventory.                      |  |  |
|           |                                                                 | GetItemDetails(item): Retrieves details of an item from the inventory. |  |  |
+-----------+-----------------------------------------------------------------+------------------------------------------------------------------------+--+--+
|           |                                                                 |                                                                        |  |  |
+-----------+-----------------------------------------------------------------+------------------------------------------------------------------------+--+--+