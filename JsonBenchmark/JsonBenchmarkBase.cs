using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using JsonBenchmark.TestDTOs;

namespace JsonBenchmark
{
    public abstract class JsonBenchmarkBase
    {
        protected const string TestFilesFolder = "TestFiles";
        protected string JsonSampleString;
        protected object JsonSampleObject;

        protected string JsonSampleString2;
        protected object JsonSampleObject2;

        protected byte[] JsonSampleByteArray;
        protected object JsonSampleObjectDif;

        protected JsonBenchmarkBase()
        {
            JsonSampleString = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, TestFilesFolder, "chucknorris.json"));
            JsonSampleObject = Newtonsoft.Json.JsonConvert.DeserializeObject(JsonSampleString);


            JsonSampleString2 = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, TestFilesFolder, "random.json"));
            JsonSampleObject2 = Newtonsoft.Json.JsonConvert.DeserializeObject(JsonSampleString2);

            JsonSampleByteArray = Encoding.UTF8.GetBytes(JsonSampleString);

            using (Stream stream = new MemoryStream(JsonSampleByteArray))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Root));
                JsonSampleObjectDif = (Root) serializer.ReadObject(stream);
            }
        }
    }
}
