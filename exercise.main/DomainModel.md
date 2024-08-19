|Class       | Method/Property                                     | Scenario              | Output       |
|------------|-----------------------------------------------------|-----------------------|--------------|
| User       | AddToBasket(string sku)                             | Basket is full        | bool (false) |
|            |                                                     | Basket is not full    | bool (true)  |
|            | RemoveFromBasket(string sku)                        | Item is in basket     | bool (true)  |
|            |                                                     | Item is not in basket | bool (false) |
|            | GetItemPrice(string sku)	                           |                       | float        |
|            | GetTotalCost()                                      |                       | float        |
|            | ChangeBasketCapacity(int newCapacity)               | User is manager       | bool (true)  |
|            |                                                     | User is not manager   | bool (false) |
| Basket	 | int BasketCapacity                                  |                       |              |
|            | int TotalCost                                       |                       |              |
|            | List< ShopItem > items				               |                       |              |
|            | Inventory inventory					               |                       |              |
|            | Add(string sku)                                     | Basket is full        | bool (false) |
|            |                                                     | Basket is not full    | bool (true)  |
|            | Remove(string sku)                                  | Item is in basket     | bool (true)  |
|            |                                                     | Item is not in basket | bool (false) |
|            | PriceItem(string sku)				               |                       | float		  |
| Inventory  | Dictionary< string, ShopItem  >	                   |                       |              |
| ShopItem   | string sku                                          |                       |              |
|			 | float Price										   |					   |              |
|            | Char Type                                           |                       |              |
|            | String Description                                  |                       |              |