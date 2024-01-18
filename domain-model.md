| Classes   | Methods                    | Scenario                                       | Outputs |
|-----------|----------------------------|------------------------------------------------|---------|
| `Basket`  | `Add(Bagel bagel)`         | Adds a bagel to the basket                     | bool    |
|           | `Remove(Bagel bagel)`      | Removes a bagel from the basket                | bool    |
|           | `ChangeCapacity(int cap)`  | Changes the capacity of the basket             | void    |
|           | `Cost(bool skip)`          | Returns the cost of items in without discounts | double  |
| `Bagel`   | `Cost()`                   | Returns the cost of a bagel                    | double  |
|           | `AddFilling(Filling fill)` | Adds filling to bagel                          | void    |
| `Filling` | `Cost()`                   | Returns the cost of a filling                  | double  |
| `Basket`  | `Cost()`                   | Returns the cost of items after discounts      | double  |
|           | `GetReceipt()`             | Returns the receipt                            | string  |