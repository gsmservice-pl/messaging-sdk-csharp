# SmsMessageRecipients

The recipient number or multiple recipients numbers of single message. To set one recipient, please use `SmsMessageRecipients.CreateStr()` method simply passing to it a `string` with his phone number. To set multiple recipients, please use `SmsMessageRecipients.CreateArrayOfStr()` method passing to it `List<string>`. Optionally you can also set custom id (user identifier) for each message - use `SmsMessageRecipients.CreatePhoneNumberWithCid()` method passing `PhoneNumberWithCid` object (in case of single recipient) or `SmsMessageRecipients.CreateArrayOfPhoneNumberWithCid()` method passing List<PhoneNumberWithCid> (in case of multiple recipients).


## Supported Types

### Str

```csharp
SmsMessageRecipients.CreateStr(/* values here */);
```

### ArrayOfStr

```csharp
SmsMessageRecipients.CreateArrayOfStr(/* values here */);
```

### PhoneNumberWithCid

```csharp
SmsMessageRecipients.CreatePhoneNumberWithCid(/* values here */);
```

### ArrayOfPhoneNumberWithCid

```csharp
SmsMessageRecipients.CreateArrayOfPhoneNumberWithCid(/* values here */);
```
