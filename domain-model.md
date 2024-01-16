# Original domain model 

| Classes  | Members	 | Methods						|	Scenario				 | Output |
| ---------|-------------|------------------------------|----------------------------|--------|
| Customer | List<Bagel> | addBagel(string type)        | Bagel is added to list     | true   |
|		   |             |						        | List (basket) is full      | false  |
|		   |			 | removeBagel(string type)     | Bagel is in the basket     | true   | 
|		   |		     |							    | Bagel is NOT in the basket | false  |
| Manager  |			 | changeBasketLimit(int limit) | Change basket size		 | true   |

# New domain model 

| Classes  | Members              | Methods                          | Scenario                         | Output |
|----------|----------------------|----------------------------------|----------------------------------|--------|
| Customer | List<Bagel>          | addBagel(Bagel bagel)            | Bagel is added to the basket     | true   |
|          | Basket(int capacity) |                                  | Basket is full                   | false  |
|          |                      | removeBagel(Bagel bagel)         | Bagel is removed from the basket | true   |
|          |                      |                                  | Bagel is NOT in the basket       | false  |
|          |                      | total()                          | Get total cost of the basket     | double |
|          |                      | getPrice(Bagel bagel)            | Get price of a bagel             | double |
|          |                      | addFilling(Filling filling)      | Add filling to the bagel         | true   |
|          |                      | getFillingPrice(Filling filling) | Get price of filling             | double |
| Manager  |                      | changeCapacity(int capacity)     | Change capacity of the basket    | true   |
|          | Inventory()          | checkInventory()                 | Item is in inventory             | true   |
|          |                      |                                  | Item is not in inventory         | false  |