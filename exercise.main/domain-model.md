| Class                | Method                                   | Member                                                | Scenario                     | Return         |
|----------------------|------------------------------------------|-------------------------------------------------------|------------------------------|----------------|
| Basket               | addItem(Inventory, item, quantity)       | Class Inventory, String item, Integer quantity        | full basket                  | false          |
|                      |                                          |                                                       | add item                     | true           |
|                      |                                          |                                                       | Item not found               | false          |
|                      | removeItem(Inventory, sku, quantity)     | Class Inventory, String item, Integer quantity        | remove item                  | true           |
|                      |                                          |                                                       | Item not found               | false          |
|                      | changeCapacity(capacity)                 | Integer capacity                                      | Changed capacity             | true           |
|                      |                                          |                                                       | Unable to change capacity    | false          |
|                      | getTotalCost()                           | ArrayList<Item>                                       | Get total cost               | Return cost    |
| Inventory            | printInventory()						  | Dictonary<String,Item> inventory,String inventoryName | Show all added products      | String[]       |
|                      | getAllProducts()                         |                                                       | Show all products            | String[]       |
| Item                 | getType()                                |                                                       | get type                     | String type    |
|                      | getVariant()                             |                                                       | get variant                  | String variant |
|                      | getSku()                                 |                                                       | get sku                      | String sku     |
|                      | getPrice()                               |                                                       | get price                    | double price   |
|                      | getQuantity()                            |                                                       | get quantity                 | int quantity   | 