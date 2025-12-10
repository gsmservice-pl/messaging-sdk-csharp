
[![NuGet Version](https://img.shields.io/nuget/v/Gsmservice.Gateway)](https://www.nuget.org/packages/Gsmservice.Gateway)
[![GitHub License](https://img.shields.io/github/license/gsmservice-pl/messaging-sdk-csharp)](https://github.com/gsmservice-pl/messaging-sdk-csharp/blob/main/LICENSE)
[![Static Badge](https://img.shields.io/badge/built_by-Speakeasy-yellow)](https://www.speakeasy.com/?utm_source=gsmservice-gateway&utm_campaign=csharp)

# SzybkiSMS.pl Messaging REST API SDK for C# (powered by GSMService.pl)

This package includes Messaging SDK for C# to send SMS & MMS messages directly from your app via https://szybkisms.pl messaging platform.

## Additional documentation:

A documentation of all methods and types is available below in section [Available Resources and Operations
](#available-resources-and-operations).

Also you can refer to the [REST API documentation](https://api.szybkisms.pl/rest/) for additional details about the basics of this SDK.
<!-- No Summary [summary] -->

<!-- Start Table of Contents [toc] -->
## Table of Contents
<!-- $toc-max-depth=2 -->
* [SzybkiSMS.pl Messaging REST API SDK for C# (powered by GSMService.pl)](#szybkismspl-messaging-rest-api-sdk-for-c-powered-by-gsmservicepl)
  * [Additional documentation:](#additional-documentation)
  * [SDK Installation](#sdk-installation)
  * [Requirements:](#requirements)
  * [SDK Example Usage](#sdk-example-usage)
  * [Available Resources and Operations](#available-resources-and-operations)
  * [Retries](#retries)
  * [Error Handling](#error-handling)
  * [Server Selection](#server-selection)
  * [Authentication](#authentication)
  * [Custom HTTP Client](#custom-http-client)
* [Development](#development)
  * [Maturity](#maturity)
  * [Contributions](#contributions)

<!-- End Table of Contents [toc] -->

<!-- Start SDK Installation [installation] -->
## SDK Installation

### NuGet

To add the [NuGet](https://www.nuget.org/) package to a .NET project:
```bash
dotnet add package Gsmservice.Gateway
```

### Locally

To add a reference to a local instance of the SDK in a .NET project:
```bash
dotnet add reference src/Gsmservice/Gateway/Gsmservice.Gateway.csproj
```
<!-- End SDK Installation [installation] -->
## Requirements:
- Minimal .NET Runtime version: 8.0

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

<!-- Start Available Resources and Operations [operations] -->
## Available Resources and Operations

<details open>
<summary>Available methods</summary>

### [Accounts](docs/sdks/accounts/README.md)

* [Get](docs/sdks/accounts/README.md#get) - Get account details
* [GetSubaccount](docs/sdks/accounts/README.md#getsubaccount) - Get subaccount details

### [Common](docs/sdks/common/README.md)

* [Ping](docs/sdks/common/README.md#ping) - Checks API availability and version

### [Incoming](docs/sdks/incoming/README.md)

* [List](docs/sdks/incoming/README.md#list) - List the received SMS messages
* [GetByIds](docs/sdks/incoming/README.md#getbyids) - Get the incoming messages by IDs
* [RemoveByIds](docs/sdks/incoming/README.md#removebyids) - Remove the incoming messages from your inbox

### [Outgoing](docs/sdks/outgoing/README.md)

* [GetByIds](docs/sdks/outgoing/README.md#getbyids) - Get the messages details and status by IDs
* [CancelScheduled](docs/sdks/outgoing/README.md#cancelscheduled) - Cancel a scheduled messages
* [List](docs/sdks/outgoing/README.md#list) - Lists the history of sent messages

#### [Outgoing.Mms](docs/sdks/mms/README.md)

* [GetPrice](docs/sdks/mms/README.md#getprice) - Check the price of MMS Messages
* [Send](docs/sdks/mms/README.md#send) - Send MMS Messages

#### [Outgoing.Sms](docs/sdks/sms/README.md)

* [GetPrice](docs/sdks/sms/README.md#getprice) - Check the price of SMS Messages
* [Send](docs/sdks/sms/README.md#send) - Send SMS Messages

### [Senders](docs/sdks/senders/README.md)

* [List](docs/sdks/senders/README.md#list) - List allowed senders names
* [Add](docs/sdks/senders/README.md#add) - Add a new sender name
* [Delete](docs/sdks/senders/README.md#delete) - Delete a sender name
* [SetDefault](docs/sdks/senders/README.md#setdefault) - Set default sender name

</details>
<!-- End Available Resources and Operations [operations] -->

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
    server: SDKConfig.Server.Prod,
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

<!-- Start Custom HTTP Client [http-client] -->
## Custom HTTP Client

The C# SDK makes API calls using an `ISpeakeasyHttpClient` that wraps the native
[HttpClient](https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient). This
client provides the ability to attach hooks around the request lifecycle that can be used to modify the request or handle
errors and response.

The `ISpeakeasyHttpClient` interface allows you to either use the default `SpeakeasyHttpClient` that comes with the SDK,
or provide your own custom implementation with customized configuration such as custom message handlers, timeouts,
connection pooling, and other HTTP client settings.

The following example shows how to create a custom HTTP client with request modification and error handling:

```csharp
using Gsmservice.Gateway;
using Gsmservice.Gateway.Utils;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

// Create a custom HTTP client
public class CustomHttpClient : ISpeakeasyHttpClient
{
    private readonly ISpeakeasyHttpClient _defaultClient;

    public CustomHttpClient()
    {
        _defaultClient = new SpeakeasyHttpClient();
    }

    public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken? cancellationToken = null)
    {
        // Add custom header and timeout
        request.Headers.Add("x-custom-header", "custom value");
        request.Headers.Add("x-request-timeout", "30");
        
        try
        {
            var response = await _defaultClient.SendAsync(request, cancellationToken);
            // Log successful response
            Console.WriteLine($"Request successful: {response.StatusCode}");
            return response;
        }
        catch (Exception error)
        {
            // Log error
            Console.WriteLine($"Request failed: {error.Message}");
            throw;
        }
    }

    public void Dispose()
    {
        _httpClient?.Dispose();
        _defaultClient?.Dispose();
    }
}

// Use the custom HTTP client with the SDK
var customHttpClient = new CustomHttpClient();
var sdk = new Client(client: customHttpClient);
```

<details>
<summary>You can also provide a completely custom HTTP client with your own configuration:</summary>

```csharp
using Gsmservice.Gateway.Utils;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

// Custom HTTP client with custom configuration
public class AdvancedHttpClient : ISpeakeasyHttpClient
{
    private readonly HttpClient _httpClient;

    public AdvancedHttpClient()
    {
        var handler = new HttpClientHandler()
        {
            MaxConnectionsPerServer = 10,
            // ServerCertificateCustomValidationCallback = customCertValidation, // Custom SSL validation if needed
        };

        _httpClient = new HttpClient(handler)
        {
            Timeout = TimeSpan.FromSeconds(30)
        };
    }

    public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken? cancellationToken = null)
    {
        return await _httpClient.SendAsync(request, cancellationToken ?? CancellationToken.None);
    }

    public void Dispose()
    {
        _httpClient?.Dispose();
    }
}

var sdk = Client.Builder()
    .WithClient(new AdvancedHttpClient())
    .Build();
```
</details>

<details>
<summary>For simple debugging, you can enable request/response logging by implementing a custom client:</summary>

```csharp
public class LoggingHttpClient : ISpeakeasyHttpClient
{
    private readonly ISpeakeasyHttpClient _innerClient;

    public LoggingHttpClient(ISpeakeasyHttpClient innerClient = null)
    {
        _innerClient = innerClient ?? new SpeakeasyHttpClient();
    }

    public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken? cancellationToken = null)
    {
        // Log request
        Console.WriteLine($"Sending {request.Method} request to {request.RequestUri}");
        
        var response = await _innerClient.SendAsync(request, cancellationToken);
        
        // Log response
        Console.WriteLine($"Received {response.StatusCode} response");
        
        return response;
    }

    public void Dispose() => _innerClient?.Dispose();
}

var sdk = new Client(client: new LoggingHttpClient());
```
</details>

The SDK also provides built-in hook support through the `SDKConfiguration.Hooks` system, which automatically handles
`BeforeRequestAsync`, `AfterSuccessAsync`, and `AfterErrorAsync` hooks for advanced request lifecycle management.
<!-- End Custom HTTP Client [http-client] -->

<!-- Placeholder for Future Speakeasy SDK Sections -->

# Development

## Maturity

This SDK is in continuous development and there may be breaking changes between a major version update. Therefore, we recommend pinning usage
to a specific package version. This way, you can install the same version each time without breaking changes unless you are intentionally
looking for the latest version.

## Contributions

While we value open-source contributions to this SDK, this library is generated programmatically. Any manual changes added to internal files will be overwritten on the next generation.
We look forward to hearing your feedback. Feel free to open a PR or an issue with a proof of concept and we'll do our best to include it in a future release.