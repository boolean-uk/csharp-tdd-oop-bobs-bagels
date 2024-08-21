# Domain model for Bob's Bagels Extension Task 3
## Discounts

### User stories:
>1.
>As a customer,
I want to see the discount list,
So I can see what to buy.




 
 
| Classes   | Methods | Scenario | Outputs |
|-----------|---------|----------|---------|
| `Inventory ` |ShowDiscountList()|Returns a list of the discout oppurtunitys  |List<Discount ,> |
|| GetItemBySKU(string SKU) | Returns an inventory product | InventoryProduct|
| `Basket ` | CheckDiscount() | Checks if the basket has enough bagels to receive a discount | bool |
|| AddDiscount() | Adds the discount to the purchase| void|
|| ListItems()| extend from task 2 to include the adddiscount method| List<Purchase.>|



#### Discount List:

|SKU|	Name|	Variant	|Price|	Special offers|
|-----------|---------|----------|---------|
|BGLO	|Bagel|	Onion|	.49	|6 for 2.49|
|BGLP	|Bagel|	Plain	|.39	|12 for 3.99|
|BGLE|	Bagel	|Everything	|.49	|6 for 2.49|
|COFB	|Coffee	|Black	|.99	|Coffee & Bagel for 1.25



