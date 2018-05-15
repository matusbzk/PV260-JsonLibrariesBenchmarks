using System.IO;
using System.Runtime.Serialization.Json;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;
using BenchmarkDotNet.Attributes.Jobs;
using JsonBenchmark.TestDTOs;

namespace JsonBenchmark
{
    [ClrJob(isBaseline: true)]
    [RPlotExporter, RankColumn]
    [HtmlExporter]
    public class DifferentJsonDeserializersBenchmarks : JsonBenchmarkBase
    {
        [Benchmark]
        public Root DifferentJson_Deserialize()
        {
            using (Stream stream = new MemoryStream(JsonSampleByteArray))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Root));
                return (Root) serializer.ReadObject(stream);
            }
        }
    }
}
