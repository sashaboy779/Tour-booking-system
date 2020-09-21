# 🎫 Tour booking system 
![](readmeImg.jpg)

## Features
* Resorts and tour management
* Tour booking
* Searching and filtering by tour's type, county, regions, rating etc.
* Users management and authentication
* Roles support

## Prerequisites
Before you begin, ensure you have met the following requirements:

* You have a Windows machine
* You have installed [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

## Tech Stack
ASP.NET Web API 2, Microsoft SQL Server

## Authentication
Some resources are protected so you will need to provide JWT token with the request. For example, let's get the administrator's token.
1. Send the request using a **PowerShell** 
```powershell
$headers = New-Object "System.Collections.Generic.Dictionary[[String],[String]]"
$headers.Add("Content-Type", "application/x-www-form-urlencoded")

$body = "username=Adminko&Password=Password1%21&grant_type=password"

$response = Invoke-RestMethod 'https://localhost:44314/oauth/token' -Method 'POST' -Headers $headers -Body $body
$response | ConvertTo-Json
```
2. Copy `access_token`
3. Add JWT token in future requests like so
```powershell
$headers.Add("Authorization", "Bearer <your access_token here>")
``` 

## Status codes

The API is designed to return different status codes that help to determine if something went wrong.

*The following table gives an overview of how the API generally behaves.*

| Request type | Returned status code |
| ------------ | ----------- |
| `GET`   | `200 OK` if the resource is accessed and returns the result as JSON. |
| `POST`  | `201 Created` if the resource is successfully created and returns the newly created resource as JSON. |
| `PUT` | `204 No Content` if the resource is modified successfully. The modified result is returned as JSON. |
| `DELETE` | `204 No Content` if the resource was deleted successfully. |

*The following table describes the possible return codes for API requests.*

| Return values | Description |
| ------------- | ----------- |
| `200 OK` | The `GET` request was successful, the resource(s) is returned as JSON. |
| `204 No Content` | The request was successful and there is no additional content to send in the response body. |
| `201 Created` | The `POST` request was successful and the resource is returned as JSON. |
| `400 Bad Request` | A required attribute of the API request is missing, e.g., the name of a tour is not given. |
| `401 Unauthorized` | The user is not authenticated, a valid [user token](#authentication) is necessary. |
| `404 Not Found` | A resource could not be accessed, e.g., a resort could not be found by provided ID. |
| `405 Method Not Allowed` | The request is not supported. |
| `500 Server Error` | Something went wrong at a server-side. |


