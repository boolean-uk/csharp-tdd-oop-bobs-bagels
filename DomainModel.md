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

Class Basket 

Properties

private List<Item>() listItems {get;}
private int basketLimit = 4;




Methods

public string AddItemToBasket(string itemCode)
-returns message if item was added to basket.
-returns error if itemcode does not exist.

public string RemoveItemFromBasket(string itemCode) removes an Item from the basket.
-returns message if Item was removerd.
-returns error of Item is not in basket.


public string ChangeBasketSize(int newBasketSize) changes the amount of bagles the basket can hold. 
-returns message that the basketsize was changed from old to new size.

public string GetBasketCost() 
-returns a message with the cost of the items in the basket.

public string GetItemCost(itemID)
-returns the cost of specifyed item.

public void GetFillingsCost()
-writes all fillings from inventory in the console. filling name, itemID and cost.

public Item GetItemFromBasket(itemID)
-returns an item based on itemID.
-used to add 


public string AddFillingToBagle(itemID) "moved this from Item to here because it makes more sense"
-adds a filling to the Bagle.
-returns an error if filling does not exist

-----------------------------------------------------------------------------------



Class Item

Properties

String Name
string itemID
float Cost
string Variant

List <Item> BagleFillings


Methods



public float GetTotalItemCost()
-returns total cost for Item.



---------------------------------------------------------------------------------------

class Inventory

properties

private Dictionary <Item item,string itemID> ShopInventory {get;}


Methods

CreateNewItem(string name, string itemID, float cost, string variant)
-creates new item and adds it to the ShopInventory.

public Item GetItem(itemID)
returns Item based in itemID.
	

	








