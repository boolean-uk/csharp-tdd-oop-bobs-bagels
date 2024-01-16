CLASS: Basket

Properties: 
private int capacity
private List<Item> contents

Methods:
bool addItem (SKU)
returns: true/false (Could add item/exceeds capacity)

bool removeItem (SKU)
returns: true/false (Could remove item/item does not exist in basket)

int changeCapacity (int newCapacity)
returns: newCapacity

CLASS: Receipt

Properties:
Dictionary <string, float> (name, price) priceList
private float totalCost

Methods:
void addCost (float itemCost)

void printList (priceList)
prints the list of items and their prices

string printTotalCost (totalCost)
returns: $"Your total comes to: {totalCost}"

CLASS: Item

Properties:
float price
string SKU
string type (name in datastructure)
sring variant
Private List<Item> subItems
Dictionary<string, float> (SKU, price) priceList

Methods:
bool addFilling (Item item) 
returns:
true if: this.type = Bagel
false if: this.type != Bagel