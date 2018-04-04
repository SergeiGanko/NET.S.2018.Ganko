﻿using System;
using System.Configuration;
using static Streams.StreamsExtension;

namespace ConsoleClient
{
    class Program
    {
        static void Main()
        {
            var source = ConfigurationManager.AppSettings["sourceFilePath"];

            var destination = ConfigurationManager.AppSettings["destinationFilePath"];

            Console.WriteLine($"ByteCopy() done. Total bytes: {ByByteCopy(source, destination)}");

            Console.WriteLine($"InMemoryByteCopy() done. Total bytes: {InMemoryByByteCopy(source, destination)}");

            Console.WriteLine($"ByBlockCopy() done. Total bytes: {ByBlockCopy(source, destination)}");

            Console.WriteLine($"InMemoryByBlockCopy() done. Total bytes: {InMemoryByBlockCopy(source, destination)}");

            Console.WriteLine($"BufferedCopy() done. Total bytes: {BufferedCopy(source, destination)}");

            Console.WriteLine($"ByLineCopy() done. Total strings: {ByLineCopy(source, destination)}");

            Console.WriteLine(IsContentEquals(source, destination));
        }
    }
}

