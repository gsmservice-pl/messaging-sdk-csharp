# Gsmservice.Gateway


<!-- Start SDK Example Usage [usage] -->
## SDK Example Usage

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

<!-- Start Retries [retries] -->
## Retries

Some of the endpoints in this SDK support retries. If you use the SDK without any configuration, it will fall back to the default retry strategy provided by the API. However, the default retry strategy can be overridden on a per-operation basis, or across the entire SDK.

To change the default retry strategy for a single API call, simply pass a `RetryConfig` to the call:
```csharp
using Gsmservice.Gateway;
using Gsmservice.Gateway.Models.Components;

var sdk = new Client(bearer: "<YOUR API ACCESS TOKEN>");

var res = await sdk.Accounts.GetAsync(retryConfig: new RetryConfig(
    strategy: RetryConfig.RetryStrategy.BACKOFF,
    backoff: new BackoffStrategy(
        initialIntervalMs: 1L,
        maxIntervalMs: 50L,
        maxElapsedTimeMs: 100L,
        exponent: 1.1
    ),
    retryConnectionErrors: false
));

// handle response
```

If you'd like to override the default retry strategy for all operations that support retries, you can use the `RetryConfig` optional parameter when intitializing the SDK:
```csharp
using Gsmservice.Gateway;
using Gsmservice.Gateway.Models.Components;

var sdk = new Client(
    retryConfig: new RetryConfig(
        strategy: RetryConfig.RetryStrategy.BACKOFF,
        backoff: new BackoffStrategy(
            initialIntervalMs: 1L,
            maxIntervalMs: 50L,
            maxElapsedTimeMs: 100L,
            exponent: 1.1
        ),
        retryConnectionErrors: false
    ),
    bearer: "<YOUR API ACCESS TOKEN>"
);

var res = await sdk.Accounts.GetAsync();

// handle response
```
<!-- End Retries [retries] -->

<!-- Start Error Handling [errors] -->
## Error Handling

[`ClientException`](./src/Gsmservice/Gateway/Models/Errors/ClientException.cs) is the base exception class for all HTTP error responses. It has the following properties:

| Property      | Type                  | Description           |
|---------------|-----------------------|-----------------------|
| `Message`     | *string*              | Error message         |
| `Request`     | *HttpRequestMessage*  | HTTP request object   |
| `Response`    | *HttpResponseMessage* | HTTP response object  |

Some exceptions in this SDK include an additional `Payload` field, which will contain deserialized custom error data when present. Possible exceptions are listed in the [Error Classes](#error-classes) section.

### Example

```csharp
using Gsmservice.Gateway;
using Gsmservice.Gateway.Models.Components;
using Gsmservice.Gateway.Models.Errors;

var sdk = new Client(bearer: "<YOUR API ACCESS TOKEN>");

try
{
    var res = await sdk.Accounts.GetAsync();

    // handle response
}
catch (ClientException ex)  // all SDK exceptions inherit from ClientException
{
    // ex.ToString() provides a detailed error message
    System.Console.WriteLine(ex);

    // Base exception fields
    HttpRequestMessage request = ex.Request;
    HttpResponseMessage response = ex.Response;
    var statusCode = (int)response.StatusCode;
    var responseBody = ex.Body;

    if (ex is Models.Errors.ErrorResponse) // different exceptions may be thrown depending on the method
    {
        // Check error data fields
        Models.Errors.ErrorResponsePayload payload = ex.Payload;
        string Type = payload.Type;
        long Status = payload.Status;
        // ...
    }

    // An underlying cause may be provided
    if (ex.InnerException != null)
    {
        Exception cause = ex.InnerException;
    }
}
catch (System.Net.Http.HttpRequestException ex)
{
    // Check ex.InnerException for Network connectivity errors
}
```

### Error Classes

**Primary exceptions:**
* [`ClientException`](./src/Gsmservice/Gateway/Models/Errors/ClientException.cs): The base class for HTTP error responses.
  * [`ErrorResponse`](./src/Gsmservice/Gateway/Models/Errors/ErrorResponse.cs): An object that complies with RFC 9457 containing information about a request error.

<details><summary>Less common exceptions (2)</summary>

* [`System.Net.Http.HttpRequestException`](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httprequestexception): Network connectivity error. For more details about the underlying cause, inspect the `ex.InnerException`.

* Inheriting from [`ClientException`](./src/Gsmservice/Gateway/Models/Errors/ClientException.cs):
  * [`ResponseValidationError`](./src/Gsmservice/Gateway/Models/Errors/ResponseValidationError.cs): Thrown when the response data could not be deserialized into the expected type.
</details>
<!-- End Error Handling [errors] -->

<!-- Start Server Selection [server] -->
## Server Selection

### Select Server by Name

You can override the default server globally by passing a server name to the `server: string` optional parameter when initializing the SDK client instance. The selected server will then be used as the default on the operations that use it. This table lists the names associated with the available servers:

| Name      | Server                                  | Description           |
| --------- | --------------------------------------- | --------------------- |
| `prod`    | `https://api.szybkisms.pl/rest`         | Production system     |
| `sandbox` | `https://api.szybkisms.pl/rest-sandbox` | Test system (SANDBOX) |

#### Example

```csharp
using Gsmservice.Gateway;
using Gsmservice.Gateway.Models.Components;

var sdk = new Client(
    server: SDKConfig.Server.Sandbox,
    bearer: "<YOUR API ACCESS TOKEN>"
);

var res = await sdk.Accounts.GetAsync();

// handle response
```

### Override Server URL Per-Client

The default server can also be overridden globally by passing a URL to the `serverUrl: string` optional parameter when initializing the SDK client instance. For example:
```csharp
using Gsmservice.Gateway;
using Gsmservice.Gateway.Models.Components;

var sdk = new Client(
    serverUrl: "https://api.szybkisms.pl/rest",
    bearer: "<YOUR API ACCESS TOKEN>"
);

var res = await sdk.Accounts.GetAsync();

// handle response
```
<!-- End Server Selection [server] -->

<!-- Start Authentication [security] -->
## Authentication

### Per-Client Security Schemes

This SDK supports the following security scheme globally:

| Name     | Type | Scheme      |
| -------- | ---- | ----------- |
| `Bearer` | http | HTTP Bearer |

To authenticate with the API the `Bearer` parameter must be set when initializing the SDK client instance. For example:
```csharp
using Gsmservice.Gateway;
using Gsmservice.Gateway.Models.Components;

var sdk = new Client(bearer: "<YOUR API ACCESS TOKEN>");

var res = await sdk.Accounts.GetAsync();

// handle response
```
<!-- End Authentication [security] -->

<!-- Placeholder for Future Speakeasy SDK Sections -->