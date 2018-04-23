using System;
using System.IO;
using Task2.Solution;

namespace Task2.Tests
{
    internal sealed class Program
    {
        private static void Main()
        {
            var bytesGenerator = new RandomBytesFileGenerator();
            var charsgenerator = new RandomCharsFileGenerator();
            bytesGenerator.GenerateFiles(2, 10);
            charsgenerator.GenerateFiles(2, 15);

            var randomBytesFiles = Directory.GetFiles(bytesGenerator.WorkingDirectory, "*.bytes");

            Console.WriteLine("\n*** File with bytes ***");

            foreach (var byteFile in randomBytesFiles)
            {
                var file = new FileInfo(byteFile);
                Console.WriteLine($"Name: {file.Name}, Length: {file.Length}");
            }

            var randomCharsFiles = Directory.GetFiles(charsgenerator.WorkingDirectory, "*.txt");

            Console.WriteLine("\n*** File with characters ***");

            foreach (var charFile in randomCharsFiles)
            {
                var file = new FileInfo(charFile);
                Console.WriteLine($"Name: {file.Name}, Length: {file.Length}");
            }
        }
    }
}
