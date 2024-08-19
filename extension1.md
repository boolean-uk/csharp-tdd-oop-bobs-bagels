## Extension 1: Discounts

In a normal supermarket, things are identified using Stock Keeping Units, or SKUs.

In Bob's Bagels, we'll use the first 3 letters of a bagel with an extra letter for the variant. For example: an 'everything bagel' has a SKU of `BGLE`.

Our goods are priced individually. In addition, some items are multi-priced: buy n of them, and they'll cost you y pounds.

#### Bob's Bagels Inventory

| SKU  | Name   | Variant    | Price | Special offers          |
|------|--------|------------|-------|-------------------------|
| BGLO | Bagel  | Onion      | .49   | 6 for 2.49              |
| BGLP | Bagel  | Plain      | .39   | 12 for 3.99             |
| BGLE | Bagel  | Everything | .49   | 6 for 2.49              |
| COFB | Coffee | Black      | .99   | Coffee & Bagel for 1.25 |

Every Bagel is available for the `6 for 2.49` and `12 for 3.99` offer, but fillings still cost the extra amount per bagel.

#### Example orders
```
2x BGLO  = 0.98
12x BGLP = 3.99
6x BGLE  = 2.49
3x COF   = 2.97
           ----
          10.43
```

```
16x BGLP = 5.55
           ----
           5.55
```

## Task

Update and extend your program to handle these orders at Bob's Bagels.

Start with extracting useful stories and a functional domain model that represents these requirements.

User Story 11:
As a customer,
So I can "save" money by utilizing special offers,
I'd like to be able to purchase multiple of the same product

User Story 12:
As a manager,
So I can trick customers into buying in bulk,
I'd like the price of products to be reduced when purchasing a certain amount of them

User Story 13:
As a manager,
So I don't scam my customers,
I'd like to be able to calculate if a combination of items result in a special offer

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
|             | `Purchase(Manager manager)`                              | Request to purchase everything in the basket                                       | true    |
|             |                                                          | Could not afford everything                                                        | false   |
|-------------|----------------------------------------------------------|------------------------------------------------------------------------------------|---------| //Spacing to improve readability
| `Basket`    | `Basket(Manager mngr)`                                   | Create a basket that can hold products, refer to manager for size                  | ----    |
|             | `Search(string product)`                                 | Search through a basket to check if it has the product, return index               | int     |
|             |                                                          | Product does not exist in basket or basket is empty, return -1                     | int     |
|             | `TotalCost()`                                            | Return the cost of all products in the basket                                      | float   |
|-------------|----------------------------------------------------------|------------------------------------------------------------------------------------|---------|
| `Product`   | `Product(Base information, int amount)`                  | Create a product with the given a "Base" struct with all information               | ----    |
|             | `AddFilling(Product filling)`                            | Update a product by adding a filling to it                                         | void    |
|             | `Cost()`                                                 | Return the cost of this product                                                    | float   |
|             | `IsBagel()`                                              | Return true if it is a bagel                                                       | true    |
|             |                                                          | Return false if it is not a bagel                                                  | false   |
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
|             | `Purchase(Basket bskt)`                                  | Pay for everything in the basket and empty it                                      | true    |
|             |                                                          | Could not afford                                                                   | false   |
|-------------|----------------------------------------------------------|------------------------------------------------------------------------------------|---------|