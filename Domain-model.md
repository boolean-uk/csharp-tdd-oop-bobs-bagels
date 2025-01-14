
## Domain Model

| Classes | Methods/Properties                         | Scenario                                                      | Outputs                     |
|---------|--------------------------------------------|---------------------------------------------------------------|-----------------------------|
|Basket.cs| AddItem(Item item)                         | Add type of bagel                                             |                             |
|Basket.cs| RemoveItem(Item item)                      | Remove bagel                                                  |                             |
|Basket.cs| Public property FullBasket(string message) | Message if basket full                                        | String "Basket is full"     |
|Basket.cs| ChangeCapacityForBaskets(int NewCapacity)  | Change capacity of baskets                                    |                             |
|Basket.cs| CanRemoveItemFromBasket                    | Get message if trying to remove item that isn`t in the basket | String "Item not in basket" |
|Basket.cs| CalculateTotalPriceWithDiscount()          | Get the total cost of items in basket                         | Int showing totalPrice      |
|Basket.cs| BagelCost(int priceBagel)                  | Get the cost of the bagel before adding to basket             | Int showing cost of bagel   |
|Basket.cs| AddItem()                                  | Choose filling before adding it to bagel order                |                             |
|Basket.cs| ShowCostForFilling()                       | Get the cost for filling before adding it                     | Int showing fillingCost     |
|Basket.cs| CheckIfInInventory()                       | Can only order things that are stocked in inventory           | String "Not in inventory"   |
|Basket.cs| CalculateTotalPriceWithDiscount()          | Prices will change based on how many items                    | Int showing totalPrice      |
|Basket.cs| GenerateReceipt()                          | Generate receipt for each order                               | Print of receipt            |



