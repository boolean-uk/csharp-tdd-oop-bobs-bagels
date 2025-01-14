# Domain

## User stories
1. Public: So I can order a bagel before work, I'd like to add a specific type of bagel to my basket.
2. Public: So I can change my order, I'd like to remove a bagel from my basket.
3. Public: So that I can not overfill my small bagel basket I'd like to know when my basket is full when I try adding an item beyond my basket capacity.
4. Public: So that I can maintain my sanity I'd like to know if I try to remove an item that doesn't exist in my basket.
5. Customer: So I know how much money I need, I'd like to know the total cost of items in my basket.
6. Customer: So I know what the damage will be, I'd like to know the cost of a bagel before I add it to my basket.
7. Customer: So I can shake things up a bit, I'd like to be able to choose fillings for my bagel.
8. Customer: So I don't over-spend, I'd like to know the cost of each filling before I add it to my bagel order.
9. Manager: So we don't get any weird requests, I want customers to only be able to order things that we stock in our inventory.
10. Manager: So that I can expand my business, I’d like to change the capacity of baskets.

## Requirements
* Add bagel to basket
* Remove bagel from basket
* Basket capacity
* Feedback on full basket
* Error on remove non-existing item
* See total cost of basket
* See cost of bagel before adding to basket
* Allow for choosing filling of bagel
* See cost of filling before adding to bagel
* Only allow for ordering items in stock
* Allow for changing basket capacity for admins


### Extensions:

1. Allow for special discounts: 3 for 2 and such
2. Add functionality for receipts to be printed
3. Support discounts in the receipts
4. Send text message confirmation
5. Order by text message
6. See text message history

## Classes

* StoreItem
* Basket
* Store
* Receipt
* User?
* Discount
* IRepository
* ListRepository

** Instead of making a table, I made empty classes and function stubs before creating any code. **

