# Common
(*Common*)

## Overview

This section describes other usefull operations and tools

### Available Operations

* [Ping](#ping) - Checks API availability and version

## Ping

Check the API connection and the current API availability status. Also you will get the current API version number. The request doesn't contain a body or any parameters.

As a successful result a `PingResponse` object will be returned. This request doesn't need to be authenticated.

In case of an error, the `ErrorResponse` object will be returned with proper HTTP header status code (our error response complies with [RFC 9457](https://www.rfc-editor.org/rfc/rfc7807)).

### Example Usage

```csharp
using Gsmservice.Gateway;
using Gsmservice.Gateway.Models.Components;

var sdk = new Client();

var res = await sdk.Common.PingAsync();

// handle response
```

### Response

**[Models.Requests.PingResponse](../../Models/Requests/PingResponse.md)**

### Errors

| Error Type                                     | Status Code                                    | Content Type                                   |
| ---------------------------------------------- | ---------------------------------------------- | ---------------------------------------------- |
| Gsmservice.Gateway.Models.Errors.ErrorResponse | 400, 4XX, 503, 5XX                             | application/problem+json                       |