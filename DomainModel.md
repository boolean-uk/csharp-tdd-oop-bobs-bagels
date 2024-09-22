# Domain Model - Core

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
| `Basket` | `Dictionary<Item, int> _items (value is num of same item in basket)` | `AddItem(Item item)` | Add item to basket | `true` |
| `Basket` | `Dictionary<Item, int> _items, int basketCapacity` | `AddItem(Item item)` | Add item to basket when basket is full | `false` |
| `Basket` | `Dictionary<Item, int> _items` | `RemoveItem(Item item)` | Remove item from basket | `true` |
| `Basket` | `Dictionary<Item, int> _items` | `RemoveItem(Item item)` | Remove item from basket that doesn't exist in basket | `false` |
| `Basket` | `int basketCapacity` | `ChangeCapacity(int capacity, User user)` | As manager change basket capacity | `true` |
| `Basket` | `Dictionary<Item, int> _items` | `SumOfItemCosts()` | Get sum of total cost of items in basket | `float` |
| `BobsBagelStore` | `List<Item> _inventory` | `GetItem(string sku)` | Get item from inventory | `true` |
| `BobsBagelStore` | `List<Item> _inventory` | `ViewInventory()` | View products in store to choose wanted name and variant | `Console + bool` |
| `BobsBagelStore` | `List<Item> _inventory` | `ViewInventory()` | View products with prices | `Console + bool` |
| `Item` | float Price |  | Get price of item | `float` |


# Domain Model - Extension 2: Receipts
- As a customer, So i know which items im paying for, I'd like to get a receipt when checking out with the items in my basket.
- As a customer, So i know how much money i need to pay, I'd like get a total sum of the cost of all the items in my receipt.
- As a manager, So i know how the business of the store is going, I'd like to view total profit from customers today.

| **Classes** | **Members** | **Methods** | **Scenario** | **Outputs** |
|:--:|:--:|:--:|:--:|:--:|
| `BobsBagelStore` | `List<Receipt> _receipts` | `GenerateReceipt(Basket basket)` | Generate receipt from items in basket | `Receipt?` |
| `Receipt` | `Basket _relatedBasket` | `PrintReceipt(Item item)` | Print out receipt to terminal | `Console` |
| `BobsBagelStore` | `List<Receipt> _receipts` | `ViewProfits()` | View total profits today | `Console + float` |


# Domain Model - Extension 1 & 3: Discounts on receipt
- As a customer, So im able to save money, I'd like to take advantage of special offers available in the store.

| **Classes** | **Members** | **Methods** | **Scenario** | **Outputs** |
|:--:|:--:|:--:|:--:|:--:|
| `Item` | `List<Receipt> _receipts` | `GenerateReceipt(Basket basket)` | Generate receipt from items in basket | `Receipt?` |
| `Receipt` | `Basket _relatedBasket` | `PrintReceipt(Item item)` | Print out receipt to terminal | `Console` |
| `BobsBagelStore` | `List<Receipt> _receipts` | `ViewProfits()` | View total profits today | `Console + float` |