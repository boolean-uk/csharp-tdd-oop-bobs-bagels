Old domain model:
| Classes  | Methods                 | Scenario                                                        | Outputs                       |
|----------|-------------------------|-----------------------------------------------------------------|-------------------------------|
| `Basket` | `Add(string name)`      | Adding a bagel now checks if basket is full before proceeding   | Only add if basket isn't full |
|          | `Remove()`              | If basket is empty                                              | false                         |
|          |                         | If the basket has bagel/bagels, remove one                      | true                          |
|          | `IsFull()`              | If the basket is not yet full                                   | false                         |
|          |                         | If the basket is full and cannot handle more bagels             | true                          |
|          | `SetCapacity(int size)` | If the basket cannot be decreased due to having too many bagels | false                         |
|          |                         | If the basket can be decreased/increased                        | true                          |
|          | `Remove(string name)`   | If that bagel doesn't exist in the basket                       | false                         |
|          |                         | If that bagel exists in the basket, remove it                   | true                          |


1. As a member of the public,
So I can order a bagel before work,
I'd like to add a specific type of bagel to my basket.

2. As a member of the public,
So I can change my order,
I'd like to remove a bagel from my basket.

3. As a member of the public,
So that I can not overfill my small bagel basket
I'd like to know when my basket is full when I try adding an item beyond my basket capacity.

4. As a Bob's Bagels manager,
So that I can expand my business,
I’d like to change the capacity of baskets.

5. As a member of the public
So that I can maintain my sanity
I'd like to know if I try to remove an item that doesn't exist in my basket.

6. As a customer,
So I know how much money I need,
I'd like to know the total cost of items in my basket.

7. As a customer,
So I know what the damage will be,
I'd like to know the cost of a bagel before I add it to my basket.

8. As a customer,
So I can shake things up a bit,
I'd like to be able to choose fillings for my bagel.

9. As a customer,
So I don't over-spend,
I'd like to know the cost of each filling before I add it to my bagel order.

10. As the manager,
So we don't get any weird requests,
I want customers to only be able to order things that we stock in our inventory.


| Classes     | Methods                                                  | Scenario                                                                           | Outputs |
|-------------|----------------------------------------------------------|------------------------------------------------------------------------------------|---------|
| `Customer`  | `Customer(Manager mngr, float allowance)`                | Create a customer with their own basket and wallet                                 | ----    |
|             | `Add(Manager mngr, string product)`                      | Request to add a product of this type                                              | true    |
|             |                                                          | This product does not exist or basket is too full                                  | false   |
|             | `Remove(Manager mngr, string product)`                   | Request to remove a product of this type from basket                               | true    |
|             |                                                          | This product does not exist in basket                                              | false   |
|             | `TotalCost()`                                            | Request to know the total cost of everything currently in the basket               | float   |
|             | `HowMuch(Manager mngr, string product)`                  | Request to know how much this product costs                                        | float   |
|             | `AddFilling(Manager mngr, string filling, string bagel)` | Request to add a filling of a certain type                                         | true    |
|             |                                                          | Filling does not exist or bagel is not in basket                                   | false   |
|             | `HowMuchFillings(Manager mngr)`                          | Request to know how much every filling costs                                       | float   | //Could expand this to a string that lists all fillings and individual prices, but all fillings cost 0.12
|             | `Purchase(Manager manager)`                              | Request to purchase everything in the basket                                       | true    |
|             |                                                          | Could not afford everything                                                        | false   |
|-------------|----------------------------------------------------------|------------------------------------------------------------------------------------|---------| //Spacing to improve readability
| `Basket`    | `Basket(Manager mngr)`                                   | Create a basket that can hold products, refer to manager for size                  | ----    |
|             | `Search(string product)`                                 | Search through a basket to check if it has the product, return index               | int     |
|             |                                                          | Product does not exist in basket or basket is empty, return -1                     | int     |
|             | `TotalCost()`                                            | Return the cost of all products in the basket                                      | float   |
|-------------|----------------------------------------------------------|------------------------------------------------------------------------------------|---------|
| `Product`   | `Product(Base information)`                              | Create a product with the given a "Base" struct with all information               | ----    |
|             | `AddFilling(string name, float price)`                   | Update a product by adding a filling to it                                         | void    |
|             | `Cost()`                                                 | Return the cost of this product                                                    | float   |
|-------------|----------------------------------------------------------|------------------------------------------------------------------------------------|---------|
| `Inventory` | `Inventory()`                                            | Create an inventory that keeps track of all items it has on sale                   | ----    |
|             | `Find(string product)`                                   | Search for a product to see if it exists                                           | true    |
|             |                                                          | Product does not exist                                                             | false   |
|             | `GetProduct(string product)`                             | Returns selected product                                                           | Product |
|             | `IsFilling(string filling)`                              | Check if the filling exists                                                        | true    |
|             |                                                          | Filling does not exist                                                             | false   |
|             | `HowMuchFillings()`                                      | Return the cost of each filling in the inventory                                   | float   |
|-------------|----------------------------------------------------------|------------------------------------------------------------------------------------|---------|
| `Manager`   | `Manager()`                                              | Create a manager that takes requests from the customer                             | ----    |
|             | `ChangeBasketSize(int newSize)`                          | Update the standard size of baskets, but leave already existing baskets untouched  | true    |
|             |                                                          | If the new size is not a positive number                                           | false   |
|             | `AddProduct(Basket bskt, string product)`                | Add this type of product to the customer's basket                                  | true    |
|             |                                                          | This product does not exist                                                        | false   |
|             | `RemoveProduct(Basket bskt, string product)`             | Remove this type of product from the customer's basket                             | true    |
|             |                                                          | This product does not exist or basket is empty                                     | false   |
|             | `HowMuchProduct(Basket bskt, string product)`            | Return the cost of the selected product if it exists, otherwise return 0           | float   |
|             | `AddFilling(Basket bskt, string filling, string bagel)`  | Add the filling to the bagel                                                       | true    |
|             |                                                          | Bagel or filling does not exist                                                    | false   |
|             | `Purchase(Basket bskt)`                                  | Pay for everything in the basket and empty it                                      | true    |
|             |                                                          | Could not afford                                                                   | false   |
|-------------|----------------------------------------------------------|------------------------------------------------------------------------------------|---------|


