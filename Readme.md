# Introduction
This repository demonstrate some issues with Visual Studio Custom
Debugger Visualizer infrastructure. It is the minimal amount of code
necessary to reproduce systematically some problems with the detection
of installed custom debugger visualizer.

# Prerequists
Visual Studio Professional Edition 2022 must be installed locally. If
using Enterprise Edition, the `<HintPath>` to the assembly
`Microsoft.VisualStudio.DebuggerVisualizer.dll` must be adapted.

The last tested version was 17.3.1, 64bit. See section System Details
for full details.


# Content of the solution
The solution hosts 3 projects:
 - `DebuggerVisualizer.DebuggerSide.csproj` declare a set of custom
   visualizers for types and interfaces that are defined either in the
   `System.Collection` namespace, or in the project
   `TestDomain.csproj`,
 - `TestDomain.csproj` define a small set of dummy types, generic,
   non-generic, interface and classes for testing purposes,
 - `TestDebuggerVisualizer.csproj` is a small runnable
   (`<OutputType>exe</OutputType>`) project that instanciate a few
   objects, and lets you put a breakpoint to inspect the runtime
   values with the debugger in Visual Studio.

# Bug reproduction
Open the solution with Visual Studio, and build all.

Upon building the project `DebuggerVisualizer.DebuggerSide.csproj`,
the build output is automatically published in the folder
`<UserHome>\Visual Studio 2022\Visualizers\`, thus installing the
custom visualizer declared in the file `AssemblyAttributes.cs`.

Set a breakpoint on the last line of file `Program.cs`, run the
project with debugger attached, and see for which object custom
visualizers are effectively offered.

The project `DebuggerVisualizer.DebuggerSide.csproj` declares custom
visualizer for types:
 - `List<>`,
 - `List<double>`,
 - `IList<>`,
 - `IList<double>`,
 - `IEnumerable<>`,
 - `IEnumerable<double>`,
 - `ICollection<>`,
 - `ICollection<double>`,
 - `IReadOnlyList<>`,
 - `IReadOnlyList<double>`,
 - `IReadOnlyCollection<>`
 - `IReadOnlyCollection<double>`,
 - `ICollection`,
 - `MyGenericObject<>`,
 - `MyGenericObject<double>`,
 - `MyObject`,
 - `MyInterface`,
 - `MyGenericInterface<>`,
 - `MyGenericInterface<double>`.

According to the documentation, the custom debugger visualizers only
support [open
types](https://learn.microsoft.com/en-us/visualstudio/debugger/create-custom-visualizers-of-data?view=vs-2022#write-custom-visualizers),
as is also mentionned in the documentation of
[DebuggerTypeProxy](https://learn.microsoft.com/en-us/visualstudio/debugger/using-debuggertypeproxy-attribute?view=vs-2022#using-generics-with-debuggertypeproxy).

Some old documentation mention that debugger visualizers [support any
managed class except the type `object` and
`Array`](https://learn.microsoft.com/en-us/visualstudio/debugger/create-custom-visualizers-of-data?view=vs-2022#write-custom-visualizers).

The following tables sums up each expression, which visualizer is
expected to be offered and which is effectively offered:

| Visualizer                    | `new List<double> { 1.0 }`                                | `new MyGenericObject<double>()`           | `new MyObject()`                                          | `(MyInterface)new MyInterfaceImplementation()` | `(MyGenericInterface<double>)new MyGenericInterfaceImplementation<double>();` |
|-------------------------------|-----------------------------------------------------------|-------------------------------------------|-----------------------------------------------------------|------------------------------------------------|-------------------------------------------------------------------------------|
| `List<>`                      | expected: :heavy_check_mark:, offered: :x:                | expected: :x:,               offered: :x: | expected: :x:, offered: :x:                               | expected: :x:, offered: :x:                    | expected: :x:,offered: :x:                                                    |
| `List<double>`                | expected: :x:,                offered: :heavy_check_mark: | expected: :x:,               offered: :x: | expected: :x:, offered: :x:                               | expected: :x:, offered: :x:                    | expected: :x:,offered: :x:                                                    |
| `IList<>`                     | expected: :heavy_check_mark:, offered: :x:                | expected: :x:,               offered: :x: | expected: :x:, offered: :x:                               | expected: :x:, offered: :x:                    | expected: :x:,offered: :x:                                                    |
| `IList<double>`               | expected: :x:,                offered: :x:                | expected: :x:,               offered: :x: | expected: :x:, offered: :x:                               | expected: :x:, offered: :x:                    | expected: :x:,offered: :x:                                                    |
| `IEnumerable<>`               | expected: :heavy_check_mark:, offered: :heavy_check_mark: | expected: :x:,               offered: :x: | expected: :x:, offered: :x:                               | expected: :x:, offered: :x:                    | expected: :x:,offered: :x:                                                    |
| `IEnumerable<double>`         | expected: :x:,                offered: :heavy_check_mark: | expected: :x:,               offered: :x: | expected: :x:, offered: :x:                               | expected: :x:, offered: :x:                    | expected: :x:,offered: :x:                                                    |
| `ICollection<>`               | expected: :heavy_check_mark:, offered: :x:                | expected: :x:,               offered: :x: | expected: :x:, offered: :x:                               | expected: :x:, offered: :x:                    | expected: :x:,offered: :x:                                                    |
| `ICollection<double>`         | expected: :x:,                offered: :x:                | expected: :x:,               offered: :x: | expected: :x:, offered: :x:                               | expected: :x:, offered: :x:                    | expected: :x:,offered: :x:                                                    |
| `IReadOnlyList<>`             | expected: :heavy_check_mark:, offered: :x:                | expected: :x:,               offered: :x: | expected: :x:, offered: :x:                               | expected: :x:, offered: :x:                    | expected: :x:,offered: :x:                                                    |
| `IReadOnlyList<double>`       | expected: :x:,                offered: :x:                | expected: :x:,               offered: :x: | expected: :x:, offered: :x:                               | expected: :x:, offered: :x:                    | expected: :x:,offered: :x:                                                    |
| `IReadOnlyCollection<>        | expected: :heavy_check_mark:, offered: :x:                | expected: :x:,               offered: :x: | expected: :x:, offered: :x:                               | expected: :x:, offered: :x:                    | expected: :x:,offered: :x:                                                    |
| `IReadOnlyCollection<double>` | expected: :x:,                offered: :x:                | expected: :x:,               offered: :x: | expected: :x:, offered: :x:                               | expected: :x:, offered: :x:                    | expected: :x:,offered: :x:                                                    |
| `ICollection`                 | expected: :heavy_check_mark:, offered: :x:                | expected: :x:,               offered: :x: | expected: :x:, offered: :x:                               | expected: :x:, offered: :x:                    | expected: :x:,offered: :x:                                                    |
| `MyGenericObject<>`           | expected: :x:,                offered: :x:                | expected: :heavy_check_mark:,offered: :x: | expected: :x:, offered: :x:                               | expected: :x:, offered: :x:                    | expected: :x:,offered: :x:                                                    |
| `MyGenericObject<double>`     | expected: :x:,                offered: :x:                | expected: :x:,               offered: :x: | expected: :x:, offered: :x:                               | expected: :x:, offered: :x:                    | expected: :x:,offered: :x:                                                    |
| `MyObject`                    | expected: :x:,                offered: :x:                | expected: :x:,               offered: :x: | expected: :heavy_check_mark:, offered: :heavy_check_mark: | expected: :x:, offered: :x:                    | expected: :x:,offered: :x:                                                    |
| `MyInterface`                 | expected: :x:,                offered: :x:                | expected: :x:,               offered: :x: | expected: :x:, offered: :x:                               | expected: :heavy_check_mark:, offered: :x:     | expected: :x:,offered: :x:                                                    |
| `MyGenericInterface<>`        | expected: :x:,                offered: :x:                | expected: :x:,               offered: :x: | expected: :x:, offered: :x:                               | expected: :x:, offered: :x:                    | expected: :heavy_check_mark:,offered: :x:                                     |
| `MyGenericInterface<double>`  | expected: :x:,                offered: :x:                | expected: :x:,               offered: :x: | expected: :x:, offered: :x:                               | expected: :x:, offered: :x:                    | expected: :x:,offered: :x:                                                    |
|-------------------------------|-----------------------------------------------------------|-------------------------------------------|-----------------------------------------------------------|------------------------------------------------|-------------------------------------------------------------------------------|

Moreover, if one decomment the declaration of the visualizer
specifically for the closed type `SortedList<int, string>` and rebuild
the solution (thus installing the custom visualizer), then not a
single visualizer is offered anymore, not even the builtin ones
shipped with Visual Studio. This issue has already been reported in
2018, but has not been fixed and is still present.

From the results above, it seems that the interface `IEnumerable<>`
and/or `List<>` is/are somehow treated specially by Visual Studio, and
any other generic type is not supported as expected, even if
open. Interfaces are not supported at all, despite being a type, if my
understanding of the documentation is correct.

These undocumented limitations (only `IEnumerable<>` and non generic
types supported) makes this custom debugger visualizer pretty useless
for my use cases, which is really a shame. The ability to customise
the display of data while debugging is an absolute superpower, and
this infrastructure is not getting all the attention and support it
really deserve. It even feels like it's becoming legacy and will be
soon phased out.


# System Details
Details of the installation are the following:
```
Microsoft Visual Studio Professional 2022
Version 17.3.1
VisualStudio.17.Release/17.3.1+32811.315
Microsoft .NET Framework
Version 4.8.04084

Installed Version: Professional

Visual C++ 2022   00476-80000-00000-AA768
Microsoft Visual C++ 2022

ASP.NET and Web Tools   17.3.375.53775
ASP.NET and Web Tools

Azure App Service Tools v3.0.0   17.3.375.53775
Azure App Service Tools v3.0.0

C# Tools   4.3.0-3.22401.3+41ae77386c335929113f61d6f51f2663d2780443
C# components used in the IDE. Depending on your project type and settings, a different version of the compiler may be used.

Common Azure Tools   1.10
Provides common services for use by Azure Mobile Services and Microsoft Azure Tools.

Microsoft JVM Debugger   1.0
Provides support for connecting the Visual Studio debugger to JDWP compatible Java Virtual Machines

NuGet Package Manager   6.3.0
NuGet Package Manager in Visual Studio. For more information about NuGet, visit https://docs.nuget.org/

Syntax Visualizer   1.0
An extension for visualizing Roslyn SyntaxTrees.

Test Adapter for Boost.Test   1.0
Enables Visual Studio's testing tools with unit tests written for Boost.Test.  The use terms and Third Party Notices are available in the extension installation directory.

Test Adapter for Google Test   1.0
Enables Visual Studio's testing tools with unit tests written for Google Test.  The use terms and Third Party Notices are available in the extension installation directory.

TypeScript Tools   17.0.10701.2001
TypeScript Tools for Microsoft Visual Studio

Visual Basic Tools   4.3.0-3.22401.3+41ae77386c335929113f61d6f51f2663d2780443
Visual Basic components used in the IDE. Depending on your project type and settings, a different version of the compiler may be used.

Visual F# Tools   17.1.0-beta.22363.4+1b94f89d4d1f41f20f9be73c76f4b229d4e49078
Microsoft Visual F# Tools

Visual Studio IntelliCode   2.2
AI-assisted development for Visual Studio.
```
