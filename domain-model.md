```
1.
As a member of the public,
So I can order a bagel before work,
I'd like to add a specific type of bagel to my basket.
```

| Class  | Method           | Member Variables         | Scenario              | Outputs/Results                 |
|--------|------------------|--------------------------|-----------------------|---------------------------------|
| Basket | add(string item) | string item              | adds Item to the list | Return the list with added Item |
|        |                  | List<string> basket      |                       |                                 |


```
2.
As a member of the public,
So I can change my order,
I'd like to remove a bagel from my basket.
```
| Class  | Method              | Member Variables         | Scenario              | Outputs/Results             |
|--------|---------------------|--------------------------|-----------------------|-----------------------------|
| Basket | remove(string item) | String item              | if item is in basket  | Remove item from the basket |
|        |                     | List<string> basket      | if item not in basket | return null                 |


```
3.
As a member of the public,
So that I can not overfill my small bagel basket
I'd like to know when my basket is full when I try adding an item beyond my basket capacity.
```
| Class  | Method           | Member Variables    | Scenario                      | Outputs/Results                  |
|--------|------------------|---------------------|-------------------------------|----------------------------------|
| Basket | add(string item) | String item         | if the capacity is full       | Return false                     |
|        |                  | List<string> basket | if capacity is not full       | Return the list with added bagel |

```
4.
As a Bob's Bagels manager,
So that I can expand my business,
I’d like to change the capacity of baskets.
```
| Class  | Method                       | Member Variables    | Scenario            | Outputs/Results               |
|--------|------------------------------|---------------------|---------------------|-------------------------------|
| Basket | changeCapacity(int capacity) | int capacity        | Change value of the | Return "Capacity has changed" |
|        |                              | List<string> basket | capacity            |                               |

``` 
5.
As a member of the public
So that I can maintain my sanity
I'd like to know if I try to remove an item that doesn't exist in my basket.
```
| Class  | Method              | Member Variables    | Scenario              | Outputs/Results                        |
|--------|---------------------|---------------------|-----------------------|----------------------------------------|
| Basket | remove(string item) | string item         | if item is in basket  | Remove item from basket                |
|        |                     | List<string> basket | if item not in basket | Return "item does not exist in basket" |

```
6.
As a customer,
So I know how much money I need,
I'd like to know the total cost of items in my basket.
```

| Class  | Method                  | Member Variables    | Scenario                         | Outputs/Results    |
|--------|-------------------------|---------------------|----------------------------------|--------------------|
| Basket | totalCost()             | double cost         | Loop through, if items in basket | Add price to total |
|        |                         | List<string> basket | Loop ends                        | Return total       |

```
7.
As a customer,
So I know what the damage will be,
I'd like to know the cost of a bagel before I add it to my basket.
```

| Class  | Method                  | Member Variables          | Scenario                  | Outputs/Results          |
|--------|-------------------------|---------------------------|---------------------------|--------------------------|
| Basket | checkPrice(string item) | Item item                 | If bagel in inventory     | return price of bagel    |
|        |                         | List<string> basket       | If bagel not in inventory | return no bagel/no price |
|        |                         | List<Item> inventory      |                           |                          |
|        |                         |                           |                           |                          |
| Item   | getPrice()              | double price              | get price of item         |                          |


```
8.
As a customer,
So I can shake things up a bit,
I'd like to be able to choose fillings for my bagel.
```

| Class  | Method                                  | Member Variables     | Scenario             | Outputs/Results           |
|--------|-----------------------------------------|----------------------|----------------------|---------------------------|
| Basket | addFilling(string item, string filling) | string item          | if item in inventory | return bagel with filling |
|        |                                         | string filling       |                      |                           |
|        |                                         | List<string> basket  |                      |                           |
|        |                                         | List<Item> inventory |                      |                           |
| Item   | getName()                               | string name          |                      |                           |

```
9.
As a customer,
So I don't over-spend,
I'd like to know the cost of each filling before I add it to my bagel order.
```

| Class  | Method                  | Member Variables     | Scenario                 | Outputs/Results          |
|--------|-------------------------|----------------------|--------------------------|--------------------------|
| Basket | checkPrice(string item) | string item          | If item in inventory     | return price of bagel    |
|        |                         | List<string> basket  | If item not in inventory | return no bagel/no price |
|        |                         | List<Item> inventory |                          |                          |
| Item   | getPrice()              | double price         |                          |                          |



```
10.
As the manager,
So we don't get any weird requests,
I want customers to only be able to order things that we stock in our inventory.
```


| Class  | Method           | Member Variables     | Scenario                   | Outputs/Results |
|--------|------------------|----------------------|----------------------------|-----------------|
| Basket | add(string item) | String item          | If item exist in inventory | add item        |
|        |                  | List<string> basket  | If item not in inventory   | return null     |
|        |                  | List<Item> inventory |                            |                 |


```
Domain model for EXTENSION 1
```

| Class  | Method            | Member Variables      | Scenario                                                           | Result              |
|--------|-------------------|-----------------------|--------------------------------------------------------------------|---------------------|
| Basket | double discount() | List<Item> inventory  | Create 3 new items in inventory with SKU: DIS6, DIS12, DISCB.      | return double price |
|        |                   | List<string> basket   | Iterate through the basket to count the amount of bagels and add   |                     |
|        |                   | List<string> discount | the discount SKU to the discount-list and calculate the totalprice |                     |


```
Domain model for EXTENSION 2
```
| Class  | Method           | Member Variables           | Scenario                                             | Result         |
|--------|------------------|----------------------------|------------------------------------------------------|----------------|
| Basket | string receipt() | ArrayList<Item> inventory  |                                                      | return receipt |
|        |                  | ArrayList<string> basket   | Iterate through basket, count and calculate the cost |                |
|        |                  | ArrayList<string> discount |                                                      |                |
