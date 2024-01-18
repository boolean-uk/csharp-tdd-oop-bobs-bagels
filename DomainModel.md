| Classes         | Methods                         | Scenario						| Outputs				|
|-----------------|---------------------------------|-------------------------------|-----------------------|
| `Basket`        | Add(Bagel)						| Adds a bagel to cart			|Bagel added			|
| `Basket`		  | Remove(Bagel)					| Removes Bagel from cart		|Bagel removed			|
| `Basket`		  | if Basket>Capacity				| Adds Bagel to full basket		|Basket is full			|
| `Basket`		  | Capcity.increase				| Increase basket size		 	|Basket size increased	|
| `Basket`		  |Remove.Bagel	!					| Removes nonexisting Bagel 	|bagel not in basket	|
| `Basket`		  | TotalCost(Basket)				| Add Cost of everything		| "Cost X"				|
| `Bagel`		  |	Bagel.fillings					|	Choose filling for bagel	| Bagel with bacon added|
| `Stock`		  |	CheckStock						| Product not in stock			| Error no item in stock|
| `bagel`		  | Price							| Price of each item displayed  |Bagel with X filling is|



Extension: 
| Classes         | Methods                         | Scenario						| Outputs				|
|-----------------|---------------------------------|-------------------------------|-----------------------|
| `Basket`        |CheckDiscount					| 6 bagels in cart				|discount applied		|
|				  |									| 6 bagels and coffee			|relevant discount 		|
|				  |									| 2 bagles in cart				|no discount 			|
