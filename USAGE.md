<!-- Start SDK Example Usage [usage] -->
### Sending single SMS Message

This example demonstrates simple sending SMS message to a single recipient:

```csharp
using Gsmservice.Gateway;
using Gsmservice.Gateway.Models.Requests;
using Gsmservice.Gateway.Models.Components;
using System.Collections.Generic;

var sdk = new Client(bearer: "<YOUR API ACCESS TOKEN>");

SendSmsRequestBody req = SendSmsRequestBody.CreateArrayOfSmsMessage(
    new List<SmsMessage>() {
        new SmsMessage() {
            Recipients = SmsMessageRecipients.CreateArrayOfStr(
                new List<string>() {
                    "+48999999999",
                }
            ),
            Message = "To jest treść wiadomości",
            Sender = "Bramka SMS",
            Type = Gsmservice.Gateway.Models.Components.SmsType.SmsPro,
            Unicode = true,
            Flash = false,
            Date = null,
        },
    }
);

var res = await sdk.Outgoing.Sms.SendAsync(req);

// handle response
```

### Sending single MMS Message

This example demonstrates simple sending MMS message to a single recipient:

```csharp
using Gsmservice.Gateway;
using Gsmservice.Gateway.Models.Requests;
using Gsmservice.Gateway.Models.Components;
using System.Collections.Generic;

var sdk = new Client(bearer: "<YOUR API ACCESS TOKEN>");

SendMmsRequestBody req = SendMmsRequestBody.CreateArrayOfMmsMessage(
    new List<MmsMessage>() {
        new MmsMessage() {
            Recipients = Recipients.CreateArrayOfStr(
                new List<string>() {
                    "+48999999999",
                }
            ),
            Subject = "To jest temat wiadomości",
            Message = "To jest treść wiadomości",
            Attachments = Attachments.CreateArrayOfStr(
                new List<string>() {
                    "<file_body in base64 format>",
                }
            ),
            Date = null,
        },
    }
);

var res = await sdk.Outgoing.Mms.SendAsync(req);

// handle response
```
<!-- End SDK Example Usage [usage] -->