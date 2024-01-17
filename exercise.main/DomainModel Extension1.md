## Bob's Inventory
| SKU  | Price | Name   | Variant       |
|------|-------|--------|---------------|
| BGLO | 0.49  | Bagel  | Onion         |
| BGLP | 0.39  | Bagel  | Plain         |
| BGLE | 0.49  | Bagel  | Everything    |
| BGLS | 0.49  | Bagel  | Sesame        |
| COFB | 0.99  | Coffee | Black         |
| COFW | 1.19  | Coffee | White         |
| COFC | 1.29  | Coffee | Cappuccino    |
| COFL | 1.29  | Coffee | Latte         |
| FILB | 0.12  | Filling| Bacon         |
| FILE | 0.12  | Filling| Egg           |
| FILC | 0.12  | Filling| Cheese        |
| FILX | 0.12  | Filling| Cream Cheese  |
| FILS | 0.12  | Filling| Smoked Salmon |
| FILH | 0.12  | Filling| Ham           |

# Extension 1

## New Requirements
1. Products are identified using Stock Keeping Units, or SKUs.

To acheive this I will create a new class `Basket` that will abstract the current Core solution (`BasketManager` and `Inventory`).

2. Some items are multi-priced.

| SKU  | Name    | Variant     | Price | Special Offers    |
|------|---------|-------------|-------|-------------------|
| BGLO | Bagel   | Onion       | 0.49  | 6 for 2.49        |
| BGLP | Bagel   | Plain       | 0.39  | 12 for 3.99       |
| BGLE | Bagel   | Everything  | 0.49  | 6 for 2.49        |
| COFB | Coffee  | Black       | 0.99  | Coffee & Bagel for 1.25 |

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
	
## Basket class functionality
| User story | Method | Scenario | Output |
|---|---|---|---|
| 1 | `int Add(string sku)` | There is a item in inventory with `sku` and `Basket` is not full | Adds product to `Basket.Bagels`. And returns the bagels ID|
| 10|| There is no item in Inventory with `sku` | Displays `$"There is no item with SKU: {sku}"`. And returns `0`|
| 3 || `Basket` is full     | Displays `"Basket is full"`. And returns `0`|
| 2 | `Remove(int id)` | There is a product in basket with `id` | Removes product from `Basket`|
| 5 || There is no product in basket with `id` | Displays `$"No products were found with ID: {id}"`|
| 4 | `ChangeCapacity(int capacity)` |  | Sets `Basket.Capacity` to `capacity`|
| 6 | `double Cost()` |  | Returns total cost of products in basket |
| 7, 9 | `double ProductCost(string sku)` | There is a item in inventory with `sku` | Returns  `Price` of product |
| 10|                          | There is no item in Inventory with `sku` | Displays `$"There is no item with SKU: {sku}"`|
| 8 | `AddFilling(int id, string sku)` | There is a product in basket with `id` and there is a item with `sku` in inventory | Adds `filling` to `Fillings` on the bagel that has the `id`|
|  || There is no product in basket with `id` | Displays `$"There is no product with ID: {id}"` |
| 10|                          | There is no item in Inventory with `sku` | Displays `$"There is no item with SKU: {sku}"`|