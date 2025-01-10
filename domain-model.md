| **Classes**     | **Methods/Properties**   | **Scenarios**                                                          | **Outputs**               |
|-----------------|--------------------------|------------------------------------------------------------------------|---------------------------|
| Basket.cs       | Add(Item item)           | Add an item to your basket, restricted to items in inventory.          | bool, available space > 0 |
| Basket.cs       | Remove(Item item)        | Remove an item from your basket                                        | bool, if exists           |
| Basket.cs       | Capacity                 | Get / Set capacity of basket. Set restricted to mangers.               | int                       |
| Basket.cs       | CalculateCost()          | Gets the total price of all items in the basket, with discounts added. | Receipt                   |
| Item.cs         | Cost                     | The total cost of the item                                             |                           |
| Bagel.cs : Item | AddFilling(Item filling) | Adds a filling to the bagel.                                           |                           |
