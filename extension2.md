## Extension 2: Receipts

Receipts are important.

## Task

Update and extend your program to handle printing receipts. These receipts should print to the terminal.

Start with extracting useful stories and a functional domain model that represents these requirements.

Tip: Think about a Receipt as an object. What other objects are contained in a receipt?

#### Example Receipt
```
    ~~~ Bob's Bagels ~~~

    2021-03-16 21:38:44

----------------------------

Onion Bagel        2   £0.98
Plain Bagel        12  £3.99
Everything Bagel   6   £2.49
Coffee             3   £2.97

----------------------------
Total                 £10.43

        Thank you
      for your order!
```

```
    ~~~ Bob's Bagels ~~~

    2021-03-16 21:40:12

----------------------------

Plain Bagel        16  £5.55

----------------------------
Total                  £5.55

        Thank you
      for your order!
```

User Story 14:
As a customer,
So I can check how much I spent,
I'd like to recieve a reciept for my purchase.


| Classes     | Methods                                                  | Scenario                                                                           | Outputs |
|-------------|----------------------------------------------------------|------------------------------------------------------------------------------------|---------|
| `Customer`  | `Customer(Manager mngr, float allowance)`                | Create a customer with their own basket and wallet                                 | ----    |
|             | `Add(Manager mngr, string product, int amount)`          | Request to add x amount of a product of this type                                  | true    |
|             |                                                          | This product does not exist or basket is too full                                  | false   |
|             | `Remove(Manager mngr, string product, int amount)`       | Request to remove x amount of a product of this type from basket                   | true    |
|             |                                                          | This product does not exist in basket                                              | false   |
|             | `TotalCost()`                                            | Request to know the total cost of everything currently in the basket               | float   |
|             | `HowMuch(Manager mngr, string product)`                  | Request to know how much this product costs                                        | float   |
|             | `AddFilling(Manager mngr, string filling, string bagel)` | Request to add a filling of a certain type                                         | true    |
|             |                                                          | Filling does not exist or bagel is not in basket                                   | false   |
|             | `HowMuchFillings(Manager mngr)`                          | Request to know how much every filling costs                                       | float   | //Could expand this to a string that lists all fillings and individual prices, but all fillings cost 0.12
|             | `Purchase(Manager manager)`                              | Request to purchase everything in the basket                                       | string  |
|             |                                                          | Could not afford everything                                                        | false   |
|-------------|----------------------------------------------------------|------------------------------------------------------------------------------------|---------| //Spacing to improve readability
| `Basket`    | `Basket(Manager mngr)`                                   | Create a basket that can hold products, refer to manager for size                  | ----    |
|             | `Search(string product)`                                 | Search through a basket to check if it has the product, return index               | int     |
|             |                                                          | Product does not exist in basket or basket is empty, return -1                     | int     |
|             | `TotalCost()`                                            | Return the cost of all products in the basket                                      | float   |
|-------------|----------------------------------------------------------|------------------------------------------------------------------------------------|---------|
| `Product`   | `Product(Base information)`                              | Create a product with the given a "Base" struct with all information               | ----    |
|             | `AddFilling(Product filling)`                            | Update a product by adding a filling to it                                         | void    |
|             | `Cost()`                                                 | Return the cost of this product                                                    | float   |
|             | `IsBagel()`                                              | Return true if it is a bagel                                                       | true    |
|             |                                                          | Return false if it is not a bagel                                                  | false   |
|             | `IncreaseAmount(int amount)`                             | Increase the amount of the product by the given amount                             | void    |
|             | `DecreaseAmount(int amount)`                             | Decrease the amount of the product by the given amount                             | void    |
|             | `GetAmount()`                                            | Return the amount of the product                                                   | int     |
|             | `GetExcessBagelAmount()`                                 | Return the amount of bagels left after the bagel discounts have been applied       | int     |
|-------------|----------------------------------------------------------|------------------------------------------------------------------------------------|---------|
| `Inventory` | `Inventory()`                                            | Create an inventory that keeps track of all items it has on sale                   | ----    |
|             | `Find(string product)`                                   | Search for a product to see if it exists                                           | true    |
|             |                                                          | Product does not exist                                                             | false   |
|             | `GetProduct(string product)`                             | Returns selected product                                                           | Product |
|             | `HowMuchFillings()`                                      | Return the cost of each filling in the inventory                                   | float   |
|-------------|----------------------------------------------------------|------------------------------------------------------------------------------------|---------|
| `Manager`   | `Manager()`                                              | Create a manager that takes requests from the customer                             | ----    |
|             | `ChangeBasketSize(int newSize)`                          | Update the standard size of baskets, but leave already existing baskets untouched  | true    |
|             |                                                          | If the new size is not a positive number                                           | false   |
|             | `AddProduct(Basket bskt, string product, int amount)`    | Add x amount of this type of product to the customer's basket                      | true    |
|             |                                                          | This product does not exist                                                        | false   |
|             | `RemoveProduct(Basket bskt, string product, int amount)` | Remove x amount of this type of product from the customer's basket                 | true    |
|             |                                                          | This product does not exist or basket is empty                                     | false   |
|             | `HowMuchProduct(string product)`                         | Return the cost of the selected product if it exists, otherwise return 0           | float   |
|             | `HowMuchFillings()`                                      | Return the cost of all fillings                                                    | float   |
|             | `AddFilling(Basket bskt, string filling, string bagel)`  | Add the filling to all bagels of this type                                         | true    |
|             |                                                          | Bagel or filling does not exist                                                    | false   |
|             | `Purchase(Basket bskt)`                                  | Pay for everything in the basket, print receipt and empty it                       | true    |
|             |                                                          | Could not afford                                                                   | false   |
|-------------|----------------------------------------------------------|------------------------------------------------------------------------------------|---------|