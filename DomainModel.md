#Domain Models




| Classes              | Methods                                                  | Scenario                                  | Outputs |
|----------------------|----------------------------------------------------------|-------------------------------------------|---------|
| `Core`			   | `AddBagleToBasket(Enum Bagle)`                           | add bagle to basket.                      | Creates a bagle object that is added to basket  |
|                      | `romeveBagle(Enum Bagle)`				                  | Enter bagle enum that exists in basket    | removes bagle from basket    |
|                      | `bascetMaxSize(int size, adminCheck)`                                | input int 10                              | changes basketsixe to 10  |
|                      | `calculateTotalCost()`                                   | call function when having a basket        | returns total cost of items in basket    |
| `Bagle`              | `getCostOfBagle()`                                       | call func                        | returns cost of bagle  |
|                      | `SetFilling(filling f)`                                  | add filling cheese                 | adds cheese to array   |
| `filling`            | `getCostOfFilling()`                                     | when addign filling                     | return cost of filling  |
| `person`            | `isManager()`										   | check if person is mannager                    | return true if manager  |