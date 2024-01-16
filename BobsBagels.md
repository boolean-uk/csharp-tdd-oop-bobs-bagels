
```
Classes:
Basket
Bagel
Inventory
```

```

````




| Classes           | Members                                                             | Methods                                               | Scenario                       | Outputs      |
|-------------------|---------------------------------------------------------------------|-------------------------------------------------------|--------------------------------|--------------|
| `Basket`          | `Dictionary<string, int> bagels (key is type and value is price)`   | `AddBagel(string SKU)`                                |                                | Console.Out  | 
|                   |                                                                     | `RemoveBagel(string SKU)`                             | Bagel *is* in basket           | true         |
|                   |                                                                     |                                                       | Bagel *is not* in basket       | false        |
|                   |                                                                     | `IsBasketFull()`                                      | Basket *is* full               | true         |
|                   |                                                                     |                                                       | Basket *is not* full           | false        |
|                   |                                                                     | `ChangeBasketCapacity(int capacity)`                  |                                |              | 
|                   |                                                                     | `TotalBasketCost()`                                   |                                | int          |


| Classes  | Methods                                               | Scenario                       | Outputs      |
|----------|-------------------------------------------------------|--------------------------------|--------------|
| `Item`   |                                                       |                                |              |




| Classes     | Members                                                                  | Methods                                               | Scenario                       | Outputs      |
|-------------|--------------------------------------------------------------------------|-------------------------------------------------------|--------------------------------|--------------|
| `Inventory` | `List<Item> Inventory (Contains variables SKU, Price, Name and Variant)` |

