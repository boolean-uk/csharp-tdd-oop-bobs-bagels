## User Stories [CORE]
1. As a member of the public,
So I can order a bagel before work,
I'd like to add a specific type of bagel to my basket.

2. As a member of the public,
So I can change my order,
I'd like to remove a bagel from my basket.

3. As a member of the public,
So that I can not overfill my small bagel basket
I'd like to know when my basket is full when I try adding an item beyond my basket capacity.

4. As a Bob's Bagels manager,
So that I can expand my business,
I’d like to change the capacity of baskets.

5. As a member of the public
So that I can maintain my sanity
I'd like to know if I try to remove an item that doesn't exist in my basket.

6. As a customer,
So I know how much money I need,
I'd like to know the total cost of items in my basket.

7. As a customer,
So I know what the damage will be,
I'd like to know the cost of a bagel before I add it to my basket.

8. As a customer,
So I can shake things up a bit,
I'd like to be able to choose fillings for my bagel.

9. As a customer,
So I don't over-spend,
I'd like to know the cost of each filling before I add it to my bagel order.

10. As the manager,
So we don't get any weird requests,
I want customers to only be able to order things that we stock in our inventory.

## User Stories [Extended: Discounts]
11. As the manager,
So we can sell stuff before it goes bad and entice customers to buy,
I want to be able to set `Special Offer` for any product that matches `buy x nr of z for y`, `buy z, get [a,..] for y`.

<!-- 12.  As the manager,
So we don't lose money by allowing infinite purchases of a discounted product,
I want to be able to define how many of product `z` that should have the `Special Offer`. -->

13. As a customer,
So I know that I'm paying the the discounted price for a discounted product and no more,
I'd like a discount to automatically be applied when I buy `x` nr of `z` if a product has a `buy x nr of z for y` discount.

## User Stories [Extended: Reciepts]
14. As a customer,
So I can justify the cost of my purchases to my partner,
I'd like to get a reciepe containing my purchased products, along with the cost of each.

15. As a Manager,
So that we have a value to request the customer to pay,
I'd like the reciepe to contain a Total for all products on the reciept.

16. As a Manager,
So I can keep track of the stock for each product,
I want each purchase to be registered and the stock to be updated. 

17.   As a Manager,
So that the customer will have a good impression of us,
I want there to be a `thank you` message to the customer.

18.  As a Manager,
So that that the customer will know where they bought the bagels,
I want our name to be printed on the reciept.

19.  As a Manager,
So I can verify that the purchase is within our return time policy if a customer tries to return a product,
I want the date and time of the purchase present on the reciept.

20.  As a Manager,
So I don't waste unnecessary amount of reciept paper,
I want identical products to be grouped together and a number to be used to represent the amount.

21.  As a Manager,
So that we have a way to identify each purchase,
I want the date and time of the purchase present on the reciept.

22.  As a Developer,
So that I don't need to buy a reciept printer,
I want to be able to print a reciep to the terminal.

## User Stories [Extended: Discounted Reciepts]

23. as a Customer, 
so that I know that all the discounts has been accounted for,
I want to see all the discounts (per product) on the reciept.

24.  as a Manager, 
so that they feel extra good about their purchase,
I want the customer to see how much they saved on discounts.

| User Story Id | Class            | Method/Property             | Scenario                                                                                                  | Output                                                                                |
|---------------|------------------|-----------------------------|-----------------------------------------------------------------------------------------------------------|---------------------------------------------------------------------------------------|
| 1             | Product          | Abstract class ?            | A Basket contains a list of different Products                                                            | Allows for polymorphism                                                               |
| 11            | Product          | DateTime ExpirationDate     | Manager wants to apply a discount to all Products with a expiration date less than 2 days                 | ExpirationDate is returned                                                            |
| 7, 9          | Product          | Price (prop)                | User wants to know the price of a product                                                                 | returns value of Product                                                              |
|               |                  |                             |                                                                                                           |                                                                                       |
| 7, 9          | StoreFront       | Interface + impl.           | Present product and deal information                                                                      | User interface that shows products, guide user into buying                                                                                      |
|               |                  |                             |                                                                                                           |                                                                                       |
| 1             | Basket           | Add                         | User wants to add a bagel to their basket, to purchase                                                    | Bagel product added to the basket                                                     |
| 2             | Basket           | Remove                      | user wants to remove a bagel from their basket, not to be included in the puschase                        | The removed bagel is no longer part of the Products in the basket                     |
| 5             | Basket           | Remove                      | User removes an item that doesn't exist in their basket                                                   | User recieves a warning                                                               |
| 16            | Basket           | Remove                      | User removes several items from their inventory                                                           | Products will return to the Inventory stock                                                               |
| 3             | Basket           | Capacity (prop)             | The user tries to add another bagel to their basket, but the basket is full                               | No new bagel will be added to the basket, basket product list remains unchanged       |
| 4             | Basket           | Capacity (prop)             | Manager decides to allow one more item in the basket                                                      | The basket now contains a productlist that can fit one more item                      |
| 6             | Basket           | GetTotal                    | User has added several products to basket, they want to know how much its going to cost                   | returns the sum of all items                                                          |
| 10            | Basket           | Add                         | User wants to add a Product to their Basket, but stock is 0                          | nothing is added                                                                      |
| 8             | Basket           | Add                         | User want to select several fillings for their Bagle                                  | Fillings are addded to the order                                      |
|               |                  |                             |                                                                                                           |                                                                                       |
|               |                  |                             |                                                                                                           |                                                                                       |
|               |                  |                             |                                                                                                           |                                                                                       |
| 11            | DiscountManager  | discountTypes (list)        | Different Discount types can defined and added to the DiscountManager                                     | Each discount type is considered when calculating the total to pay                                                                                       |
| 13            | DiscountManager  | calculateDiscount           | applies and calculate the best possible discount (a product can only be part of one discount)             | The most valuable discounts will always be applied at checkout                                                                                        |
|               |                  |                             |                                                                                                           |                                                                                       |
| 11            | Discount         | Constructor                 | class used to represent discounts                                                                         | Allows to create different types of Discounts, example: based on expiry date                                                                                      |
| 11, 24        | Discount         | GetDiscountedPrice(...)     | user is paying and the discounted price needs to be applied                                               | User ends up paying the reduced price                                                 |
| 11, 24        | Discount_XforY   | Discount impl     | Manager wants to create discounts for `buy x nr of z for y`, `buy z, get [a,..] for y` for multiple products        | Created discount types can now be registered to DiscountManager to be used by customers                                                 |
|               |                  |                             |                                                                                                           |                                                                                       |
|               |                  |                             |                                                                                                           |                                                                                       |
| 13            | CashRegister     | Constructor                 | all purchases is handled by the CashRegister                                                              |                                                                                       |
| 13            | CashRegister     | RegisterBasket              | User is ready to pay, all products in their basket will be summed up,  any discount will be accounted for | Sets the currentBasket, ready for user to Pay                                         |
| 13            | CashRegister     | Basket CurrentBasket (prop) | The current Basket instance being processed                                                               |                                                                                       |
| 13, 14, 15    | CashRegister     | FinalizePurchase            | User provides required amont of money                                                                     | returns a reciept, deletes basket                                                     |
| 17, 18, 20, 21, 22, 23, 24    | CashRegister     | FinalizePurchase            | the Reciept will contain Product information (product and amount of it), purchase DateTime, Store title and a `thank you`                               |                                                                                       |
| 13            | CashRegister     | FinalizePurchase            | User doesn't have enough money                                                                            | currentBasket is set to Null                                                          |
|               |                  |                             |                                                                                                           |                                                                                       |
| 16            | Inventory        | Constructor                 | Keep tracks on the inventory                                                                              |                                                                                       |
| 10            | Inventory        | Stock (Dictionary)                | User wanted to add Product to their order, but stock is 0                             |   Nothing is added                                                                                    |
| 16            | Inventory        | Remove(Product)             | Product is removed when placed in users basket                                                         | Product is removed from inventory                                                     |
| 16            | Inventory        | Remove(Product)             | Product a removed when User Finalizes a Purchase                                                         | Product is removed from inventory                                                     |
| 16            | Inventory        | add(Product, nr)            | Manager bought 100 jars of pickle                                                                         | 100 jars of pickle added to the inventory                                             |




<!--| 8             | ProductComponent | ProductComponent  Product   | User want to order a custom product, containing one or several ingredients                                | A Product that contains a list of ProductComponent (which are inherited from Product) |-->
<!-- | 8             | ProductDesigner  | Factory class for Products  | Used to construct products                                                                                |                                                                                       |
| 8             | ProductDesigner  | Create                      | User want to select several fillings for their Bagle                                  | a Bagle is returned with the requested fillings                                       | -->
<!--| 12            | Discount         | Condition (lambda)          | defines what circumstances the discount is valid for (Limited amount, )                                   |                                                                                       | -->
<!-- | 19            | Inventory        | History (prop)              | When a purchase is made, it is kept in the history using DateTime as an ID                                |                                                                                       | -->
<!-- | 16            | Inventory        | SetBusy(Product)            | Marks an Product as taken by another Users Basket                                                         |                                                                                       | -->
<!--  | | |                  | |                                    |                        | -->