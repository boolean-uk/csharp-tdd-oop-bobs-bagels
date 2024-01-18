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

## Stories
```
1.
As an organised individual,
So I can organise my receipts,
I'd like to see the date and time of my purchase,
```
```
2.
As an organised individual
So I can keep track of my finances,
I'd like to see the name and price of the products, with quantity and total cost, as well as discounts on my receipt,
```
| `Classes` | `Methods`       | `Scenarios` | `Outputs`                                                   |
|-----------|-----------------|-------------|-------------------------------------------------------------|
| `Receipt` | `PrintHeader`   |             | `Prints the headline of the receipt`                        |
|           | `PrintItems`    |             | `Prints the items from the basket, with quantity and price` |
|           | `PrintEnd`      |             | `Prints a thank you note`                                   |