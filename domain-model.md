# Domain Model

# User Stories

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
As a member of the public,
So that I can maintain my sanity
I'd like to know if I try to remove an item that doesn't exist in my basket.

5.
As a customer,
So I know how much money I need,
I'd like to know the total cost of items in my basket.

6.
As a customer,
So I know what the damage will be,
I'd like to know the cost of a bagel before I add it to my basket.

7.
As a customer,
So I can shake things up a bit,
I'd like to be able to choose fillings for my bagel.

8.
As a customer,
So I don't over-spend,
I'd like to know the cost of each filling before I add it to my bagel order.

9.
As a Bob's Bagels manager,
So that I can expand my business,
I’d like to change the capacity of baskets.

10.
As the manager,
So we don't get any weird requests,
I want customers to only be able to order things that we stock in our inventory.


| Classes                | Methods                                                | Scenario                                                                                   | Expected Output                                                                         |
|------------------------|--------------------------------------------------------|--------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------|
| `Bagel`                | `Constructor(string name)`                             | `Creating a bagel with a specific name.`                                                   | `Bagel object is created with the specified name.`                                      |
| `Basket`               | `GetBagelCost(string bagelName)`                       | `Getting the cost of the selected bagel.`                                                  | `The cost of the selected bagel is returned.`                                           |
|                        | `Constructor(int capacity)`                            | `Creating a basket with a specific capacity.`                                              | `Basket object is created with the specified capacity.`                                 |
|                        | `IsFull()`                                             | `Checking if the basket is full.`                                                          | `IsFull() returns true if the basket is full; otherwise, false.`                        |
|                        | `GetBagelCount()`                                      | `Getting the current number of bagels in the basket.`                                      | `The current number of bagels in the basket is returned.`                               |
|                        | `GetTotalCost()`                                       | `Getting the total cost of items in the basket.`                                           | `The total cost of all items in the basket is returned.`                                |
|                        | `ChangeBasketCapacity(int newCapacity)`                | `Changing the capacity of a specific basket to a new value.`                               | `The capacity of the specified basket is updated to the new value.`                     |
|                        | `AddFillingToBagel(Bagel bagel, string fillingSKU)`    | `Adding filling for the selected bagel.`                                                   | `The specified filling is added to the bagel and its price is returned.`                |
|                        | `AddBagel(Bagel bagel)`                                | `Adding a bagel to the basket.`                                                            | `Bagel is added to the basket, and the bagel count increases.`                          |
|                        | `RemoveBagel(Bagel bagel)`                             | `Removing a bagel from the basket.`                                                        | `Bagel is removed from the basket, and the bagel count decreases.`                      |
|                        | `RemoveNonExistingBagel(Bagel bagel)`                  | `Removing a bagel that doesn't exist in the basket.`                                       | `RemoveNonExistingBagel() returns false if the bagel is not in the basket.`             | 
|                        | `CheckStock(string itemSKU)`                           | `Ordering only something that is in stock.`                                                | `CheckStock() checks if the item with the specified SKU is available in the inventory.` |
                                                                                                                                                                                 `If it's available, it returns true; otherwise, it returns false.`                      |
