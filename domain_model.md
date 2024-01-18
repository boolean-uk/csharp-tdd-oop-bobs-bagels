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

Methods:
public Item addItem (string SKU, float price, string type, string variant)
returns: the created Item

Class: Item
Properties: 
private string SKU
private float price
private string type
private string variant

Class: Bagel : Item

Class: BagelWithFilling : Bagel


Class: Coffee : Item

Class: User