# Accounts
(*Accounts*)

## Overview

### Available Operations

* [Get](#get) - Get account details
* [GetSubaccount](#getsubaccount) - Get subaccount details

## Get


Get current account balance and other details of your account. You can check also account limit and if account is main one. Main accounts have unlimited privileges and using [User Panel](https://panel.szybkisms.pl) you can create as many subaccounts as you need.
 
This method doesn't take any parameters. As a successful result a details of current account you are logged in using an API Access Token will be returned.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="getAccountDetails" method="get" path="/account" -->
```csharp
using Gsmservice.Gateway;
using Gsmservice.Gateway.Models.Components;

var sdk = new Client(bearer: "<YOUR API ACCESS TOKEN>");

var res = await sdk.Accounts.GetAsync();

// handle response
```

### Response

**[GetAccountDetailsResponse](../../Models/Requests/GetAccountDetailsResponse.md)**

### Errors

| Error Type                                     | Status Code                                    | Content Type                                   |
| ---------------------------------------------- | ---------------------------------------------- | ---------------------------------------------- |
| Gsmservice.Gateway.Models.Errors.ErrorResponse | 401, 403, 4XX                                  | application/problem+json                       |
| Gsmservice.Gateway.Models.Errors.ErrorResponse | 5XX                                            | application/problem+json                       |

## GetSubaccount


Check account balance and other details such subcredit balance of a subaccount. Subaccounts are additional users who can access your account services and the details. You can restrict access level and setup privileges to subaccounts using [user panel](https://panel.szybkisms.pl).

This method accepts a `string` with user login. You should pass there the full subaccount login to access its data. 

As a successful result the details of subaccount with provided login will be returned.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="getSubaccountDetails" method="get" path="/account/{user_login}" -->
```csharp
using Gsmservice.Gateway;
using Gsmservice.Gateway.Models.Components;

var sdk = new Client(bearer: "<YOUR API ACCESS TOKEN>");

var res = await sdk.Accounts.GetSubaccountAsync(userLogin: "some-login");

// handle response
```

### Parameters

| Parameter                                          | Type                                               | Required                                           | Description                                        | Example                                            |
| -------------------------------------------------- | -------------------------------------------------- | -------------------------------------------------- | -------------------------------------------------- | -------------------------------------------------- |
| `UserLogin`                                        | *string*                                           | :heavy_check_mark:                                 | Login of the subaccount (user) to get the data for | some-login                                         |

### Response

**[GetSubaccountDetailsResponse](../../Models/Requests/GetSubaccountDetailsResponse.md)**

### Errors

| Error Type                                     | Status Code                                    | Content Type                                   |
| ---------------------------------------------- | ---------------------------------------------- | ---------------------------------------------- |
| Gsmservice.Gateway.Models.Errors.ErrorResponse | 401, 403, 404, 4XX                             | application/problem+json                       |
| Gsmservice.Gateway.Models.Errors.ErrorResponse | 5XX                                            | application/problem+json                       |