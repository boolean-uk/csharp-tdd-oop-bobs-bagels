| Classes | Methods/Properties                        | Scenarios                                      | Outputs                                                         |
|---------|-------------------------------------------|------------------------------------------------|-----------------------------------------------------------------|
| Basket  | Add(Item item)                            | add an item to basket                          | adds (one) item to basket (if it exists)                        |
| Basket  | Remove(Item item)                         | remove an item from the basket (if possible)   | removes (one) item from the basket, error if item not in basket |
| Basket  | SpaceLeft()                               | see how much space is left in the basket       | returns amount of free space in basket                          |
| Basket  | ChangeCapacity(int newCapacity)           | change capacity of basket                      |                                                                 |
| Basket  | GetTotalCost()                            | get total cost of basket                       | returns total cost of all items in basket                       |
| Item    | cost                                      | see price of item                              | returns the price of an item                                    |
| Bagel   | possibleFillings                          | see fillings                                   | returns a list of the possible fillings                         |
| Bagel   | AddFilling(Item filling, item toBagel)    | adds a filling to the bagel                    | adds a filling to the bagel                                     |
| Receipt | PrintReceipt(List\<Item\> items )         | prints the receipt for the customer to receive | writes receipt to console and returns the cost after discounts  |