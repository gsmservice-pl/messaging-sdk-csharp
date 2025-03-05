# Incoming
(*Incoming*)

## Overview

### Available Operations

* [List](#list) - List the received SMS messages
* [GetByIds](#getbyids) - Get the incoming messages by IDs

## List


Get the details of all received messages from your account incoming messages box. This method supports pagination so you have to pass `page` (number of page with received messages which you want to access) and a `limit` (max of received messages per page) parameters. Messages are fetched from the latest one. This method will accept maximum **50** as `limit` parameter value.

As a successful result a `ListIncomingMessagesResponse` object will be returned with `IncomingMessages` property of type `List<IncomingMessage>` containing `IncomingMessage` objects, each object per single received message. `ListIncomingMessagesResponse` object will contain also a `Headers` property where you can find `X-Total-Results` (a total count of all received messages which are available in incoming box on your account), `X-Total-Pages` (a total number of all pages with results), `X-Current-Page` (A current page number) and `X-Limit` (messages count per single page) elements.

### Example Usage

```csharp
using Gsmservice.Gateway;
using Gsmservice.Gateway.Models.Components;

var sdk = new Client(bearer: "<YOUR API ACCESS TOKEN>");

var res = await sdk.Incoming.ListAsync(
    page: 1,
    limit: 10
);

// handle response
```

### Parameters

| Parameter                     | Type                          | Required                      | Description                   | Example                       |
| ----------------------------- | ----------------------------- | ----------------------------- | ----------------------------- | ----------------------------- |
| `Page`                        | *long*                        | :heavy_minus_sign:            | Page number of results        | 1                             |
| `Limit`                       | *long*                        | :heavy_minus_sign:            | Number of results on one page | 10                            |

### Response

**[ListIncomingMessagesResponse](../../Models/Requests/ListIncomingMessagesResponse.md)**

### Errors

| Error Type                                     | Status Code                                    | Content Type                                   |
| ---------------------------------------------- | ---------------------------------------------- | ---------------------------------------------- |
| Gsmservice.Gateway.Models.Errors.ErrorResponse | 400, 401, 403, 404, 4XX                        | application/problem+json                       |
| Gsmservice.Gateway.Models.Errors.ErrorResponse | 5XX                                            | application/problem+json                       |

## GetByIds


Get the details of one or more received messages using their `ids`. This method accepts a `List<long>` containing unique incoming message *IDs*, which were given while receiving a messages. The method will accept maximum 50 identifiers in one call.

As a successful result a `GetIncomingMessagesResponse` object will be returned with an `IncomingMessages` property of type `List<IncomingMessage>` containing `IncomingMessage` objects, each object per single received message. `GetIncomingMessagesResponse` object will contain also a `Headers` property where you can find `X-Success-Count` (a count of incoming messages which were found and returned correctly) and `X-Error-Count` (count of incoming messages which were not found) elements.

### Example Usage

```csharp
using Gsmservice.Gateway;
using Gsmservice.Gateway.Models.Components;
using System.Collections.Generic;

var sdk = new Client(bearer: "<YOUR API ACCESS TOKEN>");

var res = await sdk.Incoming.GetByIdsAsync(ids: new List<long>() {
    43456,
});

// handle response
```

### Parameters

| Parameter                                                                                                    | Type                                                                                                         | Required                                                                                                     | Description                                                                                                  |
| ------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------ |
| `Ids`                                                                                                        | List<*long*>                                                                                                 | :heavy_check_mark:                                                                                           | Array of Message IDs assigned by the system. The system will accept a maximum of 50 identifiers in one call. |

### Response

**[GetIncomingMessagesResponse](../../Models/Requests/GetIncomingMessagesResponse.md)**

### Errors

| Error Type                                     | Status Code                                    | Content Type                                   |
| ---------------------------------------------- | ---------------------------------------------- | ---------------------------------------------- |
| Gsmservice.Gateway.Models.Errors.ErrorResponse | 400, 401, 404, 4XX                             | application/problem+json                       |
| Gsmservice.Gateway.Models.Errors.ErrorResponse | 5XX                                            | application/problem+json                       |