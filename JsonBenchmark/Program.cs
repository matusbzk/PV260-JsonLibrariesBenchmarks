using System;
using BenchmarkDotNet.Running;

namespace JsonBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<JsonDeserializersBenchmarks>();
            BenchmarkRunner.Run<JsonSerializersBenchmarks>();
            BenchmarkRunner.Run<JsonStreamDeserializersBenchmarks>();
            BenchmarkRunner.Run<DifferentJsonDeserializersBenchmarks>();
            BenchmarkRunner.Run<DifferentJsonSerializersBenchmarks>();
            BenchmarkRunner.Run<JsonDeserializersBenchmarksWithLoad>();

            Console.ReadKey();
        }
    }
}
