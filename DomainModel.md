Domain Models


Class      |            Attribute                        | Method               | Output        
--------------------------------------------------------------------------------------------------------------------------------
Basket     | Item list Bagel, Coffee                     | AddItem              | Boolean Success or fail
           | Capacity                                    | RemoveItem           | Boolean Success or fail
           | Inventory                                   | IsBasketFull         | Boolean is full or not
           |                                             | SetCapacity          | Update the capacity
           |                                             | GetCapacity          | Int returns current capacity
           |                                             | ContainsItem         | Boolean if item exists
           |                                             | GetTotalCost         | Total cost of basket
           |                                             | GenerateReceipt      | Generate the receipt for basket
================================================================================================================================
Bagel      | SKU number, the price, the name and variant | GetPrice             | Price of bagel
           | List of fillings                            | AdFilling            | Boolean Success or fail
           |                                             | RemoveFilling        | Boolean Success or fail
           |                                             | TotalCostWithFilling | Total cost with the fillings
================================================================================================================================
Filling    | SKU number, the price, the name             | GetPrice             | Price of the filling
================================================================================================================================
Coffee     | SKU number, the price and variant           | GetPrice             | Price of the coffee
================================================================================================================================
Inventory  | Item list Bagel, coffee and fillings        | DoesTheItemExist     | Boolean does the item exist or not 
           |                                             | GetPriceOfItem       | Price of an item
           |                                             | StockInventory       | The original stock
           |                                             | GetDiscountForBulk   | Gives a discount for an item you buy in bulk
           |                                             | GetDiscountForCombo  | Gives a discount for combining items
================================================================================================================================
Discount   | Type of discount, bulk or combo             | DiscountOrNot        | Boolean discount or not
           | Amount of discount                          | CalculateTheDiscount | New total after applying discount
================================================================================================================================
Receipt    | Time of purshase                            | GeneratePrint        | String Time to print
           | List of all items in order                  | ToString             | String of receipt to print
           | Total price of the purhased basket          |                      |
================================================================================================================================
OrderItem  | The actual items                            | TotalPrice           | Total price for the quantity of item
           | The amount of items                         |
