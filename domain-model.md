# Bob's Bagels - Domain Model

Fillings are made very simple in this exercise. Realistically you might want to only allow products of variant
"Bagel" and "Coffee" to be added directly to the basket, while variant "Topping" can only be added directly
with a bagel, for instance by storing the data in a new class called Order. In Order you could keep track of
a main product, and also some possible toppings for the main product. Then you would create a method for adding
the topping to the Order. It gets a bit more complicated, but you could do it this way. I'll keep it simple.

| Class           | Members                 | Method/Property             | Scenario                  | Output     |
|-----------------|-------------------------|-----------------------------|---------------------------|------------|
| BagelShop       | `Dictionary<string, Product> category`| Category {get;}  | category of products      | Dictionary |
|                 |							| grabBasket()                | gives an empty basket     | Basket     |
|                 |                         |                             |                           |            |
| Basket          | `List<Product> products`| add(int sku)                | item got added to basket  | true       |
|				  | `int capacity`          |                             | item did not get added    | false      |
|                 |		                    | remove(int sku)             | item got removed          | true       |
|                 |                         |                             | item did not get removed  | false      |
|                 |                         | changeCapacity(int size)    | capacity got changed      | true       |
|                 |                         |                             | capacity didnt get changed| false      |
|                 |                         | exists(string item)         | check if item is in basket| bool       |
|                 |                         | costOfBagel(int sku)        | get cost of a bagel       | double     |
|                 |                         | Products {get;}             | get products in basket    | list       |
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