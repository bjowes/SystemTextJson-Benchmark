using BenchmarkDotNet.Running;
using System;

namespace JsonTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionsCreationSummary = BenchmarkRunner.Run<OptionsCreation>();
            var serializeSingleSummary = BenchmarkRunner.Run<SerializeSingle>();
            var serializeListSummary = BenchmarkRunner.Run<SerializeList>();
            var serializeEachSummary = BenchmarkRunner.Run<SerializeEach>();
            var serializeOverloadsSummary = BenchmarkRunner.Run<SerializeOverloads>();

            Console.WriteLine();
            Console.WriteLine("-- OptionsCreation");
            Console.Write(optionsCreationSummary.Table);

            Console.WriteLine();
            Console.WriteLine("-- SerializeSingle");
            Console.Write(serializeSingleSummary.Table);

            Console.WriteLine();
            Console.WriteLine("-- SerializeList");
            Console.Write(serializeListSummary.Table);

            Console.WriteLine();
            Console.WriteLine("-- SerializeEach");
            Console.Write(serializeEachSummary.Table);

            Console.WriteLine();
            Console.WriteLine("-- SerializeOverloads");
            Console.Write(serializeOverloadsSummary.Table);
        }
    }

}
