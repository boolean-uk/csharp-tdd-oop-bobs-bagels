#Domain Models In Here

```
Summary of User stories 1-10


| Classes    |        Members/Attributes                             |                 Methods                                  | Scenario                                                                     | Outputs                                                                 |
| --------   |-------------------------------------------------------|----------------------------------------------------------|------------------------------------------------------------------------------|-------------------------------------------------------------------------|           
| `Basket`   |List<Item> BagelList, int BasketCapacity               | `AddBagel(Item item)`                                    | Adds a bagel to the basket, ensuring the basket is not full.                 |True if the bagel is successfully added, false otherwise.                |                                                            |                                        |          
|            |                                                       | `RemoveBagel(string bagelType)`                          | Attempt to remove a bagel from the basket.                                   |True if the bagel is found and removed, false otherwise.                 |
|            |                                                       | `IsBasketFull()`                                         | Checking if the basket is full before adding an item.                        |True if the basket is full, false otherwise.                             |
|            |                                                       | `ChangeBasketCapacity(int newCapacity)`                  | Changes the basket capacity.                                                 |True if the capacity is changed successfully, false otherwise.           | 
|            |                                                       | `GetTotalCost()`                                         | Calculating the total cost of all items in the basket.                       |Total cost of items in the basket (double).                              |
|	         |                                                       | `GetBagelCost(string sku)`                               | Get the cost of a specific bagel without adding it to the basket.            |Cost of the specified bagel (double) or 0 if not found                   |
|            |                                                       |  `GetChosenFilling(string sku)`                          | Get the chosen filling for a specific bagel.                                 |The chosen filling for the specified bagel (string) or "Bagel not found".|
|            |                                                       |  `GetCostOfEachFilling(string sku)`                      | Get the cost of a specific filling.                                          |Cost of the specified filling (double) or 0 if not found.                |
|            |                                                       |                                                          |                                                                              |                                                                         |  
|            |                                                       |                                                          |                                                                              |                                                                         | 
|            |                                                       |                                                          |                                                                              |                                                                         |  
| `Item`     |'string Sku, double Price, string Name, string Variant'| 'Constructor Item(string sku, double price,              |Create an item with specific SKU, price, name, and variant                    |  Item instance                                                          |
|            |                                                       |   string name, string variant)'                          |                                                                              |                                                                         | 
|            |                                                       |                                                          |                                                                              |                                                                         |
|            |                                                       |                                                          |                                                                              |                                                                         |   
|            |                                                       |                                                          |                                                                              |                                                                         |  
|            |                                                       |                                                          |                                                                              |                                                                         | 
|            |                                                       |                                                          |                                                                              |                                                                         | 
|            |                                                       |                                                          |                                                                              |                                                                         |   
|'Inventory' |  'List<Item> Stock'                                   |'GetItemBySKU(string sku)'                                |Retrieve an item from the inventory by SKU                                    |  Item instance or null                                                  |   
|            |                                                       |                                                          |                                                                              |                                                                         |     
|            |                                                       |                                                          |                                                                              |                                                                         | 
|            |                                                       |                                                          |                                                                              |                                                                         |                             


Extension 1

User Stories:
1.
I have not got my paycheck for this month yet. 
I want to get special offers on certain items in my order, 
so that I can get discounts based on the quantity I purchase.

2
I am not good at Math.
I want to calculate the total cost of my order, considering both individual 
prices and special offers, so that I know how much I will be charged.



| Classes        | Members/Attributes                                      | Methods                                                 | Scenario                                                                                         | Outputs                                                        |
| ---------------| --------------------------------------------------------| ------------------------------------------------------- | -------------------------------------------------------------------------------------------------| -------------------------------------------------------------- |
| `Basket`       | List<Item> BagelList, int BasketCapacity                | `AddBagel(Item item)`                                   | Adds a bagel to the basket, ensuring the basket is not full.                                    | True if the bagel is successfully added, false otherwise.       |
|                |                                                         | `RemoveBagel(string bagelType)`                         | Attempts to remove a bagel from the basket.                                                     | True if the bagel is found and removed, false otherwise.        |
|                |                                                         | `IsBasketFull()`                                        | Checks if the basket is full before adding an item.                                             | True if the basket is full, false otherwise.                   |
|                |                                                         | `ChangeBasketCapacity(int newCapacity)`                 | Changes the basket capacity.                                                                    | True if the capacity is changed successfully, false otherwise.  |
|                |                                                         | `GetTotalCost()`                                        | Calculates the total cost of all items in the basket.                                           | Total cost of items in the basket (double).                    |
|                |                                                         | `GetBagelCost(string sku)`                              | Gets the cost of a specific bagel without adding it to the basket.                              | Cost of the specified bagel (double) or 0 if not found.        |
|                |                                                         | `GetChosenFilling(string sku)`                          | Gets the chosen filling for a specific bagel.                                                   | The chosen filling for the specified bagel (string) or "Bagel not found". |
|                |                                                         | `GetCostOfEachFilling(string sku)`                      | Gets the cost of a specific filling.                                                            | Cost of the specified filling (double) or 0 if not found.      |
|                |                                                         |                                                         |                                                                                                 |                                                                |
| `Item`         | 'string Sku, double Price, string Name, string Variant' | 'Constructor Item(string sku, double price, string name,| Creates an item with a specific SKU, price, name, and variant.                                  | Item instance 
                                                                             string variant, SpecialOffer offer = null)'             |                                                                                    |
|                |                                                         |                                                         |                                                                                                 |                                                                |
| `SpecialOffer` | int Quantity, double SpecialPrice                       |                                                         | Represents special offers for an item.                                                          |                                                                |
|                |                                                         |                                                         |                                                                                                 |                                                                |
| `Inventory`    | 'List<Item> Stock'                                      | 'GetItemBySKU(string sku)'                               | Retrieves an item from the inventory by SKU.                                                   | Item instance or null                                          |


```

