## Extension 4

### Task
Use [twilio](https://www.twilio.com/docs/sms/quickstart/java) to send order confirmations, the order summary, and a delivery time via SMS. For this extension, use an arbitrary delivery time.

#### Part 1
```
Users should receive a text message with their order summary,
and delivery time when they complete their order.
```
<table>
	<thead>
		<td>Class</td>
		<td>Method</td>
		<td>Description</td>
		<td>Ouput</td>
	</thead>
	<tbody>
		<td><code>MessageService</code></td>
		<td><code>Send(string message)</code></td>
		<td>Send an SMS with the given message</td>
		<td>void</td>
	</tbody>
	<tbody>
		<td></td>
		<td><code>SendOrderConfirmation(Basket basket)</code></td>
		<td>Sends the customer a confirmation on their order with
		an estimated delivery time.</td>
		<td>bool</td>
	</tbody>
</table>

#### Part 2
```
Users should also be able to make orders via text message.
```
<table>
	<thead>
		<td>Class</td>
		<td>Method</td>
		<td>Description</td>
		<td>Ouput</td>
	</thead>
	<tbody>
		<td></td>
		<td>ProcessOrder(Basket basket)</td>
		<td>Processes the order a customer send via SMS</td>
		<td>void</td>
	</tbody>
</table>

#### Part 3
```
Users should be able to see a history of messages they have sent and received.
```