using System;
using System.IO;
using EushullyEditor;

namespace Unpacker
{
    class Program
    {
        static void Main(string[] args)
        {
            //SingleFileMode(args);
            AllFileMode();
        }

        private static void AllFileMode()
        {
            var files = new DirectoryInfo(Environment.CurrentDirectory).GetFiles("*.bin", SearchOption.TopDirectoryOnly);
            foreach (var fileInfo in files)
            {
                var editor = new BinEditor(File.ReadAllBytes(fileInfo.FullName));
                var strings = editor.Import();

                if (strings.Length > 1)
                {
                    File.WriteAllLines($"{fileInfo.FullName}.txt", strings);
                }
                else
                {
                    File.Delete(fileInfo.FullName);
                }
            }
        }

        private static void SingleFileMode(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: EushullyScriptor.exe <file.bin>");
                return;
            }

            var config = new FormatOptions(); //Start with default config
            var editor = new BinEditor(File.ReadAllBytes(args[0]), config);
            string[] allStrings = editor.Import(); //Create Variable with all entries

            var fInfo = new FileInfo(args[0]);
            //To Save
            File.WriteAllLines($"{Environment.CurrentDirectory}\\{fInfo.Name}.txt", allStrings);
        }
    }
}
