## Extension 4

### Task
Use [twilio](https://www.twilio.com/docs/sms/quickstart/java) to send order confirmations, the order summary, and a delivery time via SMS. For this extension, use an arbitrary delivery time.

#### Part 1
```
Users should receive a text message with their order summary,
and delivery time when they complete their order.
```

| `Classes`    | `Methods`        | `Scenarios` | `Outputs`                                   |
|--------------|------------------|-------------|---------------------------------------------|
| `SMSService` | `SendSummary`    |             | `Sends a order summary to the phone number` |

#### Part 2
```
Users should also be able to make orders via text message.
```

#### Part 3
```
Users should be able to see a history of messages they have sent and received.
```