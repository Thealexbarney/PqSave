using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace PqSave
{
    public static class Scripting
    {

        public static void SetCount(this ItemStorage items, Item type, short count)
        {
            var item = items.datas.FirstOrDefault(x => x.id == type);
            if (item == null)
            {
                item = new ItemStorage.Core { id = type, isNew = true };
                items.datas.Add(item);
            }
            item.num = count;
        }

        public static void RunScript(SerializeData save, string filename)
        {
            Console.WriteLine();
            Console.WriteLine($"Running {filename}...");

            try
            {
                var script = File.ReadAllText(filename);
                var scriptOptions = ScriptOptions.Default
                    .AddReferences(Assembly.GetExecutingAssembly(), typeof(ZeroFormatter.DirtyTracker).Assembly, typeof(ZeroFormatter.IKeyTuple).Assembly)
                    .AddImports("System", "System.Linq", "PqSave", "ZeroFormatter")
                    .WithSourceResolver(SourceFileResolver.Default)
                    .WithMetadataResolver(ScriptMetadataResolver.Default)
                    .WithEmitDebugInformation(true);
                CSharpScript.RunAsync(script, scriptOptions, new ScriptHost { Save = save }).Wait();
            }
            catch (CompilationErrorException ex)
            {
                Console.WriteLine($"Error compiling {filename}:");
                Console.WriteLine(string.Join(Environment.NewLine, ex.Diagnostics));
            }
            catch (AggregateException ex)
            {
                Console.WriteLine($"Error running {filename}:");
                foreach (var inner in ex.Flatten().InnerExceptions)
                {
                    string message = inner.ToString()
                        .Split(new[] { "--- End of" }, StringSplitOptions.None).FirstOrDefault()
                        ?.Replace(".<<Initialize>>d__0.MoveNext()", "")
                        .Replace("Submission#0", "Script");
                    Console.WriteLine(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error running {filename}:\n{ex.Message}");
            }

            Console.WriteLine($"Finished {filename}");
        }
    }

    public class ScriptHost
    {
        public SerializeData Save { get; set; }
    }
}
