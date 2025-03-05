# Mms
(*Outgoing.Mms*)

## Overview

### Available Operations

* [GetPrice](#getprice) - Check the price of MMS Messages
* [Send](#send) - Send MMS Messages

## GetPrice


Check the price of single or multiple MMS messages at the same time before sending them. You can pass a single `MmsMessage` object using `GetMmsPriceRequestBody.CreateMmsMessage()` method (for single message) or `List<MmsMessage>` using `GetMmsPriceRequestBody.CreateArrayOfMmsMessage()` method (for multiple messages). Each `MmsMessage` object has several properties, describing message parameters such as recipient phone number, content of the message, attachments, etc.
The method will accept maximum **50** messages in one call.

As a successful result a `GetMmsPriceResponse` object will be returned  containing a `Price` objects, one object per each single message. You should check the `Error` property of each `Price` object to make sure which messages were priced successfully and which finished with an error. Successfully priced messages will have `null` value of `Error` property.

`GetSmsPriceResponse` object will include also `Headers` property with `X-Success-Count` (a count of messages which were processed successfully) and `X-Error-Count` (count of messages which were rejected) elements.

### Example Usage

```csharp
using Gsmservice.Gateway;
using Gsmservice.Gateway.Models.Components;
using Gsmservice.Gateway.Models.Requests;
using System.Collections.Generic;

var sdk = new Client(bearer: "<YOUR API ACCESS TOKEN>");

GetMmsPriceRequestBody req = GetMmsPriceRequestBody.CreateArrayOfMmsMessage(
    new List<MmsMessage>() {
        new MmsMessage() {
            Recipients = Recipients.CreatePhoneNumberWithCid(
                new PhoneNumberWithCid() {
                    Nr = "+48999999999",
                    Cid = "my-id-1113",
                }
            ),
            Subject = "To jest temat wiadomości",
            Message = "To jest treść wiadomości",
            Attachments = Attachments.CreateArrayOfStr(
                new List<string>() {
                    "<file_body in base64 format>",
                }
            ),
        },
    }
);

var res = await sdk.Outgoing.Mms.GetPriceAsync(req);

// handle response
```

### Parameters

| Parameter                                                                 | Type                                                                      | Required                                                                  | Description                                                               |
| ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- |
| `request`                                                                 | [GetMmsPriceRequestBody](../../Models/Requests/GetMmsPriceRequestBody.md) | :heavy_check_mark:                                                        | The request object to use for the request.                                |

### Response

**[GetMmsPriceResponse](../../Models/Requests/GetMmsPriceResponse.md)**

### Errors

| Error Type                                     | Status Code                                    | Content Type                                   |
| ---------------------------------------------- | ---------------------------------------------- | ---------------------------------------------- |
| Gsmservice.Gateway.Models.Errors.ErrorResponse | 400, 401, 4XX                                  | application/problem+json                       |
| Gsmservice.Gateway.Models.Errors.ErrorResponse | 5XX                                            | application/problem+json                       |

## Send


Send single or multiple MMS messages at the same time. You can pass a single `MmsMessage` object using `SendMmsRequestBody.CreateMmsMessage()` method (for single message) or `List<MmsMessage>` using `SendMmsRequestBody.CreateArrayOfMmsMessage()` method (for multiple messages). Each `SmsMessage` object has several properties, describing message parameters such recipient phone number, content of the message, attachments or scheduled sending date, etc. This method will accept maximum 50 messages in one call.

As a successful result a `SendMmsResponse` object will be returned with `Messages` property of type List<Message> containing `Message` objects, one object per each single message. You should check the `StatusCode` property of each `Message` object to make sure which messages were accepted by gateway (queued) and which were rejected. In case of rejection, `StatusDescription` property will include a reason.

`SendSmsResponse` will also include `Headers` property with `X-Success-Count` (a count of messages which were processed successfully), `X-Error-Count` (count of messages which were rejected) and `X-Sandbox` (if a request was made in Sandbox or Production system) elements.

### Example Usage

```csharp
using Gsmservice.Gateway;
using Gsmservice.Gateway.Models.Components;
using Gsmservice.Gateway.Models.Requests;
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
        },
    }
);

var res = await sdk.Outgoing.Mms.SendAsync(req);

// handle response
```

### Parameters

| Parameter                                                         | Type                                                              | Required                                                          | Description                                                       |
| ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- |
| `request`                                                         | [SendMmsRequestBody](../../Models/Requests/SendMmsRequestBody.md) | :heavy_check_mark:                                                | The request object to use for the request.                        |

### Response

**[SendMmsResponse](../../Models/Requests/SendMmsResponse.md)**

### Errors

| Error Type                                     | Status Code                                    | Content Type                                   |
| ---------------------------------------------- | ---------------------------------------------- | ---------------------------------------------- |
| Gsmservice.Gateway.Models.Errors.ErrorResponse | 400, 401, 403, 4XX                             | application/problem+json                       |
| Gsmservice.Gateway.Models.Errors.ErrorResponse | 5XX                                            | application/problem+json                       |