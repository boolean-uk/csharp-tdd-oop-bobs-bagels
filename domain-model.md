| Classes	| Members                                                            | Methods							| Scenario														| Outputs	|
|-----------|--------------------------------------------------------------------|----------------------------------|---------------------------------------------------------------|-----------|
| `Basket`	| `List<Products> _items` (product is its own class)				 | `Add(Bagle)`						| Item with the provided name *is not* already in the basket	| true		|
|			| `int _capacity`                                                    |									| Bagle basket *is* full										| false		|
|			|                                                                    |									| Item exists													| true		|
|			|                                                                    |									| Item does not exist											| false		|
|			|                                                                    | `Remove(string)`                 | Item with the provided name *is* in the basket				| int		|
|			|                                                                    |									| Item with the provided name *is not* in the basket			| int		|
|			|                                                                    | `ChangeCapacity(int)`            |																| int		|
|			|                                                                    | `TotalCost()`					|																| double	|
|			|                                                                    | `AddFilling()`					|																| double	|
|-----------|--------------------------------------------------------------------|----------------------------------|---------------------------------------------------------------|-----------|
| Classes	| Members																				| Methods							| Scenario														| Outputs	|
|-----------|---------------------------------------------------------------------------------------|-----------------------------------|---------------------------------------------------------------|-----------|
| `Bakery`	| `List<(string SKU, double Price, Product.ProdType Type, string Variant)> _products;`	| `AddToBasket(string, int)`		|																| bool		|
|			| `int _basketCapacity`																	| `RemoveFromBasket(string, int)`	|																| int		|
|			| `List<Basket> _customers`																| `ChangeCapacity(int)`				|																| int		|
|			|																						| `BagleCost(string)`				|																| double	|
|			|																						| `AddFilling()`					|																| double	|
|			|																						| `FillingCost(string)`				|																| double	|
|			|																						| `CheckOut()`						|																| double	|
|			|																						| `Discount(double, List<Product>)`	|																| double	|
|			|																						|									|																|			|
