# Athonet.Api

A .NET client library for the Athonet API, providing access to HSS and MOGW endpoints.

[![Nuget](https://img.shields.io/nuget/v/Athonet.Api)](https://www.nuget.org/packages/Athonet.Api/)
[![Nuget](https://img.shields.io/nuget/dt/Athonet.Api)](https://www.nuget.org/packages/Athonet.Api/)
![GitHub](https://img.shields.io/github/license/panoramicdata/Athonet.Api)
[![Codacy Badge](https://app.codacy.com/project/badge/Grade/37eeb615858649b5938c9574a390e2a6)](https://www.codacy.com/gh/panoramicdata/Athonet.Api/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=panoramicdata/Athonet.Api&amp;utm_campaign=Badge_Grade)

## Installation

Install via NuGet Package Manager:

```bash
dotnet add package Athonet.Api
```

Or via Package Manager Console:

```powershell
Install-Package Athonet.Api
```

## Features

- HSS (Home Subscriber Server) API support
- MOGW (Mobile Gateway) API support
- Certificate-based authentication
- Configurable SSL certificate validation
- Request/response logging support
- Built on Refit for type-safe HTTP operations

## Usage

### Basic Setup

```csharp
using Athonet.Api;
using System.Security.Cryptography.X509Certificates;

// Configure the client
var options = new AthonetClientOptions
{
    Username = "your-username",
    Password = "your-password",
    Certificate = new X509Certificate2("path/to/certificate.pfx", "password"),
    Hostname = "your-athonet-host.com",
    Port = 446, // Default port
    IgnoreSslCertificateErrors = false,
    StoreLastRequestAndResponse = true // Enable for debugging
};

// Create the client
using var client = new AthonetClient(options);

// Access HSS API
var hssData = await client.Hss.GetSubscribersAsync();

// Access MOGW API
var events = await client.Mogw.GetEventsAsync(...);
```

### Configuration Options

| Property | Type | Required | Default | Description |
|----------|------|----------|---------|-------------|
| `Username` | `string` | Yes | - | API username |
| `Password` | `string` | Yes | - | API password |
| `Certificate` | `X509Certificate2` | Yes | - | Client certificate for authentication |
| `Hostname` | `string` | Yes | - | Athonet server hostname |
| `Port` | `int` | No | `446` | API port |
| `IgnoreSslCertificateErrors` | `bool` | No | `false` | Bypass SSL certificate validation |
| `StoreLastRequestAndResponse` | `bool` | No | `false` | Store last HTTP request/response for debugging |
| `UserAgent` | `string` | No | `"Athonet.Api-nuget-package"` | Custom User-Agent header |

### Debugging

When `StoreLastRequestAndResponse` is enabled, you can access the raw HTTP data:

```csharp
var options = new AthonetClientOptions
{
    // ... other settings
    StoreLastRequestAndResponse = true
};

using var client = new AthonetClient(options);

await client.Hss.SomeMethodAsync();

// Access raw HTTP data
var lastRequest = client.LastHttpRequest;
var lastResponse = client.LastHttpResponse;
```

### Exception Handling

```csharp
using Athonet.Api.Exceptions;

try
{
    await client.Hss.GetSubscribersAsync();
}
catch (AthonetApiException ex)
{
    Console.WriteLine($"HTTP Status: {ex.HttpStatusCode}");
    Console.WriteLine($"Response: {ex.ResponseBody}");
}
```

## Requirements

- .NET 10 or later
- Valid Athonet API credentials
- X.509 client certificate

## License

See the [LICENSE](LICENSE) file for details.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## Support

For issues and questions, please use the [GitHub Issues](https://github.com/panoramicdata/Athonet.Api/issues) page.