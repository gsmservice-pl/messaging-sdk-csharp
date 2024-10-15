# Senders
(*Senders*)

## Overview

### Available Operations

* [List](#list) - List allowed senders names
* [Add](#add) - Add a new sender name
* [Delete](#delete) - Delete a sender name
* [SetDefault](#setdefault) - Set default sender name

## List


Get a list of allowed senders defined in your account. The method doesn't take any parameters.

As a successful result a `ListSendersResponse` object will be returned wich `Senders` property of type `List<Sender>` containing `Sender` objects, each object per single sender.

### Example Usage

```csharp
using Gsmservice.Gateway;
using Gsmservice.Gateway.Models.Components;

var sdk = new Client(bearer: "<YOUR API ACCESS TOKEN>");

var res = await sdk.Senders.ListAsync();

// handle response
```

### Response

**[ListSendersResponse](../../Models/Requests/ListSendersResponse.md)**

### Errors

| Error Type                                     | Status Code                                    | Content Type                                   |
| ---------------------------------------------- | ---------------------------------------------- | ---------------------------------------------- |
| Gsmservice.Gateway.Models.Errors.ErrorResponse | 400, 401, 403, 4XX, 5XX                        | application/problem+json                       |

## Add


Define a new allowed sender on your account. You should pass as parameter a `SenderInput` object with two properties: `Sender` (defines sender name) and `Description`. Please carefully fill this property with the extensive description of a sender name (what will be its use, what the name mean, etc).

As a successful result a `AddSenderResponse` object will be returned with a `Sender` property containing a `Sender` object with details and status of added sender name.

### Example Usage

```csharp
using Gsmservice.Gateway;
using Gsmservice.Gateway.Models.Components;

var sdk = new Client(bearer: "<YOUR API ACCESS TOKEN>");

SenderInput req = new SenderInput() {
    Sender = "Bramka SMS",
    Description = "This is our company name. It contains our registered trademark.",
};

var res = await sdk.Senders.AddAsync(req);

// handle response
```

### Parameters

| Parameter                                             | Type                                                  | Required                                              | Description                                           |
| ----------------------------------------------------- | ----------------------------------------------------- | ----------------------------------------------------- | ----------------------------------------------------- |
| `request`                                             | [SenderInput](../../Models/Components/SenderInput.md) | :heavy_check_mark:                                    | The request object to use for the request.            |

### Response

**[AddSenderResponse](../../Models/Requests/AddSenderResponse.md)**

### Errors

| Error Type                                     | Status Code                                    | Content Type                                   |
| ---------------------------------------------- | ---------------------------------------------- | ---------------------------------------------- |
| Gsmservice.Gateway.Models.Errors.ErrorResponse | 400, 401, 403, 4XX, 5XX                        | application/problem+json                       |

## Delete


Removes defined sender name from your account. This method accepts a `string` with a **sender name** you want to remove. Sender name will be deleted immediately.

As a successful response there would be no Exception thrown.

### Example Usage

```csharp
using Gsmservice.Gateway;
using Gsmservice.Gateway.Models.Requests;
using Gsmservice.Gateway.Models.Components;

var sdk = new Client(bearer: "<YOUR API ACCESS TOKEN>");

var res = await sdk.Senders.DeleteAsync(sender: "Podpis");

// handle response
```

### Parameters

| Parameter                 | Type                      | Required                  | Description               | Example                   |
| ------------------------- | ------------------------- | ------------------------- | ------------------------- | ------------------------- |
| `Sender`                  | *string*                  | :heavy_check_mark:        | Sender name to be removed | Podpis                    |

### Response

**[DeleteSenderResponse](../../Models/Requests/DeleteSenderResponse.md)**

### Errors

| Error Type                                     | Status Code                                    | Content Type                                   |
| ---------------------------------------------- | ---------------------------------------------- | ---------------------------------------------- |
| Gsmservice.Gateway.Models.Errors.ErrorResponse | 400, 401, 403, 404, 4XX, 5XX                   | application/problem+json                       |

## SetDefault


Set default sender name to one of the senders names already defined on your account. This method accepts a `string` containing a **sender name** to be set as default on your account.

As a successful response no Exception will be thrown.

### Example Usage

```csharp
using Gsmservice.Gateway;
using Gsmservice.Gateway.Models.Requests;
using Gsmservice.Gateway.Models.Components;

var sdk = new Client(bearer: "<YOUR API ACCESS TOKEN>");

var res = await sdk.Senders.SetDefaultAsync(sender: "Podpis");

// handle response
```

### Parameters

| Parameter                     | Type                          | Required                      | Description                   | Example                       |
| ----------------------------- | ----------------------------- | ----------------------------- | ----------------------------- | ----------------------------- |
| `Sender`                      | *string*                      | :heavy_check_mark:            | Sender name to set as default | Podpis                        |

### Response

**[SetDefaultSenderResponse](../../Models/Requests/SetDefaultSenderResponse.md)**

### Errors

| Error Type                                     | Status Code                                    | Content Type                                   |
| ---------------------------------------------- | ---------------------------------------------- | ---------------------------------------------- |
| Gsmservice.Gateway.Models.Errors.ErrorResponse | 400, 401, 403, 4XX, 5XX                        | application/problem+json                       |
| Gsmservice.Gateway.Models.Errors.ErrorResponse | 404                                            | application/json                               |