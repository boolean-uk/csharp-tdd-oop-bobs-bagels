



| Classes         | Methods/Properties                                 | Scenario                        | Outputs          |
|-----------------|----------------------------------------------------|---------------------------------|------------------
|Basket.cs	      |Add(string bagel)                                   |Adds bagel to basket             |None?
|Basket.cs        |Remove(string bagel)								   |Removes bagel from basket	     |None?
|Basket.cs        |Maxcapacity()                                       |You want to add to your basket when capacity is reached | String "You have reached your capacity"
|Manager.cs       |ChangeMaxcapacity()                                 |Change the max capacity          |None?
|Basket.cs        |ImpossibleRemove(string bagel)				       |Notifies if user tries to delete a bagel that is not there | String
|Inventory.cs     |ShowBagelCost                                       |Shows bagel cost			     | Int
|Basket.cs        |Directory<string, int>                              |









9.

As a customer,
So I don't over-spend,
I'd like to know the cost of each filling before I add it to my bagel order.

10.

As the manager,
So we don't get any weird requests,
I want customers to only be able to order things that we stock in our inventory.








1.Basket.cs X

As a member of the public,
So I can order a bagel before work,
I'd like to add a specific type of bagel to my basket.

2. Basket.cx X

As a member of the public,
So I can change my order,
I'd like to remove a bagel from my basket.

3.Basket.cs X

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

