# Recipients

The recipient number or multiple recipients numbers of single message. To set one recipient, please use `Recipients.CreateStr()` method simply passing to it a `string` with his phone number. To set multiple recipients, please use `Recipients.CreateArrayOfStr()` method passing to it `List<string>`. Optionally you can also set custom id (user identifier) for each message - use `Recipients.CreatePhoneNumberWithCid()` method passing `PhoneNumberWithCid` object (in case of single recipient) or `Recipients.CreateArrayOfPhoneNumberWithCid()` method passing List<PhoneNumberWithCid> (in case of multiple recipients).


## Supported Types

### Str

```csharp
Recipients.CreateStr(/* values here */);
```

### ArrayOfStr

```csharp
Recipients.CreateArrayOfStr(/* values here */);
```

### PhoneNumberWithCid

```csharp
Recipients.CreatePhoneNumberWithCid(/* values here */);
```

### ArrayOfPhoneNumberWithCid

```csharp
Recipients.CreateArrayOfPhoneNumberWithCid(/* values here */);
```
