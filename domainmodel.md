### Domain Model

| Classes             | Methods/Properties                                      | Scenario                                                                                 | Outputs                    |
|---------------------|---------------------------------------------------------|------------------------------------------------------------------------------------------|----------------------------|
| **Basket**          | `AddItem(item: Product)`                                | Add a specific product (e.g., bagel, coffee, filling) to the basket.                     | Updated basket or error.   |
|                     | `RemoveItem(item: Product)`                             | Remove a product from the basket.                                                       | Updated basket or error.   |
|                     | `IsFull()`                                              | Check if the basket is at capacity when adding an item.                                  | Boolean indicating state.  |
|                     | `GetTotalCost()`                                        | Calculate the total cost of items in the basket.                                         | Total cost as decimal.     |
|                     | `SetCapacity(newCapacity: int)`                         | Change the capacity of the basket.                                                      | Updated capacity.          |
|                     | `Contains(item: Product)`                               | Check if a specific item exists in the basket.                                           | Boolean indicating state.  |
| **Product**         | `SKU`                                                   | Unique identifier for each product.                                                     | String.                    |
|                     | `Price`                                                 | The price of the product.                                                               | Decimal.                   |
|                     | `Name`                                                  | The name of the product.                                                                | String.                    |
|                     | `Variant`                                               | The variant of the product (e.g., bagel type, filling).                                  | String.                    |
| **Bagel**           | Inherits `Product`.                                     | Represents a specific type of bagel (e.g., Onion, Sesame).                               | Bagel instance.            |
| **Coffee**          | Inherits `Product`.                                     | Represents a specific type of coffee.                                                   | Coffee instance.           |
| **Filling**         | Inherits `Product`.                                     | Represents a specific type of filling (e.g., Bacon, Cheese).                            | Filling instance.          |
| **Inventory**       | `IsInStock(item: Product)`                              | Check if a product is available in the stock.                                           | Boolean indicating state.  |
|                     | `GetItemPrice(item: Product)`                           | Retrieve the price of a product.                                                        | Price as decimal.          |
| **Customer**        | `SelectBagel(bagel: Bagel)`                             | Choose a bagel to add to the basket.                                                    | Bagel selected.            |
|                     | `SelectFilling(filling: Filling)`                       | Choose a filling for a bagel.                                                           | Filling selected.          |
| **Receipt**         | `GenerateReceipt(items: List<Product>, totalCost: double)` | Create a detailed receipt for the purchase.                                             | Formatted receipt string.  |
| **DiscountRule**    | `ApplyDiscount(basket: Basket)`                         | Apply discounts to eligible products in the basket.                                     | Discounted basket.         |
| **PricingEngine**   | `CalculatePrice(products: List<Product>)`               | Calculate the total price, applying discounts if applicable.                            | Total price as decimal.    |
| **User**            | `Name`                                                  | The name of the user.                                                                   | String.                    |
|                     | `Role`                                                  | The role of the user (e.g., Customer, Manager).                                         | String.                    |
| **Manager**         | Inherits `User`.                                        | Represents a manager with access to inventory and pricing updates.                      | Manager instance.          |
