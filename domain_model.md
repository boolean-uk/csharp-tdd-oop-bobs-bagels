1.
As a customer, So I can order a bagel before work, I'd like to add a specific type of bagel to my basket.
2.
As a customer, So I can change my order, I'd like to remove a bagel from my basket.
3.
As a customer, So that I can not overfill my small bagel basket, I'd like to know when my basket is full when I try adding an item beyond my basket capacity.
4.
As the manager, So that I can expand my business, I’d like to change the capacity of baskets.
5.
As a customer, So that I can maintain my sanity, I'd like to know if I try to remove an item that doesn't exist in my basket.
6.
As a customer, So I know how much money I need, I'd like to know the total cost of items in my basket.
7.
As a customer, So I know what the damage will be, I'd like to know the cost of a bagel before I add it to my basket.
8.
As a customer, So I can shake things up a bit, I'd like to be able to choose fillings for my bagel.
9.
As a customer, So I don't over-spend, I'd like to know the cost of each filling before I add it to my bagel order.
10.
As the manager, So we don't get any weird requests, I want customers to only be able to order things that we stock in our inventory.

Class: Basket
Properties:
private int capacity
List<Item> contents //Baskets contents

Methods:
public bool addItem (Item item)
returns: true if successfull

public bool removeItem (Item item)
returns: true if successfull

public int changeBasketSize(int newSize)
return: newSize

Abstract Class: Item
Properties: 
private string SKU
private float price
private string type
private string variant
private string name // will be type + variant

Class: Bagel : Item
Properties:
Dictionary<float price, string fillingName> fillingPrices
List<Filling> bagelFilling //This bagels fillings

Methods:
public void showFillingPrices()
print fillingPrices

public void addFillin(Filling filling)

Class: Filling : Item

Class: Coffee : Item

Class: Receipt
Properties:
float total
List<Item> yourOrder

Methods:
public string showTotal(total)
return: "your total comes to: {total}"

Class: Inventory
Properties:
List<Item> inventory

Methods:
public bool inInventory(string SKU)
return: true if in inventory / false if not

._______________________________________.
|"BGLO"|0.49f|"Bagel"  | "Onion"        |
|"BGLP"|0.39f|"Bagel"  | "Plain"        |
|"BGLE"|0.49f|"Bagel"  | "Everything"   |
|"BGLS"|0.49f|"Bagel"  | "Sesame"       |
|"COFB"|0.99f|"Coffee" | "Black"        |
|"COFW"|1.19f|"Coffee" | "White"        |
|"COFC"|1.29f|"Coffee" | "Capuccino"    |
|"COFL"|0.29f|"Coffee" | "Latte"        |
|"FILB"|0.12f|"Filling"| "Bacon"        |
|"FILE"|0.12f|"Filling"| "Egg"          |
|"FILC"|0.12f|"Filling"| "Cheese"       |
|"FILX"|0.12f|"Filling"| "Cream Cheese" |
|"FILS"|0.12f|"Filling"| "Smoked Salmon"|
|"FILH"|0.12f|"Filling"| "Ham"          |