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
