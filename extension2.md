## Extension 2: Receipts

Receipts are important.

## Task

Update and extend your program to handle printing receipts. These receipts should print to the terminal.

Start with extracting useful stories and a functional domain model that represents these requirements.

Tip: Think about a Receipt as an object. What other objects are contained in a receipt?

## User story 1
As a user, So I know what I have purchased, I want a recite showing me my purchase.




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


| Classes | Methods()             | Scenario                                           | Output         |
|---------|-----------------------|----------------------------------------------------|----------------|
| Basket  | string printreceipt() | receipt is printed out if it have something inside | string receipt |
|         |                       |                                                    |                |
|         |                       |                                                    |                |