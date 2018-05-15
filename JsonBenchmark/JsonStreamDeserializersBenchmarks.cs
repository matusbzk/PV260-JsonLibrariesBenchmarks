using System.IO;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;
using BenchmarkDotNet.Attributes.Jobs;
using JsonBenchmark.TestDTOs;
using Newtonsoft.Json;

namespace JsonBenchmark
{
    [ClrJob(isBaseline: true)]
    [RPlotExporter, RankColumn]
    [HtmlExporter]
    public class JsonStreamDeserializersBenchmarks : JsonBenchmarkBase
    {

        [Benchmark]
        public Root NewtonsoftJson_Deserialize()
        {
            using (Stream stream = new MemoryStream(JsonSampleByteArray))
            using (StreamReader streamReader = new StreamReader(stream))
            using (JsonReader jsonReader = new JsonTextReader(streamReader))
            {
                JsonSerializer serializer = new JsonSerializer();

                return serializer.Deserialize<Root>(jsonReader);
            }
        }
    }
}
