# Accounts
(*Accounts*)

## Overview

### Available Operations

* [Get](#get) - Get account details
* [GetSubaccount](#getsubaccount) - Get subaccount details

## Get

Get current account balance and other details of your account. You can check also account limit and if account is main one. Main accounts have unlimited privileges and using [User Panel](https://panel.gsmservice.pl) you can create as many subaccounts as you need.
 
The request doesn't contain a body or any parameters. As a successful result an `AccountResponse` object will be returned with properties describing details of current account you are logged in to using API Access Token. This request have to be authenticated using **API Access Token**.

In case of an error, the `ErrorResponse` object will be returned with proper HTTP header status code (our error response complies with [RFC 9457](https://www.rfc-editor.org/rfc/rfc7807)).

### Example Usage

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
| Gsmservice.Gateway.Models.Errors.ErrorResponse | 401, 403, 4XX, 5XX                             | application/problem+json                       |

## GetSubaccount

Check account balance and other details such subcredit balance of a subaccount. Subaccounts are additional users who can access your account services and the details. You can restrict access level and setup privileges to subaccounts using [user panel](https://panel.gsmservice.pl).
    
This endpoint accepts a path `user_login` parameter with empty request body. You should pass the full subaccount login to access its data. 

As a successful result an `AccountResponse` object will be returned with properties describing details of subaccount with provided login. This request have to be authenticated using **API Access Token**.

In case of an error, the `ErrorResponse` object will be returned with proper HTTP header status code (our error response complies with [RFC 9457](https://www.rfc-editor.org/rfc/rfc7807)).

### Example Usage

```csharp
using Gsmservice.Gateway;
using Gsmservice.Gateway.Models.Requests;
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
| Gsmservice.Gateway.Models.Errors.ErrorResponse | 401, 403, 404, 4XX, 5XX                        | application/problem+json                       |