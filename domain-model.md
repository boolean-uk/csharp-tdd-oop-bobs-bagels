| Classes	| Members                                                            | Methods							| Scenario														| Outputs	|
|-----------|--------------------------------------------------------------------|----------------------------------|---------------------------------------------------------------|-----------|
| `Basket`	| `List<Bagles> _bagles` (bagle is its own class)					 | `Add(Bagel)`						| Item with the provided name *is not* already in the basket	| true		|
|			|                                                                    |									| Bagle basket *is* full										| false		|
|			|                                                                    | `Remove(string)`                 | Item with the provided name *is* in the basket				| int		|
|			|                                                                    |									| Item with the provided name *is not* in the basket			| int		|
|			|                                                                    | `ChangeCapacity(int)`            |																| int		|
|			|                                                                    |									|																|			|
