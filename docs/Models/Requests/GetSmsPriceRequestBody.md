# GetSmsPriceRequestBody

To check the price of a single message or messages with the same content to multiple recipients, pass a single `SmsMessage` object with the properties of this message using `SendSmsRequestBody.CreateSmsMessage()` method. To check the price of multiple messages with different content at the same time, pass a `List<SmsMessage>` with the properties of each message using `SendSmsRequestBody.CreateArrayOfSmsMessage()` method.


## Supported Types

### SmsMessage

```csharp
GetSmsPriceRequestBody.CreateSmsMessage(/* values here */);
```

### ArrayOfSmsMessage

```csharp
GetSmsPriceRequestBody.CreateArrayOfSmsMessage(/* values here */);
```
