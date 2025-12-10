# Common

## Overview

### Available Operations

* [Ping](#ping) - Checks API availability and version

## Ping


Check the API connection and the current API availability status. Also you will get the current API version number. The method doesn't accept any parameters.

As a successful result a `PingResponse` object will be returned.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="ping" method="get" path="/ping" -->
```csharp
using Gsmservice.Gateway;

var sdk = new Client();

var res = await sdk.Common.PingAsync();

// handle response
```

### Response

**[Models.Requests.PingResponse](../../Models/Requests/PingResponse.md)**

### Errors

| Error Type                                     | Status Code                                    | Content Type                                   |
| ---------------------------------------------- | ---------------------------------------------- | ---------------------------------------------- |
| Gsmservice.Gateway.Models.Errors.ErrorResponse | 400, 4XX                                       | application/problem+json                       |
| Gsmservice.Gateway.Models.Errors.ErrorResponse | 503, 5XX                                       | application/problem+json                       |