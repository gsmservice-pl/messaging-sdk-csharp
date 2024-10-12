# SendSmsRequestBody

To send a single SMS or messages with the same content to multiple recipients, pass in the Request Body a single `Sms` object with the properties of this message. To send multiple messages with different content at the same time, pass in the Request Body an `array` of `Sms` objects with the properties of each message.


## Supported Types

### Sms

```csharp
SendSmsRequestBody.CreateSms(/* values here */);
```

### ArrayOfSms

```csharp
SendSmsRequestBody.CreateArrayOfSms(/* values here */);
```
