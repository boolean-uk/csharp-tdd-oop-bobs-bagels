Class Basket

-- properties --
private List<Item> basket 
private int capacity 
-- methods --
int ChangeCapacity(int capacity) --Returns capacity
bool AddItem(string SKU)  --Returns false if Item can't be added
bool RemoveItem(string SKU) --Returns false if Item can't be removed
float TotalCost() -- Calculates and returns total cost of the basket
float GetPrice(string SKU) -- Returns cost of one item; 0 if item is invalid


Abstract Class Item
-- properties -- 
float price
string id
string variant

Class Bagel : Item
List<Filling> fillings
bool AddFilling(string SKU)
float TotalCost();

Class Filling : Item


Class Coffee : Item


Class Receipt
-- properties --
private Basket basket;
private DateTime currentTime;

-- methods --
public Receipt(Basket basket)
private Print()
