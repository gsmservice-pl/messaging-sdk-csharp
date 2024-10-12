# Client SDK

## Overview

Messaging Gateway GSMService.pl: 
# Introduction

This document was created to explain the process of integration any application or system with the **GSMService.pl** SMS Gateway via the *REST API*. Currently, there are several ways to send messages with the GSMService.pl platform:

* Directly from the [https://bramka.gsmservice.pl](https://bramka.gsmservice.pl) website [User Panel](https://panel.gsmservice.pl)
* Via this *REST API* and provided *SDKs*
* Via the legacy (deprecated) versions API: *Webservices (SOAP)* and *HTTP* 
* Via the *MAIL2SMS* service

This document describes the possibilities offered by **REST API**.

> **We kindly ask you to read this documentation carefully before starting the integration. This will make the whole process easier and will help you avoid many problems.**

## Documentation and Try Outs

This documentation is available in two formats: [**REDOC**](https://api.gsmservice.pl/rest/) and [**SWAGGER**](https://api.gsmservice.pl/rest/swagger). You can test any endpoint directly from documentation using **Try Out** feature of Swagger. Also you can [download a **YAML** file](https://api.gsmservice.pl/rest/swagger/messaging.yaml) with doc in OpenApi 3.0 format.

## Account signup and setup

Firstly, it is necessary to create your personal account at the GSMService.pl SMS Gateway platform if you haven't one and activate access to the API. To register a new account please [signup the form](https://panel.gsmservice.pl/rejestracja). After signing up and fully activation of an account you have to activate an access to the API.

To do it please use [this site](https://panel.gsmservice.pl/api) - fill the *New API Access* form with your preferred API login, set your API password, select which API standard you want to activate for this account (select **REST API** there). Optionally you can add IP adresses (or IP pool with CIDR notation) from which access to your API account will be possible. You can also set a callback address there to collect any messages status updates automatically. When a status of a messaga changes, the callback address will be called with passing parameters with new message status.

After setup an API access you will get an unique **API Access Token** - please write it down as there won't be possible to display it again (you will have the possibility to regenerate it only). This token will be required to authenticate all the requests made with API on your account.

## Authentication of API requests

All the endpoints of this REST API have to be authenticated using your API Access Token with one exception: */rest/ping* endpoint which doesn't need an authentication. 

To make an authenticated request you should add to all requests an ***Authorization* header** which you have generated in previous step:

```
Authorization: Bearer &lt;YOUR_API_ACCESS_TOKEN&gt;
```

## URLs to connect to API

Please use this SSL secured adresses to connect to REST API:

* ```https://api.gsmservice.pl/rest``` - for production system

* ```https://api.gsmservice.pl/rest-sandbox``` - for test system (Sandbox)

> [!NOTE]
> **When calling our API, make sure you are using TLS version 1.2 or higher. Older versions are no longer supported.**

# SDK Client Libraries

For developers integrating SMS functionality into their app, we provide a convenient SDK Libraries.

Our SDKs allow you to quickly start interacting with the Gateway using your favorite programming language. Currently we support the following languages:

## PHP 8

To install PHP SDK issue the following command:

```shell
composer require gsmservice-pl/messaging-sdk-php
```
More information and documentation you can find at our [GitHub](https://github.com/gsmservice-pl/messaging-sdk-php) 

## Typescript

To install Typescript SDK issue the following command:

### NPM

```shell
npm add @gsmservice-pl/messaging-sdk-typescript
```

More information and documentation you can find at our [GitHub](https://github.com/gsmservice-pl/messaging-sdk-typescript) 

