

## Domain model

| Classes    | Methods/Properties          | Senario                                                                                       | Outputs                       |
|------------|-----------------------------|-----------------------------------------------------------------------------------------------|-------------------------------|
| Basket.cs  | AddItem(Product product)    | Adds the product to the basket (list of products)                                             | Added product                 |
| Basket.cs  | RemoveItem(Product product) | Removes the product from the basket                                                           | Removed product               |
| Basket.cs  | var maxItemsInBasket        | A variable that checks if the max amount of items in the basket is exeded when adding an item | True/False if exeded or not   |
| Basket.cs  | Set maxItemInBasekt         | Changes the value of the max amount of items in the basket                                    | New limit for the basket      |
| Basket.cs  | RemoveItem(Product product) | If the product does not exist when trying to remove return a message                          | Product is not in your basket |
| Basket.cs  | TotalPrice()                | Gets the total price of the products in my basket                                             | Price                         |
| Bagel.cs   | GetPrice(Bagel bagel)       | Gets the price of a specific bagel                                                            | Price                         |
| Bagel.cs   | SetFilling(Filling filling) | Sets a filling to the bagel                                                                   | New price + filling           |
| Product.cs | GetFillingPrice()           | Returns all the fillings and there price from the list of products                            | All fillings                  |
| Product.cs | GetBagelPrice()             | Returns all the bagels and there price from the list of products                              | All bagels                    |
| Basket.cs  | AddItem(Product product)    | Make sure that the product exists in the list of available products                           | Product exist/doesnt          |


