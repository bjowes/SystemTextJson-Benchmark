using BenchmarkDotNet.Running;

namespace JsonTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<SerializeCall>();
            //var summary = BenchmarkRunner.Run<ObjectCreation>();
        }
    }

}
