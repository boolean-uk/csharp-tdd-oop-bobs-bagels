

Class: Basket		Method: AddProduct(product)				void: add product to list				case: As a member of the public, So I can order a bagel before work, I'd like to add a specific type of bagel to my basket.
Class: Basket		Method: RemoveProduct(product)			void: remove product from list			case: As a member of the public, So I can change my order, I'd like to remove a bagel from my basket.
Class: Basket		Method: AddProduct(product)				out: "You are overencumbered"			case: As a member of the public,So that I can not overfill my small bagel basketI'd like to know when my basket is full when I try adding an item beyond my basket capacity.
Class: Basket		Method: ChangeCapacity(n)				void: capacity = n						case:As a Bob's Bagels manager,So that I can expand my business,I’d like to change the capacity of baskets.
Class: Basket		Method: RemoveProduct(product)			out: "no such product to remove"		case:As a member of the publicSo that I can maintain my sanityI'd like to know if I try to remove an item that doesn't exist in my basket.
Class: Product		Method: AddProduct()					void: add products to other products	case:As a member of the public,So I can order a bagel before work,I'd like to add a specific type of bagel to my basket.
																									case: As a customer,So I can shake things up a bit,I'd like to be able to choose fillings for my bagel.
Class: Product		Method: GetPrice()						return: price of product				case:As a customer,So I know what the damage will be,I'd like to know the cost of a bagel before I add it to my basket.
Class: Basket		Method: TotalPrice()					return: the sum of the prices in basket case:As a customer,So I know how much money I need,I'd like to know the total cost of items in my basket.
																									case: As a customer,So I don't over-spend,I'd like to know the cost of each filling before I add it to my bagel order.
Class: Basket		Method: AddProduct()					Use: Enum								case:As the manager,So we don't get any weird requests,I want customers to only be able to order things that we stock in our inventory.




Class: Basket		Method: CalculateDiscount()		return: the discounts		case:	All bagels 6 for 2.49
																				case:	All bagels 12 for 3.99
																				case:	Coffe + bagel for 1.25
																				case:	Fillings not included







remember to commit before implementing