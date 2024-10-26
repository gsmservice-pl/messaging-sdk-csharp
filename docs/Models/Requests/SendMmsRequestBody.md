# SendMmsRequestBody

To send a single MMS or messages with the same content to multiple recipients, please use `SendMmsRequestBody.CreateMmsMessage()` method with a single `MmsMessage` object with the properties of this message. To send multiple messages with different content at the same time, please use `SendMmsRequestBody.CreateArrayOfMmsMessage()` method passing to it `List<MmsMessage>`  with the properties of each message.


## Supported Types

### MmsMessage

```csharp
SendMmsRequestBody.CreateMmsMessage(/* values here */);
```

### ArrayOfMmsMessage

```csharp
SendMmsRequestBody.CreateArrayOfMmsMessage(/* values here */);
```
