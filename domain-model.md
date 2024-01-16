| Classes         | Methods                         |  Returns  | Scenario               | Outputs					   | 
|-----------------|---------------------------------|-----------|-------------------------|----------------------------|
| `Store`	| `Price(Name name)`					| string	|												| Returns string of prices of all items of given name by variant|
| `Basket`	| `Add(Item item)`						| string	| Basket isn't full								| Item is added to basket list and returns empty string | 
|			| 										| 			| Basket is full								| Returns error that basket is full  | 
|			| `Remove(string variant)`				| string	| Basket contains bagel	of given type			| Bagel is removed from basket list and returns empty string  | 
|			|										|			| Basket doesn't contain bagel of given type	| Returns error that bagel wasn't found | 
|			| `SetCapacity(int newCapacity)`		| void		|												| Basket capacity has been changed|
|			| `Cost()`								| double	|												| Return total cost of all items in basket|
| `Item`	| `get`									| double	|												| Public value of price|
| `Bagel`	| `AddFilling(Filling filling)`			| void		|												| Adds filling to a bagel object|
| `Stock`	|										|			|												| Contains every item in the inventory|
