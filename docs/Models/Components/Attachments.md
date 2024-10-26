# Attachments

Attachments for the message. You can pass here images, audio and video files bodies. To set one attachment please use `Attachments.CreateStr()` method simply passing to it a `string` with attachment body encoded by `base64`. To set multiple attachments - please use `Attachments.CreateArrayOfStr()` method passing to it `List<string>` with attachment bodies encoded by `base64`. Max 3 attachments per message.


## Supported Types

### Str

```csharp
Attachments.CreateStr(/* values here */);
```

### ArrayOfStr

```csharp
Attachments.CreateArrayOfStr(/* values here */);
```
