| Component            | Method               | Scenario                                 | Output         |
|----------------------|----------------------|------------------------------------------|----------------|
| List <Object> Basket | Add(string SKU)      | item is in inventory and added to Basket | TRUE           |
|                      |                      | String is empty                          | FALSE          |
|                      |                      | Basket is full                           | FALSE          |
|                      |                      | Item doesnt exist                        | FALSE          |
|                      | Remove(string SKU)   | Item is removed from Basket              | TRUE           |
|                      |                      | Item doesnt exist in Basket              | FALSE          |
|                      |                      | string is empty                          | FALSE          |
|                      | BasketSize(int size) | size changed to a positive number        | TRUE           |
|                      |                      | input is less than 1                     | FALSE          |
|                      | CalcPrice()          | Basket has items with a price value      | Double (price) |
|                      |                      | Basket has no items                      | Double (price) |
|                      | GetPrice(string SKU) | Item exists                              | Double (price) |
|                      |                      | Item doesnt exist                        | NaN            |
|                      |                      |                                          |                |
