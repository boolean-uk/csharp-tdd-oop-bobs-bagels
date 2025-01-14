omain Model

| Classes   | Methods/Properties                | Scenario                                    | Outputs                 |
|-----------|-----------------------------------|---------------------------------------------|-------------------------|
|           | AddToBasket(string Id)            | Adds an order to basket                     |                         |
|           | RemoveFromBasket(string Id)       | Removes an order form basket                |                         |
| Basket.cs | CheckFull()                       | Checks if basket is at max capacity         | "Basket is full"        |
|           | SetBasketSize(int size)           | Sets a new max capacity to baskets          |                         |
|           | RemoveFromBasket(string Id)       | Tries to remove nonexsistent item           | "No such item"          |
|           | GetTotal()                        | See the total cost of items in basket       | Total cost              |
|           | Property to expose price of bagel | See price of bagel before adding to basket  | Bagel cost              |
|           | AddFillig(string Id)              | Adds filling to bagel                       |                         |
|           | Property to expose price filling  | See price of filling before adding to bagel | Filling cost            |
|           | AddToBasket(string Id)            | Tries to add nonexsistent item              | "No such ware in stock" |