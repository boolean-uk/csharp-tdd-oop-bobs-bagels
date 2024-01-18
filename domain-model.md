| Classes         | Methods                         |  Returns  | Scenario               | Outputs					   | 
|-----------------|---------------------------------|-----------|-------------------------|----------------------------|
| `Store`	| `Price(Name name)`					| string	|												| Returns string of prices of all items of given name by variant|
|			| `SetCapacity(int newCapacity)`		| void		|												| Basket capacity has been changed|
| `Basket`	| `Add(Item item)`						| string	| Basket isn't full								| Item is added to basket list and returns empty string | 
|			| 										| 			| Basket is full								| Returns error that basket is full  | 
|			| `Remove(string sku)`					| string	| Basket contains bagel	of given code			| Bagel is removed from basket list and returns empty string  | 
|			|										|			| Basket doesn't contain bagel of given code	| Returns error that bagel wasn't found | 
|			| `Cost()`								| double	|												| Return total cost of all items in basket|
|			| `DiscountedCost()`					| double	|												| Return total cost of all items in basket with discounts applied|
| `Item`	| `get`									| double	|												| Public value of price|
| `Bagel`	| `AddFilling(Filling filling)`			| void		|												| Adds filling to a bagel object|
| `Stock`	|										|			|												| Contains every item in the inventory|
