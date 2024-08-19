***
# User stories for Bob's Bagels
#### 1. As a member of the public, <br> So I can order a bagel before work, <br> I'd like to add a specific type of bagel to my basket.

#### 2. As a member of the public, <br> So I can change my order, <br> I'd like to remove a bagel from my basket.

#### 3. As a member of the public, <br> So that I can not overfill my small bagel basket <br> I'd like to know when my basket is full when I try adding an item beyond my basket capacity.

#### 4. As a Bob's Bagels manager,<br> So that I can expand my business, <br> I’d like to change the capacity of baskets.

#### 5. As a member of the public <br> So that I can maintain my sanity <br> I'd like to know if I try to remove an item that doesn't exist in my basket.

#### 6. As a customer, <br> So I know how much money I need, <br> I'd like to know the total cost of items in my basket.

#### 7. As a customer, <br> So I know what the damage will be, <br> I'd like to know the cost of a bagel before I add it to my basket.

#### 8. As a customer, <br> So I can shake things up a bit, <br> I'd like to be able to choose fillings for my bagel.

#### 9. As a customer, <br> So I don't over-spend, <br> I'd like to know the cost of each filling before I add it to my bagel order.

#### 10. As the manager, <br> So we don't get any weird requests, <br> I want customers to only be able to order things that we stock in our inventory.

***

### Bob's Bagels domain models
| **Classes** | **Methods** | **Scenario** | **Outputs** | **Description** |
|:---:|:---:|:---:|:---:|
| `Customer` | Add(Item) | Adds a bagel to the basket | bool | The Add(Item)-method calls the Add(Item)-method in basket to update the List inside the Basket-class. Returns a boolean for confirmation. |
|  | Add(Item) | Check the basket capacity before adding an item. If there is no space, send a message | bool | When using the Add(Item)-method it first checks the basket capacity using the GetBasket()-method in the Basket-class. Returns a boolean for confirmation. |
|  | Remove(Item) | Removes a bagel from the basket | bool | The Remove(Item)-method calls the Remove(Item)-method in Basket to remove the Item from the List inside the Basket-class. Returns a bool for confirmation. |
|  | Remove(Item) | Checks if the bagel exists before removing the basket. | bool | The Remove(Item)-method checks if the Item provided through the parameter exists before going on with the procedure. Returns a bool for confirmation. Returns a bool for confirmation. |
|  | GetTotalSumOfBasket() | Gets to total cost of all items in the basket | double | Loop through the basket and if the item is a Bagel check if there are any fillings. Returns a double. |
|  | GetItemCostOf(Item) | Gets the cost of the Item provided | double | The GetItemCostOf(Item) checks the basket for the provided item and gets the cost of the item through the GetItem-method if it exists. Returns a double.|
|  | ChooseFillingForBagel(Bagel, Filling) | Adds a filling to the provided bagel. | bool | When using the ChooseFillingForBagel(Bagel, Filling) it finds the provided Bagel and adds the provided Filling using an AddFilling()-method in Bagel. Returns a bool for confirmation. |
|  | GetFillingCost(Filling) | Gets the cost of the Filling provided. | double | Gets the cost of the Filling provided using the inventory List inside Shop. Returns a double. |
| `Manager` | SetBasketCapacity(int) | Changes the basket capacity to the provided integer. | bool | When using the SetBasketCapacity(int)-method it calls the set-method in Basket to set the capacity to the provided integer. Returns a bool for confirmation. |
|  | GetAvailableItems(Item) | Gets all the available items in the Shop | List\<Item> | When using the GetAvailableItems(Item)-method it calls the get-method in the Shop-class. Returns a List\<Item>. |

***

### Overview of Classes
| **Classes** | Properties |
|:---:|:---:|
|`Shop`| ShopInventory _shopInventory_, List\<Person> _people_ |
|`ShopInventory`| List\<Item> _inventory_ |
|`Person`| string _name_, bool _isManager_ |
|`Manager : Person`|  |
|`Customer : Person`| Basket _basket_ |
|`Basket`| List\<Item> _itemsInBasket_, int _capacity_ |
|`Item`| string _SKU_, int _price_, string _variant_ |
|`Bagel : Item`| List\<Filling> _bagelFillings_ |
|`Filling : Item`|  |
|`Coffee : Item`|  |