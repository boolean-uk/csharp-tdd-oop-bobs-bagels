# Bob's Bagels 

## Domain model



### Requirements Core

1. public, Add bagel to basket
2. public, Remove bagel from basket
3. public, Feedback when basket is full/add item beyond capacity
4. manager, Change capacity of basket
5. public, Feedback when trying to remove an item that doesnt exist in basket
6. customer, Show total cost of items in basket 
7. customer, See cost of bagel before adding
8. customer, Choose fillings for bagel
9. customer, See cost of each filling before adding to bagel order
10. manager, Ensure only things in inventory can be sold 
	

### Requirements Extension

11. customer, Get discount when special offers apply
12. customer, Fillings still cost extra amount per bagel
13. customer, Get receipt for order
14. customer, Get receipt with discount



| Classes      | Methods/Properties                   | Scenario                                   | Outputs                             |
|--------------|--------------------------------------|--------------------------------------------|-------------------------------------|
| Basket.cs    | AddItem(Product product)             | Add bagel to basket                        | Feedback as string                  |
| Basket.cs    | RemoveItem(Product product)          | Remove bagel from basket                   | Feedback if not in basket as string |
| Basket.cs    | Capacity                             | Change capacity of basket                  |                                     |
| Basket.cs    | Total                                | Show total cost of basket                  | sum of basket products as decimal   |
| Bagel.cs     | Price, TotalPrice                    | See price of bagel and bagel with fillings | price as decimal                    |
| Bagel.cs     | AddFilling()                         | Add filling to bagel                       |                                     |
| Filling.cs   | Price                                | See price of filling before adding         | price as decimal                    |
| Inventory.cs | Dictonary<string, IProduct> Products | Inventory of products to choose from       |                                     |
| Receipt.cs   | ComboThenBulkDiscountTotal()         | Apply combo then bulk discount to basket   | discounted price as decimal         |
| Receipt.cs   | PrintReceipt()                       | Generates and prints a receipt             |                                     |     |                                            |                    |