<!-- Start SDK Example Usage [usage] -->
### Sending single SMS Message

This example demonstrates simple sending SMS message to a single recipient:

```csharp
using Gsmservice.Gateway;
using Gsmservice.Gateway.Models.Components;
using Gsmservice.Gateway.Models.Requests;

var sdk = new Client(bearer: "<YOUR API ACCESS TOKEN>");

SendSmsRequestBody req = SendSmsRequestBody.CreateSmsMessage(
    new SmsMessage() {
        Recipients = SmsMessageRecipients.CreateStr(
            "+48999999999"
        ),
        Message = "This is SMS message content.",
        Unicode = true,
    }
);

var res = await sdk.Outgoing.Sms.SendAsync(req);

// handle response
```

### Sending single MMS Message

This example demonstrates simple sending MMS message to a single recipient:

```csharp
using Gsmservice.Gateway;
using Gsmservice.Gateway.Models.Components;
using Gsmservice.Gateway.Models.Requests;

var sdk = new Client(bearer: "<YOUR API ACCESS TOKEN>");

SendMmsRequestBody req = SendMmsRequestBody.CreateMmsMessage(
    new MmsMessage() {
        Recipients = Recipients.CreateStr(
            "+48999999999"
        ),
        Subject = "This is a subject of the message",
        Message = "This is MMS message content.",
        Attachments = Attachments.CreateStr(
            "<file body in base64 format>"
        ),
    }
);

var res = await sdk.Outgoing.Mms.SendAsync(req);

// handle response
```
<!-- End SDK Example Usage [usage] -->