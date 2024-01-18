1.
As a member of the public,
So I can order a bagel before work,
I'd like to add a specific type of bagel to my basket.

needs a method to add bagels in Basket. //specific type (ID)  Dictionary sound good.

2.
As a member of the public,
So I can change my order,
I'd like to remove a bagel from my basket.

Should be able to remove items from Basket


3.
As a member of the public,
So that I can not overfill my small bagel basket
I'd like to know when my basket is full when I try adding an item beyond my basket capacity.

basket needs an upper limit // int probably

4.
As a Bob's Bagels manager,
So that I can expand my business,
I’d like to change the capacity of baskets.

need a method for expanding basket  // should not be accessable by all

5.
As a member of the public
So that I can maintain my sanity
I'd like to know if I try to remove an item that doesn't exist in my basket.

if bagel is not in basket say so.

6.
As a customer,
So I know how much money I need,
I'd like to know the total cost of items in my basket.

method in basket to summarise the cost of every Item and their total cost.

7.
As a customer,
So I know what the damage will be,
I'd like to know the cost of a bagel before I add it to my basket.

post menu before adding orders or write the cost as we go. 
ask for feedback with console.read()?

8.
As a customer,
So I can shake things up a bit,
I'd like to be able to choose fillings for my bagel.

get bagel with method from basket.  
method in bagel to add filling to it.

9.
As a customer,
So I don't over-spend,
I'd like to know the cost of each filling before I add it to my bagel order.

when get bagel function is called post fillings and ask.

10.
As the manager,
So we don't get any weird requests,
I want customers to only be able to order things that we stock in our inventory.

have inventory of posible options. reject any item request that is not part of inventory.



public class basket
Properties 

Methods
______________________________________________________________________________
public class Inventory
Properties
private Dictionary<string,Item> _shopInventory

public Dictionary<string,Item> ShopInventory{ get{return _shopInventory} } //read only

Methods
public void CreateNewItem(string name, string itemID, string variant, float cost) made for creating the inventory.

public Item GetItem(string ItemID)
-returns Item based on ID.

public bool ContainsItem(string ItemID)
-returns true if an item with ID ItemID is found.
-returns false if not.

______________________________________________________________________________
public class Item

private string _name
private string _itemID
private string _variant
private float _cost

constructor for defining variabels

public string Name		//read only
public string ItemID	//read only
public string Variant	//read only
public float Cost		//read only

_________________________________________________________________________
public class Bagle:Item
properties 
private List<Fillings> _bagleFillings

method
public float GetTotalCost() goes through every filling and adds their costs to the bagle. // should only be called when the total basket price is needed. 

constructor for defining variabels

public List<Fillings> BagleFillings		//Read Only

public class Coffee:Item
public class Filling:Item
