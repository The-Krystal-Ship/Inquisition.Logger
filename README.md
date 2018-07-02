![NuGet](https://img.shields.io/nuget/dt/Inquisition.Logging.svg) ![NuGet](https://img.shields.io/nuget/v/Inquisition.Logging.svg)

Build: [![AppVeyor](https://img.shields.io/appveyor/ci/gruntjs/grunt.svg)](https://ci.appveyor.com/project/Flysenberg/inquisition-logging)

[NuGet package](https://www.nuget.org/packages/Inquisition.Logging)

# Inquisition.Logging

Simple logging library, very similar in style to ASP.Net Core's integrated `ILogger<T>`.

Works with Dependency Injection.

## Why?

Logging is an important part of programming, usually when running a program you want some feedback to know that your program is doing what you want it to do. There are quite a few Logger implementations out there, and all of them are good at doing what they're supposed to do. This one is just a simple, no complications logging library.

## Setup

Alright so here's some code you can use:

if (`isUsingDependencyInjection`)
{

Just use the `ILogger<T>` already provided by ASP.Net. It's already there, and does the same thing and more. I made this just because i coudn't use the integrated one and I really liked the output style it had.

}
else
{

The only two method that `ILogger<T>` provides are `.LogError()` and `.LogInformation()`, with a few overloads each, which sould cover the basic needs when logging.

You can simple create instances whenever you want:

```csharp
ILogger<MyClass> logger = new Logger<MyClass>();
```

You can also go wild and make your own implementation of `ILogger<T>`.
If you do and feel like sharing it, feel free to send a pull request!

}
