using System;
using System.IO;
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
    public class JsonDeserializersBenchmarksWithLoad : JsonBenchmarkBase
    {
        [Benchmark]
        public Root NewtonsoftJson_Deserialize()
        {
            string str = JsonSampleString = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, TestFilesFolder, "chucknorris.json"));
            return JsonConvert.DeserializeObject<Root>(str);
        }
    }
}
