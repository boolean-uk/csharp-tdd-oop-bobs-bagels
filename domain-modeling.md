Single page domain modell

| Classes    | Members                                                               | Methods                                     | Scenario                                                 | Outputs             |
|------------|-----------------------------------------------------------------------|---------------------------------------------|----------------------------------------------------------|---------------------|
| `Core`     | `String capacity` (capacity of items in the basket)                   |                      |                                                                                 |                     |
|            | `List<string> basketList` (list of items in basket)                   |                                             |                                                          |                     |
|            |                                                                       | `addBagel(string name)`                     |  Bagel *is not* already in the list                      | true                |
|            |                                                                       |                                             |                                                          |                     |
|            |                                                                       |                                             | Bagel *is* already in the list                           | false               |
|            |                                                                       | `removeBagel(string bagel)`                 | Bagel with the provided name *is not* in the list        | true                |
|            |                                                                       |                                             |                                                          |                     |
|		     |                                                                       | `fullBasket()`						       | Basket is full                         				  | true                | 
|            |                                                                       |                                             | Basket is not full                                       | false               |
|            |                                                                       |                                             |                                                          |                     |
|            |                                                                       | `basketCapacity(int capacity)`              | Basket capacity is increased                             | int                 |
|            |                                                                       |                                             |                                                          |                     |
|            |                                                                       |                                             |                                                          |                     |
|            |                                                                       | `notInBasket(string bagel)`                 | Trying to remove bagel not in basket                     | string              |
|            |                                                                       |                                             |                                                          |                     |


Multiple class domain modelling

| Classes    | Members                                                               | Methods                                     | Scenario                                                 | Outputs             |
|------------|-----------------------------------------------------------------------|---------------------------------------------|----------------------------------------------------------|---------------------|
| `Products` | List<Products> products (list of product                              |                                             |                                                          |                     |
|            | string name (Name of product)                                         |                                             |                                                          |                     | 
|            | double price (product price)                                          |                                             |                                                          |                     |       
|            | string id (product id)                                                |                                             |                                                          |                     |            
|            | string variant (product type)                                         |                                             |                                                          |                     |
|            |                                                                       |`addProduct(Product prod)`                   |  product *is not* already in the list                    | true                |
|            |                                                                       |                                             |  product *is* already in the list                        | false               |
| `Basket`   | List<Products> BasketList  (list of products)                         |                                             |                                                          |                     |
|            | int Capacity (Capacity of the basket)                                 |                                             |                                                          |                     |
|            | Menu menue (Holds the items on the menu                               |                                             |                                                          |                     |
|            |                                                                       |`addProduct(Product prod)`                   | product *is not* already in the list                     | true                |
|            |                                                                       |                                             | product *is* already in the list                         | false               |
|            |                                                                       |`removeProduct(Product prod)`                | product *is not* already in the list                     | true                |
|            |                                                                       |                                             | product *is* already in the list                         | false               |
|            |                                                                       |`changeBasketSize(int size)`                 | increase the basket size                                 | int                 |
|            |                                                                       |`RemoveIemNotInBasket(Product prod)`         | Item to remove is not in basket                          | string              |
|            |                                                                       |`TotalCost()`                                | See total cost of items                                  | double              |
|            |                                                                       |`showMenu()`                                 | See the menu                                             | string (menu object)|
|            |                                                                       |                                             |                                                          |                     |
|            |                                                                       |                                             |                                                          |                     |
|            |                                                                       |                                             |                                                          |                     |
|            |                                                                       |                                             |                                                          |                     |
|            |                                                                       |                                             |                                                          |                     |
|            |                                                                       |                                             |                                                          |                     |
|            |                                                                       |                                             |                                                          |                     |
|            |                                                                       |                                             |                                                          |                     |
|            |                                                                       |                                             |                                                          |                     |
|            |                                                                       |                                             |                                                          |                     |
|            |                                                                       |                                             |                                                          |                     |



`Manager`		Capacity (Capacity of the basket)						ChangeCapacity(int size)
																		setInventory() ??
																		checkInventory()

		


`Products`		List<Bagel> BagelList (list of all bagel types)
				List<Filling> FillingList (list of all fillings)
				List<Coffee> CoffeeList (list of all Coffee types)
				int stock
				string name 
				dobble price 
				string id
				string variant
				



`Basket`		List<Products> ShoppingBasket							AddBagel(type??)
																		RemoveBagel(string)
																		BasketFullMessage()
																		RemoveIemNotInBasket()
																		TotalCost()
																		ShowMenu()
																		ChooseFillings()
																		checkInventory()
				


`Bagel`			string name 
				dobble price 
				string id
				string variant

`Coffee`		string name 
				dobble price 
				string id
				string variant

`Fillings`		string name 
				dobble price 
				string id
				string variant


