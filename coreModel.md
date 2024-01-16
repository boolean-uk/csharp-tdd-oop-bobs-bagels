# Domain Model

| `Classes`    | `Methods`            | `Scenarios`              | `Outputs`                                          |
|--------------|----------------------|--------------------------|----------------------------------------------------|
| `Filling`    | `Price`              |                          | `Returs the price of the filling`                  |
|              | `Variant`            |                          | `Returns the type of the filling`                  |
|              | `ID`                 |                          | `Returns the ID of the filling`                    |
| `Coffee`     | `Price`              |                          | `Returns the price of the coffee`                  |
|              | `Variant`            |                          | `Returns the type of the coffee`                   |
|              | `ID`                 |                          | `Returns the ID of the coffee`                     |
| `Bagel`      | `Price`              |                          | `Returns the price of the bagel`                   |
|              | `Variant`            |                          | `Returns the type of the bagel`                    |
|              | `ID`                 |                          | `Returns the ID of the bagel`                      |
|              | `SetFilling(Filling)`|                          | `Filling is added to bagel`                        |
| `Basket`     | `Bagels`             |                          | `Returns a list of bagels in the basket`           |
|              | `Capacity`           |                          | `Returns the capacity of the basket`               |
|              | `Total`              |                          | `Returns the total cost of bagels in the basket`   |
|              | `Add(Bagel)`         | `Basket is not full`     | `Bagel added to basket`                            |
|              |                      | `Basket is full`         | `Returns a message stating basket is full`         |
|              |                      | `Item is in stock`       | `Bagel added to basket`                            |
|              |                      | `Item is not in stock`   | `Returns a message that the bagel is not in stock` |
|              | `Remove(Bagel)`      | `Bagel is in basket`     | `Bagel is removed from basket`                     |
|              |                      | `Bagel is not in basket` | `Returns a message stating bagel is not in basket` |
| `BobsBagels` | `Stock`              |                          | `Dictionary of the bagels in stock`                |
|              | `IncreaseCapacity`   |                          | `Increases the capacity of the baskets`            |
