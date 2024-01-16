| Classes	| Members                                                            | Methods							| Scenario														| Outputs	|
|-----------|--------------------------------------------------------------------|----------------------------------|---------------------------------------------------------------|-----------|
| `Basket`	| `List<Bagles> _bagles` (bagle is its own class)					 | `Add(Bagle)`						| Item with the provided name *is not* already in the basket	| true		|
|			|                                                                    |									| Bagle basket *is* full										| false		|
|			|                                                                    |									| Item exists													| true		|
|			|                                                                    |									| Item does not exist											| false		|
|			|                                                                    | `Remove(string)`                 | Item with the provided name *is* in the basket				| int		|
|			|                                                                    |									| Item with the provided name *is not* in the basket			| int		|
|			|                                                                    | `ChangeCapacity(int)`            |																| int		|
|			|                                                                    | `TotalCost()`					|																| double	|
|			|                                                                    | `BagleCost(string)`				|																| double	|
|			|                                                                    | `FillingCost(string)`			|																| double	|
|			|                                                                    |									|																|			|
