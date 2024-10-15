# Client SDK

## Overview

Messaging Gateway GSMService.pl

This package includes Messaging SDK for C# to send SMS %26 MMS messages directly from your app via [https://bramka.gsmservice.pl](https://bramka.gsmservice.pl) messaging platform.

*Client* class is used to initialize SDK environment.

Please initialize it this way:

```
using Gsmservice.Gateway;

var sdk = new Client(bearer: "%3CYOUR API ACCESS TOKEN%3E");
```

If you want to use a Sandbox test system please initialize it as follows:

```
var sdk = new Client(bearer: "%3CYOUR API ACCESS TOKEN%3E", null, SDKConfig.Server.Sandbox);
```