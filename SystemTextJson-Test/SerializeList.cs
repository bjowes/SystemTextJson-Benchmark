using AutoBogus;
using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Text.Json;

namespace JsonTest
{
    [ShortRunJob]
    public class SerializeList
    {
        [Params(10, 100, 1000, 10000)]
        public int N { get; set; }

        private List<MyObject> myObjects;
        private static JsonSerializerOptions jsonStaticDefaultOptions = new JsonSerializerOptions();
        private static JsonSerializerOptions jsonStaticCamelOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public SerializeList()
        {
        }

        [GlobalSetup]
        public void GlobalSetup()
        {
            myObjects = AutoFaker.Generate<MyObject>(N);
        }

        [Benchmark]
        public void Serialize()
        {
            JsonSerializer.Serialize(myObjects);
        }

        [Benchmark]
        public void Serialize_InlineOptions_Default()
        {
            JsonSerializer.Serialize(myObjects, new JsonSerializerOptions ());
        }

        [Benchmark]
        public void Serialize_InlineOptions_CamelCase()
        {
            JsonSerializer.Serialize(myObjects, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }

        [Benchmark]
        public void Serialize_StaticOptions_Default()
        {
            JsonSerializer.Serialize(myObjects, jsonStaticDefaultOptions);
        }

        [Benchmark]
        public void Serialize_StaticOptions_CamelCase()
        {
            JsonSerializer.Serialize(myObjects, jsonStaticCamelOptions);
        }
    }
}
