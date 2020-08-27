using AutoBogus;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace JsonTest
{
    [ShortRunJob]
    public class SerializeCall
    {
        private MyObject myObject;
        private static JsonSerializerOptions jsonStaticDefaultOptions = new JsonSerializerOptions();
        private static JsonSerializerOptions jsonStaticCamelOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public SerializeCall()
        {
        }

        [GlobalSetup]
        public void GlobalSetup()
        {
            myObject = AutoFaker.Generate<MyObject>();
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
        public void Serialize_AltInlineOptions_Default()
        {
            JsonSerializer.Serialize(myObject, typeof(MyObject), new JsonSerializerOptions());
        }


        [Benchmark]
        public void Serialize_Alt2InlineOptions_Default()
        {
            JsonSerializer.Serialize<MyObject>(myObject, new JsonSerializerOptions());
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
        public void Serialize_StaticOptions_Default()
        {
            JsonSerializer.Serialize(myObject, jsonStaticDefaultOptions);
        }

        [Benchmark]
        public void Serialize_StaticOptions_CamelCase()
        {
            JsonSerializer.Serialize(myObject, jsonStaticCamelOptions);
        }

        [Benchmark]
        public void Serialize_VariableOptions_Default()
        {
            var options = new JsonSerializerOptions();
            JsonSerializer.Serialize(myObject, options);
        }

        [Benchmark]
        public void Serialize_VariableOptions_CamelCase()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            JsonSerializer.Serialize(myObject, options);
        }        
    }
}
