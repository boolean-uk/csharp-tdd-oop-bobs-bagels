# Core

| Classes | Fields | 
| - | - |
| `Basket` | `List<Product> _basket` `int _maxBasketSize` |
| `Product` | `string SKU` `float productPrice` |
| `Bagel` | `List<Fill> filling` `string SKUName` `float basePrice` |
| `Filling` | `string SKUName` `float price` |
| `Coffee` | `string SKUName` `float price` | 
| `Inventory` | `Dictionary<string, float> coffeePrices` `Dictionary<string, float> bagelPrices` `Dictionary<string, float> fillingPrices` |
| `ProductFactory` | |

| Classes | Methods | Scenario (user_story_#) | Outputs |
|-|-|-|-|
| `Basket` | `AddItemToBasket(string[] SKUs)` | Add item to basket (1) | true |
| | | Failed to add item to basket (1, 2, 10) | false |
| | `AddItemToBasket(Product item)` | Add item to basket (1) | true |
| | | Failed to add item to basket (1, 2, 10) | false |
| | `SetBasketSize(int newSize)` | Change maximum basket capacity (4) | int |
| | `GetBasketPrice()` | Show total price of basket (6) | float | 
| | `RemoveProductFromBasket(string[] SKUs)` | Remove a item from the basket (2, 5) | true |
| | | Failed to remove item from basket (5) | false | 
| | `RemoveProductFromBasket(Product item)` | Remove a item from the basket (2, 5) | true |
| | | Failed to remove item from basket (5) | false | 
| | `IsFull()` | Ensure the basket is not full (3) | false |
| | | The basket is already full (3) | true | 
| | `IsValid(Product item)` | Validate that the provided item is in the inventory | true |
| | | If provided item is not in the inventory | false | 
| `Product` (interface) | `GetPrice()` | Retrieve the price of the product | float |
| | `GetBasePrice()` | Retrieve the base price of the product | float |
| | `GetSKUName()` | Retrieve the primary SKU name of the product | string |
| | | Failed to add item to product (1,2,10) | false |
| `Bagel` | `AddFilling(Filling fill)` | Add filling to bagel (1,8) | true |
| | | Failed to add filling (1, 8, 10) | false | 
| | `GetPrice()` | Retrieve price of the complete bagel including filling (7) | float |
| | `GetBasePrice()` | Retrieve the base price of the product | float |
| | `GetSKUName()` | Retrieve the primary SKU name of the product | string |
| | | Failed to add item to product (1,2,10) | false |
| `Coffee` | `GetPrice()` | Retrieve price of the coffee | float |
| | `GetBasePrice()` | Retrieve the base price of the product | float |
| | `GetSKUName()` | Retrieve the primary SKU name of the product | string |
| | | Failed to add item to product (1,2,10) | false |
| `Filling` | `GetPrice()` | Retrieve filling cost (9) | float | 
|| `IsValid(string SKU)` | Ensure valid filling SKU (10) | true |
| | | Filling SKU was invalid (10) | false |
| `Inventory` | `GetCoffePrice(string SKU)` | Retrieve cost of the specified coffee | float | 
| | | Could not find the specified coffee | 0 |
| | `GetBagelPrice(string SKU)` | Retrieve cost of the specified bagel | float | 
| | | Could not find the specified bagel | 0 |
| | `GetFillingPrice(string SKU)` | Retrieve cost of the specified filling | float | 
| | | Could not find the specified filling | 0 | 
| `ProductFactory` | `GenerateProduct(string[] SKU)`| Generate the product object | Product |
| | `ValidateProductSKU(string SKU)` | SKU provided was valid | true |
| | | SKU provided was invalid | false | 

## User story interpretation notes:
### 5. 
Assuming this can be integrated into 2., that it does not necessarily require dedicated output.

### 7.
Interpret the "cost of bagel" to also extend to coffee if selected as item to add to basket. 

# Extension 1
_(Only new additions, these are built on top of the old classes)

| Classes | fields | 
|-|-|
| `DiscountManager` (*static*) | |
| `Discount`| `List<Type> ProductSequence` `string Name` `float DiscountPrice` |

| Classes | Methods | Scenario (user_story_#) | Outputs | 
|-|-|-|-|
| `Basket`| `GetBasketPriceAfterDiscount()` | Returns the final price of the basket after applying all discounts | float |
| `Bagel` | `GetBasePrice` | Retrieve the price of the base bagel (excluding fillings) | float | 
| `DiscountManager` | `ApplyDiscount(Basket basket)` (*static*) | Apply the most beneficial discount to the basket and return the new total price | float | 
| `Discount`(abstract) | `GetSequence()` | Retrieve a shallow copy list of Types in the discount sequence | List<Type> |
| `DiscountBundleBagelAndCoffee` (implementes Discount) | - | - | - |
| `DiscountBundleLarge` (implements Discount) | - | - | - |
| `DiscountMundleSmall` (implements Discount) | - | - | - |

# Post Extension 1
*(Wanted to add a Person class for the core project. Not related to any extensions)*

| Classes | fields | 
|-|-|
|`Person`| `string Name` `bool _admin` `Basket basket` |


| Classes | Method | Scenario | Outputs | 
|-|-|-|-|
|`Person`| `GetBasket()` | Retrieve the basket regisetered on the Person | Basket|
| | `IsAdmin()` | If the user is administrator | true|
||| If the user is not an administrator | false | 