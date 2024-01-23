```
1.
As a member of the public,
So I can order a bagel before work,
I'd like to add a specific type of bagel to my basket.
```
| Classes         | Methods                                     | Scenario                         | Outputs     |
|-----------------|---------------------------------------------|----------------------------------|-------------|
| `Basket`		  | `Additem(string name, string variant)`		| Add item to non empty cart	   | void		 |
|                 |                                             | Cart is full					   | print error |

```
2.
As a member of the public,
So I can change my order,
I'd like to remove a bagel from my basket.
```
| Classes         | Methods                                     | Scenario                         | Outputs     |
|-----------------|---------------------------------------------|----------------------------------|-------------|
| `Basket`		  | `RemoveItem(string name, string variant)`	| Remove bagel from non empty cart | void		 |
|                 |                                             | Cart is empty					   | print error |

```
3.
As a member of the public,
So that I can not overfill my small bagel basket
I'd like to know when my basket is full when I try adding an item beyond my basket capacity.
```

| Classes         | Methods                                     | Scenario                         | Outputs     |
|-----------------|---------------------------------------------|----------------------------------|-------------|
| `Basket`		  | `CheckCapacity(Bool value)`					| Cart full						   | false		 |
|                 |                                             | Cart not full					   | true		 |



```
4.
As a Bob's Bagels manager,
So that I can expand my business,
I’d like to change the capacity of baskets.
```

| Classes         | Methods                                     | Scenario                         | Outputs     |
|-----------------|---------------------------------------------|----------------------------------|-------------|
| `Basket`		  | `ChangeCartCapacity(int capacity)`			| set new capacity				   | void		 |


```
5.
As a member of the public
So that I can maintain my sanity
I'd like to know if I try to remove an item that doesn't exist in my basket.
```
| Classes         | Methods                                     | Scenario                         | Outputs     |
|-----------------|---------------------------------------------|----------------------------------|-------------|
| `Basket`		  | `CheckForItem()`							| Item in cart					   | true		 |
|                 |                                             | Item not in cart				   | false		 |


```
6.
As a customer,
So I know how much money I need,
I'd like to know the total cost of items in my basket.
```
| Classes         | Methods                                     | Scenario                         | Outputs     |
|-----------------|---------------------------------------------|----------------------------------|-------------|
| `Basket`		  | `Sum()`										| Items in cart					   | int sum	 |
|                 |                                             | no items in cart				   | 0			 |

```
7.
As a customer,
So I know what the damage will be,
I'd like to know the cost of a bagel before I add it to my basket.
```
| Classes         | Methods                                     | Scenario                         | Outputs     |
|-----------------|---------------------------------------------|----------------------------------|-------------|
| `Basket`		  | `GetCost()`									| 								   | int cost	 |
|                 |                                             |								   |			 |

```
8.
As a customer,
So I can shake things up a bit,
I'd like to be able to choose fillings for my bagel.
```
| Classes         | Methods                                     | Scenario                         | Outputs     |
|-----------------|---------------------------------------------|----------------------------------|-------------|
| `Basket`		  | `AddFilling(sting variant)`					| 	added to cart				   | void		 |
|                 |                                             |								   |			 |

```
9.
As a customer,
So I don't over-spend,
I'd like to know the cost of each filling before I add it to my bagel order.
```
| Classes         | Methods                                     | Scenario                         | Outputs     |
|-----------------|---------------------------------------------|----------------------------------|-------------|
| `Basket`		  | `AddFilling(sting variant)`					| 	added to cart				   | void		 |
|                 |                                             |								   |			 |

```
10.
As the manager,
So we don't get any weird requests,
I want customers to only be able to order things that we stock in our inventory.
```




| SKU  | Name   | Variant    | Price | Special offers          |
|------|--------|------------|-------|-------------------------|
| BGLO | Bagel  | Onion      | .49   | 6 for 2.49              |
| BGLP | Bagel  | Plain      | .39   | 12 for 3.99             |
| BGLE | Bagel  | Everything | .49   | 6 for 2.49              |
| COFB | Coffee | Black      | .99   | Coffee & Bagel for 1.25 |

Every Bagel is available for the `6 for 2.49` and `12 for 3.99` offer, but fillings still cost the extra amount per bagel.


| Classes         | Methods                                     | Scenario                         | Outputs					    |
|-----------------|---------------------------------------------|----------------------------------|--------------------------------|
| `Basket`		  | `CalculateDiscount(List<Product>)`			| 	6 of the same bagel			   | sum - (6*priceOfBagel) + 2.49  |
|                 |                                             |	12 of the same bagel		   | sum - (12*priceOfBagel) + 3.99 |
|				  |												|   any 1 Coffee and any 1 bagel   | sum - (coffee + Bagel) + 1.25  | 
