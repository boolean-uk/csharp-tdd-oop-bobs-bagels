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

# Extension 2

## New Requirements
Update and extend your program to handle printing receipts. These receipts should print to the terminal.

## User stories
As a customer, 
I want to receive a detailed receipt showing each item purchased, the quantity, the cost per item, and the total cost, 
so I can understand what I'm paying for.

## Classes
| Class | Properties |
|---|---|
| Receipt | `List<ReceiptItem> Items`, `DateTime DateOfPurchase`, `double TotalCost` |
| ReceiptItem | `string Name`, `int Quantity`, `double Price` |


## Basket class functionality
| class|  Method | Scenario | Output |
|---|---|---|---|
| Basket | `Receipt Receipt(Order order)` |  | Returns a `Receipt` |
| Receipt | `int DisplayReceipt()` |  | Displays the receipt in the terminal |
