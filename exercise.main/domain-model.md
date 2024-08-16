`1.
As a member of the public,
So I can order a bagel before work,
I'd like to add a specific type of bagel to my basket.`

| Classes  | Members                                                            | Methods                          | Scenario                                                   | Outputs |
|----------|--------------------------------------------------------------------|----------------------------------|------------------------------------------------------------|---------|
| `Bagel ` | `SKU, Name, Variant, Price, Filling`                               | `Just constructor?`              | Item added                                                 |         |
| `Item`   | `SKU, Price, Name, Variant, Filling`                               | `GetShopItem()`                  | Creates an item for the basket with the customers selection| item    |
| `Basket` |  `List<Itemlist> items, Subtotal`                                  | `List total`                     | Shows items and their total                                | double cost   |

`2.
As a member of the public,
So I can change my order,
I'd like to remove a bagel from my basket.`

| Classes  | Members                                                            | Methods                             | Scenario                                                   | Outputs |
|----------|--------------------------------------------------------------------|-------------------------------------|------------------------------------------------------------|---------|
| `Basket` | `List<Itemlist> items`                                             | `remove(item)`                      | Item removed                                               | true    |
|          |                                                                    |                                     | Item not sucsesfully removed                               | false   |
|          |                                                                    |                                     |                                                            |         |

`3.
As a member of the public,
So that I can not overfill my small bagel basket
I'd like to know when my basket is full when I try adding an item beyond my basket capacity.`

| Classes  | Members                                                            | Methods                             | Scenario                                                   | Outputs |
|----------|--------------------------------------------------------------------|-------------------------------------|------------------------------------------------------------|---------|
| `Basket` | `int maxcap`                                                       |                                     |                                                            |         |
|          | `int current`                                                      |                                     |                                                            |         |
|          |                                                                    |    hasCap(int maxcap, int current)  |   If current is less than maxcap                           |   true  |
|          |                                                                    |    hasCap(int maxcap, int current)  |   If current is equal or more than maxcap                  |   false |

`4.
As a Bob's Bagels manager,
So that I can expand my business,
I'd like to change the capacity of baskets.`

| Classes  | Members                                                            | Methods                             | Scenario                                                   | Outputs                |
|----------|--------------------------------------------------------------------|-------------------------------------|------------------------------------------------------------|------------------------|
| `Basket` | `int maxcap`                                                       | `int changeCap(int)`                | Cap changed                                                | new cap int            |
| `Admin`  | `bool isAdmin`                                                     |                                     | Admin is logged in                                         | Can access editCap     | 
|          |                                                                    |                                     | Admin is not logged in                                     |  Can not access editCap|

`5.
As a member of the public
So that I can maintain my sanity
I'd like to know if I try to remove an item that doesn't exist in my basket.`

| Classes  | Members                                                            | Methods                             | Scenario                                                   | Outputs |
|----------|--------------------------------------------------------------------|-------------------------------------|------------------------------------------------------------|---------|
| `Basket` | `List<string>basketContent`                                        | `exists(string)`                    | check that item exists in basket                           | true    |
|          |                                                                    |                                     | else                                                       | false   |
|          |                                                                    |                                     |                                                            |         |