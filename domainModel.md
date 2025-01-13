# **Domain Model**

---

## **1. Add a specific type of bagel to the basket**

### **Customer**

| **Method**             | **Object Variables** | **Context**                                                        | **Output/Return**      |
|-------------------------|----------------------|----------------------------------------------------------------------|------------------------|
| `Order(string sku)`     | `Basket basket`      | If there is capacity, add an item with matching SKU to the basket.   | `bool wasAdded`        |
|                         |                      | If the basket is full, do not add the item.                          | `bool wasNotAdded`     |

---

## **2. Remove a bagel from the basket**

### **Customer**

| **Method**             | **Object Variables** | **Context**                                                                                              | **Output/Return**                |
|-------------------------|----------------------|----------------------------------------------------------------------------------------------------------|----------------------------------|
| `Delete(string sku)`    | `Basket basket`      | If the input matches an item, delete the item from the basket.                                           | `string "{sku} has been deleted"` |
|                         |                      | If the input does not match an item, do nothing.                                                        | `string "{sku} was not found"`    |

---

## **3. Notify when the basket is full**

### **Customer**

| **Method**             | **Object Variables** | **Context**                                                        | **Output/Return**      |
|-------------------------|----------------------|----------------------------------------------------------------------|------------------------|
| `Order(string sku)`     | `Basket basket`      | If there is capacity, add an item with matching SKU to the basket.   | `bool true` if added   |
|                         |                      | If the basket is full, do not add the item.                          | `bool false` if not added |

---

## **4. Change basket capacity**

### **Store**

| **Method**                    | **Object Variables**      | **Context**                                                                                                                                                          | **Output/Return** |
|--------------------------------|---------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------|-------------------|
| `SetCapacity(int newCapacity)` | `List<Item> items`        | Update the global `capacity`. If `newCapacity` is less than the current capacity, iterate over all customers' baskets. Remove the newest items until capacity is met. | `void`            |

---

## **5. Handle removal of non-existing items**

### **Basket**

| **Method**               | **Object Variables**     | **Context**                                                                                                                | **Output/Return**      |
|---------------------------|--------------------------|----------------------------------------------------------------------------------------------------------------------------|------------------------|
| `DeleteItem(string sku)`  | `List<Item> items`       | Iterate over `List<Item>` to find an item with matching SKU. If found, delete the item.                                     | `bool true` if deleted |
|                           |                          | If no matching item is found, do nothing.                                                                                  | `bool false` if not found |

---

## **6. Calculate total cost of items in the basket**

### **Basket**

| **Method**                    | **Object Variables**     | **Context**                                      | **Output/Return**      |
|--------------------------------|--------------------------|--------------------------------------------------|------------------------|
| `CalculateTotalCost()`         | `List<Item> items`       | Sum the costs of all items in the basket.        | `double totalCost`     |
|                                |                          | If the basket is empty, return `0.0`.            | `double totalCost = 0.0` |

---

## **7. View cost of an item before adding it**

### **Customer**

| **Method**                          | **Object Variables** | **Context**                             | **Output/Return**      |
|-------------------------------------|----------------------|-----------------------------------------|------------------------|
| `CalculateCostBeforeOrder(string sku)` | `Basket basket`      | Check and return the cost of the item.  | `double itemCost`      |

---

## **8. Choose fillings for a bagel**

### **Customer**

| **Method**                      | **Object Variables** | **Context**                                                                                                                   | **Output/Return**      |
|---------------------------------|----------------------|-----------------------------------------------------------------------------------------------------------------------------|------------------------|
| `ChooseFilling(string sku)`     | `Basket basket`      | If the basket contains a bagel, prompt the user to choose a filling by SKU. Add the filling to the bagel if selected.        | `Basket updatedBasket` |

---

## **9. View cost of fillings**

### **Customer**

| **Method**                      | **Object Variables** | **Context**                                                                                                                   | **Output/Return**      |
|---------------------------------|----------------------|-----------------------------------------------------------------------------------------------------------------------------|------------------------|
| `ChooseFilling(string sku)`     | `Basket basket`      | Display the cost of fillings before adding them. If no filling is chosen, continue without modification.                     | `void`                |

---

## **10. Restrict orders to available stock**

### **Customer**

| **Method**             | **Object Variables**  | **Context**                                                                                                     | **Output/Return**       |
|-------------------------|-----------------------|-----------------------------------------------------------------------------------------------------------------|-------------------------|
| `Order(string sku)`     | `Basket basket`      | If the SKU matches an item in `Store.Inventory`, add it to the basket. If not, display an error message.          | `bool added` or `bool notAdded` |

---

## **11. Apply best discounts**

### **Store**

| **Method**                     | **Object Variables**                | **Context**                                                                                                                         | **Output/Return**                 |
|---------------------------------|-------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------|-----------------------------------|
| `ApplyDiscounts(Basket basket)` | `List<Item> items`</br>`Dictionary<Item, int> itemCounter` | Count the items in the basket. Apply the best discounts to maximize savings. Return a basket with the discounted total.            | `List<Item> discountedItems`     |

---
