# Client SDK

## Overview

Messaging Gateway GSMService.pl

This package includes Messaging SDK for C# to send SMS and MMS messages directly from your app via [https://bramka.gsmservice.pl](https://bramka.gsmservice.pl) messaging platform.

*Client* class is used to initialize SDK environment.

Please initialize it this way:

```
using Gsmservice.Gateway;

var sdk = new Client(bearer: "YOUR API ACCESS TOKEN");
```

If you want to use a Sandbox test system please initialize it as follows:

```
var sdk = new Client(bearer: "YOUR API ACCESS TOKEN", null, SDKConfig.Server.Sandbox);
```

Bramka GSMService.pl
<https://bramka.gsmservice.pl>