`1, 6 and 8.
As a member of the public,
So I can order a bagel before work,
I'd like to add a specific type of bagel to my basket. I'd like to be able to choose fillings, and
I'd like to know the total cost of items in my basket.`

| Classes                  | Members                                                | Methods                           | Scenario                                                     | Outputs |
|--------------------------|--------------------------------------------------------|-----------------------------------|--------------------------------------------------------------|---------|
| `abstract class Item`    | `string sku, double price, string name, string variant`|                                   |                                                              |         |  
| `Bagel implements Item ` |        `Filling`                                       |                                   |                                                              |         |
| `static class ChosenItem`|                                                        |`public static MakeBagel(sku, price, name, variant)`| Makes a bagel from the select input params | Bagel object| 
|                          |                                                        |`public static Bagel AddFillings(Bagel bagel, List<Filling> fillings)`| Adds chosen fillings to the Bagel | Bagel object with  updated fillings string| 
|                          |                                                        |`public static Filling ChooseFillings(sku, price, name, variant)`     | Returns a filling object | Filling object|
| `Basket`                 | `List<Item> Selections`                                |`AddToSelection()`                | Adds the item and fillings (if any) to a list              | void    |
|                          | `Dictionary<int, List<Item>> BasketItems`              |`AddToBasket()`                   | Adds the selection (a list object) to the basket           | void    |
|                          |                                                        |`BasketTotal`                     | SubTotal of basket items                                   | double  |

`2.
As a member of the public,
So I can change my order,
I'd like to remove a bagel from my basket.`

| Classes  | Members                                                            | Methods                             | Scenario                                                   | Outputs |
|----------|--------------------------------------------------------------------|-------------------------------------|------------------------------------------------------------|---------|
| `Basket` | `List<Item> items`                                                 | `remove(item)`                      | Item removed                                               | true    |
|          |                                                                    |                                     | Item not sucsesfully removed                               | false   |
|          |                                                                    |                                     |                                                            |         |

`3.
As a member of the public,
So that I can not overfill my small bagel basket
I'd like to know when my basket is full when I try adding an item beyond my basket capacity.`

| Classes  | Members                                                            | Methods                             | Scenario                                                   | Outputs |
|----------|--------------------------------------------------------------------|-------------------------------------|------------------------------------------------------------|---------|
| `Basket` | `int Cap`                                                          |                                     |                                                            |         |
|          | `int BasketItemCount`                                              | UpdateCount()                       | Counts the items in the basket, if they are bagel or coffee| int     |
|          | `string CapNotice`                                                 | AddToBasket()                       | Updated method: Calls the UpdateItemCount() -  against cap - Updates CapNotice string | void    | 

`4.
As a Bob's Bagels manager,
So that I can expand my business,
I'd like to change the capacity of baskets.`

| Classes  | Members                                                            | Methods                             | Scenario                                                   | Outputs                |
|----------|--------------------------------------------------------------------|-------------------------------------|------------------------------------------------------------|------------------------|
| `Basket` | `int Cap`                                                          | `int ChangeCap(int)`                | Cap changed                                                | new cap int            |
| `Admin`  | `bool isAdmin`                                                     |                                     | Admin is logged in                                         | Can access editCap     | 
|          |                                                                    |                                     | Admin is not logged in                                     | Can not access editCap |

`5.
As a member of the public
So that I can maintain my sanity
I'd like to know if I try to remove an item that doesn't exist in my basket.`

| Classes  | Members                                                            | Methods                             | Scenario                                                   | Outputs |
|----------|--------------------------------------------------------------------|-------------------------------------|------------------------------------------------------------|---------|
| `Basket` | string NotFoundNotice                                              |                                     |                                                            
|          |                                                                    | RemoveFromBasket(int id)            |Check basket dictionary for key presence, if found => remove entry| void    |
|          |                                                                    |                                     |If not found => Update NotFoundNotice string to be used in future prompt|         |
|          |                                                                    |                                     |                                                            |         |

`7.
As a customer,
So I know what the damage will be,
I'd like to know the cost of a bagel before I add it to my basket.`

`9.
As a customer,
So I don't over-spend,
I'd like to know the cost of each filling before I add it to my bagel order.`

For the usecases 7 and 9 above - I've tested by ensuring that the price of each bagel and filling is programatically accessible before adding them to the basket, and they are.
Unless we're to make prompts with the console and compare the strings etc, I believe these usecases are tested for and implemented. Lines 230-253 in UnitTest1.cs



`10.
As the manager,
So we don't get any weird requests,
I want customers to only be able to order things that we stock in our inventory.`

| Classes                  | Members                                                            | Methods                             | Scenario                                                   | Outputs |
|--------------------------|--------------------------------------------------------------------|-------------------------------------|------------------------------------------------------------|---------|
| `static class Inventory` | `Bagelstock, coffeestock, fillingstock`                            |                                     |                                                            |         |
|                          |                                                                    | bool InStock(int stockitem)         | Used when customer tries adding things to basket/making bagel| true/false |
| `Basket`                 |                                                                    | Modified AddToSelection(Item item)  | Checks if stock int is larger than 0, adds to selection if true|   void   |
|                          | `string OfOufStockNotice`                                          |                                     | To be used in userprompt when item out of stock            |         |

`Extension usecase 1
Basket should discount instances of 6 and 12 bagels, but not fillings.`

| Classes                  | Members                                                            | Methods                             | Scenario                                                   | Outputs |
|--------------------------|--------------------------------------------------------------------|-------------------------------------|------------------------------------------------------------|---------|
| `Basket`                 |  `BagelCounter`                                                    |                                     |                                                            |         |
|                          |                                                                    | 
