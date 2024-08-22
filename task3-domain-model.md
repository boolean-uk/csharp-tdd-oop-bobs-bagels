# Domain model for Bob's Bagels Extension Task 3
## Discounts on receipt

### User stories:
>1.
>As a customer,
I want to see what the receipt to include discounts,
So I can see how much I have saved on my order.



 
 
| Classes   | Methods | Scenario | Outputs |
|-----------|---------|----------|---------|
| `Basket ` |  ListItems()| extend from task 2 to include discounts| List<Purchase.>|
| `Receipt`	|  ReceiptToString() | Extend method to include printing what the customer has saved | string|



#### Discount List:

|SKU|	Name|	Variant	|Price|	Special offers|
|-----------|---------|----------|---------|
|BGLO	|Bagel|	Onion|	.49	|6 for 2.49|
|BGLP	|Bagel|	Plain	|.39	|12 for 3.99|
|BGLE|	Bagel	|Everything	|.49	|6 for 2.49|
|COFB	|Coffee	|Black	|.99	|Coffee & Bagel for 1.25


