| Classes         | Methods                         |  Returns  | Scenario               | Outputs					   | 
|-----------------|---------------------------------|-----------|-------------------------|----------------------------|
| `Basket`	| `Add(Bagel bagel)`					| string	| Basket isn't full								| Bagel is added to basket list and retuns empty string | 
|			| 										| 			| Basket is full								| Returns error that basket is full  | 
|			| `Remove(string type)`					| string	| Basket contains bagel	of given type			| Bagel is removed from basket list  | 
|			|										|			| Basket doesn't contain bagel of given type	| Returns error that bagel wasn't found | 
|			| `SetCapacity(int newCapacity)`		| void		| Every time									| Basket capacity has been changed for everyone|
|			| `Cost()`								| double	| Every time									| Return total cost of all items in basket|
| `Bagel`	| `get`									| double	|												| Public value which includes cost of filling|
|			| `AddFilling(Filling filling)`			| void		|												| Adds filling to the bagel object|
| `Filling`	| `get`									| double	|												| Public value|
| `Stock`	|										|			|												| Contains every item in the inventory|
