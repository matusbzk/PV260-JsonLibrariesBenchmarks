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
    public class DifferentJsonSerializersBenchmarks : JsonBenchmarkBase
    {
        [Benchmark]
        public string DifferentJson_Deserialize()
        {
            string result;
            using (Stream stream = new MemoryStream())
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Root));
                serializer.WriteObject(stream, JsonSampleObjectDif);
                using (StreamReader streamReader = new StreamReader(stream))
                {
                    result = streamReader.ReadToEnd();
                }
            }

            return result;
        }
    }
}
