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

## Task

Update and extend your program to handle these orders at Bob's Bagels.

Start with extracting useful stories and a functional domain model that represents these requirements.

## User stories

```
1. 
As a manager of Bob's bagels,
I want at most one discount to be applied to a customers basket,
so that my company is not too altruistic
```

``` 
2.
As a customer at Bob's Bagels,
I want to take advantage of multi-price offers,
so that I can save money when buying in bulk.
``` 

```
3. 
As a cashier at Bob's Bagels,
I want to identify bagels using their SKU codes,
so that I can easily manage and process orders.
```

```
4. 
As a cashier at Bob's Bagels,
I want the discounts to be applied when calculating the total,
so that I can finish scanning the products before a discount is chosen
```