# AccountResponse

An object containing information about the User's account and balance


## Fields

| Field                                                 | Type                                                  | Required                                              | Description                                           | Example                                               |
| ----------------------------------------------------- | ----------------------------------------------------- | ----------------------------------------------------- | ----------------------------------------------------- | ----------------------------------------------------- |
| `Login`                                               | *string*                                              | :heavy_minus_sign:                                    | User Login                                            | some_login                                            |
| `AccountType`                                         | [AccountType](../../Models/Components/AccountType.md) | :heavy_minus_sign:                                    | Account type                                          | PRE-PAID                                              |
| `Limit`                                               | *float*                                               | :heavy_minus_sign:                                    | Acount limit                                          | 0                                                     |
| `Credit`                                              | *float*                                               | :heavy_minus_sign:                                    | Current account balance                               | 130.44                                                |
| `Subcredit`                                           | *float*                                               | :heavy_minus_sign:                                    | Subaccount credit balance (null if unlimited)         | 65.32                                                 |
| `Currency`                                            | *string*                                              | :heavy_minus_sign:                                    | Account currency                                      | PLN                                                   |
| `Name`                                                | *string*                                              | :heavy_minus_sign:                                    | User name and surname                                 | Andrzej Nowak                                         |
| `IsMain`                                              | *bool*                                                | :heavy_minus_sign:                                    | Is main account?                                      | true                                                  |