using AutoBogus;
using BenchmarkDotNet.Attributes;
using System.Text.Json;

namespace JsonTest
{
    //[ShortRunJob]
    public class SerializeOverloads
    {
        private MyObject myObject;

        public SerializeOverloads()
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
    }
}
