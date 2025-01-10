### Domain Model

| Classes             | Methods/Properties                                      | Scenario                                                                                 | Outputs                    |
|---------------------|---------------------------------------------------------|------------------------------------------------------------------------------------------|----------------------------|
| **Basket**          | `AddItem(item: Product)`                                | Add a specific type of bagel to the basket.                                              | Updated basket or error.   |
|                     | `RemoveItem(item: Product)`                             | Remove a bagel from the basket.                                                          | Updated basket or error.   |
|                     | `IsFull()`                                              | Check if the basket is full when adding an item.                                         | Boolean indicating state.  |
|                     | `GetTotalCost()`                                        | Calculate the total cost of items in the basket.                                         | Total cost as decimal.     |
|                     | `SetCapacity(newCapacity: int)`                         | Change the capacity of the basket.                                                      | Updated capacity.          |
|                     | `Contains(item: Product)`                               | Check if a specific item exists in the basket.                                           | Boolean indicating state.  |
| **Product**         | `SKU`                                                   | Unique identifier for each product.                                                     | String.                    |
|                     | `Price`                                                 | The price of the product.                                                               | Decimal.                   |
|                     | `Name`                                                  | The name of the product.                                                                | String.                    |
|                     | `Variant`                                               | The variant of the product (e.g., bagel type, filling).                                  | String.                    |
| **Bagel**           | Inherits `Product`. `Variant`                           | Represents a specific type of bagel (e.g., Onion, Sesame).                               | Bagel instance.            |
| **Coffee**           | Inherits `Product`. `Variant`                           | Represents a specific type of Coffee.                               | Bagel instance.            |
| **Filling**         | Inherits `Product`. `Variant`                        | Represents a specific type of filling (e.g., Bacon, Cheese).                            | Filling instance.          |
| **Inventory**       | `IsInStock(item: Product)`                              | Check if a product is available in the stock.                                           | Boolean indicating state.  |
|                     | `GetItemPrice(item: Product)`                           | Retrieve the price of a product before adding to the basket.                            | Price as decimal.          |
| **Customer**        | `SelectBagel(bagel: Bagel)`                             | Choose a bagel to add to the basket.                                                    | Bagel selected.            |
|                     | `SelectFilling(filling: Filling)`                       | Choose a filling for a bagel.                                                           | Filling selected.          |
