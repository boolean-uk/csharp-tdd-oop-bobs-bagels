# Domain Model - first iteration

## Methods

### Product (Bagel, coffee, etc.)

| Function Name  | Parameters               | Behavior                       | Returns      |
|----------------|--------------------------|--------------------------------|--------------|
| GetCost        | double cost              | Get cost of product            | double       |
| SetCost        | double newCost           | Set cost of product            | void         |
| AddPromo       | int amount, double price | Add a new promotion on product | void         |

### Basket

| Function Name            | Parameters             | Behavior                                        | Returns |
|--------------------------|------------------------|-------------------------------------------------|---------|
| Basket                   | int? capacity          | Constructor, sets capacity to cart              | void    |
| Add                      | string SKU, int amount | Adds product to basket                          | void    |
| Remove                   | string SKU, int amount | Removes product from basket                     | void    |
| SetCapacity              | int newCapacity        | Sets the new capacity of a basket               | void    |
| [private] CheckDiscounts |                        | Checks if there are any discounts               | void    |
| [private] CheckCapacity  |                        | Checks whether the basket can fit more products | bool    |
| GetTotal                 |                        | Gets the total cost of the basket               | int     |
| Order                    |                        | Submits the bagel order                         | void    |
| [override] ToString      |                        | Generates a string representation of cart       | string  |

### BasketItem
| Function Name  | Parameters               | Behavior                       | Returns      |
|----------------|--------------------------|--------------------------------|--------------|
| Product		 |							|  Get and set                   | Product      |
| Amount		 |							|  Get and set                   | int			|
| Price			 |							|  Get and set                   | double       |
| Discount		 |							|  Get and set                   | double       |

### Inventory

| Function Name | Parameters                  | Behavior                          | Returns |
|---------------|-----------------------------|-----------------------------------|---------|
| Add           | Product product, int amount |                                   |         |
| Remove        | Product product, int amount |                                   |         |
| GetProduct    | string SKU                  | Get product by SKU                | Product |
| GetStock      |                             | Get stock of the specific product | int     |

### Order

| Function Name       | Parameters      | Behavior                                          | Returns |
|---------------------|-----------------|---------------------------------------------------|---------|
| Order               | List<OrderLine> | Constructor                                       | void    |
| [override] ToString |                 | Generate string representation of order (receipt) | string  |

### OrderLine
| Function Name  | Parameters               | Behavior                       | Returns      |
|----------------|--------------------------|--------------------------------|--------------|
| Amount		 |							|  Get and set                   | int          |
| Price			 |							|  Get and set                   | double		|
| Discount		 |							|  Get and set                   | double       |
| BasketItem	 |							|  Get and set                   | BasketItem   |


# Domain Model - second iteration

## Methods

### Product (Bagel, coffee, etc.)

| Function Name  | Parameters               | Behavior                       | Returns      |
|----------------|--------------------------|--------------------------------|--------------|
| Price			 |							|  Get and set                   | double       |
| Type			 |							|  Get and set                   | ProductType  |
| SKU			 |							|  Get and set                   | string       |
| Variant		 |							|  Get and set                   | string       |

### Basket

| Function Name            | Parameters             | Behavior                                        | Returns |
|--------------------------|------------------------|-------------------------------------------------|---------|
| Add                      | Product item, ?int amount    | Adds a product to the basket. If product exists, updates the amount              | bool    |
| Remove                   | Product item			| Removes a specific product from the basket      | void    |
| Remove                   | string SKU				| Removes a product by its SKU                    | void    |
| Capacity				   |						| Get and set									  | int     |
| GetTotal                 |                        | Gets the total cost of the basket               | int     |
| SubmitOrder              |						| Submits the basket order with applied discounts | void    |
| [override] ToString      |                        | Generates a string representation of basket     | string  |


### BasketItem
| Function Name  | Parameters               | Behavior                       | Returns      |
|----------------|--------------------------|--------------------------------|--------------|
| Product		 |							|  Get and set                   | Product      |
| Amount		 |							|  Get and set                   | int			|
| Price			 |							|  Get and set                   | double       |
| Discount		 |							|  Get and set                   | double       |

### Inventory

| Function Name | Parameters                  | Behavior                          | Returns |
|---------------|-----------------------------|-----------------------------------|---------|
| Add           | Product product, int amount | Add product to inventory                                  | void    |
| Remove        | string sku, int amount	  | Remove item from inventory                                  | void    |
| GetProduct    | string SKU                  | Get product by SKU                | Product |
| GetStock      |                             | Get stock of the specific product | int     |
| Products      |                             | Returns a dictionary of all products in inventory | Dictionary<string, Product>     |

### Order

| Function Name       | Parameters      | Behavior                                          | Returns |
|---------------------|-----------------|---------------------------------------------------|---------|
| Order               | List<OrderLine> | Constructor                                       | void    |
| [override] ToString |                 | Generate string representation of order (receipt) | string  |

### OrderLine
| Function Name  | Parameters               | Behavior                       | Returns      |
|----------------|--------------------------|--------------------------------|--------------|
| Amount		 |							|  Get and set                   | int          |
| Price			 |							|  Get and set                   | double		|
| Discount		 |							|  Get and set                   | double       |
| BasketItem	 |							|  Get and set                   | BasketItem   |

### Discount

| Function Name       | Parameters      | Behavior																		 | Returns |
|---------------------|-----------------|---------------------------------------------------							 |---------|
| AddQuantityDiscount | string sku, int quantity, double discountedPrice | Adds a quantity-based discount to the system  | void    |
| AddComboDiscount | List<string> combo, double value | Adds a combo discount for a list of products  | void    |
| RemoveQuantityDiscount | string sku, int quantity | Removes a quantity-based discount  | void    |
| RemoveComboDiscount | List<string> combo | Removes a combo discount for the specified combo  | void    |
| CalculateDiscount | 	BasketItem item | Calculates the discount for a specific item in the basket  | double    |
| GetComboDiscount | List<BasketItem> items | Checks if a combo discount can be applied  | double    |