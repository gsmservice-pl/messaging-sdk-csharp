# Outgoing
(*Outgoing*)

## Overview

### Available Operations

* [GetByIds](#getbyids) - Get the messages details and status by IDs
* [CancelScheduled](#cancelscheduled) - Cancel a scheduled messages
* [List](#list) - Lists the history of sent messages

## GetByIds


Check the current status and details of one or more messages using their `ids`. You have to pass a `List<long>` containing unique message *IDs* which details you want to fetch. This method will accept maximum 50 identifiers in one call.

As a successful result a `GetMessagesResponse` object will be returned containing `Messages` property of type `List<Message>` with `Message` objects, each object per single found message. `GetMessagesResponse` object will also contain `Headers` property where you can find `X-Success-Count` (a count of messages which were found and returned correctly) and `X-Error-Count` (count of messages which were not found) elements.

### Example Usage

```csharp
using Gsmservice.Gateway;
using Gsmservice.Gateway.Models.Components;
using System.Collections.Generic;

var sdk = new Client(bearer: "<YOUR API ACCESS TOKEN>");

var res = await sdk.Outgoing.GetByIdsAsync(ids: new List<long>() {
    43456,
});

// handle response
```

### Parameters

| Parameter                                                                                                    | Type                                                                                                         | Required                                                                                                     | Description                                                                                                  |
| ------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------ |
| `Ids`                                                                                                        | List<*long*>                                                                                                 | :heavy_check_mark:                                                                                           | Array of Message IDs assigned by the system. The system will accept a maximum of 50 identifiers in one call. |

### Response

**[GetMessagesResponse](../../Models/Requests/GetMessagesResponse.md)**

### Errors

| Error Type                                     | Status Code                                    | Content Type                                   |
| ---------------------------------------------- | ---------------------------------------------- | ---------------------------------------------- |
| Gsmservice.Gateway.Models.Errors.ErrorResponse | 400, 401, 403, 404, 4XX                        | application/problem+json                       |
| Gsmservice.Gateway.Models.Errors.ErrorResponse | 5XX                                            | application/problem+json                       |

## CancelScheduled


Cancel messages using their `ids` which were scheduled to be sent at a specific time. You have to pass a `List<long>` containing the unique message IDs, which were returned after sending a message. This method will accept maximum 50 identifiers in one call. You can cancel only messages with *SCHEDULED* status.
 
As a successful result a `CancelMessagesResponse` object will be returned, with `CancelledMessages` property of type `List<CancelledMessage>` containing `CancelledMessage` objects. The `Status` property of each `CancelledMessage` object will contain a status code of operation - `204` if a particular message was cancelled successfully and other code if an error occured.
 
`CancelMessagesResponse` object will also contain `Headers` property where you can find `X-Success-Count` (a count of messages which were cancelled successfully), `X-Error-Count` (count of messages which were not cancelled) and `X-Sandbox` (if a request was made in Sandbox or Production system) elements.

### Example Usage

```csharp
using Gsmservice.Gateway;
using Gsmservice.Gateway.Models.Components;
using System.Collections.Generic;

var sdk = new Client(bearer: "<YOUR API ACCESS TOKEN>");

var res = await sdk.Outgoing.CancelScheduledAsync(ids: new List<long>() {
    43456,
});

// handle response
```

### Parameters

| Parameter                                                                                                    | Type                                                                                                         | Required                                                                                                     | Description                                                                                                  |
| ------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------ |
| `Ids`                                                                                                        | List<*long*>                                                                                                 | :heavy_check_mark:                                                                                           | Array of Message IDs assigned by the system. The system will accept a maximum of 50 identifiers in one call. |

### Response

**[CancelMessagesResponse](../../Models/Requests/CancelMessagesResponse.md)**

### Errors

| Error Type                                     | Status Code                                    | Content Type                                   |
| ---------------------------------------------- | ---------------------------------------------- | ---------------------------------------------- |
| Gsmservice.Gateway.Models.Errors.ErrorResponse | 400, 401, 403, 404, 4XX                        | application/problem+json                       |
| Gsmservice.Gateway.Models.Errors.ErrorResponse | 5XX                                            | application/problem+json                       |

## List


Get the details and current status of all of sent messages from your account message history. This method supports pagination so you have to pass a `page` (number of page with messages which you want to access) and a `limit` (max of messages per page) parameters. Messages are fetched from the latest one. This method will accept maximum value of **50** as `limit` parameter value.

As a successful result a `ListMessagesResponse` object will be returned containing `Messages` property of type `List<Message>` with a `Message` objects, each object per single message. `ListMessagesResponse` will also contain `Headers` property where you can find `X-Total-Results` (a total count of all messages which are available in history on your account), `X-Total-Pages` (a total number of all pages with results), `X-Current-Page` (A current page number) and `X-Limit` (messages count per single page) elements.

### Example Usage

```csharp
using Gsmservice.Gateway;
using Gsmservice.Gateway.Models.Components;

var sdk = new Client(bearer: "<YOUR API ACCESS TOKEN>");

var res = await sdk.Outgoing.ListAsync(
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

**[ListMessagesResponse](../../Models/Requests/ListMessagesResponse.md)**

### Errors

| Error Type                                     | Status Code                                    | Content Type                                   |
| ---------------------------------------------- | ---------------------------------------------- | ---------------------------------------------- |
| Gsmservice.Gateway.Models.Errors.ErrorResponse | 400, 401, 403, 404, 4XX                        | application/problem+json                       |
| Gsmservice.Gateway.Models.Errors.ErrorResponse | 5XX                                            | application/problem+json                       |