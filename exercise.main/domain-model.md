| Class                | Method                                   | Member                                                | Scenario                     | Return         |
|----------------------|------------------------------------------|-------------------------------------------------------|------------------------------|----------------|
| Basket               | addItem(Inventory, item, quantity)       | Class Inventory, String item, Integer quantity        | full basket                  | false          |
|                      |                                          |                                                       | add item                     | true           |
|                      |                                          |                                                       | Item not found               | false          |
|                      | removeItem(Inventory, sku, quantity)     | Class Inventory, String item, Integer quantity        | remove item                  | true           |
|                      |                                          |                                                       | Item not found               | false          |
|                      | changeCapacity(capacity)                 | Integer capacity                                      | Changed capacity             | true           |
|                      |                                          |                                                       | Unable to change capacity    | false          |
|                      | getTotalCost()                           | List<Item>                                            | Get total cost               | Return cost    |
|					   | ItemcsCount()							  | List<Item>                                            | Get item list length		 | Return Length  |
|                      | ShowBasket()                             | List<Item>                                            | Show Basket List			 | String Items   |
| Inventory            | printInventory()						  | Dictonary<String,Item> inventory,String inventoryName | Show all added products      | String[]       |
|                      | GetBagelInventory()                      | Dictonary<String,Item>                                | Get all Bagels               | Dictonary      |
|                      | GetFillingInventory()                    | Dictonary<String,Item>                                | Get all Fillings             | Dictonary      |
|                      | GetCoffeeInventory()                     | Dictonary<String,Item>                                | Get all Coffees              | Dictonary      |
|                      | GetItemBySKU()                           | Dictonary<String,Item>                                | Get Item by SKU              | Dictonary      |
| Item                 | Name()                                   |                                                       | get name                     | String type    |
|                      | Variant()                                |                                                       | get variant                  | String variant |
|                      | Sku()                                    |                                                       | get sku                      | String sku     |
|                      | Price()                                  |                                                       | get price                    | double price   |
|                      | Quantity()                               |                                                       | get quantity                 | int quantity   |
|                      | setQuantity()                            | Integer quantity                                      | set quantity                 |                | 
|                      | ToString()                               | Item                                                  | Items as string              | string Item    | 