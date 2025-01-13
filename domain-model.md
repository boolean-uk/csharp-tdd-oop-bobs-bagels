1. As a member of the public,\
So I can order a bagel before work,\
I'd like to add a specific type of bagel to my basket.

2. As a member of the public,\
So I can change my order,\
I'd like to remove a bagel from my basket.

3. As a member of the public,\
So that I can not overfill my small bagel basket\
I'd like to know when my basket is full when I try adding an item beyond my basket capacity.

4. As a Bob's Bagels manager,\
So that I can expand my business,\
I�d like to change the capacity of baskets.

5. As a member of the public\
So that I can maintain my sanity\
I'd like to know if I try to remove an item that doesn't exist in my basket. 

6. As a customer,\
So I know how much money I need,\
I'd like to know the total cost of items in my basket.

7. As a customer, \
So I know what the damage will be,\
I'd like to know the cost of a bagel before I add it to my basket.

8. As a customer, \
So I can shake things up a bit, \
I'd like to be able to choose fillings for my bagel.

9. As a customer, \
So I don't over-spend, \
I'd like to know the cost of each filling before I add it to my bagel order.

10. As the manager, \
So we don't get any weird requests,\
I want customers to only be able to order things that we stock in our inventory.

11. Extension 1 - Discounts \
As a manager,
So we can attract more customers, \
I want to offer a discount on bagels when they purchase 6 for �2.49 and 12 for �3.99 

11. Extension 1 - Discounts \
As a manager,
So we can attract even more customers, \
I want to offer a discount when customers purchase a coffee and bagel together for �1.25 
	 
12. Extension 2 - Printing Receipt \
As a manager, \
So customers can see a clear summary of their purchase \
I want to be able to print a detailed receipt of each purchase

12. Extension 3 - Printing Receipt with discount \
As a manager, \
So customers can see the incredible amount of money they saved \
I want the receipt to display all the discounts 

13. Extension 4 Part 1 - SMS \
As a manager, \
So customers can get order information digitally \
I want users to receive a text with their order summary,\
and delivery time when they complete their order.

| Classes   | Methods                                     | Scenario                                              | Outputs                 |
|-----------|---------------------------------------------|-------------------------------------------------------|-------------------------|
| Basket    | List\<Product> products {get; set;}          | Store all products currently in basket                | List\<Product> products  |
|           | GetPrice(String SKU)                        | Check cost of something e.g before adding to basket   | decimal cost            |
|           | AddProduct(String SKU)                      | customer adds product to their basket if not full     | bool                    |
|           | RemoveProduct(String SKU)                   | removes product if exists                             | bool                    |
|           | int MaxCapacity {set; get;} = 3 | sets max capacity for baskets                         | int maxCapacity         |
|           | GetTotalCost()                              | uses products list to get current basket cost         | decimal cost                |
|           | ApplyDiscounts(List\<Product> basketItems) |	goes through basket and applies discount prices | List\<Product> updatedItems |
| Inventory | List\<Product> inventory {get; set;}         | Store all products that should be available for order | List\<Product> inventory |
|			| Dictionary<String, Decimal> GetFillingsPriceList() | Use to get prices of just the fillings | Dictionary\<String, Decimal> fillingPrices |
| Product   | decimal Price {get; set;}                   | store a price for each bagel                          | decimal cost            |
|           | string Name {get;set;}                      | store type of product e.g Bagel, Coffee, Filling      | string ItemType         |
|           | string SKU {get; set; }                     | store SKU of product                                  | string SKU              |
|           | string Variant {get; set;}                  | store product variant                                 | string Variant          |
|			| decimal Discount { get; set; } = 0m;        | store the amount saved to display in receipt          | decimal discount        |
| Receipt   | DateTime Date { get; set; } = DateTime.Now; | store the date and time of receipt creation           |   Datetime  date        |
|           | string Header { get; set; } = "~~~ Bob's Bagels ~~~";| store receipt header                         |   string header        |
|           | PrintReceipt(List\<Product> items, decimal total)| print a formatted receipt of the customers purchase |    void      |
| TextMessage | SendMessage(List\<Product> items, decimal total) | send a confirmation message with an order summary to the customer         |   void       |
|           | FormatMessage(List\<Product> items, decimal total)| format the body of the confirmation message     |   string messageBody        |