| Classes            | Methods                                     | Scenario                                                            | Outputs                 |
|--------------------|---------------------------------------------|---------------------------------------------------------------------|-------------------------|
| Basket             | List\<Product> products {get; set;}          | Store all products currently in basket                              | List\<Product> products  |
|                    | GetPrice(Product item)                      | Check cost of something e.g before adding to basket                 | decimal cost            |
|                    | GetFillingPrice()                           |                                                                     |                         |
|                    | AddBagel(Bagel item, bool addFillings)      | customer adds a bagel to their basket if not full                   | bool                    |
|                    | AddDrink(Coffee item)                       | customers adds a drink to their order                               | bool                    |
|                    | RemoveProduct(Product item)                 | removes product if exists, should remove fillings if bagel selected | bool                    |
|                    | int MaxCapacity {set(isManager)); get;} = 3 | sets bax capacity for baskets                                       | int maxCapacity         |
|                    | GetTotalCost()                              | uses products list to get current basket cost                       | int cost                |
| Inventory          | List\<Product> inventory {get; set;}         | Store all products that should be available for order               | List\<Product> inventory |
| Product (Abstract) | decimal Price {get; set;}                   | store a price for each bagel                                        | decimal cost            |
|                    | string Name {get;set;}                      | store type of product e.g Bagel, Coffee, Filling                    | string ItemType         |
|                    | string SKU {get; set; }                     | store SKU of product                                                | string SKU              |
|                    | string Variant {get; set;}                  | store product variant                                               | string Variant          |
| Bagel:Product      | List\<Filling> fillings {get; set;}         | store any fillings added to the bagel                               | List\<Filling> fillings  |
| Coffee:Product     |                                             | inherits                                                            |                         |
| Filling: Product   |                                             | inherits                                                            |                         |