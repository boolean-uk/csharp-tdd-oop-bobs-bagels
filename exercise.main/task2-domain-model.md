# Domain model for Bob's Bagels Extension Task 2
## Printing receipts

### User stories:
>1.
>As a customer,
So I can see what I have bought,
I'd like see my receipt.


>2.
>As a customer, 
I want to see the stores name and a timestamp on my receipt,
So that i know where and when I made the purchase

>3.
>As a customer,
I want the receipt to list all items I purchased,
Including their names, quantities and individual prices,
So that I can review my purchase 

>4. 
>As a customer, 
I want the receipt to display the total cost of my purchase,
So that I know how much I spent

>5.
>As a customer, I want the receipt to include a thank you message, 
So that I feel appreciated for my purchase

 
 
| Classes   | Methods | Scenario | Outputs |
|-----------|---------|----------|---------|
|`Receipt` |ReceiptToString()| Converts the receipt to a string | string|
| `Basket` |ListItems()|Makes a list of all the items in the customers basket (name, qty, price)|List<Purchase,>|
||CreateReceipt() | Creates a receipt based on store name, a list purchased products and total cost| Receipt|
||PrintReceipt() |Prints the customers receipt in the terminal| string | 
|`Inventory`| GetStoreName()| Returns the name of the store | string|
|`Purchase`|



