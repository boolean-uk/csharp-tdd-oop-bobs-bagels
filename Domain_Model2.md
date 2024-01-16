# Domain model

## User Stories
```
1-3, 5.
As a member of the public (aka. a Person),
> So I can order a bagel before work,
>	I'd like to add a specific type of bagel to my basket.
> So I can change my order,
>	I'd like to remove a bagel from my basket.
> So that I can not overfill my small bagel basket
>	I'd like to know when my basket is full when I try adding an item beyond my basket capacity.
> So that I can maintain my sanity
>	I'd like to know if I try to remove an item that doesn't exist in my basket.
```

```
6-9.
As a customer,
> So I know how much money I need,
> 	I'd like to know the total cost of items in my basket.
> So I know what the damage will be,
>	I'd like to know the cost of a bagel before I add it to my basket.
> So I can shake things up a bit,
>	I'd like to be able to choose fillings for my bagel.
> So I don't over-spend,
>	I'd like to know the cost of each filling before I add it to my bagel order.
```

```
4, 10.
As a Bob's Bagels manager,
> So that I can expand my business,
>	I’d like to change the capacity of baskets.
> So we don't get any weird requests,
>	I want customers to only be able to order things that we stock in our inventory.
```


## Bob's Inventory

| SKU  | Price | Name    | Variant       |
|------|-------|---------|---------------|
| BGLO | 0.49  | Bagel   | Onion         |
| BGLP | 0.39  | Bagel   | Plain         |
| BGLE | 0.49  | Bagel   | Everything    |
| BGLS | 0.49  | Bagel   | Sesame        |
| COFB | 0.99  | Coffee  | Black         |
| COFW | 1.19  | Coffee  | White         |
| COFC | 1.29  | Coffee  | Capuccino     |
| COFL | 1.29  | Coffee  | Latte         |
| FILB | 0.12  | Filling | Bacon         |
| FILE | 0.12  | Filling | Egg           |
| FILC | 0.12  | Filling | Cheese        |
| FILX | 0.12  | Filling | Cream Cheese  |
| FILS | 0.12  | Filling | Smoked Salmon |
| FILH | 0.12  | Filling | Ham           |


## Table

| Classes             | Methods                                                      | Scenario               | Outputs |
|---------------------|--------------------------------------------------------------|------------------------|---------|
| `abstract Object`   |                                                    |                        | `` |
| `Person : Object`   |                                            |                        | `` |
| `Customer : Person` |                                                      |                        | `` |
| `Manager : Person`  | `public bool AlterSize(Basket basket, int newSize)` | Update the size of the basket | `true` |
|                     |                                                      | Cannot update basket size due to newSize variable is invalid, or basket doesn't exist | `false` |
| `abstract Product : Object` | `public double GetPrice()`                  |                        | `value` |
| `Bagel : Product`   |                                                      |                        |   |
| `Coffee : Product`  |                                                      |                        |   |
| `Filling : Product` |                                                      |                        |   |
| `Basket : Object`   | `public bool AddProduct(Product product)`           | Add product to basket    | `true` |
|                     |                                                      | Cannot add product to basket due to basket size limit     | `false` |
|                     |                                                      | Cannot add product to basket due to product being invalid | `false` |
|                     | `public bool RemoveProduct(Product product)`        | Remove product from basket | `true` |
|                     |                                                      | Cannot remove product from basket due to product not existing in basket, or is invalid | `false` |
|                     | `protected internal bool AlterSize(int newSize)` | Update the size of the basket to newSize if newSize is valid | `true` |
|                     |                                            | Cannot update the size of the basket to newSize because newSize is invalid (negative number or past max limit) | `false` |
| `Store`             |       |  | `` |
|                     |       |  | `` |
