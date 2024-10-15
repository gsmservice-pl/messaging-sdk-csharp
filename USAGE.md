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
            Recipients = Recipients.CreateArrayOfStr(
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
<!-- End SDK Example Usage [usage] -->