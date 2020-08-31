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
            //var serializeListSummary = BenchmarkRunner.Run<SerializeList>();
            //var serializeOverloadsSummary = BenchmarkRunner.Run<SerializeOverloads>();

            Console.WriteLine();
            Console.WriteLine("OptionsCreation");
            Console.Write(optionsCreationSummary);

            Console.WriteLine();
            Console.WriteLine("SerializeSingle");
            Console.Write(serializeSingleSummary);
        }
    }

}
