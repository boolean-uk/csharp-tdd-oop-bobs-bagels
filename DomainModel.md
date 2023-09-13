Domain Models


Class      |            Attribute                        | Method               | Output        
-------------------------------------------------------------------------------------------------------------------
Basket     | Item list Bagel, Coffee                     | AddItem              | Boolean Success or fail
           | Capacity                                    | RemoveItem           | Boolean Success or fail
           |                                             | IsBasketFull         | Boolean is full or not
           |                                             | SetCapacity          | Update the capacity
           |                                             | GetCapacity          | Int returns current capacity
           |                                             | ContainsItem         | Boolean if item exists
           |                                             | GetTotalCost         | Total cost of basket
====================================================================================================================
Bagel      | SKU number, the price, the name and variant | GetPrice             | Price of bagel
           | List of fillings                            | AdFilling            | Boolean Success or fail
           |                                             | RemoveFilling        | Boolean Success or fail
           |                                             | TotalCostWithFilling | Total cost with the fillings
====================================================================================================================
Filling    | SKU number, the price, the name             | GetPrice             | Price of the filling
====================================================================================================================
Coffee     | SKU number, the price, the name and variant | GetPrice             | Price of the coffee
====================================================================================================================
Inventory  | Item list Bagel, coffee and fillings        | DoesTheItemExist     | Boolean does the item exist or not 
           |                                             | GetPriceOfItem       | Price of an item