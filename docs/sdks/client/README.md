# Client SDK

## Overview

Messaging Gateway SzybkiSMS.pl

This package includes Messaging SDK for C# to send SMS and MMS messages directly from your app via [https://szybkisms.pl](https://szybkisms.pl) messaging platform.

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

SzybkiSMS.pl
<https://szybkisms.pl>

### Available Operations
