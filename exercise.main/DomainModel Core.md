# Core

## User stories
1. I'd like to add a specific type of bagel to my basket.
2. I'd like to remove a bagel from my basket.
3. I'd like to know when my basket is full when I try adding an item beyond my basket capacity.
4. I’d like to change the capacity of baskets.
5. I'd like to know if I try to remove an item that doesn't exist in my basket.
6. I'd like to know the total cost of items in my basket.
7. I'd like to know the cost of a bagel before I add it to my basket.
8. I'd like to be able to choose fillings for my bagel.
9. I'd like to know the cost of each filling before I add it to my bagel order.
10. I want customers to only be able to order things that we stock in our inventory.
 
## Classes
| Class | properties |
|---|---|
| BagelVariant | `string Name`, `double Price` |
| BagelFilling | `string Name`, `double Price` |
| CoffeeVariant | `string Name`, `double Price` |
| Bagel | `BagelVariant Variant`, ` List<BagelFilling> Fillings` |
| Coffee | `CoffeeVariant Variant` |
| Basket | `List<Bagel> Bagels`, `List<Coffee> Coffees`, `int Capacity` |

## Functionality
| User story | Class | Method | Scenario | Output |
|---|---|---|---|---|
| 1 | Basket | `Add(Bagel bagel)`, `Add(Coffee coffee)` | `Basket` is not full | Adds product to `Basket.Bagels`|
| 3 | Basket |                    | `Basket` is full    | Displays `"Basket is full"`|
| 2 | Basket | `Remove(Bagel bagel)`, `Remove(Coffee coffee)` | Product exists in `Basket`       | Removes|
| 5 | Basket |                      | Product does not exist in `Basket` | Displays `$"{product} was not found in basket"`|
| 4 | Basket | `ChangeCapacity(int capacity)` |  | Sets `Basket.Capacity` to `capacity`|
| 6 | Basket | `double Cost()` |  | Returns total cost of products in `Basket` |
| 7 | Bagel | `double Cost()` |  | Returns total `Price` of `Variant` + all `BagelFilling`s |
| 8 | Bagel | `AddFilling(BagelFilling filling)` |  | Adds `filling` to `Fillings`|
| 9 | BagelFilling | `IEnumerable<BagelFilling> GetAll()` |  | Returns all the `Filling`s |

