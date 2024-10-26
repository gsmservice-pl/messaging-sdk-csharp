# GetMmsPriceRequestBody

To check the price of a single message or messages with the same content to multiple recipients, pass a single `MmsMessage` object with the properties of this message using `SendMmsRequestBody.CreateMmsMessage()` method. To check the price of multiple messages with different content at the same time, pass a `List<MmsMessage>` with the properties of each message using `SendMmsRequestBody.CreateArrayOfMmsMessage()` method.


## Supported Types

### MmsMessage

```csharp
GetMmsPriceRequestBody.CreateMmsMessage(/* values here */);
```

### ArrayOfMmsMessage

```csharp
GetMmsPriceRequestBody.CreateArrayOfMmsMessage(/* values here */);
```
