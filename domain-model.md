# Bob's Bagels - Domain Model
```
1.
As a member of the public,
So I can order a bagel before work,
I'd like to add a specific type of bagel to my basket.

2.
As a member of the public,
So I can change my order,
I'd like to remove a bagel from my basket.

3.
As a member of the public,
So that I can not overfill my small bagel basket
I'd like to know when my basket is full when I try adding an item beyond my basket capacity.

5.
As a member of the public
So that I can maintain my sanity
I'd like to know if I try to remove an item that doesn't exist in my basket.

6.
As a customer,
So I know how much money I need,
I'd like to know the total cost of items in my basket.

7.
As a customer,
So I know what the damage will be,
I'd like to know the cost of a bagel before I add it to my basket.

8.
As a customer,
So I can shake things up a bit,
I'd like to be able to choose fillings for my bagel.

9.
As a customer,
So I don't over-spend,
I'd like to know the cost of each filling before I add it to my bagel order.
```
<table>
	<thead>
		<td>Class</td>
		<td>Method</td>
		<td>Scenario</td>
		<td>Output</td>
	</thead>
	<tbody>
		<td><code>Customer</code></td>
		<td><code>Order(IFood food)</code></td>
		<td>Add a specific type of food to the basket</td>
		<td>void</td>
	</tbody>
	<tbody>
		<td></td>
		<td><code>Order(IFood food)</code></td>
		<td>Throw an exception when about to overfill the basket</td>
		<td>Exception</td>
	</tbody>
	<tbody>
		<td></td>
		<td><code>Remove(IFood food)</code></td>
		<td>Remove a food from the basket</td>
		<td>bool</td>
	</tbody>
	<tbody>
		<td></td>
		<td><code>Remove(IFood food)</code></td>
		<td>Throw an exception when about to remove a non-existing food</td>
		<td>Exception</td>
	</tbody>
</table>

<table>
	<thead>
		<td>Class</td>
		<td>Method</td>
		<td>Scenario</td>
		<td>Output</td>
	</thead>
	<tbody>
		<td><code>IFood</code></td>
		<td><code>Price</code></td>
		<td>Get the price of the selected food</td>
		<td>float</td>
	</tbody>
	<tbody>
		<td></td>
		<td><code>Name</code></td>
		<td>Get the name of the IFood</td>
		<td>string</td>
	</tbody>
	<tbody>
		<td></td>
		<td><code>SKU</code></td>
		<td>Get the SKU of the selected food</td>
		<td>string</td>
	</tbody>
	<tbody>
		<td></td>
		<td><code>Variant</code></td>
		<td>Get the variant of the IFood</td>
		<td>Enum</td>
	</tbody>
	<tbody>
		<td><code>Bagel : IFood</code></td>
		<td><code>Filling</code></td>
		<td>Get and set the filling of the bagel</td>
		<td>Filling || void</td>
	</tbody>
	<tbody>
		<td><code>Filling : IFood</code></td>
		<td></td>
		<td></td>
		<td></td>
	</tbody>
</table>


```
4.
As a Bob's Bagels manager,
So that I can expand my business,
I’d like to change the capacity of baskets.

10.
As the manager,
So we don't get any weird requests,
I want customers to only be able to order things that we stock in our inventory.
```
<table>
	<tbody>
		<td><code>Basket</code></td>
		<td><code>Capacity</code></td>
		<td>Get and set the capacity of the basket</td>
		<td>int || void</td>
	</tbody>
	<tbody>
		<td><code>Customer</code></td>
		<td><code>Order(IFood food, List&ltstring> availableSkus)</code></td>
		<td>Only let the customer order what is in the available SKUs list.</td>
		<td>bool</td>
	</tbody>
</table>