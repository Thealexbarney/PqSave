using System;
using System.IO;

namespace PqSave
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                PrintUsage();
                return;
            }

            switch (args[0])
            {
                case "d":
                    var encSave = File.ReadAllBytes(args[1]);
                    File.WriteAllBytes(args[2], Encryption.DecryptSave(encSave));
                    break;
                case "e":
                    var decSave = File.ReadAllBytes(args[1]);
                    File.WriteAllBytes(args[2], Encryption.EncryptSave(decSave));
                    break;
                case "s":
                    var save = new SaveManager(File.ReadAllBytes(args[1]));

                    for (int i = 3; i < args.Length; i++)
                    {
                        Scripting.RunScript(save.SerializeData, args[i]);
                    }

                    File.WriteAllBytes(args[2], save.Export());
                    break;
                default:
                    PrintUsage();
                    return;
            }
        }

        private static void PrintUsage()
        {
            Console.WriteLine("Usage: pqsave mode input output [script1] [script2]...");
            Console.WriteLine("  modes:");
            Console.WriteLine("    d Decrypt");
            Console.WriteLine("    e Encrypt");
            Console.WriteLine("    s Script - Run scripts on an encrypted save");
        }
    }
}
