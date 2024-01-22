Domain Model

1.
As a member of the public,
So I can order a bagel before work,
I'd like to add a specific type of bagel to my basket.
=> Basket.addItem(Product)

2.
As a member of the public,
So I can change my order,
I'd like to remove a bagel from my basket.
=> Basket.removeItem(string bagelid)

3.
As a member of the public,
So that I can not overfill my small bagel basket
I'd like to know when my basket is full when I try adding an item beyond my basket capacity.
=> Basket.addItem(obj) =>ErrorMessage "Basket is full"
4.
As a Bob's Bagels manager,
So that I can expand my business,
I�d like to change the capacity of baskets.
=> In Basket()
=> Private int _capacity
=> Public int Capacity{get set}

5.
As a member of the public
So that I can maintain my sanity
I'd like to know if I try to remove an item that doesn't exist in my basket.
=> Basket.removeItem(item)=>	if Item is in Basket => remove => return successMessage	
								if Item is Not in Basket => Return ErrorMessage "Basket is full"

6.
As a customer,
So I know how much money I need,
I'd like to know the total cost of items in my basket.
=> Basket.GetTotal();

7.
As a customer,
So I know what the damage will be,
I'd like to know the cost of a bagel before I add it to my basket.
=> Item.Price{get;}

8.
As a customer,
So I can shake things up a bit,
I'd like to be able to choose fillings for my bagel.
=> Iventory.getListOfFillings(item.Name); 
=> Product.Variant{set}
=> Basket.AddItem(Item)

9.
As a customer,
So I don't over-spend,
I'd like to know the cost of each filling before I add it to my bagel order.
=> Inventory.getListOfFilling(item.Name= Bagel) => Prints List with corresponding Variants and prices

10.
As the manager,
So we don't get any weird requests,
I want customers to only be able to order things that we stock in our inventory.

Inventory.printInventory() => if InStock > 0 => print menu
variant.name
variant.price
variant.inStock


Class		| Method					 |	Scenario												| Output
-----------	|----------------------------|----------------------------------------------------------|-------------------------------
Basket      | addItem(Product)			 | if Basket.ItemList.Count =< capacity => add to ItemList	|
	 		| addItem(Product)			 | if Basket.ItemList.Count >= capacity						| string Message "Basket is full"
Nr 2		| Basket.removeItem(Product) | if itemIsInBasket => Basket.ItemList.remove(Product)		|	
Nr 5		| removeBagel(string)		 | if Basket.IndexOf(string) < 0							| string Message "Nothing was removed, Bagel was not in the basket"		 							
Nr 4		| Public int Capacity{get set}| set _capacity = int value								|

Class	| Field			| Properties | Methods  |
Basket	|_capacity(int)	| 

