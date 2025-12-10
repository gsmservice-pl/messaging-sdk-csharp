# Outgoing.Sms

## Overview

### Available Operations

* [GetPrice](#getprice) - Check the price of SMS Messages
* [Send](#send) - Send SMS Messages

## GetPrice


Check the price of single or multiple SMS messages at the same time before sending them. You can pass a single `SmsMessage` object using `GetSmsPriceRequestBody.CreateSmsMessage()` method (for single message) or `List<SmsMessage>` using `GetSmsPriceRequestBody.CreateArrayOfSmsMessage()` method (for multiple messages). Each `SmsMessage` object has several properties, describing message parameters such as recipient phone number, content of the message, type, etc.
The method will accept maximum **100** messages in one call.

As a successful result a `GetSmsPriceResponse` object will be returned with `Prices` property of type `List<Price>` containing a `Price` objects, one object per each single message. You should check the `Error` property of each `Price` object to make sure which messages were priced successfully and which finished with an error. Successfully priced messages will have `null` value of `Error` property.

`GetSmsPriceResponse` object will include also `Headers` property with `X-Success-Count` (a count of messages which were processed successfully) and `X-Error-Count` (count of messages which were rejected) elements.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="getSmsPrice" method="post" path="/messages/sms/price" -->
```csharp
using Gsmservice.Gateway;
using Gsmservice.Gateway.Models.Components;
using Gsmservice.Gateway.Models.Requests;

var sdk = new Client(bearer: "<YOUR API ACCESS TOKEN>");

GetSmsPriceRequestBody req = GetSmsPriceRequestBody.CreateSmsMessage(
    new SmsMessage() {
        Recipients = SmsMessageRecipients.CreateStr(
            "+48999999999"
        ),
        Message = "This is SMS message content.",
        Unicode = true,
    }
);

var res = await sdk.Outgoing.Sms.GetPriceAsync(req);

// handle response
```

### Parameters

| Parameter                                                                 | Type                                                                      | Required                                                                  | Description                                                               |
| ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- |
| `request`                                                                 | [GetSmsPriceRequestBody](../../Models/Requests/GetSmsPriceRequestBody.md) | :heavy_check_mark:                                                        | The request object to use for the request.                                |

### Response

**[GetSmsPriceResponse](../../Models/Requests/GetSmsPriceResponse.md)**

### Errors

| Error Type                                     | Status Code                                    | Content Type                                   |
| ---------------------------------------------- | ---------------------------------------------- | ---------------------------------------------- |
| Gsmservice.Gateway.Models.Errors.ErrorResponse | 400, 401, 4XX                                  | application/problem+json                       |
| Gsmservice.Gateway.Models.Errors.ErrorResponse | 5XX                                            | application/problem+json                       |

## Send


Send single or multiple SMS messages at the same time. You can pass a single `SmsMessage` object using `SendSmsRequestBody.CreateSmsMessage()` method (for single message) or `List<SmsMessage>` using `SendSmsRequestBody.CreateArrayOfSmsMessage()` method (for multiple messages). Each `SmsMessage` object has several properties, describing message parameters such recipient phone number, content of the message, type or scheduled sending date, etc. This method will accept maximum 100 messages in one call.

As a successful result a `SendSmsResponse` object will be returned with `Messages` property of type List<Message> containing `Message` objects, one object per each single message. You should check the `StatusCode` property of each `Message` object to make sure which messages were accepted by gateway (queued) and which were rejected. In case of rejection, `StatusDescription` property will include a reason.

`SendSmsResponse` will also include `Headers` property with `X-Success-Count` (a count of messages which were processed successfully), `X-Error-Count` (count of messages which were rejected) and `X-Sandbox` (if a request was made in Sandbox or Production system) elements.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="sendSms" method="post" path="/messages/sms" -->
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

### Parameters

| Parameter                                                         | Type                                                              | Required                                                          | Description                                                       |
| ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- |
| `request`                                                         | [SendSmsRequestBody](../../Models/Requests/SendSmsRequestBody.md) | :heavy_check_mark:                                                | The request object to use for the request.                        |

### Response

**[SendSmsResponse](../../Models/Requests/SendSmsResponse.md)**

### Errors

| Error Type                                     | Status Code                                    | Content Type                                   |
| ---------------------------------------------- | ---------------------------------------------- | ---------------------------------------------- |
| Gsmservice.Gateway.Models.Errors.ErrorResponse | 400, 401, 403, 4XX                             | application/problem+json                       |
| Gsmservice.Gateway.Models.Errors.ErrorResponse | 5XX                                            | application/problem+json                       |