#Domain Models In Here

Exercise 1)
| Classes         | List                    | Methods                                                          | Outputs                                        |
|-----------------|-------------------------|------------------------------------------------------------------|------------------------------------------------|
|                 | `List<string> basket`   | `public bool Add(string sku)`                                    |  Adds bagel to basket                          |
| `Basket`        |                         |									                               |                                                |
|                 |                         | `public bool Remove(string sku)`                                 |  Removes bagel from basket                     |
|                 |                         | `public bool ChangeCapacity(int capacity)`                       |  Changes total capacity of Basket              |
|                 |                         | `public double totalCost(int capacity)`                          |  Changes total capacity of Basket              |
|                 |                         | `public double GetCostOfABagel(int capacity, out bool?)`         |  Changes total capacity of Basket              |
|                 |                         | `public bool AddAndChooseFilling(Bagel sku, string filling)`     |  Changes total capacity of Basket              |
|                 |                         | `public double GetCostOfFilling(string filling, out bool?)`      |  Changes total capacity of Basket              |
|                 |                         | `private double CalculateCost()`                                 |  Changes total capacity of Basket              |
|                 |                         | `public double Receipt()`                                 |  Changes total capacity of Basket              |




```
As a Bob's Bagels manager,
So I can sell more bagels,
I'd like to have a special offer which sells 6 bagels for 2.49.
```

```
As a Bob's Bagels manager,
So I can sell more bagels,
I'd like to have a special offer which sells 12 bagels for 3.99.
```

```
As a Bob's Bagels manager,
So I can sell more products,
I'd like to have a special offer which sells a combination of coffee and bagel for 1.25.
```

```
As a Custmer,
So i can see products i bought and the price for each produkt,
I'd like to receive a receipt.
```

