# User Stories

1. I want to add a specific type of bagel to my basket.  
2. I want to remove a bagel from my basket.  
3. I want to know if my basket is full when I try adding an item beyond its capacity.  
4. I want to change the capacity of baskets.  
5. I want to know if I try to remove an item that doesn't exist in my basket.  
6. I want to know the total cost of items in my basket.  
7. I want to know the cost of a bagel before I add it to my basket.  
8. I want to choose fillings for my bagel.  
9. I want to know the cost of each filling before I add it to my bagel order.  
10. I want to ensure customers can only order items that are in stock in the inventory.  

| Classes    | Methods                                          | Scenario                                           | Outputs                                                |
|------------|--------------------------------------------------|----------------------------------------------------|--------------------------------------------------------|
| Basket.cs  | AddBagelVariantToBasket(Bagel bagelVariant)      | Add a specific type of bagel to the basket         | Returns true if the bagel is added, false otherwise    |
| Basket.cs  | RemoveBagelVariantFromBasket(Bagel bagelVariant) | Remove a bagel from the basket                     | Returns true if the bagel is removed, false otherwise  |
| Basket.cs  | BagelBasketIsFull()                              | Check if the basket is full                        | Returns "Basket is full!" or "Basket is not full!"     |
| Basket.cs  | ChangeBasketCapacity(int newCapacity)            | Change the capacity of the basket                  | Returns a message confirming capacity change           |
| Basket.cs  | CanRemoveItemInBasket(Inventory item)            | Check if an item exists in the basket for removal  | Returns a message confirming or denying item existence |
| Basket.cs  | TotalCostOfItems()                               | Calculate the total cost of items in the basket    | Returns the total cost as a double value               |
| Basket.cs  | ReturnCostOfBagel(Bagel bagelVariant)            | Get the cost of a specific bagel                   | Returns the price of the bagel as a double             |
| Basket.cs  | ChooseBagelFilling(Filling bagelFilling)         | Select a filling for a bagel                       | Returns the name of the filling or an error message    |
| Basket.cs  | CostOfEachFilling(Filling bagelFilling)          | Get the cost of a specific filling                 | Returns the price of the filling as a double           |
| Basket.cs  | MustBeInInventory(string sku)                    | Check if an item exists in the inventory           | Returns true if the item exists, false otherwise       |
