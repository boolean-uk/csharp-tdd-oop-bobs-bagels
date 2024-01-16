| Classes   | Members                                                                 | Methods                                 | Scenario                                               | Outputs |
|-----------|-------------------------------------------------------------------------|-----------------------------------------|--------------------------------------------------------|---------|
| `Basket`  | List<Product> products List<string> menu (stores this months valid sku) | `add(string sku)`                       | The basket is not full and the sku is valid            | true    |
|           |                                                                         |                                         | The basket is full or the sku is invalid               | false   |
|           | List<Product> products                                                  | `remove(string sku)`                    | The basket contained a bagel of specified type         | true    |
|           |                                                                         |                                         | The basket did not contained a bagel of specified type | false   |
|           | int capasity                                                            | `setCapacity(int capasity)`             |                                                        |         |
|           |                                                                         | `getBasketPrice()`                      |                                                        | double  |
|           |                                                                         | `setFillingToBagel(int id, string sku)` | Is successfull                                         | true    |
|           |                                                                         |                                         | Is unsuccessfull                                       | false   |
| `Product` |                                                                         | `getPrice()`                            |                                                        | double  |
| `Bagel`   | List<string> fillingMenu (stores this months valid sku)                 | `setFilling(string sku)`                | The sku is valid                                       | true    |
|           |                                                                         |                                         | the sku is invalid                                     | false   |
