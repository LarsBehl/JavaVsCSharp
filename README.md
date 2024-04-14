# Java vs C#
This repository contains a sample `.NET` application, which highlights _some_ of the differences between `Java` and `C#`/`.NET`.

## Project structure
The file `Program.cs` is the main class of the application. Since `.NET 6`/`C# 10` top level statements are supported. The difference is highlighted in `./Program.cs`.<br/>
Additionally, each `.NET`/`C#` project contains a project file. For this application the project file is called `./JavaVsCSharp.csproj`. The project definition is always found in the root directory of the application. The file contains the configuration of the project like which sdk should be used, which type of file is generated (e.g. library or executable) and which features should be enabled/disabled. There is a lot more that can be configured. For additional information please refere to the [official documentation](https://learn.microsoft.com/en-us/dotnet/core/project-sdk/overview).
