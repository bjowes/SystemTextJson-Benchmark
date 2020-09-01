using AutoBogus;
using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Text.Json;

namespace JsonTest
{
    //[ShortRunJob]
    public class SerializeEach
    {
        [Params(10, 100, 1000)]
        public int N { get; set; }

        private List<MyObject> myObjects;
        private static JsonSerializerOptions jsonStaticDefaultOptions = new JsonSerializerOptions();
        private static JsonSerializerOptions jsonStaticCamelOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public SerializeEach()
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
            foreach (var o in myObjects)
            {
                JsonSerializer.Serialize(o);
            }
        }

        [Benchmark]
        public void Serialize_InlineOptions_Default()
        {
            foreach (var o in myObjects)
            {
                JsonSerializer.Serialize(o, new JsonSerializerOptions());
            }
        }

        [Benchmark]
        public void Serialize_InlineOptions_CamelCase()
        {
            foreach (var o in myObjects)
            {
                JsonSerializer.Serialize(o, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            }
        }

        [Benchmark]
        public void Serialize_StaticOptions_Default()
        {
            foreach (var o in myObjects)
            {
                JsonSerializer.Serialize(o, jsonStaticDefaultOptions);
            }
        }

        [Benchmark]
        public void Serialize_StaticOptions_CamelCase()
        {
            foreach (var o in myObjects)
            {
                JsonSerializer.Serialize(o, jsonStaticCamelOptions);
            }
        }
    }
}
