# Domain Model

- As a member of the public, So I can order a bagel before work, I'd like to add a specific type of bagel to my basket.
- As a member of the public, So I can change my order, I'd like to remove a bagel from my basket.
- As a member of the public, So that I can not overfill my small bagel basket I'd like to know when my basket is full when I try adding an item beyond my basket capacity.
- As a Bob's Bagels manager, So that I can expand my business, I’d like to change the capacity of baskets.
- As a member of the public So that I can maintain my sanity I'd like to know if I try to remove an item that doesn't exist in my basket.
- As a customer, So I know how much money I need, I'd like to know the total cost of items in my basket.
- As a customer, So I know what the damage will be, I'd like to know the cost of a bagel before I add it to my basket.
- As a customer, So I can shake things up a bit, I'd like to be able to choose fillings for my bagel.
- As a customer, So I don't over-spend, I'd like to know the cost of each filling before I add it to my bagel order.
- As the manager, So we don't get any weird requests, I want customers to only be able to order things that we stock in our inventory.


| **Classes** | **Members** | **Methods** | **Scenario** | **Outputs** |
|:--:|:--:|:--:|:--:|:--:|
| `Basket` | `Dictionary<Item, int> items (value is num of same item in basket)` | `AddItemToBasket(Item item)` | Add item to basket | `true` |
| `Basket` | `Dictionary<Item, int> items` | `RemoveItemFromBasket(Item item)` | Remove item from basket | `true` |
| `Basket` | `Dictionary<Item, int> items` | `RemoveItemFromBasket(Item item)` | Remove item from basket that doesn't exist in basket | `false` |
| `Basket` | `Dictionary<Item, int> items, int basketCapacity` | `AddItemToBasket(Item item)` | Add item to basket when basket is full | `false` |
| `Basket, User` | `Dictionary<Item, int> items, int basketCapacity` | `ChangeCapacity(int capacity)` | As manager(admin) change basket capacity | `true` |
| `Basket` | `Dictionary<Item, int> items` | `Sum()` | Get sum of total cost of items in basket | `float` |
| `Item` | float price |  | Get price of item | `float` |
| `BobsBagelStore` | `Dictionary<Item, int> inventory` | `ViewInventory()` | View products in store to choose wanted name and variant | `Console + bools` |
| `BobsBagelStore` | `Dictionary<Item, int> inventory` | `ViewInventory()` | View products with prices | `Console + bools` |
| `BobsBagelStore` | `Dictionary<Item, int> inventory` | `AddItemToBasket(Item item, Basket basket)` | Get item from inventory in stock | `true` |
| `BobsBagelStore` | `Dictionary<Item, int> inventory` | `AddItemToBasket(Item item, Basket basket)` | Get item from inventory that is not in stock | `true` |


