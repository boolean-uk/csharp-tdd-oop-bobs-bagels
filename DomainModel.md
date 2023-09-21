Domain Models


Class              |            Attribute                        | Method               | Output        
--------------------------------------------------------------------------------------------------------------------------------
Basket             | Item list of order items                    | AddItem              | Boolean Success or fail
                   | Capacity                                    | RemoveItem           | Boolean Success or fail
                   | Inventory                                   | IsBasketFull         | Boolean is full or not
                   |                                             | SetCapacity          | Update the capacity
                   |                                             | GetCapacity          | Int returns current capacity
                   |                                             | ContainsItem         | Boolean if item exists
                   |                                             | GetTotalCost         | Total cost of basket
                   |                                             | GenerateReceipt      | Generate the receipt for basket
                   |                                             | GetTotalSavings      | Total savings of the basket
                   |                                             | GetItemSavings       | Savings for each item in basket
================================================================================================================================
Interface IProduct |                                             | GetPrice             | Get the price of the product
================================================================================================================================
Bagel              | SKU number, the price, the name and variant | TotalCostWithFilling | Total cost with the fillings
(Implements        | List of fillings                            | AddFilling           | Boolean Success or fail
IProduct)          |                                             | RemoveFilling        | Boolean Success or fail
================================================================================================================================
Filling            | SKU number, the price, the name             | GetPrice             | Price of the filling
================================================================================================================================
Coffee (implements | SKU number, the price and variant           |                      | 
IProduct)          |                                             |                      |
================================================================================================================================
Inventory          | Item list Bagel, coffee and fillings        | DoesTheItemExist     | Boolean does the item exist or not 
                   |                                             | GetPriceOfItem       | Price of an item
                   |                                             | StockInventory       | The original stock
                   |                                             | GetDiscountForBulk   | Gives a discount for an item you buy in bulk
                   |                                             | GetDiscountForCombo  | Gives a discount for combining items
================================================================================================================================
Discount           | Type of discount                            | IsDiscounted         | Boolean discount or not
                   | Amount of discount                          | CalculateDiscount    | New total after applying discount
================================================================================================================================
BulkDiscount       | Quantity, BulkPrice                         |                      |
(Inherits Discount)|                                             |                      |       
================================================================================================================================
ComboDiscount      | ComboItems, ComboPrice                      |                      |
(Inherits Discount)|                                             |                      |
================================================================================================================================
Receipt            | Time of purshase                            | GeneratePrint        | String Time to print
                   | List of all items in order                  | ToString             | String of receipt to print
                   | Total price of the purshased basket         | GetSavings           | Total savings for the receipt
                   |                                             | DisplayItemSavings   | Display savings for each item
================================================================================================================================
OrderItem          | The actual items                            | TotalPrice           | Total price for the quantity of item
                   | The amount of items                         | GetSavings           | Savings for the item
                   | Original price                              |                      |
                   | Discounted Price                            |                      |
================================================================================================================================            