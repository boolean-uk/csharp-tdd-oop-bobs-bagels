## Extension 4

### Task
Use [twilio](https://www.twilio.com/docs/sms/quickstart/java) to send order confirmations, the order summary, and a delivery time via SMS. For this extension, use an arbitrary delivery time.

# Important
As I don't wish to sign up for Twilio I have written some "pseudocode" for this extension.
While it uses the proper Twilio package and functionality from that, the pseudocode aspect of it stems from not being able to test the sms functionality of the code.
As a result I made the API use Swagger so the endpoints that Twilio would use could be tested easily. 
This can be used to mock the sms functionality, which allows the user to submit orders in two ways:
1. POST request to /sms with SmsRequest (from Twilio) where the request.Body is a string of SKU "SKU1, SKU2, ...".
2. POST request to /sms/simple with a list of SKU ["SKU1", "SKU2", ...].



#### Part 1
```
Users should receive a text message with their order summary,
and delivery time when they complete their order.
```
This is returned for all the POST endpoints.

#### Part 2
```
Users should also be able to make orders via text message.
```
Implemented via POST to api/sms (that Twilio would use). 

#### Part 3
```
Users should be able to see a history of messages they have sent and received.
```
Implemented via [HttpGet("{SId}")] where SId is the SId you want to get history for.