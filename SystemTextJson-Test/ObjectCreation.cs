using AutoBogus;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace JsonTest
{
    [ShortRunJob]
    public class ObjectCreation
    {
        private JsonSerializerOptions jsonOptions;
        private MyObject myObject2;

        public ObjectCreation()
        {
        }

        public void UseEm()
        {
            Console.WriteLine(jsonOptions);
            Console.WriteLine(myObject2);
        }

        [Benchmark]
        public void NoOp()
        {
        }

        [Benchmark]
        public void CreateMyObject()
        {
            myObject2 = new MyObject();
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
