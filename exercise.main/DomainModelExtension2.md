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
