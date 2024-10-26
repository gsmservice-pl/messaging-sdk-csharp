
[![NuGet Version](https://img.shields.io/nuget/v/Gsmservice.Gateway)](https://www.nuget.org/packages/Gsmservice.Gateway)
[![GitHub License](https://img.shields.io/github/license/gsmservice-pl/messaging-sdk-csharp)](https://github.com/gsmservice-pl/messaging-sdk-csharp/blob/main/LICENSE)
[![Static Badge](https://img.shields.io/badge/built_by-Speakeasy-yellow)](https://www.speakeasy.com/?utm_source=gsmservice-gateway&utm_campaign=csharp)

# GSMService.pl Messaging REST API SDK for C#

This package includes Messaging SDK for C# to send SMS & MMS messages directly from your app via https://bramka.gsmservice.pl messaging platform.

## Additional documentation:

A documentation of all methods and types is available below in section [Available Resources and Operations
](#available-resources-and-operations).

Also you can refer to the [REST API documentation](https://api.gsmservice.pl/rest/) for additional details about the basics of this SDK.
<!-- No Summary [summary] -->

<!-- Start Table of Contents [toc] -->
## Table of Contents

* [SDK Installation](#sdk-installation)
* [SDK Example Usage](#sdk-example-usage)
* [Available Resources and Operations](#available-resources-and-operations)
* [Retries](#retries)
* [Error Handling](#error-handling)
* [Server Selection](#server-selection)
* [Authentication](#authentication)
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
## Requeirements:
- Minimal .NET Runtime version: 8.0

<!-- Start SDK Example Usage [usage] -->
## SDK Example Usage

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
            Recipients = SmsMessageRecipients.CreateArrayOfStr(
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

### Sending single MMS Message

This example demonstrates simple sending MMS message to a single recipient:

```csharp
using Gsmservice.Gateway;
using Gsmservice.Gateway.Models.Requests;
using Gsmservice.Gateway.Models.Components;
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
            Date = null,
        },
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

Handling errors in this SDK should largely match your expectations. All operations return a response object or throw an exception.

By default, an API error will raise a `Gsmservice.Gateway.Models.Errors.SDKException` exception, which has the following properties:

| Property      | Type                  | Description           |
|---------------|-----------------------|-----------------------|
| `Message`     | *string*              | The error message     |
| `Request`     | *HttpRequestMessage*  | The HTTP request      |
| `Response`    | *HttpResponseMessage* | The HTTP response     |

When custom error responses are specified for an operation, the SDK may also throw their associated exceptions. You can refer to respective *Errors* tables in SDK docs for more details on possible exception types for each operation. For example, the `GetAsync` method throws the following exceptions:

| Error Type                                     | Status Code                                    | Content Type                                   |
| ---------------------------------------------- | ---------------------------------------------- | ---------------------------------------------- |
| Gsmservice.Gateway.Models.Errors.ErrorResponse | 401, 403, 4XX, 5XX                             | application/problem+json                       |

### Example

```csharp
using Gsmservice.Gateway;
using Gsmservice.Gateway.Models.Components;
using System;
using Gsmservice.Gateway.Models.Errors;

var sdk = new Client(bearer: "<YOUR API ACCESS TOKEN>");

try
{
    var res = await sdk.Accounts.GetAsync();

    // handle response
}
catch (Exception ex)
{
    if (ex is Models.Errors.ErrorResponse)
    {
        // Handle exception data
        throw;
    }
    else if (ex is Gsmservice.Gateway.Models.Errors.SDKException)
    {
        // Handle default exception
        throw;
    }
}
```
<!-- End Error Handling [errors] -->

<!-- Start Server Selection [server] -->
## Server Selection

### Select Server by Name

You can override the default server globally by passing a server name to the `server: string` optional parameter when initializing the SDK client instance. The selected server will then be used as the default on the operations that use it. This table lists the names associated with the available servers:

| Name | Server | Variables |
| ----- | ------ | --------- |
| `prod` | `https://api.gsmservice.pl/rest` | None |
| `sandbox` | `https://api.gsmservice.pl/rest-sandbox` | None |



### Override Server URL Per-Client

The default server can also be overridden globally by passing a URL to the `serverUrl: str` optional parameter when initializing the SDK client instance. For example:
<!-- End Server Selection [server] -->

<!-- Start Authentication [security] -->
## Authentication

### Per-Client Security Schemes

This SDK supports the following security scheme globally:

| Name        | Type        | Scheme      |
| ----------- | ----------- | ----------- |
| `Bearer`    | http        | HTTP Bearer |

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

# Development

## Maturity

This SDK is in continuous development and there may be breaking changes between a major version update. Therefore, we recommend pinning usage
to a specific package version. This way, you can install the same version each time without breaking changes unless you are intentionally
looking for the latest version.

## Contributions

While we value open-source contributions to this SDK, this library is generated programmatically. Any manual changes added to internal files will be overwritten on the next generation.
We look forward to hearing your feedback. Feel free to open a PR or an issue with a proof of concept and we'll do our best to include it in a future release.