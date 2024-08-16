#Domain Models In Here

Second Domain Model
| Classes         | Methods                          | Scenario                                | Outputs                                             |
|-----------------|----------------------------------|-----------------------------------------|-----------------------------------------------------|
| `Member`        | `addBagel(string name)`          | if bagel type exists                    | add bagel to basket list of member; return true     |
|				  |					                 | if bagel type does not exist            | triggers warning; return false                      |	
|                 | `removeBagel(string name)`       | if bagel type in basket                 | remove one bagel of said type; return true          |
|				  |						             | if bagel type not in basket             | triggers warning; return false                      |
|				  |	`basketOverflowWarning()`        | if called                               | prints warning                                      |
|				  |	`bagelNotInBasketWarning()`      | if called                               | prints warning                                      |
|				  | `getBasketCapacity()`            | method is called                        | returns the current basket capacity set by manager  |
|				  | `getCurrentBasketContent()`      | method is called                        | returns the length of the basket dict               |
|||||
|||||
|||||
| `Customer` ||||
|				  | `getCurrentBasketCost()`         | method is called                        | returns the cost of all bagels in basket            |
|				  | `checkBagelPrices()`             | method is called                        | returns the cost of all bagels available            |
|				  | `chooseBagelFillng(string name)` | if filling exists                       | adds bagel filling to basket                        |
|				  | `checkFillingPrices()`           | if called                               | returns the cost of all fillings available          |
|||||
|||||
|||||
| `Manager` ||||
|				  | `changeBasketCapacity(int size)` | method is called with int arg           | adjusts the basket capacity to size arg             |
|				  | `restockInventory()`             | if called                               | resets inventory to default stock                   |
|||||

|||||
|||||


| `Product`       | `getType()`                      | if called                               | returns the type of product                         |
|                 | `getPrice()`                     | if called                               | returns the price of product                        |
|                 | `getName()`                      | if called                               | returns the name of product                         |
|                 | `getSKU()`                      | if called                               | returns the name of product                         |
|||||
|||||
|||||
|||||
|||||


