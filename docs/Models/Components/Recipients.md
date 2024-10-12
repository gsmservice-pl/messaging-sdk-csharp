# Recipients

The recipient number or multiple recipients numbers of single message. To set one recipient, simply pass here a `string` with his phone number. To set multiple recipients, pass here a simple `array` of `string`. Optionally you can also set custom id (user identifier) for each message - pass `PhoneNumberWithCid` object (in case of single recipient) or `Array` of `PhoneNumberWithCid` (in case of multiple recipients).


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
