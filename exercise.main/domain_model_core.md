Core

| Classes    | Methods                     | Scenario                                                               | Outputs                                         |
|------------|-----------------------------|------------------------------------------------------------------------|-------------------------------------------------|
| Basket.cs  | addProduct(sku)             | Adds the product with the given SKU to the basket object, if it exist. | $"{product} has been added to your basket!"     |
| Basket.cs  | removeProduct(sku)          | Removes the product with the given SKU from the basket, if it exist.   | $"{product} has been removed from your basket!" |
| Basket.cs  | isFull()                    | Returns true or false, based on if the basket is full or not.          | true || false                                   |
| Basket.cs  | changeCapacity(newCapacity) | Changes the capacity of a basket to newCapacity.                       |                                                 |
| Basket.cs  | totalCost()                 | Calculates and returns the total cost of the products in the basket.   | $"Total cost: {totalCost}!"                     |
| Bagel.cs   | Price()                     | Returns the cost of the bagel.                                         | $"Price of {bagelType} bagel is {price}!"       |
| Bagel.cs   | addFilling(fillingType)     | Adds the given fillingType to the bagel, if it exist.                  | $"Added {fillingType} on bagel!"                |
| Filling.cs | Price()                     | Returns the cost of the filling.                                       | $"Price of {fillingType} is {price}"            |

Extension 1: Discounts

| Classes     | Methods                          | Scenario                                      | Outputs                      |
|-------------|----------------------------------|-----------------------------------------------|------------------------------|
| Order.cs    | calculateDiscount(sku, quantity) | Calculates discount based on sku and quantity | Discount amount              |
| Order.cs    | ApplyDiscounts()                 | Applies discounts to basket items             |                              |

Extension 2: Receipts

| Classes    | Methods           | Scenario                                                | Outputs                   |
|------------|-------------------|---------------------------------------------------------|---------------------------|
| Receipt.cs | generateReceipt() | Creates and formats a receipt based on basket contents. | Formatted receipt string. |

Extension 3: Discount Receipts

It was easier to create an OrderItem with the values sku, itemName, quantity and price in Extention 2, just added savings value to the OrderItem for it to work with generateReceipt().

Extension 4:

| Classes        | Methods                                     | Scenario                                                          | Outputs                      |
|----------------|---------------------------------------------|-------------------------------------------------------------------|------------------------------|
| TwilioClass.cs | SendMessage(toPhoneNumber, messageBody)     | Sends simple messageBody to toPhoneNumber                         | Sent message: {message.Body} |
| Order.cs       | OrderToSms()                                | Formats the order to a sms friendly string                        |                              |
| TwilioClass.cs | SendOrderConfirmation(toPhoneNumber, order) | Sends order confirmation sms with order summary and delivery time |                              |



