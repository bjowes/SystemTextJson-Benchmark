using AutoBogus;
using BenchmarkDotNet.Attributes;
using System.Text.Json;

namespace JsonTest
{
    [ShortRunJob]
    public class SerializeSingle
    {
        private MyObject myObject;
        private static JsonSerializerOptions jsonStaticDefaultOptions = new JsonSerializerOptions();
        private static JsonSerializerOptions jsonStaticCamelOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        private JsonSerializerOptions jsonCamelOptions;
        private JsonSerializerOptions jsonDefaultOptions;

        public SerializeSingle()
        {
        }

        [GlobalSetup]
        public void GlobalSetup()
        {
            myObject = AutoFaker.Generate<MyObject>();
            jsonCamelOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            jsonDefaultOptions = new JsonSerializerOptions();
        }


        [Benchmark]
        public void Serialize()
        {
            JsonSerializer.Serialize(myObject);
        }

        [Benchmark]
        public void Serialize_InlineOptions_Default()
        {
            JsonSerializer.Serialize(myObject, new JsonSerializerOptions ());
        }

        [Benchmark]
        public void Serialize_InlineOptions_CamelCase()
        {
            JsonSerializer.Serialize(myObject, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }

        [Benchmark]
        public void Serialize_StaticMemberOptions_Default()
        {
            JsonSerializer.Serialize(myObject, jsonStaticDefaultOptions);
        }

        [Benchmark]
        public void Serialize_StaticMemberOptions_CamelCase()
        {
            JsonSerializer.Serialize(myObject, jsonStaticCamelOptions);
        }

        [Benchmark]
        public void Serialize_MemberOptions_Default()
        {
            JsonSerializer.Serialize(myObject, jsonDefaultOptions);
        }

        [Benchmark]
        public void Serialize_MemberOptions_CamelCase()
        {
            JsonSerializer.Serialize(myObject, jsonCamelOptions);
        }

        [Benchmark]
        public void Serialize_LocalOptions_Default()
        {
            var options = new JsonSerializerOptions();
            JsonSerializer.Serialize(myObject, options);
        }

        [Benchmark]
        public void Serialize_LocalOptions_CamelCase()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            JsonSerializer.Serialize(myObject, options);
        }        
    }
}
