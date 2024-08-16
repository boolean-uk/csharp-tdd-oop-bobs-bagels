
| Class		      | Methods                                | Scenario                             | Output     |
|-----------------|----------------------------------------|--------------------------------------|------------|
| `Basket`        | `AddItem(Item item)`                   | Adds the given item to the basket    | true       |
|				  |                                        | Basket is full and it's not possible | false      |
| `Basket`        | `RemoveItem(Item item)`				   | Removes the given item from basket   | true       |
|				  |										   | Item does not exist in the basket    | false	   |
| `Basket`		  | `ChangeCapasity(int capacity)`		   | Changes the cpacity of the basket    | void       |
| `Basket`        | `GetCost()`                            | Gets the total cost of the basket    | int        |
| `Item`          | `GetItemCost()`						   | Gets the price of the given item     | int        |
| `Item`          | `AddFilling(Filling filling)`		   | Adds the given filling to the bagel  | true	   |
|				  |										   | Unable to add filling				  | false      |
| `BobsBagel`	  | `ChangeBasketCapacity(int cap)`		   | Changes the capacity of new baskets  | true	   |
