

| Classes | User     | Methods/Properties                     | Scenarios                                    | Outputs                                                         |
|---------|----------|----------------------------------------|----------------------------------------------|-----------------------------------------------------------------|
| Basket  | Customer | Add(Item item)                         | add an item to basket                        | adds (one) item to basket (if it exists)                        |
| Basket  | Customer | Remove(Item item)                      | remove an item from the basket (if possible) | removes (one) item from the basket, error if item not in basket |
| Basket  | Customer | SpaceLeft()                            | see how much space is left in the basket     | returns amount of free space in basket                          |
| Basket  | Manager  | ChangeCapacity(int newCapacity)        | change capacity of basket                    |                                                                 |
| Basket  | Customer | GetTotalCost()                         | get total cost of basket                     | returns total cost of all items in basket                       |
| Item    | Customer | cost                                   | see price of item                            | returns the price of an item                                    |
| Bagel   | Customer | possibleFillings                       | see fillings                                 | returns a list of the possible fillings                         |
| Bagel   | Customer | AddFilling(Item filling, item toBagel) | adds a filling to the bagel                  | adds a filling to the bagel                                     |