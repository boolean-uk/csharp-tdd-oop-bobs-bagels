| Classes    	| Methods                         	| Scenario                                                             	| Outputs          	|
|------------	|---------------------------------	|----------------------------------------------------------------------	|------------------	|
| Basket.cs  	| AddBagel(Bagel bagelType)       	| adds bagel to basket, if in stock                                    	|                  	|
| Bakset.cs  	| RemoveBagel(Bagel bagelType)    	| removes bagel from basket                                            	|                  	|
| basket.cs  	| IsFull()                        	| if basket full when adding item, throw IsFullexception               	| throws exception 	|
| store.cs   	| ChangeBasketCapacity()          	| manager changes all the baskets capacities in the store              	|                  	|
| basket.cs  	| ItemNotPresent()                	| throws ItemNotPresentException if trying to remove non existing item 	| throws exception 	|
| basket.cs  	| GetTotalCost()                  	| gets the price of all items combined in basket                       	| int total;       	|
| Bagel.cs   	| GetCost()                       	| returns the cost which is a constant member set in the class         	| int cost;        	|
| Bagel.cs   	| AddFilling(Filling fillingType) 	| adds filling to the bagels list of fillings, if in stock             	|                  	|
| Filling.cs 	| GetCost()                       	| Returns the cost of the filling                                      	| int cost;        	|
| store.cs   	| AvaiableItems()                 	| returns all avaiable items in stock                                  	| List<Item> items 	|
|            	|                                 	|                                                                      	|                  	|
|            	|                                 	|                                                                      	|                  	|