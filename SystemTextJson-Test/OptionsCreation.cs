using BenchmarkDotNet.Attributes;
using System;
using System.Text.Json;

namespace JsonTest
{
    //[ShortRunJob]
    public class OptionsCreation
    {
        private JsonSerializerOptions jsonOptions;
        private MyObject myObject;

        public OptionsCreation()
        {
        }

        public void UseEm()
        {
            Console.WriteLine(jsonOptions);
            Console.WriteLine(myObject);
        }

        [Benchmark]
        public void NoOp()
        {
        }

        [Benchmark]
        public void CreateMyObject()
        {
            myObject = new MyObject();
        }

        [Benchmark]
        public void CreateOptions()
        {
            jsonOptions = new JsonSerializerOptions();
        }

        [Benchmark]
        public void CreateOptions_Camel()
        {
            jsonOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }
    }
}
