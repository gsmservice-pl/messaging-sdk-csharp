# SendSmsRequestBody

To send a single SMS or messages with the same content to multiple recipients, please use `SendSmsRequestBody.CreateSmsMessage()` method with a single `SmsMessage` object with the properties of this message. To send multiple messages with different content at the same time, please use `SendSmsRequestBody.CreateArrayOfSmsMessage()` method passing to it `List<SmsMessage>` with the properties of each message.


## Supported Types

### SmsMessage

```csharp
SendSmsRequestBody.CreateSmsMessage(/* values here */);
```

### ArrayOfSmsMessage

```csharp
SendSmsRequestBody.CreateArrayOfSmsMessage(/* values here */);
```
