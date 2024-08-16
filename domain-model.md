# Bob's Bagels - Domain Model

| Class           | Members                 | Method/Property             | Scenario                  | Output     |
|-----------------|-------------------------|-----------------------------|---------------------------|------------|
| BagelShop       | `Dictionary<string, Product> category`| Category {get;}  | category of products      | Dictionary |
|                 |							| grabBasket()                | gives an empty basket     | Basket     |
|                 |							| getProduct(int sku)         | get the product           | Product    |
|                 |                         | refillProduct(int sku)      | customer returns product  | nothing    |
|                 |                         |                             |                           |            |
| Basket          | `List<Product> products`| add(int sku)                | item got added to basket  | true       |
|				  | `int capacity`          |                             | item did not get added    | false      |
|                 |                         | remove(int sku)             | item got removed          | true       |
|                 |                         |                             | item did not get removed  | false      |
|                 |                         | IsFull {get;}               | check if basket is full   | bool       |
|                 |                         | changeCapacity(int size)    | capacity got changed      | true       |
|                 |                         |                             | capacity didnt get changed| false      |
|                 |                         | exists(string item)         | check if item is in basket| bool       |
|                 |                         | SumOfItems {get;}           | get sum of items in cost  | double     |
|                 |                         | costOfBagel(int sku)        | get cost of a bagel       | double     |
|                 |                         |                             |                           |            |
| Product         | `string sku`            | SKU {get; set;}             | unique SKU for item       | string     |
|                 | `int price`             | Price {get; set;}           | price for item            | int        |
|                 | `string name`           | Name {get; set}             | name of item              | string     |
|                 | `string variant`        | Variant {get; set;}         | variant of item           | string     |
|                 | `static int stock`      | Stock {get; set;}           | amount of product in shop | int        |
|                 | `List<Product> extra`   | addExtra(Product extra)     | filling got added to bagel| true       |
|                 |                         |                             | filling did not get added | false      |