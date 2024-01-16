| Class   | Component              | Method                 | Scenario                                                 | Output         |
|---------|------------------------|------------------------|----------------------------------------------------------|----------------|
| Basket  | List <Product> Basket  | Add(string SKU)        | item is in inventory and added to Basket                 | TRUE           |
|         |                        |                        | String is empty                                          | FALSE          |
|         |                        |                        | Basket is full                                           | FALSE          |
|         |                        |                        | Item doesnt exist                                        | FALSE          |
|         |                        | Remove(string SKU)     | Item is removed from Basket                              | TRUE           |
|         |                        |                        | Item doesnt exist in Basket                              | FALSE          |
|         |                        |                        | string is empty                                          | FALSE          |
|         |                        | BasketSize(int size)   | size changed to a positive number                        | TRUE           |
|         |                        |                        | input is less than 1                                     | FALSE          |
|         |                        | CalcPrice()            | Basket has items with a price value                      | Double (price) |
|         |                        |                        | Basket has no items                                      | Double (price) |
| Product | List <Product> Filling | AddFilling(Product filling) | Called in a Bagel product, filling is a Filling enum | TRUE           |
|         |                        |                        | One of the conditions above is untrue                    | FALSE          |
