| Class   | Component                    | Method                                      | Scenario                                                     | Output                                    |
|---------|------------------------------|---------------------------------------------|--------------------------------------------------------------|-------------------------------------------|
| Basket  | List <Product> Basket        | Add(string SKU)                             | item is in inventory and added to Basket                     | TRUE                                      |
|         |                              |                                             | String is empty                                              | FALSE                                     |
|         |                              |                                             | Basket is full                                               | FALSE                                     |
|         |                              |                                             | Item doesnt exist                                            | FALSE                                     |
|         |                              | Remove(string SKU)                          | Item is removed from Basket                                  | TRUE                                      |
|         |                              |                                             | Item doesnt exist in Basket                                  | FALSE                                     |
|         |                              |                                             | string is empty                                              | FALSE                                     |
|         |                              | BasketSize(int size)                        | size changed to a positive number                            | TRUE                                      |
|         |                              |                                             | input is less than 1                                         | FALSE                                     |
|         |                              | CalcPrice()                                 | Basket has items with a price value                          | Double (price)                            |
|         |                              |                                             | Basket has no items                                          | Double (price)                            |
|         | List <Discount> DiscountList | CheckDiscount()                             | x amount of SKU's match the criteria for discount            | (Double discountedPrice, double fillings) |
|         |                              | MoveProduct(string ProductName, int Amount) | x amount of products are moved from Basket to DiscountBasket | TRUE                                      |
|         |                              |                                             | SKU doesnt exist                                             | FALSE                                     |
|         |                              |                                             | Amount is 0 or lower                                         | FALSE                                     |
| Product | List <Product> Filling       | AddFilling(Product filling)                 | Called in a Bagel product, filling has a Filling enum        | TRUE                                      |
|         |                              |                                             | Called outside bagel product                                 | FALSE                                     |
|         |                              |                                             | Filling does not have filling enum                           | FALSE                                     |
|         |                              |                                             | FIlling is null                                              | FALSE                                     |
|         |                              | RemoveFilling(Product filling)              | Product is removed                                           | TRUE                                      |
|         |                              |                                             | List is empty                                                | FALSE                                     |
|         |                              |                                             | Filling is null                                              | FALSE                                     |
|         |                              |                                             | Filling is not in list                                       | FALSE                                     |
