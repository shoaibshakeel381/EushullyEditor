using System;
using System.IO;
using EushullyEditor;

namespace EushullyEncryptor
{
    class Program
    {
        static void Main(string[] args)
        {
            SingleFileMode(args);
        }
        
        private static void SingleFileMode(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: EushullyEncryptor.exe <file.bin>");
                return;
            }

            var binFileName = args[0];
            var oldBinFileName = binFileName + ".old";
            var txtFileName = binFileName + ".txt";
            File.Move(binFileName, oldBinFileName);
            Console.WriteLine($"Bin File: {oldBinFileName}");
            Console.WriteLine($"Text File: {txtFileName}");
            var editor = new BinEditor(File.ReadAllBytes(oldBinFileName));
            editor.Import();

            //To Save
            var readAllLines = File.ReadAllLines(txtFileName);
            Console.WriteLine($"Text File Contents: {string.Join("\n\t", readAllLines)}");
            var export = editor.Export(readAllLines);
            File.WriteAllBytes(binFileName, export);
        }
    }
}
