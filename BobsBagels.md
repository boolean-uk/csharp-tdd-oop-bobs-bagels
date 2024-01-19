
```
1.
As a member of the public,
So I can order a bagel before work,
I'd like to add a specific type of bagel to my basket.

8.
As a customer,
So I can shake things up a bit,
I'd like to be able to choose fillings for my bagel.

10.
As the manager,
So we don't get any weird requests,
I want customers to only be able to order things that we stock in our inventory.
```

| Classes  | Members                                                                | Methods                | Scenario                       | Outputs   |
|----------|------------------------------------------------------------------------|------------------------|--------------------------------|-----------|
| `Basket` | `List<Item> BasketItems (Item contains, Sku, Price, Name and Variant)` | `AddItem(string SKU)`  | Item *is* in inventory         | Nothing   | 
|          |                                                                        |                        | Item *is not* in inventory     | Nothing   |


```
2.
As a member of the public,
So I can change my order,
I'd like to remove a bagel from my basket.
```

```
5.
As a member of the public
So that I can maintain my sanity
I'd like to know if I try to remove an item that doesn't exist in my basket.
```

| Classes  | Members                                                                | Methods                  | Scenario                       | Outputs  |
|----------|------------------------------------------------------------------------|--------------------------|--------------------------------|----------|
| `Basket` | `List<Item> BasketItems (Item contains, Sku, Price, Name and Variant)` | `RemoveItem(string SKU)` | Item *is* in basket            | True     |
|          |                                                                        |                          | Item *is not* in basket        | False    |


```
3.
As a member of the public,
So that I can not overfill my small bagel basket
I'd like to know when my basket is full when I try adding an item beyond my basket capacity.
```

| Classes  | Members                                                                | Methods         | Scenario             | Outputs |
|----------|------------------------------------------------------------------------|-----------------|----------------------|---------|
| `Basket` |`List<Item> BasketItems (Item contains, Sku, Price, Name and Variant)`  |`IsBasketFull()` | Basket *is* full     | True    |
|          |                                                                        |                 | Basket *is not* full | False   |


```
4.
As a Bob's Bagels manager,
So that I can expand my business,
I’d like to change the capacity of baskets.
```


| Classes  | Members                             | Methods                                 | Scenario                         | Outputs     |
|----------|-------------------------------------|-----------------------------------------|----------------------------------|-------------|
| `Basket` | `int Capacity (Capacity of basket)` | `ChangeBasketCapacity(int newCapacity)` | BasketItems.Count >= newCapacity | Nothing     |  
|          |                                     |                                         | else                             | newCapacity |

```
7.
As a customer,
So I know what the damage will be,
I'd like to know the cost of a bagel before I add it to my basket.
```

| Classes     | Members                                                | Methods         | Scenario | Outputs     |
|-------------|--------------------------------------------------------|-----------------|----------|-------------|
| `Inventory` | `List<Item> InventoryItems`                            | `CostOfBagel()` |          | Console.out |

```
9.
As a customer,
So I don't over-spend,
I'd like to know the cost of each filling before I add it to my bagel order.
```

| Classes     | Members                                                | Methods           | Scenario  | Outputs     |
|-------------|--------------------------------------------------------|-------------------|-----------|-------------|
| `Inventory` | `List<Item> InventoryItems`                            | `CostOfFilling()` |           | Console.out |  


| Classes   | Members         | Methods          | Scenario  | Outputs     |
|-----------|-----------------|------------------|-----------|-------------|
| `Receipt` | `Basket basket` | `PrintReceipt()` |           | Console.out |  






