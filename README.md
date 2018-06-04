# PqSave

This program will allow you to read and write Pokémon Quest save files.

### Usage
````
Usage: pqsave mode input output [script1] [script2]...
  modes:
    d Decrypt
    e Encrypt
    s Script - Run scripts on an encrypted save
````

## User Scripts
User-provided C# scripts can be run to modify the save data.

Two examples have been provided:
- [Modify ticket count](PqSave/Scripts/tickets.csx)
- [Set item counts to 999](PqSave/Scripts/items.csx)

## Running on Linux or macOS

.NET Core can run PqSave on Linux or macOS.
Make sure .NET Core is installed, open a terminal in the directory containing PqSave and run the program with `dotnet PqSave.dll`

## Building

#### Using Visual Studio 2017
1. Open `PqSave.sln` in Visual Studio
2. Run `Build Solution`

If you do not have .NET Core 2.0 or higher installed, Visual Studio will give an error saying that the `netcoreapp2.0` build failed.
The .NET Framework 4.6 build should still succeed if this happens.

#### Using the .NET Core SDK

1. Install the [.NET Core SDK](https://www.microsoft.com/net/download/windows)
2. Open a command prompt in the directory containing `PqSave.sln`
3. Run `dotnet build -f netcoreapp2.0`

If you have the .NET Framework 4.6 Targeting Pack installed the .NET Core SDK will also build the program for .NET Framework 4.6.

