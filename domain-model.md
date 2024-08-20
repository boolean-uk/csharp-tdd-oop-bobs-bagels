# Bob's Bagels - Domain Model

| Class           | Members                 | Method/Property             | Scenario                  | Output     |
|-----------------|-------------------------|-----------------------------|---------------------------|------------|
| BagelShop       | `Dictionary<string, Product> category`| Category {get;}  | category of products      | Dictionary |
|                 |							| GrabBasket()                | gives an empty basket     | Basket     |
|                 |                         | ReceiptPrinter()            | builds a receipt          | StringBuilder|
|                 |                         |                             |                           |            |
| ProductOrder    | `Product product`       | Product {get;}              | get the product           | Product    |
|                 | `int amount`            | Amount {get; set;}          | get or set the amount     | int        |
|                 |                         | Cost {get;}                 | get the cost of the order | double     |
|                 | `double discount`       | Discount{get; set;}         | set discount for order    | nothing    |
|                 | `Product? coffee`       | Coffee {get; set}           | get or set the coffee     |            |
|                 | `List<Product> fillings`| Fillings {get;}             | get the fillings for bagel| list       |
|                 |                         | AddFilling()                | if filling got added      | true       |
|                 |                         |                             | if filling didnt get added| false      |
|                 |                         |                             |                           |            |
| Basket          | `List<Product> products`| Add(string sku)             | item got added to basket  | true       |
|				  | `int capacity`          | Add(string sku, int amount) | item did not get added    | false      |
|                 |                         | Add(string sku1, string sku2) |                         |            |
|                 |                         | Add(string sku, string[] skus) |                        |            |
|                 |		                    | Remove(string sku)          | item got removed          | true       |
|                 |                         |                             | item did not get removed  | false      |
|                 |                         | ChangeCapacity(int size)    | capacity got changed      | true       |
|                 |                         |                             | capacity didnt get changed| false      |
|                 |                         | Exists(string item)         | check if item is in basket| bool       |
|                 |                         | CostOfBagel(string sku)     | get cost of a bagel       | double     |
|                 |                         | Products {get;}             | get products in basket    | list       |
|                 |                         | ProductOrders {get;}        | get productorders         | dict       |
|                 |                         | Capacity {get;}             | get the capacity          | int        |
|                 |                         | IsFull {get;}               | check if basket is full   | bool       |
|                 |                         | SumOfItems {get;}           | get sum of items in cost  | double     |
|                 |                         |                             |                           |            |
| Product         | `string sku`            | SKU {get; set;}             | unique SKU for item       | string     |
|                 | `int price`             | Price {get; set;}           | price for item            | int        |
|                 | `string name`           | Name {get; set}             | name of item              | string     |
|                 | `string variant`        | Variant {get; set;}         | variant of item           | string     |
|                 | `int stock`             | Stock {get; set;}           | amount of product in shop | int        |
|                 |                         | DecreaseStock()             | returns true if stock not 0 | bool     |
|                 |                         | IncreaseStock()             | returns true              | bool       |
| Bagel           | inherits from Product   |                             |                           |            |
| Coffee          | inherits from Product   |                             |                           |            |
| Filling         | inherits from Product   |                             |                           |            |
| BagelCoffee     | inherits from Product   |                             |                           |            |