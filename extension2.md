## Extension 2: Receipts

Receipts are important.

## Task

Update and extend your program to handle printing receipts. These receipts should print to the terminal.

Start with extracting useful stories and a functional domain model that represents these requirements.

Tip: Think about a Receipt as an object. What other objects are contained in a receipt?

#### Example Receipt
```
    ~~~ Bob's Bagels ~~~

    2021-03-16 21:38:44

----------------------------

Onion Bagel        2   £0.98
Plain Bagel        12  £3.99
Everything Bagel   6   £2.49
Coffee             3   £2.97

----------------------------
Total                 £10.43

        Thank you
      for your order!
```

```
    ~~~ Bob's Bagels ~~~

    2021-03-16 21:40:12

----------------------------

Plain Bagel        16  £5.55

----------------------------
Total                  £5.55

        Thank you
      for your order!
```

## User stories

``` 
1.
As a customer of Bob's bagels,
I want my receipt to display the product name, quantity and price,
so that I can check that the price is right
```

```
2.
As a frequent customer of Bob's bagels,
I want my receipt to display the time of purchase,
so that I can distinguish my purchases
```

``` 
3.
As a manager of Bob's bagels,
I want the receipts from my store to show the shop name at the top,
to help my brand grow
```

``` 
4.
As a manager of Bob's bagels,
I want the receipts from my store to thank the customer for their purchase,
so that I can show my appreciation
```

``` 
5.
As a customer of Bob's bagels,
I want the receipts to be separated into sections,
so that I can easily find what I seek in the receipt
```

``` 
6.
As a manager of Bob's bagels,
I want the receipts from my store to print to the terminal,
so that my third-party software can log it easily.
```

``` 
7.
As a customer of Bob's bagels,
I want my receipt to display the total price,
so that I can confirm the sum
```