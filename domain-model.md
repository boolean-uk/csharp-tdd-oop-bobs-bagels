
# User Stories

| User Story | Methods                | Member variables               | Scenario               | Outputs/Results/Return values |
|------------|------------------------|--------------------------------|------------------------|--------------------------------|
| 1          | addBagel(string bagel) | string bagel                   | if bagel add           | true                           |
|            |                        |                                | if bagel not add       | false                          |
|------------|------------------------|--------------------------------|------------------------|--------------------------------|
| 2          | removeBagel(string bagel) | string bagel                | if bagel remove        | true                           |
|            |                        |                                | if bagel not remove    | false                          |
|------------|------------------------|--------------------------------|------------------------|--------------------------------|
| 3          | basketFull()           |                                | if basket full         | true                           |
|            |                        |                                | if basket not full     | false                          |
|------------|------------------------|--------------------------------|------------------------|--------------------------------|
| 4          | changeCap(int cap)     | int capacity                  | if cap add             | true                           |
|            |                        |                                | if cap not add         | false                          |
|------------|------------------------|--------------------------------|------------------------|--------------------------------|
| 5          | removeBagel(int cap)   | int capacity, string item     | if item exists         | true                           |
|            |                        |                                | if item not exist      | false                          |
|------------|------------------------|--------------------------------|------------------------|--------------------------------|
| 6          | totalCost()            | Dictionary<int, Bagel		   | if items in list		| return totalCost              |
|            |                        | > basket, int totalCost        | if items not exist     | null                           |
|------------|------------------------|--------------------------------|------------------------|--------------------------------|
| 8          | chooseFilling()        | Dictionary<int, Inventory	   | if choose filling		| return filling                |
|            |                        | > basket, string filling       | if not choose filling  | null                           |
|------------|------------------------|--------------------------------|------------------------|--------------------------------|
| 9          | seeBagelCost()         | Dictionary<int, Bagel> basket, | if show cost			| return list                   |
|            |                        | int cost                       | if not show cost       | null                           |
|------------|------------------------|--------------------------------|------------------------|--------------------------------|
| 10         | showInventory()        | Dictionary<int, Bagel>         | if show list           | true                           |
|            |                        | basket, Inventory[] invList    | if not show list       | false                          |
