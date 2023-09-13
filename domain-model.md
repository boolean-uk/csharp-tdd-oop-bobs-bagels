# Domain Models

| Classes         | Methods                                                         | User Story (Scenario)      | Outputs |
|-----------------|-----------------------------------------------------------------|----------------------------|---------|
| `BobsBagelsApp` | `AddBagel(string bagelType)`                                    | #3                         | `false` |
|                 |                                                                 | #1                         | `true`  |
| `BobsBagelsApp` | `RemoveBagel(string bagelType)`                                 | #2                         | `true`  |
|                 |                                                                 | #5                         | `false` |
| `BobsBagelsApp` | `ChangeCapacity(int capacity, bool isManager)`                  | #4 (if isManager is true)  | `true`  |
|                 |                                                                 | #4 (if isManager is false) | `false` |
| `BobsBagelsApp` | `GetTotalCost()`                                                | #6                         | `int`   |
| `BobsBagelsApp` | `GetBagelCost(string bagelType)`                                | #7                         | `int`   |
| `BobsBagelsApp` | `AddBagelWithFillings(string bagelType, string[] fillingTypes)` | #8                         |         |
| `BobsBagelsApp` | `GetFillingCost(string fillingType)`                            | #9                         | `int`   |

## Requirements from User Stories
1. add a specific type of bagel to my basket.
2. remove a bagel from my basket.
3. know when my basket is full when I try adding an item beyond my basket capacity.
4. change the capacity of baskets. (As a Bob's Bagels manager)
5. know if I try to remove an item that doesn't exist in my basket.
6. know the total cost of items in my basket.
7. know the cost of a bagel before I add it to my basket.
8. choose fillings for my bagel.
9.  know the cost of each filling before I add it to my bagel order.
10. only be able to order things that we stock in our inventory.
