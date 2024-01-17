# User Stories for bobs-bagels:
Class basket, Products, inventory, menu(?)

1.
As a member of the public,
So I can order a bagel before work,
I'd like to add a specific type of bagel to my basket.

2.
As a member of the public,
So I can change my order,
I'd like to remove a bagel from my basket.

3.
As a member of the public,
So that I can not overfill my small bagel basket
I'd like to know when my basket is full when I try adding an item beyond my basket capacity.

4.
As a Bob's Bagels manager,
So that I can expand my business,
I’d like to change the capacity of baskets.

5.
As a member of the public
So that I can maintain my sanity
I'd like to know if I try to remove an item that doesn't exist in my basket.

6.
As a customer,
So I know how much money I need,
I'd like to know the total cost of items in my basket.

7.
As a customer,
So I know what the damage will be,
I'd like to know the cost of a bagel before I add it to my basket.

8.
As a customer,
So I can shake things up a bit,
I'd like to be able to choose fillings for my bagel.

9.
As a customer,
So I don't over-spend,
I'd like to know the cost of each filling before I add it to my bagel order.

10.
As the manager,
So we don't get any weird requests,
I want customers to only be able to order things that we stock in our inventory.

(if in inventory, when add)


## Domain Models In here
```
1.
As a member of the public,
So I can order a bagel before work,
I'd like to add a specific type of bagel to my basket.
```

| Classes         | Methods						| Scenario										   | Outputs          |
|-----------------|-----------------------------|--------------------------------------------------|------------------|
|`basket`		  |	`Add(Product product)`		| add object Product in class basket and in a List | bool             |

```
2.
As a member of the public,
So I can change my order,
I'd like to remove a bagel from my basket.
```
| Classes         | Methods						| Scenario											  | Outputs          |
|-----------------|-----------------------------|-----------------------------------------------------|------------------|
|`basket`		  |	`Remove(Product product)`	| remove object Product in class basket and in a List | bool	         |

```
3.
As a member of the public,
So that I can not overfill my small bagel basket
I'd like to know when my basket is full when I try adding an item beyond my basket capacity.
```
| Classes         | Methods                 | Scenario																				| Outputs          |
|-----------------|-------------------------|---------------------------------------------------------------------------------------|------------------|
|`basket`		  |	`Add(Product product)`	| check if the basket is full by compare the default capacity with #items in the basket	| bool			   |

```
4.
As a Bob's Bagels manager,
So that I can expand my business,
I’d like to change the capacity of baskets.
```
| Classes         | Methods						   | Scenario														 | Outputs          |
|-----------------|--------------------------------|-----------------------------------------------------------------|------------------|
|`basket`		  |	`newCapacity(int newCapacity)` | Assign property _capacity with new input value					 | void             |


```
5.
As a member of the public
So that I can maintain my sanity
I'd like to know if I try to remove an item that doesn't exist in my basket.
```
| Classes         | Methods						 | Scenario														   | Outputs          |
|-----------------|------------------------------|-----------------------------------------------------------------|------------------|
|`basket`		  |	Remove(Product product) 	 | return false if that item doesn't exist						   | bool             |

```
6.
As a customer,
So I know how much money I need,
I'd like to know the total cost of items in my basket.
```
| Classes         | Methods						 | Scenario														   | Outputs          |
|-----------------|------------------------------|-----------------------------------------------------------------|------------------|
|`basket`		  |	totalCost					 | return the sum of the cost in the basket 					   | double           |


```
7.
As a customer,
So I know what the damage will be,
I'd like to know the cost of a bagel before I add it to my basket.
```
| Classes         | Methods						 | Scenario														   | Outputs          |
|-----------------|------------------------------|-----------------------------------------------------------------|------------------|
|`product`		  |	Product.price				 | return price of the product									   | double           |


```
8.
As a customer,
So I can shake things up a bit,
I'd like to be able to choose fillings for my bagel.
```
| Classes         | Methods						 | Scenario														   | Outputs          |
|-----------------|------------------------------|-----------------------------------------------------------------|------------------|
|`basket`		  |	Add(Product product)	 	 | If product.name == "filling" --> append to sandwichList		   | bool             |


```
9.
As a customer,
So I don't over-spend,
I'd like to know the cost of each filling before I add it to my bagel order.
```
| Classes         | Methods						 | Scenario														   | Outputs          |
|-----------------|------------------------------|-----------------------------------------------------------------|------------------|
|`Inventory`	  | getPrice()	 				 | get price of the products with specific name					   | double           |


```
10.
As the manager,
So we don't get any weird requests,
I want customers to only be able to order things that we stock in our inventory.
```
| Classes	  | Methods						 | Scenario														   | Outputs			  |
|-------------|------------------------------|-----------------------------------------------------------------|----------------------|
|`Product`	  | Product(object product)		 | If another object -> throw exception							   | throw new exception  |
|`basket`	


## Extension 1: Discounts

In a normal supermarket, things are identified using Stock Keeping Units, or SKUs.

In Bob's Bagels, we'll use the first 3 letters of a bagel with an extra letter for the variant. For example: an 'everything bagel' has a SKU of `BGLE`.

Our goods are priced individually. In addition, some items are multi-priced: buy n of them, and they'll cost you y pounds.

#### Bob's Bagels Inventory

| SKU  | Name   | Variant    | Price | Special offers          |
|------|--------|------------|-------|-------------------------|
| BGLO | Bagel  | Onion      | .49   | 6 for 2.49              |
| BGLP | Bagel  | Plain      | .39   | 12 for 3.99             |
| BGLE | Bagel  | Everything | .49   | 6 for 2.49              |
| COFB | Coffee | Black      | .99   | Coffee & Bagel for 1.25 |

Every Bagel is available for the `6 for 2.49` and `12 for 3.99` offer, but fillings still cost the extra amount per bagel.

#### Example orders
```
2x BGLO  = 0.98
12x BGLP = 3.99
6x BGLE  = 2.49
3x COF   = 2.97
           ----
          10.43
```

```
16x BGLP = 5.55
           ----
           5.55
```

| Classes	  | Methods						 | Scenario														             | Outputs			    |
|-------------|------------------------------|---------------------------------------------------------------------------|----------------------|
|  `basket`   | discount()          		 | Before calculate the total sum check for the discount in the collection   | double               |
|                                              The method returns double to substract with total sum                                            |


