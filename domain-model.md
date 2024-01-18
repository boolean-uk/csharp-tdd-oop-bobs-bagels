# Domain model: Bob's Bagels
## Entities
### Store
Store is the central control unit that contains a databse for the other entities.
#### Fields
- Users - List of `Users`.
- BaseItems - List of all `BaseItems` on the menu.
- AddOns - List of `AddOns` on the menu.
- MaximumBasketCapacity - Determines how much each `User` can put in their Basket.
- Managers - List of `Users` that have admin priveleges.
- ActiveUser - ID of the current `User` of the system.
- #### Methods
- (Add and Remove methods for Users, BaseItems and AddOns with appropriate data integrity checks).
- Login(string) -> void - Sets ActiveUser to the specified UserID, if it exists.
- MakeManager(string) -> void - Inserts provided userID into the list of managers, if it exists. Can only be performed if ActiveUser is a manager.
- SetMaximumBasketCapacity(int) -> void - Sets a new global capacity limit for baskets. Can only be performed if ActiveUser is a manager.
### User
#### Fields
- UserID - Uniquely identifies the user.
- Basket - List of all `BaseItems` and `AddOns` for each of those items, chosen by the user.
#### Methods
- AddItem() -> Void - Adds a `BasketEntry` to the basket based on the provided `BaseItem` ID and list of `AddOns` (DefaultAddons by default), if there is space for it.
- RemoveItem(int) -> void -  Removes entry in Basket at specified index, if it exists.
- BasketCost() -> decimal - Calculates the total price of the content in the basket.
- BasketSpaceOccupation() -> decimal - Calculates the total footprint of all contents in the basket.
### BasketEntry
#### Fields
- Item - The `BaseItem` of this entry.
- Count - The amount of this item the user has in their basket.
- AddOns - List of addons for this entry.
#### Methods
- TotalCost() -> decimal - The total cost of the content in the entry.
- TotalFootprint() -> decimal - The total footprint of this entry.


### MenuItem (interface)
#### Fields
- ItemID - Uniquely identifies a `MenuItem`.
- Name - Name of the `MenuItem`.
- Price - Base price of the `MenuItem`.
- BasketFootprint - Determines how much space the `MenuItem` occupies in a `User` Basket.

### BaseItem (implements `MenuItem`)
#### Fields
- DefaultAddOns - List of `AddOns` that are default for the `BaseItem`.
- AvialableAddOns - List of `AddOns` avilable for the given `BaseItem`.

### AddOn (implements `MenuItem`)