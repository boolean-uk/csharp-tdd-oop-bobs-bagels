#Domain Models In Here

Second Domain Model
| Classes         | Methods												 | Scenario                                    | Outputs                                                        |
|-----------------|------------------------------------------------------|---------------------------------------------|----------------------------------------------------------------|
| `Customer`      | `addProduct(string name)`							 | if product type exists                      | calls method in manager to add product					        |
|				  |														 | if product does not exist                   | triggers warning; return false                                 |	
|                 | `removeBagel(string name)`							 | if product in basket					       | remove one bagel of said type; return true					    |
|				  |														 | if product not in basket		               | triggers warning; return false								    |
|				  | `checkBasketCapacity()`								 | method is called							   | returns the current basket capacity set by manager			    |
|				  | `checkBasketContent()`								 | method is called                            | returns a list of all products in basket		                |
|				  | `recieveProductInBasket(Product product)`			 | if product != null                          | adds the product to basket                                     |
|				  |                                         			 | if product == null                          | does not add the product to basket                             |
|				  | `getBagelStore()`									 | method is called							   | returns bagelstore object                                      |
|				  | `checkMenu()`                                        | method is called                            | returns the menu from the manager                              |
|				  | `getTotalCost()`                                     | method is called                            | returns the total cost of products in basket with no discount  |
|				  | `getTotalCostWithDiscount()`                         | method is called                            | returns the total cost of products in basket with discount     |
|				  | `checkout()`                                         | method is called                            | calculates total cost + discount and prints a reciept          |
|				  | `printReceipt(List<Tuple<>>)`                        | method is called                            | prints a reciept of all content in basket with discount        |
|				  | `checkMenu()`                                        | method is called                            | returns the menu from the manager                              |

| `Basket`		  | `getCapacity`                                        | method is called                            | returns the capacity of the basket                             |
|				  |	`productNotInBasketWarning()`                        | method is called                            | prints warning                                                 |
|				  |	`getProductsInBasket()`                              | method is called                            | returns list of products in basket                             |
|				  |	`addProduct(Product product)`                        | product is not null                         | adds product to list                                           |
|				  |	                                                     | product is null                             | does not add product to list                                   |
|				  |	`removeProduct(string SKU)`                          | string matches item in basket               | removes item                                                   |
|				  |	                                                     | string does not match item in basket        | does not remove item                                           |

| `Person`        | `Person(string Firstname, string LastName)`          | if called with args                         | creates an instance of person                                  |

| `Manager`       | `changeBasketCapacity(int newCapacity)`              | if called with args                         | changes the basket capacity                                    |
|				  |	`basketOverflowWarning()`                            | method is called                            | prints warning                                                 |
|				  | `getMenu()`                                          | method is called                            | returns the menu available                                     |
|				  | `getProduct(string SKU, Customer customer)`          | string matches item on menu                 | adds item to customers basket                                  |
|				  |                                                      | string does not match item on menu          | does not add item to customers basket                          |
|				  | `checkout(Basket basket)`                            | method is called                            | calculates total cost and returns list                         |

| `Product`       | `getType()`                                          | if called                                   | returns the type of product                                    |
|                 | `getPrice()`                                         | if called                                   | returns the price of product                                   |
|                 | `getName()`                                          | if called                                   | returns the name of product                                    |
|                 | `getSKU()`                                           | if called                                   | returns the name of product                                    |
|                 | `getVariants()`                                      | if called                                   | returns the variants of product                                |

| `Receipt`       | `printTop()`                                         | if called                                   | prints top of receipt                                          |
|                 | `printMid()`                                         | if called                                   | prints mid of receipt                                          |
|                 | `printBottom()`                                      | if called                                   | prints bottom of receipt                                       |


