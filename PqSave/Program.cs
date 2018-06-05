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

            try
            {
                Run(args);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error reading files");
                Console.WriteLine(ex.Message);
            }
        }

        private static void Run(string[] args)
        {
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
                case "x":
                    var savex = new SaveManager(File.ReadAllBytes(args[1]));
                    var output = Json.Serialize(savex);
                    File.WriteAllText(args[2], output);
                    break;
                case "i":
                    string import = File.ReadAllText(args[1]);
                    SaveManager savei = Json.DeSerialize(import);
                    File.WriteAllBytes(args[2], savei.Export());
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
            Console.WriteLine("Usage: pqsave mode input output [script1 (In script mode only)] [script2]...");
            Console.WriteLine("  modes:");
            Console.WriteLine("    d Decrypt save");
            Console.WriteLine("    e Encrypt save");
            Console.WriteLine("    x Export save to JSON");
            Console.WriteLine("    i Import save from JSON");
            Console.WriteLine("    s Script - Run scripts on an encrypted save");
        }
    }
}
