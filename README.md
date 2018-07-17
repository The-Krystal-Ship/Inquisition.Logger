![Downloads](https://img.shields.io/nuget/dt/Inquisition.Logging.svg)
![Version](https://img.shields.io/nuget/v/Inquisition.Logging.svg)
[![Build](https://img.shields.io/appveyor/ci/gruntjs/grunt.svg)](https://ci.appveyor.com/project/Flysenberg/inquisition-logging)

[Manual NuGet package download](https://www.nuget.org/packages/Inquisition.Logging)

# TheKrystalShip.Logging

## Setup

The two methods that `ILogger<T>` provides are `.LogError()` and `.LogInformation()`, with a few overloads each, which sould cover the basic needs when logging to the console.

You can create instances whenever you want:

```csharp
using TheKrystalShip.Logging

// ...

public class MyClass
{
    private readonly ILogger<MyClass> _logger;

    public MyClass()
    {
        _logger = new Logger<MyClass>(LoggerStyle.Default);
    }
}
```

Or you can use the provided `IServiceCollection` extension enabling dependency injection:

> **!** This makes the output default to `LoggerStyle.Compact`

### Services:

```csharp
using TheKrystalShip.Logging.Extensions

// ...

services = new ServiceCollection()
    .AddLogger()
    .BuildServiceProvider();
```

### Injection:

```csharp
using TheKrystalShip.Logging;

// ...

public class MyClass
{
    private readonly ILogger<MyClass> _logger;

    public MyClass(ILogger<MyClass> logger)
    {
        _logger = logger;
    }
}
```

### Output

Format: `[DateTime] [LineNumber] Type - Message`

#### LoggerStyle.Compact

![CompactView](https://raw.githubusercontent.com/TheKrystalShip/Logging/master/Logging/Assets/compact.PNG)

#### LoggerStyle.Default

![Default view](https://raw.githubusercontent.com/TheKrystalShip/Logging/master/Logging/Assets/default.PNG)
