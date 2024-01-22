## Domain model for Bobs Bagels

Class
: `Basket()`

Properties
: `List<string> _bagels = new List<string>{"A", "B", "C"}`
: `List<string> _basket`
: `int _capacity = 5`

Methods
: `Add(string description)`
    * adds a new bagel order to _basket. Must be a string included in the _bagels list. 
    * Outputs an error message (Console.WriteLine) if the list capacity is exceeded.

: `Remove(string description)`
    * removes bagel from _basket. 
    * Outputs an error message (Console.WriteLine) if the bagel is not in the basket. 

: `ChangeCapacity(int capacity)`
    * changes the value of the _capacity variable.
    * the default of capacity is 5