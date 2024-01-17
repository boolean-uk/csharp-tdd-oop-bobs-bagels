# Bagel Basket System

## Classes:

1. **Basket**
   - Properties:
     - `capacity: int`
     - `items: List[str]`
   - Methods:
     - `add_item(item: str) -> None`
     - `remove_item(item: str) -> None`
     - `is_full() -> bool`
     - `change_capacity(new_capacity: int) -> None`

## Test Cases:

1. **Add a Bagel to Basket**
   - As a member of the public,
   - So I can order a bagel before work,
   - I'd like to add a specific type of bagel to my basket.

2. **Remove a Bagel from Basket**
   - As a member of the public,
   - So I can change my order,
   - I'd like to remove a bagel from my basket.

3. **Check if Basket is Full**
   - As a member of the public,
   - So that I can not overfill my small bagel basket,
   - I'd like to know when my basket is full when I try adding an item beyond my basket capacity.

4. **Change Basket Capacity**
   - As a Bob's Bagels manager,
   - So that I can expand my business,
   - I’d like to change the capacity of baskets.

5. **Check if Item Exists Before Removing**
   - As a member of the public,
   - So that I can maintain my sanity,
   - I'd like to know if I try to remove an item that doesn't exist in my basket.





| Classes  | Members                                                            | Methods                          | Scenario                                                   | Outputs |
|----------|--------------------------------------------------------------------|----------------------------------|------------------------------------------------------------|---------|
| `Basket` | `HashMap<String, int> items` (key is product name, value is price) | `add(String product, int price)` | Item with the provided name *is not* already in the basket | true    |
|          |                                                                    |                                  | Item with the provided name *is* already in the basket     | false   |
|          |                                                                    | `total()`                        |                                                            | int     |